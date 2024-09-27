using System;
using System.Xml.Serialization;

namespace PcTechs.models
{
    [XmlInclude(typeof(MotherBoard))]
    [XmlInclude(typeof(GPU))]
    [XmlInclude(typeof(RAM))]
    [XmlInclude(typeof(CPU))]
    [XmlInclude(typeof(PowerSupply))]
    [XmlInclude(typeof(StorageDevice))]
    [XmlInclude(typeof(CoolingSystem))]
    [XmlInclude(typeof(ComputerCase))]
    [XmlInclude(typeof(OutMonitor))]
    public abstract class Component
    {
        [XmlElement("ComponentType")]
        public string? ComponentType { get; set; }

        [XmlElement("Name")]
        public string? Name { get; set; }

        [XmlElement("Cost")]
        public decimal Cost { get; set; }

        [XmlElement("ConnectionType")]
        public string? ConnectionType { get; set; }

        [XmlElement("Manufactor")]
        public string? Manufactor { get; set; }

        public abstract string GetInfo();
    }

    [XmlRoot("MotherBoard")]
    public class MotherBoard : Component
{
    [XmlElement("socket")]
    public string? socket { get; set; }

    [XmlElement("TypeOfSupportedMemory")]
    public string? TypeOfSupportedMemory { get; set; }

    [XmlElement("FormFactor")]
    public string? FormFactor { get; set; }

    [XmlElement("ChipSet")]
    public string? ChipSet { get; set; }

    [XmlElement("MemorySlots")]
    public decimal MemorySlots { get; set; }

    [XmlElement("PCI")]
    public float PCI { get; set; }

    public override string GetInfo()
    {
        string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| socket: {socket}| Memory Type: {TypeOfSupportedMemory}| Form Factor: {FormFactor}| Chipset: {ChipSet}| MSlots: {MemorySlots}| PCI: {PCI}|";
        Console.WriteLine(info);
        return info;
    }
}


    public class GPU : Component
    {
        [XmlElement]
        public string? GraphicalProcessor { get; set; }

        [XmlElement]
        public decimal GMemory { get; set; }

        [XmlElement]
        public decimal BusBitRate { get; set; }

        [XmlElement]
        public string? MemoryType { get; set; }

        [XmlElement]
        public string? ConnectionInterface { get; set; }

        [XmlElement]
        public decimal MonitorsCount { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| Graphical Processor: {GraphicalProcessor}| GMemory: {GMemory}| Bus Bit Rate: {BusBitRate}| Memory Type: {MemoryType}| Connection Interface: {ConnectionInterface}| Monitors Count: {MonitorsCount}|";
            Console.WriteLine(info);
            return info;
        }
    }

    public class RAM : Component
    {
        [XmlElement]
        public decimal VolumeSize { get; set; }

        [XmlElement]
        public decimal frequency { get; set; }

        [XmlElement]
        public bool Radiator { get; set; }

        [XmlElement]
        public float CASLatency { get; set; }

        [XmlElement]
        public decimal Rang { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| Volume Size: {VolumeSize}| frequency: {frequency}| Radiator: {Radiator}| CAS: {CASLatency}| Rang: {Rang}|";
            Console.WriteLine(info);
            return info;
        }
    }

    public class CPU : Component
    {
        [XmlElement]
        public string? socket { get; set; }

        [XmlElement]
        public decimal cores { get; set; }

        [XmlElement]
        public bool IntegratedGPU { get; set; }

        [XmlElement]
        public string? MemoryType { get; set; }

        [XmlElement]
        public decimal frequency { get; set; }

        [XmlElement]
        public decimal TDP { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| socket: {socket}| cores: {cores}| GPU: {IntegratedGPU}| Memory type: {MemoryType}| frequency: {frequency}| TDP: {TDP}|";
            Console.WriteLine(info);
            return info;
        }
    }

    public class PowerSupply : Component
    {
        [XmlElement]
        public decimal PowerOutput { get; set; }

        [XmlElement]
        public string? EfficiencyRating { get; set; }

        [XmlElement]
        public string? FormFactor { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Power Output: {PowerOutput}W| Efficiency Rating: {EfficiencyRating}| Form Factor: {FormFactor}| Connection Type: {ConnectionType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }

    public class StorageDevice : Component
    {
        [XmlElement]
        public decimal Capacity { get; set; }

        [XmlElement]
        public string? Type { get; set; }

        [XmlElement]
        public string? Interface { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Type: {Type}| Capacity: {Capacity}GB| Interface: {Interface}| Connection Type: {ConnectionType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }

    public class CoolingSystem : Component
    {
        [XmlElement]
        public string? CoolingType { get; set; }

        [XmlElement]
        public string? CompatibleSockets { get; set; }

        [XmlElement]
        public decimal NumberOfFans { get; set; }

        [XmlElement]
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
        [XmlElement]
        public string? FormFactor { get; set; }

        [XmlElement]
        public string? Color { get; set; }

        [XmlElement]
        public bool HasWindow { get; set; }

        [XmlElement]
        public decimal NumberOfDriveBays { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Form Factor: {FormFactor}| Color: {Color}| Has Window: {HasWindow}| Number of Drive Bays: {NumberOfDriveBays}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }

    public class OutMonitor : Component
    {
        [XmlElement]
        public decimal Size { get; set; }

        [XmlElement]
        public string? Resolution { get; set; }

        [XmlElement]
        public decimal RefreshRate { get; set; }

        [XmlElement]
        public string? PanelType { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Size: {Size}\"| Resolution: {Resolution}| Refresh Rate: {RefreshRate}Hz| Panel Type: {PanelType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }
}
