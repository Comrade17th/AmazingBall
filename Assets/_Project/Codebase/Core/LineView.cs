using _Project.Codebase.Core.Ball;
using _Project.Codebase.Interfaces;
using _Project.Codebase.VisualDebug;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core
{
    public class LineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        
        private IReadOnlyBallTransform ballTransform;
        private IInputProvider _inputProvider;

        [Inject]
        public void Construct(IInputProvider inputProvider, IReadOnlyBallTransform ballView)
        {
            _inputProvider = inputProvider;
            ballTransform = ballView;
        }

        private void Update()
        {
            int lineEndIndex = 1;
            int lineStartIndex = 0;
            
            if (_inputProvider.GetDetection())
            {
                Vector3 pointerPosition = _inputProvider.GetPosition(true);
                GeometryDebug.DrawSphere(pointerPosition, Color.red, radius: 0.2f, seconds: 0.05f);
                
                _lineRenderer.SetPosition(lineEndIndex, pointerPosition);
                _lineRenderer.SetPosition(lineStartIndex, ballTransform.Position);
            }
            else
            {
                _lineRenderer.SetPosition(lineEndIndex, ballTransform.Position);
                _lineRenderer.SetPosition(lineStartIndex, ballTransform.Position);
            }
        }
    }
}