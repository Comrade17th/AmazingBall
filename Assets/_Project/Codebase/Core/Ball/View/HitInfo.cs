using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    public struct HitInfo
    {
        public readonly Vector3 Point;
        public readonly Vector3 Normal;
        public readonly Vector3 Velocity;

        public HitInfo(Vector3 point, Vector3 normal, Vector3 velocity)
        {
            Point = point;
            Normal = normal;
            Velocity = velocity;
        }
    }
}