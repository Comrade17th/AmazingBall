using UnityEngine;

namespace _Project.Codebase.Core
{
    public class PhysicsBody : MonoBehaviour
    {
        [SerializeField] private float _friction = 0.5f;
        
        [SerializeField] private float _velocity = 3;
        private Vector3 _direction = Vector3.forward;

        private void FixedUpdate()
        {
            if (_velocity <= 0.0f)
                _velocity = 0;
            else
                _velocity -= _friction * Time.deltaTime;
            
            transform.Translate(_direction * (_velocity * Time.fixedDeltaTime));
        }

        public void AddVelocity(float velocity, Vector3 direction)
        {
            
        }

        private void AddFriction()
        {
            
        }
    }
}