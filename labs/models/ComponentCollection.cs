using System.Collections;
using PcTechs.logs;
using PcTechs.dataspace;
using PcTechs.Interfaces;


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

        // Сортировка компонентов с использованием делегатов (lab 3)
        public void SortComponents(Func<T, T, int> comparison)
        {
            _components.Sort(new Comparison<T>(comparison));
        }

        // Применение действия к каждому компоненту
        public void ForEachComponent(Action<T> action)
        {
            foreach (var component in _components)
            {
                action(component);
            }
        }

        // Асинхронная сортировка с логированием (новое)
        public async Task SortComponentsAsync(Comparison<T> comparison, Action<int> onElementProcessed, Logger<string> logger)
        {
            logger.Log("Запуск асинхронной сортировки...");

            await Task.Run(() =>
            {
                int count = 0;
                _components.Sort((x, y) =>
                {
                    count++;
                    onElementProcessed(count);
                    return comparison(x, y);
                });

                logger.Log($"Сортировка завершена. Обработано {count} элементов.");
            });
        }

        public string Serialize(ISerializer<List<T>> serializer)
        {
            return serializer.Serialize(_components);
        }

        public void Deserialize(string data, ISerializer<List<T>> serializer)
        {
            List<T>? deserializedComponents = serializer.Deserialize(data);
            if (deserializedComponents != null)
            {
                _components = deserializedComponents;
            }
        }

        public void SaveToFile(string filePath, ISerializer<List<T>> serializer)
        {
            serializer.SerializeToFile(_components, filePath);
        }

        public void LoadFromFile(string filePath, ISerializer<List<T>> serializer)
        {
            _components = serializer.DeserializeFromFile(filePath);
        }

    }
}
