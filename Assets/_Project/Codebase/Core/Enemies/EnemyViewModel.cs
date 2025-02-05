using System;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Enemies
{
	public class EnemyViewModel : IEnemyViewModel, IDisposable
	{
		private readonly IEnemyView _view;

		public Transform Transform => _view.Transform;

		public event Action<Collision> ObjectHit;

		[Inject]
		public EnemyViewModel(IEnemyView view)
		{
			_view = view;

			Bind();
		}
		
		public void Dispose() =>
			_view.ObjectHit -= OnObjectHit;

		private void Bind() =>
			_view.ObjectHit += OnObjectHit;

		private void OnObjectHit(Collision other) =>
			ObjectHit?.Invoke(other);
	}
}