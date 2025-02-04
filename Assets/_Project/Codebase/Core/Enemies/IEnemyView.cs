using System;
using UnityEngine;

namespace _Project.Codebase.Core.Enemies
{
	public interface IEnemyView
	{
		Transform Transform { get; }

		event Action<Collision> ObjectHit;
	}
}