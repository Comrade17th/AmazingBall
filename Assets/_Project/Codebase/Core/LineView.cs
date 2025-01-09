using _Project.Codebase.Core.InputProviders;
using _Project.Codebase.VisualDebug;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core
{
    public class LineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private BallView _ballView; // to DI
        
        private IInputProvider _inputProvider;
        
        //private var post = lineRenderer.setpositionCount(0);

        [Inject]
        public void Construct(IInputProvider inputProvider) //BallView ballView,
        {
            _inputProvider = inputProvider;
            // _ballView = ballView;
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
                _lineRenderer.SetPosition(lineStartIndex, _ballView.transform.position);
            }
            else
            {
                _lineRenderer.SetPosition(lineEndIndex, _ballView.transform.position);
                _lineRenderer.SetPosition(lineStartIndex, _ballView.transform.position);
            }
        }
        
        
    }
}