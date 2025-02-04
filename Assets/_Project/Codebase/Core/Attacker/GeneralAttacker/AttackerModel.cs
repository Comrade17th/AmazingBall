using UniRx;

namespace _Project.Codebase.Core.Attacker.GeneralAttacker
{
	public class AttackerModel : IAttackerModel
	{
		public ReactiveProperty<int> Damage { get; set; }

		public AttackerModel(int damage = 1)
		{
			Damage = new(damage);
		}
	}
}