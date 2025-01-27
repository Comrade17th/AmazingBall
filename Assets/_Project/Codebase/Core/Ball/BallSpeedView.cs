using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallSpeedView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _speedTMPro;
        
        private PhysicsBody _physicsBody;

        [Inject]
        private void Construct(PhysicsBody physicsBody)
        {
            _physicsBody = physicsBody;
            _physicsBody.VelocityChanged += OnVelocityChanged;
        }

        private void OnDestroy() => 
            _physicsBody.VelocityChanged += OnVelocityChanged;

        private void OnVelocityChanged(Vector3 velocity) => 
            _speedTMPro.text = velocity.ToString();
    }
}