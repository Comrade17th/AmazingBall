using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.General
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        private ReactiveProperty<Collider> _triggerEntered = new();
        private ReactiveProperty<Collider> _triggerExited = new();
        
        public IReadOnlyReactiveProperty<Collider> TriggerEntered => _triggerEntered;
        public IReadOnlyReactiveProperty<Collider> TriggerExited => _triggerExited;
        
        private void OnTriggerEnter(Collider other) => 
            _triggerEntered.Value = other;

        private void OnTriggerExit(Collider other) => 
            _triggerExited.Value = other;
    }    
}
