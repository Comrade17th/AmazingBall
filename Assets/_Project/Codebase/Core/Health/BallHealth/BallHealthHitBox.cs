using _Project.Codebase.Core.Health.GeneralHealth;

namespace _Project.Codebase.Core.Health.BallHealth
{
	public class BallHealthHitBox: HealthHitBox, IBallHealthHitBox
	{
		
	}

	public interface IBallHealthHitBox : IHealthHitBox
	{
	}
}