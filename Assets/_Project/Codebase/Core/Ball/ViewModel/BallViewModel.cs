using System;
using _Project.Codebase.Core.Ball.View;
using _Project.Codebase.Core.InputProviders;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball.ViewModel
{
    public class BallViewModel: IBallViewModel, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly IBallModel _ballModel;
        private readonly IBallView _ballView;
        private readonly ICustomVelocity _customVelocity;
        private readonly IPointerHandler _pointerHandler;
        private readonly IBallRotationViewModel _rotationViewModel;
        private readonly IBallColorViewModel _colorViewModel;
        private readonly IBallCompressionViewModel _compressionViewModel;
        private readonly IHitEffectView _hitEffectView;

        private ReactiveProperty<Vector3> _velocity = new();
        private ReactiveProperty<string> _speedLabel = new();

        public Vector3 GetPosition => _ballView.Position;
        public IReadOnlyReactiveProperty<Vector3> Velocity => _velocity;
        public IReadOnlyReactiveProperty<string> SpeedLabel => _speedLabel;

        [Inject]
        public BallViewModel(
            IBallModel ballModel,
            IBallView ballView,
            ICustomVelocity customVelocity,
            IPointerHandler pointerHandler,
            IBallRotationViewModel rotationView,
            IBallColorViewModel colorViewModel,
            IBallCompressionViewModel compressionViewModel,
            IHitEffectView hitEffectView)
        {
            _ballModel = ballModel;
            _ballView = ballView;
            _customVelocity = customVelocity;
            _pointerHandler = pointerHandler;
            _rotationViewModel = rotationView;
            _colorViewModel = colorViewModel;
            _compressionViewModel = compressionViewModel;
            _hitEffectView = hitEffectView;

            Bind();
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
            _pointerHandler.PointerUp -= OnPointerUp;
        }

        private void Bind()
        {
            _pointerHandler.PointerUp += OnPointerUp;
            
            _ballModel.Velocity
                .Subscribe(velocity => _velocity.Value = velocity)
                .AddTo(_compositeDisposable);

            _ballModel.SpeedLabel
                .Subscribe(velocityLabel => _speedLabel.Value = velocityLabel)
                .AddTo(_compositeDisposable);
            
            _velocity
                .Subscribe(OnViewModelVelocityChanged)
                .AddTo(_compositeDisposable);
            
            _ballView.VelocityRequested += OnVelocityRequested;
            _ballView.ObjectHit += OnObjectHit;
        }

        private void OnPointerUp()
        {
            Vector3 velocity = _customVelocity
                .GetPushVelocity(_ballView.Position, _pointerHandler.GetWorldPosition());
            _ballModel.Velocity.Value = velocity;
            _rotationViewModel.ChangeDirection(velocity);
        }

        private void OnViewModelVelocityChanged(Vector3 velocity)
        {
            _ballModel.Velocity.Value = velocity;
            _ballView.SetVelocity(_velocity.Value);
        }

        private void OnVelocityRequested(bool isGrounded)
        {
            _velocity.Value = _customVelocity.GetNewVelocity(_velocity.Value, isGrounded);
            _rotationViewModel.Rotate(_velocity.Value);
        }

        private void OnObjectHit(HitInfo hitInfo)
        {
            Vector3 velocity = _customVelocity.GetReflectedVelocity(
                _velocity.Value,
                hitInfo.Normal,
                _ballView.IsGrounded);
            
            _rotationViewModel.ChangeDirection(velocity);
            _ballModel.Velocity.Value = velocity;
            _colorViewModel.CompressAsync();
            _compressionViewModel.CompressAsync();
            _hitEffectView.CreateEffect(hitInfo.Point);
        }
    }

    public interface IBallViewModel
    {
        Vector3 GetPosition { get; }
        IReadOnlyReactiveProperty<Vector3> Velocity { get; }
        IReadOnlyReactiveProperty<string> SpeedLabel { get; }
    }
}