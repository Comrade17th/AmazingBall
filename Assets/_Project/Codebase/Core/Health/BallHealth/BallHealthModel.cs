using _Project.Codebase.Core.Health.GeneralHealth;
using UniRx;

namespace _Project.Codebase.Core.Health.BallHealth
{
	public class BallHealthModel: HealthModel, IBallHealthModel
	{
		public new ReactiveProperty<int> Max { get; set; } = new(10);
		public new ReactiveProperty<int> Current { get; set; } = new(10);
		public new ReactiveProperty<string> Label { get; set; } = new("Health");
		
	}
}