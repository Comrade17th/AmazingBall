using UnityEngine;

namespace _Project.Codebase.Interfaces
{
    public interface IInputProvider
    {
        bool GetDetectionUp();
        bool GetDetectionDown();
        bool GetDetection();
        Vector3 GetPosition(bool cameraToScreenWorldPoint = false);
    }
}