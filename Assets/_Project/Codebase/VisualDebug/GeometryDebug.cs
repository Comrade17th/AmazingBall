using UnityEditor.Graphs;
using UnityEngine;

namespace _Project.Codebase.VisualDebug
{
    public static class GeometryDebug
    {
        public static void DrawSphere(Vector3 position, Color color, float radius = 1, float seconds = 1)
        {
            Debug.DrawLine(position, Vector3.up * radius, color, seconds);
            Debug.DrawLine(position, Vector3.down * radius, color, seconds);
            Debug.DrawLine(position, Vector3.left * radius, color, seconds);
            Debug.DrawLine(position, Vector3.right * radius, color, seconds);
            Debug.DrawLine(position, Vector3.forward * radius, color, seconds);
            Debug.DrawLine(position, Vector3.back * radius, color, seconds);
        }
    }
}