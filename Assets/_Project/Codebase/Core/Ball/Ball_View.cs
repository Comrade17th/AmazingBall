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
        private Vector3 _velocity;
        private ReactiveProperty<bool> _isGrounded = new(false);

        public event Action<Vector3, Vector3> VelocityRequested;
        public IReadOnlyReactiveProperty<bool> IsGrounded => _isGrounded;

        public Quaternion Rotation { get => transform.rotation; set => transform.rotation = value; }
        public Vector3 Position { get => transform.position; set => transform.position = value; }


        private void Start()
        {
            _lastPosition = _groundTransform.position;
        }

        private void Update()
        {
            if (_velocity != Vector3.zero)
            {
                transform.position += _velocity * Time.deltaTime;
                VelocityRequested?.Invoke(_lastPosition, _groundTransform.position);
            }
            
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
                    _isGrounded.Value = true;
                else
                    _isGrounded.Value = false;
            }
        }
    }

    public interface IBallView : IReadOnlyBallView, IBallTransform
    {
        void SetVelocity(Vector3 velocity);
    }

    public interface IReadOnlyBallView : IReadOnlyBallTransform
    {
        event Action<Vector3, Vector3> VelocityRequested;
    }

    public interface IBallTransform : IReadOnlyBallTransform
    {
        new Quaternion Rotation { get; set; }
        new Vector3 Position { get; set; }
    }

    public interface IReadOnlyBallTransform
    {
        Quaternion Rotation { get; }
        Vector3 Position { get; }
    }
}