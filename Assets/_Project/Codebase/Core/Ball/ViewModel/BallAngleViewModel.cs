using System;
using _Project.Codebase.Core.Ball.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball.ViewModel
{
	public class BallAngleViewModel: IBallAngleViewModel, IDisposable
	{
		private readonly CompositeDisposable _compositeDisposable = new();
		private readonly IBallAngleView _angleView;
		private readonly IBallRotationViewModel _rotationViewModel;

		private ReactiveProperty<Quaternion> _rotation = new();

		[Inject]
		public BallAngleViewModel(IBallAngleView angleView, IBallRotationViewModel rotationViewModel)
		{
			_angleView = angleView;
			_rotationViewModel = rotationViewModel;

			_rotationViewModel.Rotation
				.Subscribe(quaternion => _rotation.Value = quaternion)
				.AddTo(_compositeDisposable);
		}

		public void Dispose()
		{
			_compositeDisposable?.Dispose();
		}
	}

	public interface IBallAngleViewModel
	{
	}
}