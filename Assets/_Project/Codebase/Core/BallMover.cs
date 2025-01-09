using System;
using _Project.Codebase.Core.InputProviders;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core
{
    public class BallMover
    {
        private PhysicsBody _physicsBody;
        private IInputProvider _inputProvider;
        
        private float _maxVelocity = 5f; // to static data // to physics calculation class
        private float _maxPressTime = 3f; // to static data, to push class

        [Inject]
        public BallMover(IInputProvider inputProvider, PhysicsBody physicsBody)
        {
            Debug.Log($"BallMover constructed");
            _inputProvider = inputProvider;
            _physicsBody = physicsBody;
        }
        
        private void OnPointerUp(Vector3 mouseWorldPosition)
        {
            Vector3 velocity = new Vector3();
            mouseWorldPosition.y = 0;
               
            Debug.Log($"Added velocity: {velocity}");
            //_physicsBody.AddVelocity();
        }

        private float ConvertTimeToVelocity(float time) // to push class
        {
            time = Mathf.Clamp(time, 0f, _maxPressTime);
            return _maxVelocity * (time / _maxPressTime);
        }
    }
}