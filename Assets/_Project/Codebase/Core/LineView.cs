using _Project.Codebase.Core.InputProviders;
using UnityEngine;

namespace _Project.Codebase.Core
{
    public class LineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        
        private MouseInputProvider _inputProvider = new ();
        
        private void Update()
        {
            
        }
        
        
    }
}