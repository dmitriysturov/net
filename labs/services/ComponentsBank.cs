using System;
using System.Collections.Generic;
using PcTechs.models;

namespace PcTechs.services
{
    public class ComponentsBank
    {
        
        public static Dictionary<string, List<Component>> ComponentsDictionary { get; set; } = new Dictionary<string, List<Component>>();

        
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

        
        public static List<Component>? GetComponentsByType(string componentType)
        {
            if (ComponentsDictionary.ContainsKey(componentType))
            {
                return ComponentsDictionary[componentType];
            }
            Console.WriteLine($"Компоненты типа {componentType} не найдены.");
            return null;
        }


        public static void AddComponentToBank(string componentType, Component component)
        {
            if (!ComponentsDictionary.ContainsKey(componentType))
            {
                ComponentsDictionary[componentType] = new List<Component>();
            }
            ComponentsDictionary[componentType].Add(component);
        }

        public static ComponentCollection<Component> GetAllComponents()
        {
            var allComponents = new ComponentCollection<Component>();
            foreach (var componentList in ComponentsDictionary.Values)
            {
                foreach (var component in componentList)
                {
                    allComponents.Add(component);
                }
            }
            return allComponents;
        }

    }
}
