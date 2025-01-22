using System.Collections.Generic;
using _Project.Codebase.Core.Spawnable;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Factories
{
    public class VFXFactory
    {
        private readonly Pool<EffectBase> _pool;
        private readonly EffectBase _prefab;

        protected VFXFactory(EffectBase prefab, int size = 3)
        {
            _prefab = prefab;
            _pool = new Pool<EffectBase>(InstantiateEffects(size));
        }

        public EffectBase Create(Vector3 at)
        {
            EffectBase effect = _pool.Get();
            effect.transform.position = at;
            effect.gameObject.SetActive(true);
            effect.Restart();
            
            return effect;
        }

        private List<EffectBase> InstantiateEffects(int size)
        {
            List<EffectBase> effects = new();

            for (int i = 0; i < size; i++)
            {
                EffectBase effect = GameObject.Instantiate(_prefab);
                effects.Add(effect);
            }
            
            return effects;
        }
    }
}