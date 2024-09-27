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
        }
    }
}
