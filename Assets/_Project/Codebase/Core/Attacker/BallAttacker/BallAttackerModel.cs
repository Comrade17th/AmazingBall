using UniRx;

namespace _Project.Codebase.Core.Attacker.BallAttacker
{
	public class BallAttackerModel: IBallAttackerModel
	{
		public ReactiveProperty<int> Damage { get; set; } = new(1);

		public ReactiveProperty<float> AngleRange { get; set; } = new(10);
	}

	public interface IBallAttackerModel : IAttackerModel
	{
	}

	public interface IAttackerModel
	{
		public ReactiveProperty<int> Damage { get; set; }
		public ReactiveProperty<float> AngleRange { get; set; }
	}
}