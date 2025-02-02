using System;
using UniRx;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public interface IHealthHitBox
	{
		event Action<int> TakeDamageRequested;

		void TakeDamage(int damage);
	}
}