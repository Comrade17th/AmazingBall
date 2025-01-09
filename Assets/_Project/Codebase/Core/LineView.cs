using _Project.Codebase.Core.InputProviders;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Codebase.Core
{
    public class LineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private BallView _ballView; // to DI
        
        private MouseInputProvider _inputProvider;// = new (); // to DI
        
        //private var post = lineRenderer.setpositionCount(0);
        
        private void Update()
        {
            int lineEndIndex = 1;
            int lineStartIndex = 0;
            
            if (_inputProvider.GetDetection())
            {
                Vector3 pointerPosition = _inputProvider.GetPosition();
                
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