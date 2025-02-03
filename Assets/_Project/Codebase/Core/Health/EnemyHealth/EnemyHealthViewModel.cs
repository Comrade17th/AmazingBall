using _Project.Codebase.Core.Health.GeneralHealth;
using Zenject;

namespace _Project.Codebase.Core.Health.EnemyHealth
{
	public class EnemyHealthViewModel : HealthViewModel, IEnemyHealthViewModel
	{
		[Inject]
		public EnemyHealthViewModel(
			IEnemyHealthModel model,
			IEnemyHealthView view,
			IEnemyHealthHitBox hitBox) : base(model, view, hitBox)
		{
		}
	}
}