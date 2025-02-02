using UnityEngine;

namespace _Project.Codebase.Core.Ball.View
{
    public struct HitInfo
    {
        public readonly Transform ThisTransform;
        public readonly ContactPoint ContactPoint;
        public readonly Vector3 Velocity;

        public HitInfo(ContactPoint point, Vector3 velocity, Transform thisTransform)
        {
            ContactPoint = point;
            Velocity = velocity;
            ThisTransform = thisTransform;
        }
    }
}