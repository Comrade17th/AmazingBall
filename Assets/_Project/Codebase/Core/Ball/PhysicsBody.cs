using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Codebase.Core.Ball
{
    [RequireComponent(typeof(Collider))]
    public class PhysicsBody : MonoBehaviour
    {
        private readonly float _groundMinDistance = 0.05f;
        private readonly float _heightOffset = 0.5f;
        private readonly float _gravityAcceleration = -9.8f;
        
        [SerializeField] private Transform _groundTransform;
        [SerializeField] private float _friction = 0.1f;
        [SerializeField] private Vector3 _dampening = new Vector3(0f, 1f, 0f);
        [SerializeField] private Vector3 _velocity = new Vector3(0, 0, 3);
        [SerializeField] private Vector3 _maxVelocityAbs = new Vector3(10, 5, 10);
        
        private bool _isGrounded;
        
        private void FixedUpdate()
        {
            float deltaTime = Time.fixedDeltaTime;
            
            CheckIsGrounded();
            ApplyFriction(deltaTime);
            ApplyGravity(deltaTime);

            transform.position += _velocity * deltaTime;
        }

        private void ApplyGravity(float deltaTime)
        {
            var scaledGravity = new Vector3(0, _gravityAcceleration, 0) * deltaTime;

            if(_isGrounded == false)
                _velocity += scaledGravity;
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
            var reflectedVelocity = Vector3.Reflect(_velocity, contact.normal);
            
            _velocity = reflectedVelocity;
            _velocity -= _dampening;

            CancelVelocityYAccumulation();
        }

        public void SetVelocity(Vector3 velocity)
        {
            velocity.y = _velocity.y;
            _velocity = ClampVelocity(velocity);
        }

        private void CancelVelocityYAccumulation()
        {
            float velocityCutBorder = -1.1f;

            if (_isGrounded && 
                _velocity.y < 0 && 
                _velocity.y > velocityCutBorder)
            {
                _velocity.y = 0f;
            }
        }

        private void ApplyFriction(float deltaTime)
        {
            _velocity = new Vector3(
                Mathf.MoveTowards(_velocity.x, 0, _friction * deltaTime),
                _velocity.y,
                Mathf.MoveTowards(_velocity.z, 0, _friction * deltaTime));
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