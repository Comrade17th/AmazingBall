using _Project.Codebase.Core.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Coins
{
    [RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _value = 1;
        
        private CoinCollectEffectFactory _effectFactory;

        [Inject]
        private void Construct(CoinCollectEffectFactory effectFactory) => 
            _effectFactory = effectFactory;

        public int Collect()
        {
            _effectFactory.Create(transform.position);
            return _value;
        }
    }
}