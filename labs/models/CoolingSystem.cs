using System.Xml.Serialization;
using PcTechs.Interfaces;
using PcTechs.models;

[XmlRoot("LiquidCooling")]
public class LiquidCooling : CoolingSystem, ILiquidCooling
{
    [XmlElement("RadiatorSize")]
    public decimal RadiatorSize { get; set; }

    public override string GetInfo()
    {
        string info = $"Liquid Cooling: {Name}, Radiator Size: {RadiatorSize}mm, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}


[XmlRoot("AirCooling")]
public class AirCooling : CoolingSystem, IAirCooling
{
    [XmlElement("FanSize")]
    public decimal FanSize { get; set; }

    public override string GetInfo()
    {
        string info = $"Air Cooling: {Name}, Fan Size: {FanSize}mm, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}
