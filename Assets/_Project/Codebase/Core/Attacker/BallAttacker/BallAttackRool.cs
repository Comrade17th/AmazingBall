using _Project.Codebase.Core.Ball.View;
using _Project.Codebase.VisualDebug;
using UnityEngine;

namespace _Project.Codebase.Core.Attacker.BallAttacker
{
	public class BallAttackRool: IBallAttackRool
	{
		private const float RightAngle = 90;

		public bool CanAttack(HitInfo hitInfo, float angleRange)

		{
			GeometryDebug.DrawAttackLines(hitInfo);
			Vector3 attackableForward = hitInfo.ContactPoint.otherCollider.transform.forward;
			Vector3 attackVelocity = hitInfo.Velocity;
			attackVelocity.y = 0;

			float angle = Vector3.Angle(attackableForward, attackVelocity);

			return (angle <= RightAngle + angleRange &&
			        angle >= RightAngle - angleRange);
		}
	}

	public interface IBallAttackRool
	{
		bool CanAttack(HitInfo hitInfo, float angleRange);
	}
}