using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Core.Ball.View
{
    [RequireComponent(typeof(Rigidbody), 
        typeof(Collider))]
    public class BallView : MonoBehaviour, IBallView
    {
        [SerializeField] private Transform _groundTransform;
        
        private readonly float _groundMinDistance = 0.05f;

        private Vector3 _velocity;
        private readonly List<ContactPoint> _contacts = new();
        
        private bool _isGrounded;

        public event Action<bool> VelocityRequested;
        public event Action<HitInfo> ObjectHit;
        public bool IsGrounded => _isGrounded;

        public Transform Transform => transform;

        private void Update()
        {
            if (_velocity != Vector3.zero)
                transform.position += _velocity * Time.deltaTime;
            
            CheckIsGrounded();
            VelocityRequested?.Invoke(_isGrounded);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            collision.GetContacts(_contacts);
            ContactPoint contactPoint = _contacts[0];
            ObjectHit?.Invoke( new HitInfo(contactPoint, _velocity, transform));
        }

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
                    _isGrounded = true;
                else
                    _isGrounded = false;
            }
        }
    }

    public interface IBallView : IBallTransform
    {
        void SetVelocity(Vector3 velocity);
        bool IsGrounded { get; }
        event Action<bool> VelocityRequested;
        event Action<HitInfo> ObjectHit;
    }

    public interface IBallTransform 
    {
        Transform Transform { get; }
    }
}