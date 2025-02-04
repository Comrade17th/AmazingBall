using _Project.Codebase.Core.Health.GeneralHealth;
using UniRx;

namespace _Project.Codebase.Core.Health.BallHealth
{
	public class BallHealthModel: HealthModel, IBallHealthModel
	{
		public BallHealthModel(int max = 10,
			int current = 10,
			string label = "Health")
			: base(max, current, label)

		{

		}
	}
}