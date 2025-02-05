using System;
using UnityEngine;

namespace _Project.Codebase.Core.Enemies
{
	public interface IEnemyViewModel
	{
		public Transform Transform { get; }

		public event Action<Collision> ObjectHit;
	}
}