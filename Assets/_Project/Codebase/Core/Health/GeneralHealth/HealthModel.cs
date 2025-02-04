using UniRx;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public class HealthModel : IHealthModel
	{
		public ReactiveProperty<int> Max { get; set; }

		public ReactiveProperty<int> Current { get; set; }

		public ReactiveProperty<string> Label { get; set; }

		public HealthModel(int max = 1, int current = 1, string label = "")
		{
			Max = new(max);
			Current = new(current);
			Label = new(label);
		}
	}
}