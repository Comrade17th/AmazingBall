using System;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.InputProviders
{
    public class PointerHandler : MonoBehaviour
    {
        private IInputProvider _inputProvider;
        
        public event Action PointerDown;
        public event Action PointerUp;

        [Inject]
        private void Construct(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        private void Update()
        {
            if (_inputProvider.GetDetectionUp()) 
                PointerUp?.Invoke();
            
            if(_inputProvider.GetDetectionDown())
                PointerDown?.Invoke();
        }
    }
}