using System;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Line
{
    
    [RequireComponent(typeof(LineRenderer))]
    public class LineView : MonoBehaviour, ILineView
    {
        private const int LineStartIndex = 0;
        private const int LineEndIndex = 1;

        private LineRenderer _lineRenderer;
        private IInputProvider _inputProvider;
        private Vector3 _pointerPosition;
        private Vector3 _ballPosition;
        
        public event Action BallPositionRequested;

        [Inject]
        private void Construct(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            BallPositionRequested?.Invoke();
            
            if (_inputProvider.GetDetection())
            {
                _pointerPosition = _inputProvider.GetPosition(true);
                _lineRenderer.SetPosition(LineEndIndex, _pointerPosition);
            }
            else
            {
                _lineRenderer.SetPosition(LineEndIndex, _ballPosition);
            }
            
            _lineRenderer.SetPosition(LineStartIndex, _ballPosition);
        }

        public void SetBallPosition(Vector3 position) => 
            _ballPosition = position;
    }

    public interface ILineView
    {
        event Action BallPositionRequested;
        void SetBallPosition(Vector3 position);
    }
}