using _Project.Codebase.Core.Ball.View;
using UnityEditor.Graphs;
using UnityEngine;

namespace _Project.Codebase.VisualDebug
{
    public static class GeometryDebug
    {
        public static void DrawSphere(
            Vector3 position, 
            Color color,
            float radius = 1,
            float seconds = 0.5f)
        {
            Debug.DrawLine(position, radius * Vector3.up , color, seconds);
            Debug.DrawLine(position, radius * Vector3.down , color, seconds);
            Debug.DrawLine(position, radius * Vector3.left , color, seconds);
            Debug.DrawLine(position, radius * Vector3.right , color, seconds);
            Debug.DrawLine(position, radius * Vector3.forward , color, seconds);
            Debug.DrawLine(position, radius * Vector3.back , color, seconds);
        }

        public static void DrawAttackLines(
            HitInfo hitInfo,
            float length = 10,
            float seconds = 10f)
        {
            Transform attacker = hitInfo.ThisTransform;
            Transform attackable = hitInfo.ContactPoint.otherCollider.transform;
            
            Vector3 velocity = hitInfo.Velocity;
            velocity.y = 0;
            
            float angle = Vector3.Angle(attackable.forward, velocity);
            
            Debug.DrawLine(attackable.position, attackable.position + length * attackable.forward, Color.green, seconds);
            Debug.DrawLine(attacker.position, attacker.position + length * hitInfo.Velocity, Color.magenta, seconds);
        }
    }
}