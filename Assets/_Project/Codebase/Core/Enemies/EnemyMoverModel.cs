using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Enemies
{
	public class EnemyMoverModel : IEnemyMoverModel
	{
		public ReactiveProperty<float> Speed { get; set; }

		public ReactiveProperty<Vector3> Direction { get; set; }

		public EnemyMoverModel(float speed = 10)
		{
			Speed = new(speed);
			Direction = new(Vector3.zero);
		}
	}
}