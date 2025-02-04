using UniRx;

namespace _Project.Codebase.Core.Attacker.BallAttacker
{
	public interface IAttackerModel
	{
		public ReactiveProperty<int> Damage { get; set; }
		
	}
}