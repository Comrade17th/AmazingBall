using System;
using _Project.Codebase.Core.Entities;
using _Project.Codebase.Core.General;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Wallet
{
    public class CoinCollector : MonoBehaviour
    {
        //[SerializeField] private TriggerObserver _triggerObserver;
        
        private ReactiveProperty<int> _coinCollected = new();
        
        public IReadOnlyReactiveProperty<int> CoinCollected => _coinCollected;

        private void Awake()
        {
            // _disposable = new CompositeDisposable();
            // _coinCollected = new ReactiveProperty<Coin>();
            
           
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                _coinCollected.Value = coin.Value;
                Destroy(other.gameObject);
            }
        }
    }
}