using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Core.Factories
{
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> _queue;
        
        public Pool(List<T> templates)
        {
            _queue = new Queue<T>(templates);
            Debug.Log($"init {_queue.Count}");
        }

        public void Release(T template)
        {
            _queue.Enqueue(template);
        }

        public T Get()
        {
            if (_queue.TryDequeue(out T template) == false)
                throw new Exception("No template available in pool");
            
            _queue.Enqueue(template);
            return template;
        }
    }
}
