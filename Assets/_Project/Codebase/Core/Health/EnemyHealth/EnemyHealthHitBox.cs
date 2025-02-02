using _Project.Codebase.Core.Health.GeneralHealth;
using UnityEngine;

namespace _Project.Codebase.Core.Health.EnemyHealth
{
	public class EnemyHealthHitBox: HealthHitBox, IEnemyHealthHitBox
	{
		public override void TakeDamage(int damage)
		{
			Debug.Log($"taken {damage}");
			base.TakeDamage(damage);
		}
	}
}