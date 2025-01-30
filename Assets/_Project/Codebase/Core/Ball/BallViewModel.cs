using System;
using _Project.Codebase.Core.InputProviders;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallViewModel: IBallViewModel, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly IBallModel _ballModel;
        private readonly IBallView _ballView;
        private readonly ICustomVelocity _customVelocity;
        private readonly IPointerHandler _pointerHandler;
        
        private ReactiveProperty<Vector3> _velocity = new();

        public Vector3 GetPosition => _ballView.Position;

        [Inject]
        public BallViewModel(
            IBallModel ballModel,
            IBallView ballView,
            ICustomVelocity customVelocity,
            IPointerHandler pointerHandler)
        {
            _ballModel = ballModel;
            _ballView = ballView;
            _customVelocity = customVelocity;
            _pointerHandler = pointerHandler;
    
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
            
            _velocity
                .Subscribe(OnViewModelVelocityChanged)
                .AddTo(_compositeDisposable);
            
            _ballView.VelocityRequested += OnVelocityRequested;
            _ballView.ObjectHit += OnObjectHit;
        }

        private void OnPointerUp()
        {
            _ballModel.Velocity.Value = _customVelocity
                .GetPushVelocity(_ballView.Position, _pointerHandler.GetWorldPosition());
        }

        private void OnViewModelVelocityChanged(Vector3 velocity)
        {
            _ballModel.Velocity.Value = velocity;
            _ballView.SetVelocity(_velocity.Value);
        }

        private void OnVelocityRequested(bool isGrounded) => 
            _velocity.Value = _customVelocity.GetNewVelocity(_velocity.Value, isGrounded);

        private void OnObjectHit(HitInfo hitInfo)
        {
            Vector3 velocity = _customVelocity.GetReflectedVelocity(
                _velocity.Value,
                hitInfo.Normal,
                _ballView.IsGrounded);
            _ballModel.Velocity.Value = velocity;
        }
    }

    public interface IBallViewModel
    {
        Vector3 GetPosition { get; }
    }
}