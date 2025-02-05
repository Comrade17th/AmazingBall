using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Enemies
{
	public class EnemySpawner : MonoBehaviour, IEnemySpawner
	{
		private IEnemyFactory _enemyFactory;

		//[Inject]
		private void Construct(IEnemyFactory enemyFactory)
		{
			_enemyFactory = enemyFactory;
		}
	}

	public interface IEnemySpawner
	{
	}
}