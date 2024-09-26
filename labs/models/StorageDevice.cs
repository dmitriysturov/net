using PcTechs.Interfaces;
using PcTechs.models;

public class HDD : StorageDevice, IHDD
{
    public int RPM { get; set; } // Реализация уникальной характеристики для HDD

    public override string GetInfo()
    {
        string info = $"HDD: {Name}, {Capacity}GB, {RPM} RPM, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}

public class SSD : StorageDevice, ISSD
{
    public string? NANDType { get; set; }
    public bool SupportsNVMe { get; set; }

    public override string GetInfo()
    {
        string info = $"SSD: {Name}, {Capacity}GB, NAND Type: {NANDType}, NVMe Support: {SupportsNVMe}, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}
