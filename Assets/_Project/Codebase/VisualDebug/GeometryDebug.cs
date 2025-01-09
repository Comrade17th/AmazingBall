using UnityEditor.Graphs;
using UnityEngine;

namespace _Project.Codebase.VisualDebug
{
    public static class GeometryDebug
    {
        public static void DrawSphere(Vector3 position, Color color, float radius = 1, float seconds = 0.5f)
        {
            Debug.DrawLine(position, radius * Vector3.up , color, seconds);
            Debug.DrawLine(position, radius * Vector3.down , color, seconds);
            Debug.DrawLine(position, radius * Vector3.left , color, seconds);
            Debug.DrawLine(position, radius * Vector3.right , color, seconds);
            Debug.DrawLine(position, radius * Vector3.forward , color, seconds);
            Debug.DrawLine(position, radius * Vector3.back , color, seconds);
        }
    }
}