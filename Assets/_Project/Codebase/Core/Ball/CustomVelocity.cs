using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    public class CustomVelocity : ICustomVelocity
    {
        private Vector3 _friction = new Vector3(0.5f, 0f, 0.5f);
        private Vector3 _maxVelocityAbs = new Vector3(10, 5, 10);
        
        public Vector3 GetReflectedVelocity(
            Vector3 currentVelocity,
            Vector3 contactPointNormal) =>
            Vector3.Reflect(currentVelocity, contactPointNormal);

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
        Vector3 GetReflectedVelocity(Vector3 currentVelocity, Vector3 contactPointNormal);
        Vector3 GetNewVelocity(Vector3 currentVelocity);
        Vector3 GetPushVelocity(Vector3 startPosition, Vector3 endPosition);
    }
}