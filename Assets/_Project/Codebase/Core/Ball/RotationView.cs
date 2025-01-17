using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class RotationView : MonoBehaviour
    {
        [SerializeField] private Transform _meshParent;
        [SerializeField] private float _rotationCoefficient = 0.5f;
        
        private PhysicsBody _physicsBody;
        
        [Inject]
        private void Construct(PhysicsBody physicsBody)
        {
            _physicsBody = physicsBody;
            _physicsBody.VelocityChanged += Rotate;
            _physicsBody.DirectionChanged += OnDirectionChanged;
        }

        private void OnDestroy()
        {
            _physicsBody.VelocityChanged -= Rotate;
            _physicsBody.DirectionChanged -= OnDirectionChanged;
        }

        private void Rotate(Vector3 velocity)
        {
            velocity *= _rotationCoefficient;
            
            float velocityX = Mathf.Abs(velocity.x);
            float velocityZ = Mathf.Abs(velocity.z);
            _meshParent.Rotate(new Vector3(velocityX > velocityZ ? velocityX : velocityZ, 0, 0), Space.Self);
        }

        private void OnDirectionChanged(Vector3 velocity)
        {
            if(velocity.y == 0f)
                _meshParent.localRotation = Quaternion.LookRotation(new Vector3(velocity.x, _meshParent.rotation.y, velocity.z));
        }
    }
}