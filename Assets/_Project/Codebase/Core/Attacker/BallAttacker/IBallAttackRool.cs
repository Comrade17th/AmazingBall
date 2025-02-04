using _Project.Codebase.Core.Ball.View;

namespace _Project.Codebase.Core.Attacker.BallAttacker
{
	public interface IBallAttackRool
	{
		bool CanAttack(HitInfo hitInfo, float angleRange);
	}
}