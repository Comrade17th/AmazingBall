using System;
using _Project.Codebase.Core.InputProviders;
using UnityEngine;

namespace _Project.Codebase.Core
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PhysicsBody _physicsBody;
        private IInputProvider _inputProvider;
        
        [SerializeField] private float _maxVelocity = 5f;
        [SerializeField] private float _maxPressTime = 3f;

        private void OnEnable()
        {
            //_mouseInputProvider.MouseUp += OnMouseUp;
        }

        private void OnDisable()
        {
            //_mouseInputProvider.MouseUp -= OnMouseUp;
        }

        private void OnMouseUp(float time, Vector3 mouseWorldPosition)
        {
            float velocity = ConvertTimeToVelocity(time);
            mouseWorldPosition.y = 0;
            
            
            //_physicsBody.AddVelocity();
        }

        private float ConvertTimeToVelocity(float time)
        {
            time = Mathf.Clamp(time, 0f, _maxPressTime);
            return _maxVelocity * (time / _maxPressTime);
        }
    }
}