using UniRx;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public interface IHealthHitBox
	{
		IReadOnlyReactiveProperty<int> TakeDamageRequested { get; }

		void TakeDamage(int damage);
	}
}