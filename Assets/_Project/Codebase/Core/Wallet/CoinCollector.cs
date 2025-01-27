using _Project.Codebase.Core.Coins;
using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Wallet
{
    public class CoinCollector : MonoBehaviour
    {
        private ReactiveProperty<int> _coinCollected = new();
        
        public IReadOnlyReactiveProperty<int> CoinCollected => _coinCollected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                _coinCollected.Value = coin.Collect();
                Destroy(other.gameObject);
            }
        }
    }
}