namespace PcTechs.Interfaces
{
    public interface IHDD
    {
        int RPM { get; set; } // Скорость вращения в RPM
    }

    public interface ISSD
    {
        string? NANDType { get; set; } // Тип памяти NAND
        bool SupportsNVMe { get; set; } // Поддержка NVMe
    }
}