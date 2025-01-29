using System;
using _Project.Codebase.Core.Ball;
using _Project.Codebase.Interfaces;
using _Project.Codebase.VisualDebug;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Line
{
    public class LineView : MonoBehaviour
    {
        private const int LineEndIndex = 1;
        private const int LineStartIndex = 0;
        
        [SerializeField] private LineRenderer _lineRenderer;

        private IInputProvider _inputProvider;
        private Vector3 _pointerPosition;
        private Vector3 _ballPosition;
        
        public event Action BallPositionRequested;

        [Inject]
        private void Construct(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        private void Update()
        {
            if (_inputProvider.GetDetection())
            {
                _pointerPosition = _inputProvider.GetPosition(true);
                GeometryDebug.DrawSphere(_pointerPosition, Color.red, radius: 0.2f, seconds: 0.05f);
            }
            
            _lineRenderer.SetPosition(LineEndIndex, _pointerPosition);
            _lineRenderer.SetPosition(LineStartIndex, _ballPosition);
        }

        public void SetBallPositon(Vector3 position) => 
            _ballPosition = position;
    }
}