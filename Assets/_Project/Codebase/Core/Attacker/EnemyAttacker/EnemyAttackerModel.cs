using _Project.Codebase.Core.Attacker.GeneralAttacker;

namespace _Project.Codebase.Core.Attacker.EnemyAttacker
{
	public class EnemyAttackerModel : AttackerModel, IEnemyAttackerModel
	{
		public EnemyAttackerModel(int damage = 1) : base(damage)
		{
			
		}
	}

	public interface IEnemyAttackerModel : IAttackerModel
	{
	}
}