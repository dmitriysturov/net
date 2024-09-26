using System;
using System.Collections.Generic;
using PcTechs.models;

namespace PcTechs.services
{
    public class ComponentsBank
    {
        // Словарь, где ключом будет являться ComponentType
        public static Dictionary<string, List<Component>> ComponentsDictionary { get; set; } = new Dictionary<string, List<Component>>();

        // Метод для добавления компонента в банк с использованием ComponentType
        public static void AddComponentToBank(Component component)
        {
            string? componentType = component.ComponentType;

            if (string.IsNullOrEmpty(componentType))
            {
                Console.WriteLine("Ошибка: тип компонента не указан.");
                return;
            }

            if (!ComponentsDictionary.ContainsKey(componentType))
            {
                ComponentsDictionary[componentType] = new List<Component>();
            }

            ComponentsDictionary[componentType].Add(component);
            Console.WriteLine($"{component.Name} добавлен(а) в банк компонентов как {componentType}.");
        }

        // Метод для отображения всех компонентов в банке по их типам
        public static void DisplayAvailableComponents()
        {
            Console.WriteLine("Доступные компоненты в банке:");

            foreach (var componentType in ComponentsDictionary.Keys)
            {
                Console.WriteLine($"\nТип: {componentType}");
                foreach (var component in ComponentsDictionary[componentType])
                {
                    component.GetInfo();
                }
            }
        }

        // Метод для получения компонентов по типу (ComponentType)
        public static List<Component>? GetComponentsByType(string componentType)
        {
            if (ComponentsDictionary.ContainsKey(componentType))
            {
                return ComponentsDictionary[componentType];
            }

            Console.WriteLine($"Компоненты типа {componentType} не найдены.");
            return null;
        }
    }
}
