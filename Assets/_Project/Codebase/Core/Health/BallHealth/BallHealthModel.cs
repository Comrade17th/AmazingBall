using _Project.Codebase.Core.Health.GeneralHealth;
using UniRx;

namespace _Project.Codebase.Core.Health.BallHealth
{
	public class BallHealthModel: HealthModel, IBallHealthModel
	{
		public ReactiveProperty<int> Max { get; set; } = new(10);
	}
}