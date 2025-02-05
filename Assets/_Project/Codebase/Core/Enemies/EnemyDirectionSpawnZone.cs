using _Project.Codebase.Core.SpawnZones;

namespace _Project.Codebase.Core.Enemies
{
	public class EnemyDirectionSpawnZone : DirectionSpawnZone, IEnemyDirectionSpawnZone
	{
		public EnemyType EnemyType { get; }
	}

	public interface IEnemyDirectionSpawnZone: IDirectionSpawnZone
	{
		EnemyType EnemyType { get; }
	}
}