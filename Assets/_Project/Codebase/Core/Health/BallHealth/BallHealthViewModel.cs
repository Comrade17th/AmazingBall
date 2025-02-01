using _Project.Codebase.Core.Health.GeneralHealth;
using Zenject;

namespace _Project.Codebase.Core.Health.BallHealth
{
	public class BallHealthViewModel : HealthViewModel, IBallHealthViewModel
	{
		[Inject]
		public BallHealthViewModel(
			IBallHealthModel model,
			IBallHealthView view,
			IBallHealthHitBox hitBox) 
			: base(model, view, hitBox)
		{
		}
	}
}