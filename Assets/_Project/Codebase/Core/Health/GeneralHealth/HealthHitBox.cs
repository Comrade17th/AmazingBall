using System;
using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	[RequireComponent(typeof(Collider))]
	public class HealthHitBox : MonoBehaviour, IHealthHitBox
	{
		public event Action<int> TakeDamageRequested;

		public void TakeDamage(int damage)
		{
			TakeDamageRequested?.Invoke(damage);
		}
	}
}