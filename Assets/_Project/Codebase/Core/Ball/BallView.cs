using _Project.Codebase.Interfaces;
using UnityEngine;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallView : MonoBehaviour//, IPointerDowndHandler
    {
        [SerializeField] private PhysicsBody _physicsBody;
        private IInputProvider _inputProvider;

        [Inject]
        private void Construct(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        private void Update()
        {
            if (_inputProvider.GetDetection())
            {
                Vector3 pointerPosition = _inputProvider.GetPosition(true);
                
                
                
            }
            else
            {
                
            }
        }
    }
}