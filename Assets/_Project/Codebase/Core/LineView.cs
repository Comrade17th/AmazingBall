using _Project.Codebase.Core.InputProviders;
using _Project.Codebase.VisualDebug;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Codebase.Core
{
    public class LineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private BallView _ballView; // to DI
        
        private MouseInputProvider _inputProvider;
        
        //private var post = lineRenderer.setpositionCount(0);

        [Inject]
        public void Construct( MouseInputProvider inputProvider) //BallView ballView,
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
                Vector3 pointerPosition = _inputProvider.GetPosition();
                GeometryDebug.DrawSphere(pointerPosition, Color.red);
                
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