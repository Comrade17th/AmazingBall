using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    public class CustomVelocity : ICustomVelocity
    {
        private Vector3 _friction = new Vector3(0.1f, 0f, 0.1f);
        
        public Vector3 GetReflectedVelocity(
            Vector3 currentVelocity,
            Vector3 contactPointNormal) =>
            Vector3.Reflect(currentVelocity, contactPointNormal);

        public Vector3 GetNewVelocity(Vector3 currentVelocity)
        {
            Vector3 velocity = currentVelocity;
            velocity = ApplyFriction(currentVelocity);
            return velocity;
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
    }
}