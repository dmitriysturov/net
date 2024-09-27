using System.Xml.Serialization;

namespace PcTechs.Interfaces
{
    public interface ILiquidCooling
    {
        [XmlElement]
        decimal RadiatorSize { get; set; } // Размер радиатора
    }

    public interface IAirCooling
    {
        [XmlElement]
        decimal FanSize { get; set; } // Размер вентилятора
    }
}

