using _Project.Codebase.Core.Health.GeneralHealth;

namespace _Project.Codebase.Core.Health.EnemyHealth
{
	public class EnemyHealthViewModel : HealthViewModel, IEnemyHealthViewModel
	{
		public EnemyHealthViewModel(
			IEnemyHealthModel model,
			IEnemyHealthView view,
			IEnemyHealthHitBox hitBox) : base(model, view, hitBox)
		{
		}
	}
}