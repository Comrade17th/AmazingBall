using UnityEngine;

namespace _Project.Codebase.Interfaces
{
    public interface IInputProvider
    {
        bool GetDetection();
        Vector3 GetPosition(bool cameraToScreenWorldPoint = false);
    }
}