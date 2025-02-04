using _Project.Codebase.Core.Ball.ViewModel;
using UnityEngine;

namespace _Project.Codebase.Core.Attacker.EnemyAttacker
{
	public class EnemyAttackRool : IEnemyAttackRool
	{
		private const float ParallelAngle0 = 0;
		private const float ParallelAngle180 = 180;
		
		public bool CanAttack(Transform transform, IBallViewModel ballViewModel)
		{
			Vector3 attackableForward = transform.forward;
			Vector3 ballVelocity = ballViewModel.Velocity.Value;
			ballVelocity.y = 0;

			float angle = Vector3.Angle(attackableForward, ballVelocity);

			return (Mathf.Approximately(angle,ParallelAngle0) ||
			        Mathf.Approximately(angle,ParallelAngle180));
		}
	}

	public interface IEnemyAttackRool
	{
		bool CanAttack(Transform transform, IBallViewModel ballViewModel);
	}
}