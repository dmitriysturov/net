using System.Xml.Serialization;
using PcTechs.Interfaces;
using PcTechs.models;


public class LiquidCooling : CoolingSystem, ILiquidCooling
{
    [XmlElement]
    public decimal RadiatorSize { get; set; }

    public override string GetInfo()
    {
        string info = $"Liquid Cooling: {Name}, Radiator Size: {RadiatorSize}mm, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}


public class AirCooling : CoolingSystem, IAirCooling
{
    [XmlElement]
    public decimal FanSize { get; set; }

    public override string GetInfo()
    {
        string info = $"Air Cooling: {Name}, Fan Size: {FanSize}mm, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}
