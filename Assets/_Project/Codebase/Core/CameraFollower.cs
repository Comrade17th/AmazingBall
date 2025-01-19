using System;
using _Project.Codebase.Core.Ball;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Codebase.Core
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _distance = 3.0f;
        [SerializeField] private float _height = 3.0f;
        [SerializeField] private float _damping = 5.0f;
        [SerializeField] private bool _smoothRotation = true;
        [SerializeField] private bool _followBehind = true;
        [SerializeField] private float _rotationDamping = 10.0f;
        
        private Transform _target;

        [Inject]
        private void Construct(BallView target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            
            _target = target.transform;
        }

        void LateUpdate() // https://stackoverflow.com/questions/10752435/how-do-i-make-a-camera-follow-an-object-in-unity3d-c#answers 
        {
            Vector3 wantedPosition;
            
            Debug.Log($"{_target == null}");
            
            if(_followBehind)
                wantedPosition = _target.TransformPoint(0, _height, -_distance);
            else
                wantedPosition = _target.TransformPoint(0, _height, _distance);

            transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * _damping);

            if (_smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(_target.position - transform.position, _target.up);
                transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * _rotationDamping);
            }
            else 
                transform.LookAt (_target, _target.up);
        }
    }
}