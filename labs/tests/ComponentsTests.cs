using PcTechs.models;
using PcTechs.services;
using System;
using PcTechs.UI;

namespace PcTechs.tests
{
    public static class ComponentTestData
    {
        
        public static void AddTestComponents()
        {
            
            ComponentsBank.AddComponentToBank(new MotherBoard
            {
                ComponentType = "Материнская плата",
                Name = "ASUS ROG Strix B550-F",
                Cost = 150,
                ConnectionType = "Внутренний",
                Manufactor = "ASUS",
                socket = "AM4",
                TypeOfSupportedMemory = "DDR4",
                FormFactor = "ATX",
                ChipSet = "B550",
                MemorySlots = 4,
                PCI = 4.0f
            });

            
            ComponentsBank.AddComponentToBank(new GPU
            {
                ComponentType = "Видеокарта",
                Name = "NVIDIA RTX 3080",
                Cost = 800,
                ConnectionType = "Внутренний",
                Manufactor = "NVIDIA",
                GraphicalProcessor = "RTX 3080",
                GMemory = 10240,
                BusBitRate = 320,
                MemoryType = "GDDR6X",
                ConnectionInterface = "PCI-E",
                MonitorsCount = 4
            });

         
            ComponentsBank.AddComponentToBank(new CPU
            {
                ComponentType = "Процессор",
                Name = "AMD Ryzen 7 5800X",
                Cost = 450,
                ConnectionType = "Внутренний",
                Manufactor = "AMD",
                socket = "AM4",
                cores = 8,
                IntegratedGPU = false,
                MemoryType = "DDR4",
                frequency = 3800,
                TDP = 105
            });

           
            ComponentsBank.AddComponentToBank(new RAM
            {
                ComponentType = "Оперативная память",
                Name = "Corsair Vengeance LPX 16GB",
                Cost = 90,
                ConnectionType = "Внутренний",
                Manufactor = "Corsair",
                VolumeSize = 16,
                frequency = 3200,
                Radiator = true,
                CASLatency = 16,
                Rang = 2
            });

            
            ComponentsBank.AddComponentToBank(new PowerSupply
            {
                ComponentType = "Блок питания",
                Name = "Corsair RM850x",
                Cost = 130,
                ConnectionType = "Внутренний",
                Manufactor = "Corsair",
                PowerOutput = 850,
                EfficiencyRating = "80+ Gold",
                FormFactor = "ATX"
            });

            
            ComponentsBank.AddComponentToBank(new SSD
            {
                ComponentType = "Накопитель",
                Name = "Samsung 970 EVO 1TB",
                Cost = 150,
                ConnectionType = "Внутренний",
                Manufactor = "Samsung",
                Capacity = 1024,
                NANDType = "TLC",
                SupportsNVMe = true,
                Interface = "NVMe"
            });

           
            ComponentsBank.AddComponentToBank(new HDD
            {
                ComponentType = "Накопитель",
                Name = "Seagate Barracuda 2TB",
                Cost = 60,
                ConnectionType = "Внутренний",
                Manufactor = "Seagate",
                Capacity = 2048,
                RPM = 7200,
                Interface = "SATA"
            });

            
            ComponentsBank.AddComponentToBank(new LiquidCooling
            {
                ComponentType = "Система охлаждения",
                Name = "NZXT Kraken X63",
                Cost = 180,
                ConnectionType = "Внутренний",
                Manufactor = "NZXT",
                CoolingType = "Жидкостное",
                RadiatorSize = 280,
                HasRGB = true,
                CompatibleSockets = "AM4, LGA1200"
            });

            
            ComponentsBank.AddComponentToBank(new AirCooling
            {
                ComponentType = "Система охлаждения",
                Name = "Cooler Master Hyper 212",
                Cost = 40,
                ConnectionType = "Внутренний",
                Manufactor = "Cooler Master",
                CoolingType = "Воздушное",
                FanSize = 120,
                HasRGB = false,
                CompatibleSockets = "AM4, LGA1200"
            });

            
            ComponentsBank.AddComponentToBank(new ComputerCase
            {
                ComponentType = "Корпус",
                Name = "NZXT H510",
                Cost = 80,
                ConnectionType = "Внутренний",
                Manufactor = "NZXT",
                FormFactor = "ATX",
                Color = "Черный",
                HasWindow = true,
                NumberOfDriveBays = 2
            });

            
            ComponentsBank.AddComponentToBank(new OutMonitor
            {
                ComponentType = "Монитор",
                Name = "Dell Ultrasharp U2719D",
                Cost = 400,
                ConnectionType = "Внешний",
                Manufactor = "Dell",
                Size = 27,
                Resolution = "2560x1440",
                RefreshRate = 60,
                PanelType = "IPS"
            });

            
            ComponentsBank.AddComponentToBank(new MotherBoard
            {
                ComponentType = "Материнская плата",
                Name = "MSI MPG Z490 Gaming Edge",
                Cost = 180,
                ConnectionType = "Внутренний",
                Manufactor = "MSI",
                socket = "LGA1200",
                TypeOfSupportedMemory = "DDR4",
                FormFactor = "ATX",
                ChipSet = "Z490",
                MemorySlots = 4,
                PCI = 4.0f
            });

            ComponentsBank.AddComponentToBank(new GPU
            {
                ComponentType = "Видеокарта",
                Name = "AMD Radeon RX 6800 XT",
                Cost = 700,
                ConnectionType = "Внутренний",
                Manufactor = "AMD",
                GraphicalProcessor = "RX 6800 XT",
                GMemory = 16384,
                BusBitRate = 256,
                MemoryType = "GDDR6",
                ConnectionInterface = "PCI-E",
                MonitorsCount = 4
            });

            ComponentsBank.AddComponentToBank(new CPU
            {
                ComponentType = "Процессор",
                Name = "Intel Core i7-10700K",
                Cost = 400,
                ConnectionType = "Внутренний",
                Manufactor = "Intel",
                socket = "LGA1200",
                cores = 8,
                IntegratedGPU = true,
                MemoryType = "DDR4",
                frequency = 3800,
                TDP = 125
            });

            
            ComponentsBank.AddComponentToBank(new OutMonitor
            {
                ComponentType = "Монитор",
                Name = "Acer Predator X27",
                Cost = 1800,
                ConnectionType = "Внешний",
                Manufactor = "Acer",
                Size = 27,
                Resolution = "3840x2160",
                RefreshRate = 144,
                PanelType = "IPS"
            });

          
            ComponentsBank.AddComponentToBank(new RAM
            {
                ComponentType = "Оперативная память",
                Name = "G.SKILL Trident Z RGB 32GB",
                Cost = 200,
                ConnectionType = "Внутренний",
                Manufactor = "G.SKILL",
                VolumeSize = 32,
                frequency = 3600,
                Radiator = true,
                CASLatency = 16,
                Rang = 2
            });

           
            ComponentsBank.AddComponentToBank(new PowerSupply
            {
                ComponentType = "Блок питания",
                Name = "EVGA SuperNOVA 1000 G3",
                Cost = 160,
                ConnectionType = "Внутренний",
                Manufactor = "EVGA",
                PowerOutput = 1000,
                EfficiencyRating = "80+ Gold",
                FormFactor = "ATX"
            });

           
            ComponentsBank.AddComponentToBank(new MotherBoard
            {
                ComponentType = "Материнская плата",
                Name = "Gigabyte X570 AORUS Elite",
                Cost = 180,
                ConnectionType = "Внутренний",
                Manufactor = "Gigabyte",
                socket = "AM4",
                TypeOfSupportedMemory = "DDR4",
                FormFactor = "ATX",
                ChipSet = "X570",
                MemorySlots = 4,
                PCI = 4.0f
            });

           
            ComponentsBank.AddComponentToBank(new SSD
            {
                ComponentType = "Накопитель",
                Name = "Crucial MX500 1TB",
                Cost = 120,
                ConnectionType = "Внутренний",
                Manufactor = "Crucial",
                Capacity = 1024,
                NANDType = "TLC",
                SupportsNVMe = false,
                Interface = "SATA"
            });

            
            ComponentsBank.AddComponentToBank(new AirCooling
            {
                ComponentType = "Система охлаждения",
                Name = "Noctua NH-D15",
                Cost = 90,
                ConnectionType = "Внутренний",
                Manufactor = "Noctua",
                CoolingType = "Воздушное",
                FanSize = 140,
                HasRGB = false,
                CompatibleSockets = "AM4, LGA1151"
            });

            
            ComponentsBank.AddComponentToBank(new CPU
            {
                ComponentType = "Процессор",
                Name = "Intel Core i9-10900K",
                Cost = 500,
                ConnectionType = "Внутренний",
                Manufactor = "Intel",
                socket = "LGA1200",
                cores = 10,
                IntegratedGPU = true,
                MemoryType = "DDR4",
                frequency = 3700,
                TDP = 125
            });

            
            ComponentsBank.AddComponentToBank(new GPU
            {
                ComponentType = "Видеокарта",
                Name = "AMD Radeon RX 6900 XT",
                Cost = 1000,
                ConnectionType = "Внутренний",
                Manufactor = "AMD",
                GraphicalProcessor = "RX 6900 XT",
                GMemory = 16384,
                BusBitRate = 256,
                MemoryType = "GDDR6",
                ConnectionInterface = "PCI-E",
                MonitorsCount = 4
            });

           
            ComponentsBank.AddComponentToBank(new HDD
            {
                ComponentType = "Накопитель",
                Name = "Western Digital Blue 4TB",
                Cost = 100,
                ConnectionType = "Внутренний",
                Manufactor = "Western Digital",
                Capacity = 4096,
                RPM = 5400,
                Interface = "SATA"
            });

           
            ComponentsBank.AddComponentToBank(new ComputerCase
            {
                ComponentType = "Корпус",
                Name = "Fractal Design Meshify C",
                Cost = 110,
                ConnectionType = "Внутренний",
                Manufactor = "Fractal Design",
                FormFactor = "ATX",
                Color = "Черный",
                HasWindow = true,
                NumberOfDriveBays = 2
            });
        }
    }
}
