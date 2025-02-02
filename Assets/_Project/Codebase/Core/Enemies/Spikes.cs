using _Project.Codebase.Core.Health.BallHealth;
using UnityEngine;

namespace _Project.Codebase.Core.Enemies
{
	public class Spikes: MonoBehaviour
	{
		[SerializeField] private int _damage = 1;
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out IBallHealthHitBox hitBox))
			{
				hitBox.TakeDamage(_damage);
			}
		}
	}
}