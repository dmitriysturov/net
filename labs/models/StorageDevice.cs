using System.Xml.Serialization;
using PcTechs.Interfaces;
using PcTechs.models;

[XmlRoot("HDD")]
public class HDD : StorageDevice, IHDD
{
    [XmlElement("RPM")]
    public int RPM { get; set; }

    public override string GetInfo()
    {
        string info = $"HDD: {Name}, {Capacity}GB, {RPM} RPM, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}

[XmlRoot("SSD")]
public class SSD : StorageDevice, ISSD
{
    [XmlElement("NANDType")]
    public string? NANDType { get; set; }

    [XmlElement("SupportsNVMe")]
    public bool SupportsNVMe { get; set; }

    public override string GetInfo()
    {
        string info = $"SSD: {Name}, {Capacity}GB, NAND Type: {NANDType}, NVMe Support: {SupportsNVMe}, {Cost}$";
        Console.WriteLine(info);
        return info;
    }
}
