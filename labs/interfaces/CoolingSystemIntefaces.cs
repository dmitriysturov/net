namespace PcTechs.Interfaces
{
    public interface ILiquidCooling
    {
        int RadiatorSize { get; set; } // Размер радиатора
    }

    public interface IAirCooling
    {
        int FanSize { get; set; } // Размер вентилятора
    }
}
