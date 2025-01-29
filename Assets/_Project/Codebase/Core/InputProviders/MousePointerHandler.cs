using System;
using _Project.Codebase.Interfaces;
using _Project.Codebase.VisualDebug;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.InputProviders
{
    public class MousePointerHandler : MonoBehaviour, IPointerHandler
    {
        private IInputProvider _inputProvider;
        private Camera _camera;

        public event Action PointerDown;
        public event Action PointerUp;

        [Inject]
        public void Construct(IInputProvider inputProvider, Camera camera)
        {
            _inputProvider = inputProvider;
            _camera = camera;
        }


        private void Update()
        {
            if (_inputProvider.GetDetectionUp()) 
                PointerUp?.Invoke();
            
            if(_inputProvider.GetDetectionDown())
                PointerDown?.Invoke();
            
            GeometryDebug.DrawSphere(_inputProvider.GetPosition(true), Color.magenta);
        }

        public Vector3 GetWorldPosition()
        {
            Vector3 screenPoint = _inputProvider.GetPosition();
            Ray ray = _camera.ScreenPointToRay(screenPoint);

            if (Physics.Raycast(ray, out var hit))
                return hit.point;
            
            return Vector3.zero;
        }
    }

    public interface IPointerHandler
    {
        event Action PointerDown;
        event Action PointerUp;

        Vector3 GetWorldPosition();
    }
}