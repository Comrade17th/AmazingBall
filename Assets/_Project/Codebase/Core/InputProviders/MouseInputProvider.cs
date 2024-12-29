using UnityEngine;

namespace _Project.Codebase.Core.InputProviders
{
    public class MouseInputProvider
    {
        private Camera _camera;
        private readonly KeyCode _keyCode = KeyCode.Mouse0;

        public bool GetDetection()
        {
            return Input.GetKeyDown(_keyCode);
        }

        public Vector3 GetPosition(bool cameraToScreenWorldPoint = false)
        {
            if (cameraToScreenWorldPoint)
                return _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane));

            return new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane);
        }
    }
}