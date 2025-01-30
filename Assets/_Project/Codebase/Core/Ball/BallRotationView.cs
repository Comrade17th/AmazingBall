using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallRotationView : MonoBehaviour, IBallRotationView
    {
        [SerializeField] private float _rotationCoefficient = 0.5f;
        
        public void Rotate(Vector3 velocity)
        {
            velocity *= _rotationCoefficient;
            
            float velocityX = Mathf.Abs(velocity.x);
            float velocityZ = Mathf.Abs(velocity.z);
            transform.Rotate(new Vector3(velocityX > velocityZ ? velocityX : velocityZ, 0, 0), Space.Self);
        }

        public void ChangeDirection(Vector3 velocity)
        {
            //if(velocity.y == 0f) 
            transform.localRotation = Quaternion.LookRotation(new Vector3(velocity.x, transform.rotation.y, velocity.z));
        }
    }

    public interface IBallRotationView
    {
        void Rotate(Vector3 velocity);
        void ChangeDirection(Vector3 velocity);
    }
}