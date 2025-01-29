using System;
using _Project.Codebase.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _Project.Codebase.Core.InputProviders
{
    public class MousePointerHandler : IPointerHandler, IPointerDownHandler, IPointerUpHandler
    {
        private IInputProvider _inputProvider;
        
        public event Action PointerDown;
        public event Action PointerUp;

        [Inject]
        private void Construct(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }
    }

    public interface IPointerHandler
    {
        event Action PointerDown;
        event Action PointerUp;
    }
}