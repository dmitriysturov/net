namespace PcTechs.Interfaces
{
    public interface ISerializer<T>
    {
        string Serialize(T data);
        T Deserialize(string data);
        void SerializeToFile(T data, string filePath);
        T DeserializeFromFile(string filePath);
    }
}
