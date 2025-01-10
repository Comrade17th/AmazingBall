using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    [RequireComponent(typeof(Collider))]
    public class PhysicsBody : MonoBehaviour
    {
        private readonly Vector3 _gravity = new Vector3(0f, -9.81f, 0f); // to SD
        private readonly float _groundLevel = 0f; // to another class
        private readonly float _heightOffset = 0.5f;
        
        // private readonly float Gravityf = -9.8f;
        
        [SerializeField] private float _friction = 0.1f; // to SD
        [SerializeField] private float _dampingImpactPercent = 0.1f; // to SD
        //[SerializeField] private Transform _groundCheck;
        [SerializeField] private Vector3 _velocity = new Vector3(0, 0, 3);
        [SerializeField] private Vector3 _maxVelocityAbs = new Vector3(10, 5, 10); // to static data
        
        private void Update()
        {
            // if(_velocity.y > 0.1f)
            //     _velocity += Gravity * Time.fixedDeltaTime;
            
            var deltaTime = Time.deltaTime;
            
            ApplyFriction(deltaTime);

            float minimumVelocityToZero = 0.2f;

            if(transform.position.y > _heightOffset)
                _velocity += _gravity * deltaTime;
            
            float downBorder = transform.position.y - _heightOffset;
            
            if (downBorder < _groundLevel)
            {
                if (Mathf.Abs(_velocity.y) < minimumVelocityToZero)
                    _velocity.y = 0f;
                
                transform.position = new Vector3(
                    transform.position.x,
                    _heightOffset,
                    transform.position.z);
            } 
                
            
            transform.Translate(_velocity * deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var contacts = new List<ContactPoint>();
            collision.GetContacts(contacts);
            
            ContactPoint contact = contacts[0];
            Vector3 reflectedDirection = Vector3.Reflect(_velocity, contact.normal);
            
            _velocity = reflectedDirection;
            _velocity -= _velocity * _dampingImpactPercent;
            
            // foreach (var item in collision.contacts)
            // {
            //     Debug.DrawRay(item.point, _direction * -100, Color.blue, 10f);
            //     Debug.DrawRay(item.point, item.normal * 100, Color.cyan, 10f);
            //     Debug.DrawRay(item.point,  Vector3.Reflect(_direction, item.normal) * 100, Color.magenta, 10f);
            //     Debug.Log($"origin normal {item.point} normalized: {item.point.normalized}");
            //}
        }

        public void SetVelocity(Vector3 velocity)
        {
            velocity.y = _velocity.y;
            _velocity = ClampVelocity(velocity);
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