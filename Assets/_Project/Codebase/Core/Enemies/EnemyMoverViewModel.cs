using System;
using _Project.Codebase.Core.Health.BallHealth;
using _Project.Codebase.Core.SpawnZones;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Enemies
{
	public class EnemyMoverViewModel : IEnemyMoverViewModel, IDisposable//, IInitializable
	{
		private readonly CompositeDisposable _compositeDisposable = new();
		private readonly IEnemyMoverView _view;
		private readonly IEnemyMoverModel _model;

		private ReactiveProperty<float> Speed = new();
		private ReactiveProperty<Vector3> Direction = new();

		[Inject]
		public EnemyMoverViewModel(
			IEnemyMoverView view,
			IEnemyMoverModel model)
		{
			_view = view ?? throw new ArgumentNullException(nameof(view));
			_model = model ?? throw new ArgumentNullException(nameof(model));

			Bind();
		}
		
		// public void Initialize()
		// {
		// 	Init();
		// }
		
		public void Dispose()
		{
			_compositeDisposable?.Dispose();
			_view.NewPositionRequested -= OnNewPositionRequested;
		}

		private void Bind()
		{
			_model.Speed
				.Subscribe(speed => Speed.Value = speed)
				.AddTo(_compositeDisposable);

			_model.Direction
				.Subscribe(direction => Direction.Value = direction)
				.AddTo(_compositeDisposable);

			_view.NewPositionRequested += OnNewPositionRequested;
			_view.ObjectHit += OnObjectHit;
		}

		// private void Init(IDirectionSpawnZone directionSpawnZone)
		// {
		// 	_model.Direction.Value = directionSpawnZone.Direction;
		// 	_view.SetPosition(directionSpawnZone.Position);
		// 	_view.Transform.LookAt(_view.Transform.position + Direction.Value);
		// }

		private void OnObjectHit(Collision other)
		{
			if (other.gameObject.TryGetComponent(out IBallHealthHitBox ball) == false)
			{ 
				_model.Direction.Value = Vector3.Reflect(Direction.Value, other.GetContact(0).normal);
				_view.Transform.LookAt(_view.Transform.position + Direction.Value);
			}
		}

		private void OnNewPositionRequested(Vector3 position)
		{
			Vector3 newPosition = position + Direction.Value * Speed.Value * Time.deltaTime;
			_view.SetPosition(newPosition);
		}
	}
}