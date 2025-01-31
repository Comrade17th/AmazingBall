using System;
using _Project.Codebase.Core.Ball.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball.ViewModel
{
	public class BallSpeedViewModel : IBallSpeedViewModel, IDisposable
	{
		private readonly CompositeDisposable _compositeDisposable = new();
		private readonly IBallSpeedView _velocityView;
		private readonly IBallViewModel _ballViewModel;

		private ReactiveProperty<string> _label = new();
		private ReactiveProperty<Vector3> _velocity = new();

		[Inject]
		public BallSpeedViewModel(IBallSpeedView velocityView, IBallViewModel ballViewModel)
		{
			_velocityView = velocityView;
			_ballViewModel = ballViewModel;

			Bind();
		}
		
		public void Dispose() =>
			_compositeDisposable?.Dispose();

		private void Bind()
		{
			_ballViewModel.Velocity
				.Subscribe(velocity => _velocity.Value = velocity)
				.AddTo(_compositeDisposable);
			
			_ballViewModel.SpeedLabel
				.Subscribe(label => _label.Value = label)
				.AddTo(_compositeDisposable);

			_label
				.Subscribe(_ => OnBallViewModelChanged())
				.AddTo(_compositeDisposable);
			
			_velocity
				.Subscribe(_ => OnBallViewModelChanged())
				.AddTo(_compositeDisposable);
		}

		private void OnBallViewModelChanged() =>
			_velocityView.Redraw(_label.Value, $"{VelocityToSpeed(_velocity.Value):F1}");

		private float VelocityToSpeed(Vector3 velocity) // https://avatars.mds.yandex.net/i?id=5e90ac5c3dfcbae0f0ef4e8ee627e708_l-4275030-images-thumbs&n=13
		{
			Vector3 v = velocity;
			return Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
		}
	}

	public interface IBallSpeedViewModel
	{
	}
}