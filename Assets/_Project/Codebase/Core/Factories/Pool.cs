using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Core.Factories
{
    public class Pool<T> where T : MonoBehaviour
    {
        //private readonly List<T> _templates = new();
        private readonly Queue<T> _queue;
        
        public Pool(List<T> templates) => 
            _queue = new Queue<T>(templates);

        public void Release(T template) => 
            _queue.Enqueue(template);

        public T Get()
        {
            if (_queue.TryDequeue(out T template) == false)
            {
                throw new Exception("No template available in pool");
            }
            
            template = _queue.Dequeue();
            return template;
        }
    }
}
