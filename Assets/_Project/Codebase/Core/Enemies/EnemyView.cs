using System;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Enemies
{
	[RequireComponent(typeof(Collider))]
	public class EnemyView : MonoBehaviour, IEnemyView
	{
		 public Transform Transform => transform;

		 public event Action<Collision> ObjectHit;

		 private void OnCollisionEnter(Collision other) =>
			 ObjectHit?.Invoke(other);

		 public class Factory : PlaceholderFactory<EnemyView>
		 {
			 
		 }
	}
}