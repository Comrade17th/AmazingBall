using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    public class CustomVelocity : ICustomVelocity
    {
        private Vector3 _friction = new Vector3(2f, 0f, 2f);
        private Vector3 _maxVelocityAbs = new Vector3(10, 5, 10);
        private Vector3 _hitDamping = new Vector3(0f, 1f, 0f);
        
        public Vector3 GetReflectedVelocity(Vector3 currentVelocity, Vector3 contactPointNormal, bool isGrounded)
        {
            var velocity = Vector3.Reflect(currentVelocity, contactPointNormal);
            velocity -= _hitDamping;
            return CancelVelocityYAccumulation(velocity, isGrounded);
        }

        public Vector3 GetNewVelocity(Vector3 currentVelocity)
        {
            Vector3 velocity;
            velocity = ApplyFriction(currentVelocity);
            return GetClampedVelocity(velocity);
        }

        public Vector3 GetPushVelocity(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 lineVelocity = endPosition - startPosition;
            var velocity = new Vector3(lineVelocity.x, 0f, lineVelocity.z); 
            return GetClampedVelocity(velocity);
        }
        
        private Vector3 CancelVelocityYAccumulation(Vector3 velocity, bool isGrounded)
        {
            float velocityCutBorder = -1.1f;
    
            if (isGrounded && 
                velocity.y < 0 && 
                velocity.y > velocityCutBorder)
            {
                velocity = new Vector3(velocity.x, 0, velocity.z);
            }

            return velocity;
        }

        private Vector3 GetClampedVelocity(Vector3 velocity)
        {
            return new Vector3(
                Mathf.Clamp(velocity.x, -_maxVelocityAbs.x, _maxVelocityAbs.x), 
                Mathf.Clamp(velocity.y, -_maxVelocityAbs.y, _maxVelocityAbs.y),
                Mathf.Clamp(velocity.z, -_maxVelocityAbs.z, _maxVelocityAbs.z));
        }
        
        private void ApplyGravity(){}
        
        private Vector3 ApplyFriction(Vector3 velocity)
        {
            float deltaTime = Time.deltaTime;
            
            return new Vector3(
                Mathf.MoveTowards(velocity.x, 0, _friction.x * deltaTime),
                Mathf.MoveTowards(velocity.y, 0, _friction.y * deltaTime),
                Mathf.MoveTowards(velocity.z, 0, _friction.z * deltaTime));
        }
    }

    public interface ICustomVelocity
    {
        Vector3 GetReflectedVelocity(Vector3 currentVelocity, Vector3 contactPointNormal, bool isGrounded);
        Vector3 GetNewVelocity(Vector3 currentVelocity);
        Vector3 GetPushVelocity(Vector3 startPosition, Vector3 endPosition);
    }
}