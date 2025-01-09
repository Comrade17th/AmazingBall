using UnityEngine;

namespace _Project.Codebase.Core.InputProviders
{
    public interface IInputProvider
    {
        bool GetDetection();
        Vector3 GetPosition(bool cameraToScreenWorldPoint = false);
    }
}