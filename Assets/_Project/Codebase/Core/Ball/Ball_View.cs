using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    [RequireComponent(typeof(Rigidbody), 
        typeof(Collider))]
    public class Ball_View : MonoBehaviour, IBallView
    {
        [SerializeField] private Transform _groundTransform;
        
        private readonly float _groundMinDistance = 0.05f;
        
        private Vector3 _lastPosition;
        
        private ReactiveProperty<bool> _isGrounded = new(false);
        private Vector3 _velocity;
        
        public IReadOnlyReactiveProperty<bool> IsGrounded => _isGrounded;
        public event Action<Vector3, Vector3> VeloctityRequested;

        private void Start()
        {
            _lastPosition = _groundTransform.position;
        }

        private void Update()
        {
            if (_velocity != Vector3.zero)
            {
                transform.position += _velocity * Time.deltaTime;
                VeloctityRequested?.Invoke(_lastPosition, _groundTransform.position);
                    
            }
            
        }

        // private void OnCollisionEnter(Collision collision)
        // {
        //     var velocity = _velocity.Value;
        //     
        //     var contacts = new List<ContactPoint>();
        //     collision.GetContacts(contacts);
        //     
        //     ContactPoint contact = contacts[0];
        //     var reflectedVelocity = Vector3.Reflect(velocity, contact.normal);
        //     
        //     velocity = reflectedVelocity;
        //     velocity -= _dampening;
        //     DirectionChanged?.Invoke(_velocity);
        //     ObjectHit?.Invoke( new HitInfo(contact.point, contact.normal, velocity));
        //
        //     CancelVelocityYAccumulation();
        // }

        public void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
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
                    _isGrounded.Value = true;
                else
                    _isGrounded.Value = false;
            }
        }
    }

    public interface IBallView
    {
        event Action<Vector3, Vector3> VeloctityRequested;
        
        void SetVelocity(Vector3 velocity);
    }
}