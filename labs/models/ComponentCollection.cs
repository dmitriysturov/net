using System;
using System.Collections;
using System.Collections.Generic;

namespace PcTechs.models
{
    public class ComponentCollection<T> : ICollection<T> where T : Component
    {
        private List<T> _components = new List<T>();

        public int Count => _components.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _components.Add(item);
        }

        public void Clear()
        {
            _components.Clear();
        }

        public bool Contains(T item)
        {
            return _components.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _components.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _components.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _components.GetEnumerator();
        }
    }
}
