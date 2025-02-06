using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Enemies
{
	public class EnemyFactory : IEnemyFactory
	{
		private const string HedgehogEnemyPath = "Hedgehog (enemy)";
		private const string HedgehogStayingEnemyPath = "HedgehogStaying (enemy)";
		
		private readonly DiContainer _diContainer;
		
		private EnemyView _hedgehog;
		private EnemyView _hedgehogStaying;

		public EnemyFactory(DiContainer diContainer)
		{
			_diContainer = diContainer;
		}

		public void Load()
		{
			_hedgehog = Resources.Load<EnemyView>(HedgehogEnemyPath);
			_hedgehogStaying = Resources.Load<EnemyView>(HedgehogStayingEnemyPath);
		}

		public void Create(IEnemyDirectionSpawnZone zone)
		{
			EnemyType enemyType = zone.EnemyType;
			Vector3 at = zone.Position;
			Quaternion rotation = zone.Transform.rotation;
			Transform parent = zone.Transform;
			
			switch (enemyType)
			{
				case EnemyType.Hedgehog:
					_diContainer.InstantiatePrefab(_hedgehog, at, rotation, parent);
					break;
				case EnemyType.HedgehogStaying:
					_diContainer.InstantiatePrefab(_hedgehogStaying, at, rotation, parent);
					break;
			}
		}
	}

	public interface IEnemyFactory
	{
		void Load();
		void Create(IEnemyDirectionSpawnZone zone);
	}
}