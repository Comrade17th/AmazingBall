using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	[RequireComponent(typeof(Collider))]
	public class HealthHitBox : MonoBehaviour, IHealthHitBox
	{
		private readonly ReactiveProperty<int> _takeDamageRequested = new();

		public IReadOnlyReactiveProperty<int> TakeDamageRequested => _takeDamageRequested;

		public void TakeDamage(int damage)
		{
			_takeDamageRequested.Value = damage;
		}
	}
}