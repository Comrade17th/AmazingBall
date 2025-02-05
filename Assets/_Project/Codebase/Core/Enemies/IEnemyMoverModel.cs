using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Enemies
{
	public interface IEnemyMoverModel
	{
		ReactiveProperty<float> Speed { get; set; }
		ReactiveProperty<Vector3> Direction { get; set; }
	}
}