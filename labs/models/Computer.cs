using System;

namespace PcTechs.models
{
    public class Computer
    {
        public string Name { get; set; }

        // Обобщённая коллекция для хранения компонентов
        private ComponentCollection<Component> _components = new ComponentCollection<Component>();

        public Computer(string name)
        {
            Name = name;
        }

        // Метод для добавления компонента в сборку
        public void AddComponent(Component component)
        {
            _components.Add(component);
            Console.WriteLine($"{component.Name} добавлен в сборку {Name}");
        }

        // Метод для отображения конфигурации компьютера
        public void ShowComponents()
        {
            Console.WriteLine($"Конфигурация сборки: {Name}");
            if (_components.Count == 0)
            {
                Console.WriteLine("Сборка не содержит компонентов.");
            }
            else
            {
                foreach (var component in _components)
                {
                    component.GetInfo();
                }
            }
        }
    }
}
