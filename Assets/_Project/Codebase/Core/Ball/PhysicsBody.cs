using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    [RequireComponent(typeof(Collider))]
    public class PhysicsBody : MonoBehaviour
    {
        private readonly float _groundMinDistance = 0.05f;
        private readonly float _gravityAcceleration = -9.8f;
        
        [SerializeField] private Transform _groundTransform;
        [SerializeField] private float _frictionXZ = 0.1f;
        [SerializeField] private Vector3 _velocity = Vector3.zero;
        [SerializeField] private Vector3 _dampening = new Vector3(0f, 1f, 0f);
        [SerializeField] private Vector3 _maxVelocityAbs = new Vector3(10, 5, 10);
        
        private bool _isGrounded;

        private Vector3 Velocity
        {
            get { return _velocity; }
            set
            {
                if (_velocity != value)
                {
                    _velocity = ClampVelocity(value);
                    VelocityChanged?.Invoke(_velocity);
                }
            }
        }

        public event Action<Vector3> VelocityChanged;
        public event Action<Vector3> DirectionChanged;
        public event Action<Vector3, Vector3, Vector3> ObjectHit;
        
        private void Update()
        {
            float deltaTime = Time.deltaTime;
            
            CheckIsGrounded();
            ApplyFriction(deltaTime);
            ApplyGravity(deltaTime);

            transform.position += Velocity * deltaTime;
        }

        private void ApplyGravity(float deltaTime)
        {
            var scaledGravity = new Vector3(0, _gravityAcceleration, 0) * deltaTime;

            if(_isGrounded == false)
                Velocity += scaledGravity;
        }

        private void CheckIsGrounded()
        {
            if(Physics.Raycast(
                   _groundTransform.position ,
                   _groundTransform.TransformDirection(Vector3.down), 
                   out RaycastHit hit,
                   Mathf.Infinity))
            {
                if (hit.distance < _groundMinDistance)
                    _isGrounded = true;
                else
                    _isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var contacts = new List<ContactPoint>();
            collision.GetContacts(contacts);
            
            ContactPoint contact = contacts[0];
            var reflectedVelocity = Vector3.Reflect(Velocity, contact.normal);
            
            Velocity = reflectedVelocity;
            Velocity -= _dampening;
            DirectionChanged?.Invoke(Velocity);
            ObjectHit?.Invoke(contact.point, contact.normal, Velocity);

            CancelVelocityYAccumulation();
        }

        public void SetVelocity(Vector3 velocity)
        {
            velocity.y = Velocity.y;
            Velocity = ClampVelocity(velocity);
            DirectionChanged?.Invoke(Velocity);
        }

        private void CancelVelocityYAccumulation()
        {
            float velocityCutBorder = -1.1f;

            if (_isGrounded && 
                Velocity.y < 0 && 
                Velocity.y > velocityCutBorder)
            {
                Velocity = new Vector3(Velocity.x, 0, Velocity.z);
            }
        }

        private void ApplyFriction(float deltaTime)
        {
            Velocity = new Vector3(
                Mathf.MoveTowards(Velocity.x, 0, _frictionXZ * deltaTime),
                Velocity.y,
                Mathf.MoveTowards(Velocity.z, 0, _frictionXZ * deltaTime));
        }

        private Vector3 ClampVelocity(Vector3 velocity)
        {
            return new Vector3(
                Mathf.Clamp(velocity.x, -_maxVelocityAbs.x, _maxVelocityAbs.x), 
                Mathf.Clamp(velocity.y, -_maxVelocityAbs.y, _maxVelocityAbs.y),
                Mathf.Clamp(velocity.z, -_maxVelocityAbs.z, _maxVelocityAbs.z));
        }
    }
}