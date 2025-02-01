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
		private readonly IBallViewModel _ballViewModel;

		private ReactiveProperty<Quaternion> _rotation = new();
		private ReactiveProperty<string> _label = new();

		[Inject]
		public BallAngleViewModel(IBallAngleView angleView, 
			IBallRotationViewModel rotationViewModel,
			IBallViewModel ballViewModel)
		{
			_angleView = angleView;
			_rotationViewModel = rotationViewModel;
			_ballViewModel = ballViewModel;

			Bind();
		}

		private void Bind()
		{
			_ballViewModel.AngleLabel
				.Subscribe(label => _label.Value = label)
				.AddTo(_compositeDisposable);

			_rotationViewModel.Rotation
				.Subscribe(quaternion => _rotation.Value = quaternion)
				.AddTo(_compositeDisposable);

			_rotation
				.Subscribe(rotation => OnViewModelChanged(rotation, _label.Value))
				.AddTo(_compositeDisposable);

			_label
				.Subscribe(label => OnViewModelChanged(_rotation.Value, label))
				.AddTo(_compositeDisposable);
		}

		private void OnViewModelChanged(Quaternion rotation, string label)
		{
			_angleView.Redraw(label, $"{rotation.eulerAngles.y:F1}");
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