/// <summary>
/// 
/// </summary>

using System;
using System.ComponentModel;
using System.Dynamic;
using PcTechs.Interfaces;


namespace PcTechs.models{

    public abstract class Component
    {
        public string? ComponentType { get; set; }
        public string? Name { get; set; }
        public int Cost { get; set; }

        public string? ConnectionType { get; set; }
        public string? Manufactor { get; set; }
        public abstract string GetInfo();
    }


    public class MotherBoard : Component
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string? socket;
        public string? TypeOfSupportedMemory;
        public string? FormFactor;
        public string? ChipSet;
        public int MemorySlots;
        public float PCI;

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| socket: {socket}| Memory Type: {TypeOfSupportedMemory}| Form Factor: {FormFactor}| Chipset: {ChipSet}| MSlots: {MemorySlots}| PCI: {PCI}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class GPU : Component
    {
        /// <summary>
        /// GPU - graphical processing unit
        /// </summary>
        /// <returns></returns>
        public string? GraphicalProcessor { get; set; }
        public int GMemory { get; set; }
        public int BusBitRate { get; set; }
        public string? MemoryType { get; set; }
        public string? ConnectionInterface { get; set; }
        public int MonitorsCount { get; set; }
        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| Graphical Processor: {GraphicalProcessor}| GMemory: {GMemory}| Bus Bit Rate: {BusBitRate}| Memory Type: {MemoryType}| Connection Interface: {ConnectionInterface}| Monitors Count: {MonitorsCount}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class RAM : Component
    {
        /// <summary>
        /// RAM - Random-Access Memory
        /// </summary>
        /// <returns></returns>
        
        public int VolumeSize { get; set; }
        public int Frequency { get; set; }
        public bool Radiator { get; set; }
        public float CASLatency { get; set; }
        public int Rang { get; set; }
        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| Volume Size: {VolumeSize}| Frequency: {Frequency}| Radiator: {Radiator}| CAS {CASLatency}| Rang: {Rang}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class CPU : Component
    {
        /// <summary>
        /// CPU - Central Processing Unit
        /// </summary>
        public string? socket;
        public int cores;
        public bool IntegratedGPU;
        public string? MemoryType;
        public int frequency;
        public int TDP;
        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| Socket: {socket}| Cores: {cores}| GPU: {IntegratedGPU}| Memory type: {MemoryType}| Frequency: {frequency}| TDP: {TDP}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class PowerSupply : Component    
    {
        public int PowerOutput { get; set; } // Мощность в ваттах
        public string? EfficiencyRating { get; set; } // Например, 80+ Gold
        public string? FormFactor { get; set; } // Например, ATX

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Power Output: {PowerOutput}|W Efficiency Rating: {EfficiencyRating}| Form Factor: {FormFactor}| Connection Type: {ConnectionType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class StorageDevice : Component
    {
        public int Capacity { get; set; } // Объем в ГБ
        public string? Type { get; set; } // Например, SSD или HDD
        public string? Interface { get; set; } // Например, SATA, NVMe

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Type: {Type}| Capacity: {Capacity}|GB Interface: {Interface}| Connection Type: {ConnectionType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class CoolingSystem : Component
    {
        public string? CoolingType { get; set; } // Например, Air или Liquid
        public string? CompatibleSockets { get; set; } // Например, LGA1151, AM4
        public int NumberOfFans { get; set; }
        public bool HasRGB { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Cooling Type: {CoolingType}| Compatible Sockets: {CompatibleSockets}| Number of Fans: {NumberOfFans}| Has RGB: {HasRGB}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class ComputerCase : Component
    {
        public string? FormFactor { get; set; } // Например, ATX, MicroATX
        public string? Color { get; set; }
        public bool HasWindow { get; set; }
        public int NumberOfDriveBays { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Form Factor: {FormFactor}| Color: {Color}| Has Window: {HasWindow}| Number of Drive Bays: {NumberOfDriveBays}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }


    public class OutMonitor : Component
    {
        public int Size { get; set; } // Диагональ в дюймах
        public string? Resolution { get; set; } // Например, 1920x1080
        public int RefreshRate { get; set; } // Частота обновления в Гц
        public string? PanelType { get; set; } // Например, IPS, TN, VA

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Size: {Size}\"| Resolution: {Resolution}| Refresh Rate: {RefreshRate}|Hz Panel Type: {PanelType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }
    

}
