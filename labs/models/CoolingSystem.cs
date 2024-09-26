using PcTechs.Interfaces;
using PcTechs.models;


public class LiquidCooling : CoolingSystem, ILiquidCooling
{
    public int RadiatorSize { get; set; } // Реализация уникальной характеристики для жидкостного охлаждения

    public override string GetInfo()
    {
        string info = $"Liquid Cooling: {Name}, Radiator Size: {RadiatorSize}mm, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}


public class AirCooling : CoolingSystem, IAirCooling
{
    public int FanSize { get; set; } // Реализация уникальной характеристики для воздушного охлаждения

    public override string GetInfo()
    {
        string info = $"Air Cooling: {Name}, Fan Size: {FanSize}mm, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}
