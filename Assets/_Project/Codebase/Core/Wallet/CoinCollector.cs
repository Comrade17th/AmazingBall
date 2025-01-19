using _Project.Codebase.Core.Entities;
using _Project.Codebase.Core.General;
using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Wallet
{
    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private CompositeDisposable _disposable;
        private ReactiveProperty<Coin> _coinCollected;
        
        public IReadOnlyReactiveProperty<Coin> CoinCollected => _coinCollected;

        private void Awake()
        {
            _disposable = new CompositeDisposable();
            _coinCollected = new ReactiveProperty<Coin>();
            
            _triggerObserver.TriggerEntered
                .Subscribe(collider  => OnTriggerEnetered(collider))
                .AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
            _disposable.Clear();
        }

        private void OnTriggerEnetered(Collider other)
        {
            Debug.Log($"{other == null}");
            
            if (other.TryGetComponent(out Coin coin)) 
                _coinCollected.Value = coin;
        }
    }
}