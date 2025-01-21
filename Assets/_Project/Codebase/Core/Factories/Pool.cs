using System.Collections.Generic;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Factories
{
    public class Pool<T> where T : MonoBehaviour//, IPoolableCustom<>
    {
        private readonly List<T> _templates = new();
        private readonly T _prefab;
        private Queue<T> _queue = new();
        
        public Pool(List<T> templates)
        {
            foreach (T template in templates)
            {
                _queue.Enqueue(template);
            }
            
        }
        
        
	    
        public void Release(T template)
        {
            _queue.Enqueue(template);
        }
	    
        public T Get()
        {
            if (_queue.TryDequeue(out T template) == false)
            {
                template = _queue.Dequeue();
            }
		    
            return template;
        }
    }

    
}
