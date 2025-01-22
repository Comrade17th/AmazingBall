using System.Collections.Generic;
using _Project.Codebase.Core.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Factories
{
    public class HitEffectFactory
    {
        private readonly Pool<HitVFX> _pool;
        private readonly HitVFX _prefab;

        [Inject]
        public HitEffectFactory(HitVFX prefab, int size = 3)
        {
            _prefab = prefab;
            _pool = new Pool<HitVFX>(InstantiateEffects(size));
        }

        public HitVFX Create(Vector3 at)
        {
            HitVFX effect = _pool.Get();
            effect.transform.position = at;
            effect.gameObject.SetActive(true);
            effect.Restart();
            
            return effect;
        }

        private List<HitVFX> InstantiateEffects(int size)
        {
            List<HitVFX> effects = new();

            for (int i = 0; i < size; i++)
            {
                HitVFX effect = GameObject.Instantiate(_prefab);
                effects.Add(effect);
            }
            
            return effects;
        }
    }
}