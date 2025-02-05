using System;
using UnityEngine;

namespace _Project.Codebase.Core.Enemies
{
	public interface IEnemyMoverView
	{
		event Action<Vector3> NewPositionRequested;
		event Action<Collision> ObjectHit;

		void SetPosition(Vector3 position);
	}
}