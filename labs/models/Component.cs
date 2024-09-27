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

    [XmlRoot("GPU")]
    public class GPU : Component
    {
        [XmlElement("GraphicalProcessor")]
        public string? GraphicalProcessor { get; set; }

        [XmlElement("GMemory")]
        public decimal GMemory { get; set; }

        [XmlElement("BusBitRate")]
        public decimal BusBitRate { get; set; }

        [XmlElement("MemoryType")]
        public string? MemoryType { get; set; }

        [XmlElement("ConnectionInterface")]
        public string? ConnectionInterface { get; set; }

        [XmlElement("MonitorsCount")]
        public decimal MonitorsCount { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| Graphical Processor: {GraphicalProcessor}| GMemory: {GMemory}| Bus Bit Rate: {BusBitRate}| Memory Type: {MemoryType}| Connection Interface: {ConnectionInterface}| Monitors Count: {MonitorsCount}|";
            Console.WriteLine(info);
            return info;
        }
    }

    [XmlRoot("RAM")]
    public class RAM : Component
    {
        [XmlElement("VolumeSize")]
        public decimal VolumeSize { get; set; }

        [XmlElement("frequency")]
        public decimal frequency { get; set; }

        [XmlElement("Radiator")]
        public bool Radiator { get; set; }

        [XmlElement("CASLatency")]
        public float CASLatency { get; set; }

        [XmlElement("Rang")]
        public decimal Rang { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| Volume Size: {VolumeSize}| frequency: {frequency}| Radiator: {Radiator}| CAS: {CASLatency}| Rang: {Rang}|";
            Console.WriteLine(info);
            return info;
        }
    }

    [XmlRoot("CPU")]
    public class CPU : Component
    {
        [XmlElement("socket")]
        public string? socket { get; set; }

        [XmlElement("cores")]
        public decimal cores { get; set; }

        [XmlElement("IntegratedGPU")]
        public bool IntegratedGPU { get; set; }

        [XmlElement("MemoryType")]
        public string? MemoryType { get; set; }

        [XmlElement("frequency")]
        public decimal frequency { get; set; }

        [XmlElement("TDP")]
        public decimal TDP { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Connection Type: {ConnectionType}| Manufactor: {Manufactor}| socket: {socket}| cores: {cores}| GPU: {IntegratedGPU}| Memory type: {MemoryType}| frequency: {frequency}| TDP: {TDP}|";
            Console.WriteLine(info);
            return info;
        }
    }

    [XmlRoot("PowerSupply")]
    public class PowerSupply : Component
    {
        [XmlElement("PowerOutput")]
        public decimal PowerOutput { get; set; }

        [XmlElement("EfficiencyRaiting")]
        public string? EfficiencyRating { get; set; }

        [XmlElement("FormFactor")]
        public string? FormFactor { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Power Output: {PowerOutput}W| Efficiency Rating: {EfficiencyRating}| Form Factor: {FormFactor}| Connection Type: {ConnectionType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }

    [XmlRoot("StorageDevice")]
    public class StorageDevice : Component
    {
        [XmlElement("Capacity")]
        public decimal Capacity { get; set; }

        [XmlElement("Type")]
        public string? Type { get; set; }

        [XmlElement("Interface")]
        public string? Interface { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Type: {Type}| Capacity: {Capacity}GB| Interface: {Interface}| Connection Type: {ConnectionType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }

    [XmlRoot("CoolingSystem")]
    public class CoolingSystem : Component
    {
        [XmlElement("CoolingType")]
        public string? CoolingType { get; set; }

        [XmlElement("CompatibleSockets")]
        public string? CompatibleSockets { get; set; }

        [XmlElement("NumberOfFans")]
        public decimal NumberOfFans { get; set; }

        [XmlElement("HasRGB")]
        public bool HasRGB { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Cooling Type: {CoolingType}| Compatible Sockets: {CompatibleSockets}| Number of Fans: {NumberOfFans}| Has RGB: {HasRGB}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }

    [XmlRoot("ComputerCase")]
    public class ComputerCase : Component
    {
        [XmlElement("FormFactor")]
        public string? FormFactor { get; set; }

        [XmlElement("Color")]
        public string? Color { get; set; }

        [XmlElement("HasWindow")]
        public bool HasWindow { get; set; }

        [XmlElement("NumberOfDriveBays")]
        public decimal NumberOfDriveBays { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Form Factor: {FormFactor}| Color: {Color}| Has Window: {HasWindow}| Number of Drive Bays: {NumberOfDriveBays}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }

    [XmlRoot("OutMonitor")]
    public class OutMonitor : Component
    {
        [XmlElement("Size")]
        public decimal Size { get; set; }

        [XmlElement("Resolution")]
        public string? Resolution { get; set; }

        [XmlElement("RefreshRate")]
        public decimal RefreshRate { get; set; }

        [XmlElement("PanelType")]
        public string? PanelType { get; set; }

        public override string GetInfo()
        {
            string info = $"Type: {ComponentType}| Name: {Name}| Cost: {Cost}| Size: {Size}\"| Resolution: {Resolution}| Refresh Rate: {RefreshRate}Hz| Panel Type: {PanelType}| Manufacturer: {Manufactor}|";
            Console.WriteLine(info);
            return info;
        }
    }
}
