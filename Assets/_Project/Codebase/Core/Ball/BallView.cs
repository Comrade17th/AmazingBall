using _Project.Codebase.Core.InputProviders;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private PhysicsBody _physicsBody;
        private IInputProvider _inputProvider;
        private MousePointerHandler _mousePointerHandler;
        private Camera _camera;

        [Inject]
        private void Construct(IInputProvider inputProvider, MousePointerHandler mousePointerHandler, Camera camera)
        {
            _inputProvider = inputProvider;
            _mousePointerHandler = mousePointerHandler;
            _camera = camera;

            _mousePointerHandler.PointerUp += OnMousePointerUp;
            _mousePointerHandler.PointerDown += OnMousePointerDown;
        }

        private void OnDestroy()
        {
            _mousePointerHandler.PointerUp -= OnMousePointerUp;
            _mousePointerHandler.PointerDown -= OnMousePointerDown;
        }
        
        private void OnMousePointerDown()
        {
            
        }

        private void OnMousePointerUp()
        {
            Vector3 screenPoint = _inputProvider.GetPosition();
            Ray ray = _camera.ScreenPointToRay(screenPoint);
            RaycastHit hit;
            Vector3 velocity;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPoint = hit.point;
                Vector3 startPoint = transform.position;
                
                Vector3 lineVelocity = targetPoint - startPoint;
                velocity = new Vector3(lineVelocity.x, 0f, lineVelocity.z);
                _physicsBody.SetVelocity(velocity);
            }
        }
    }
}