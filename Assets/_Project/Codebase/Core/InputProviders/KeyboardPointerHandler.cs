using System;
using _Project.Codebase.Interfaces;
using UnityEngine;

namespace _Project.Codebase.Core.InputProviders
{
    public class KeyboardPointerHandler: MonoBehaviour, IPointerHandler
    {
        private IInputProvider _inputProvider; // concrete to keyboard provider
        public event Action PointerDown;
        public event Action PointerUp;
        
        private void Update()
        {
            if (_inputProvider.GetDetectionUp()) 
                PointerUp?.Invoke();
            
            if(_inputProvider.GetDetectionDown())
                PointerDown?.Invoke();
        }
    }
}