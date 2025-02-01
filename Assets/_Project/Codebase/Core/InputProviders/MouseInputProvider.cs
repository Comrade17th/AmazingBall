using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.InputProviders
{
    public class MouseInputProvider : IInputProvider
    {
        private Camera _camera;
        private readonly KeyCode _keyCode = KeyCode.Mouse0;

        [Inject]
        public MouseInputProvider(Camera camera)
        {
            _camera = camera;
        }

        public bool GetDetectionUp() => 
            Input.GetKeyUp(_keyCode);

        public bool GetDetectionDown() => 
            Input.GetKeyDown(_keyCode);

        public bool GetDetection() => 
            Input.GetKey(_keyCode);

        public Vector3 GetPosition(bool cameraToScreenWorldPoint = false)
        {
            if (cameraToScreenWorldPoint)
                return _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane));

            return new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane);
        }
    }
}