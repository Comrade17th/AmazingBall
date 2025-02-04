using _Project.Codebase.Core.Attacker.GeneralAttacker;
using UniRx;

namespace _Project.Codebase.Core.Attacker.BallAttacker
{
	public interface IBallAttackerModel : IAttackerModel
	{
		public ReactiveProperty<float> AngleRange { get; set; }
	}
}