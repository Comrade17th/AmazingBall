using UniRx;

namespace _Project.Codebase.Core.Attacker.GeneralAttacker
{
	public interface IAttackerModel
	{
		public ReactiveProperty<int> Damage { get; set; }
		
	}
}