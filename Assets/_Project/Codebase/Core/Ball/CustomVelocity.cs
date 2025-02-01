using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    public class CustomVelocity : ICustomVelocity
    {
        private Vector3 _friction = new Vector3(2f, 0f, 2f);
        private Vector3 _maxVelocityAbs = new Vector3(10, 5, 10);
        private Vector3 _hitDamping = new Vector3(0f, 1f, 0f);
        private float _gravityAcceleration = -9.8f;

        private float DeltaTime => Time.deltaTime;
        
        public Vector3 GetReflectedVelocity(Vector3 currentVelocity, Vector3 contactPointNormal, bool isGrounded)
        {
            var velocity = Vector3.Reflect(currentVelocity, contactPointNormal);
            velocity -= _hitDamping;
            return CancelVelocityYAccumulation(velocity, isGrounded);
        }

        public Vector3 GetNewVelocity(Vector3 currentVelocity, bool isGrounded)
        {
            Vector3 velocity;
            velocity = ApplyFriction(currentVelocity);
            velocity = ApplyGravity(velocity, isGrounded);
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

        private Vector3 ApplyGravity(Vector3 velocity, bool isGrounded)
        {
            var scaledGravity = new Vector3(0, _gravityAcceleration, 0) * DeltaTime;
    
            if(isGrounded == false)
                velocity += scaledGravity;
            
            return velocity;
        }
        
        private Vector3 ApplyFriction(Vector3 velocity)
        {
            
            
            return new Vector3(
                Mathf.MoveTowards(velocity.x, 0, _friction.x * DeltaTime),
                Mathf.MoveTowards(velocity.y, 0, _friction.y * DeltaTime),
                Mathf.MoveTowards(velocity.z, 0, _friction.z * DeltaTime));
        }
    }

    public interface ICustomVelocity
    {
        Vector3 GetReflectedVelocity(Vector3 currentVelocity, Vector3 contactPointNormal, bool isGrounded);
        Vector3 GetNewVelocity(Vector3 currentVelocity, bool isGrounded);
        Vector3 GetPushVelocity(Vector3 startPosition, Vector3 endPosition);
    }
}