using System;
using _Project.Codebase.Core.Ball;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Line
{
    public class LineViewModel: IDisposable, ILineViewModel
    {
        private readonly ILineView _view;
        private readonly IBallViewModel _ballViewModel;

        [Inject]
        public LineViewModel(ILineView view, IBallViewModel ballViewModel)
        {
            _view = view;
            _ballViewModel = ballViewModel;
            _view.BallPositionRequested += OnBallPositionRequested;
        }

        public void Dispose() => 
            _view.BallPositionRequested -= OnBallPositionRequested;

        private void OnBallPositionRequested()
        {
            _view.SetBallPosition(_ballViewModel.GetPosition);
        }
    }

    public interface ILineViewModel
    {
    }
}