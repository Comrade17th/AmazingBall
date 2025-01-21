using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Factories
{
    public class VFXFactory<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private Pool<T> _pool;
        private readonly int _size;
        
        [Inject]
        public VFXFactory(T prefab, int size)
        {
            Init(prefab, size);
        }

        private void Init(T prefab, int size)
        {
            List<T> instances = new List<T>();

            for (int i = 0; i < size; i++)
            {
                T intance = GameObject.Instantiate(prefab);
                intance.gameObject.SetActive(false);
                instances.Add(intance);
            }
            
            _pool = new Pool<T>(instances);
        }

        public T Create(Vector3 at)
        {
            T instance = _pool.Get();
            _pool.Release(instance);
            instance.transform.position = at;
            return instance;
        }
    }
}