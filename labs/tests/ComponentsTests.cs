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

         
            
            
        }
    }
}
