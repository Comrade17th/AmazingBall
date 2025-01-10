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
        private PointerHandler _pointerHandler;
        private Camera _camera;

        [Inject]
        private void Construct(IInputProvider inputProvider, PointerHandler pointerHandler, Camera camera)
        {
            _inputProvider = inputProvider;
            _pointerHandler = pointerHandler;
            _camera = camera;

            _pointerHandler.PointerUp += OnPointerUp;
            _pointerHandler.PointerDown += OnPointerDown;
        }

        private void OnDestroy()
        {
            _pointerHandler.PointerUp -= OnPointerUp;
            _pointerHandler.PointerDown -= OnPointerDown;
        }

        private void Update()
        {
            
        }

        private void OnPointerDown()
        {
            Debug.Log("OnPointerDown");
        }

        private void OnPointerUp()
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