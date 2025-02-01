using UniRx;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public class HealthModel : IHealthModel
	{
		public ReactiveProperty<int> Max { get; set; }

		public ReactiveProperty<int> Current { get; set; }

		public ReactiveProperty<string> Label { get; set; }
	}
}