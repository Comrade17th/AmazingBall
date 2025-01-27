using System.Collections.Generic;
using _Project.Codebase.Core.Spawnable;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Factories
{
    public class CoinCollectEffectFactory
    {
        private readonly Pool<CoinVFX> _pool;
        private readonly CoinVFX _prefab;

        [Inject]
        public CoinCollectEffectFactory(CoinVFX prefab, int size = 3)
        {
            _prefab = prefab;
            _pool = new Pool<CoinVFX>(InstantiateEffects(size));
        }

        public CoinVFX Create(Vector3 at)
        {
            CoinVFX effect = _pool.Get();
            effect.transform.position = at;
            effect.gameObject.SetActive(true);
            effect.Restart();
            
            return effect;
        }

        private List<CoinVFX> InstantiateEffects(int size)
        {
            List<CoinVFX> effects = new();

            for (int i = 0; i < size; i++)
            {
                CoinVFX effect = GameObject.Instantiate(_prefab);
                effects.Add(effect);
            }
            
            return effects;
        }
    }
}