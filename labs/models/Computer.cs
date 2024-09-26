using System;
using System.Collections.Generic;

namespace PcTechs.models
{
    public class Computer
    {
        public string? Name { get; set; }


        // Поля для хранения компонентов сборки
        public MotherBoard? Motherboard { get; set; }
        public CPU? Processor { get; set; }
        public RAM? Memory { get; set; }
        public GPU? GraphicsCard { get; set; }
        public StorageDevice? Storage { get; set; }
        public PowerSupply? PowerSupply { get; set; }
        public CoolingSystem? Cooling { get; set; }
        public ComputerCase? Case { get; set; }
        public OutMonitor? Display { get; set; }

        public Computer(string name)
        {
            Name = name;
        }

        // Метод для добавления компонента к сборке компьютера
        public void AddComponent(Component component)
        {
            switch (component)
            {
                case MotherBoard mb:
                    Motherboard = mb;
                    break;
                case CPU cpu:
                    Processor = cpu;
                    break;
                case RAM ram:
                    Memory = ram;
                    break;
                case GPU gpu:
                    GraphicsCard = gpu;
                    break;
                case StorageDevice storage:
                    Storage = storage;
                    break;
                case PowerSupply psu:
                    PowerSupply = psu;
                    break;
                case CoolingSystem cooling:
                    Cooling = cooling;
                    break;
                case ComputerCase pcCase:
                    Case = pcCase;
                    break;
                case OutMonitor OutMonitor:
                    Display = OutMonitor;
                    break;
                default:
                    Console.WriteLine("Этот компонент не поддерживается в сборке компьютера.");
                    break;
            }
        }

        // Метод для отображения конфигурации сборки компьютера
        public void DisplayConfiguration()
        {
            Console.WriteLine($"Сборка: {Name}");
            Motherboard?.GetInfo();
            Processor?.GetInfo();
            Memory?.GetInfo();
            GraphicsCard?.GetInfo();
            Storage?.GetInfo();
            PowerSupply?.GetInfo();
            Cooling?.GetInfo();
            Case?.GetInfo();
            Display?.GetInfo();
        }
    }
}
