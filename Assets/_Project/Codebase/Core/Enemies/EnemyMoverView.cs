using System;
using UnityEngine;

namespace _Project.Codebase.Core.Enemies
{
	[RequireComponent(typeof(Collider))]
	public class EnemyMoverView : MonoBehaviour, IEnemyMoverView
	{
		private Vector3 _position;
		
		public event Action<Vector3> NewPositionRequested;
		public event Action<Collision> ObjectHit;

		private void Update()
		{
			transform.position = _position;
			NewPositionRequested?.Invoke(transform.position);
		}

		private void OnCollisionEnter(Collision other)
		{
			ObjectHit?.Invoke(other);
		}

		public void SetPosition(Vector3 position) =>
			_position = position;
	}
}