using System.Collections.Generic;
using _Project.Codebase.Core.Spawnable;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Factories
{
    public class VFXFactory : Factory //<EffectBase> where EffectBase : MonoBehaviour
    {
        private readonly EffectBase _prefab;
        private Pool<EffectBase> _pool;
        private readonly int _size;
        
        [Inject]
        public VFXFactory(EffectBase prefab, int size)
        {
            Init(prefab, size);
        }

        private void Init(EffectBase prefab, int size)
        {
            List<EffectBase> instances = new List<EffectBase>();

            for (int i = 0; i < size; i++)
            {
                EffectBase intance = GameObject.Instantiate(prefab);
                intance.gameObject.SetActive(false);
                instances.Add(intance);
            }
            
            _pool = new Pool<EffectBase>(instances);
        }

        public EffectBase Create(Vector3 at)
        {
            EffectBase instance = _pool.Get();
            instance.transform.position = at;
            instance.gameObject.SetActive(true);
            return instance;
        }

        public override MonoBehaviour Create()
        {
            throw new System.NotImplementedException();
        }
    }
}