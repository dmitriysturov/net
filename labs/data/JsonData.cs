using PcTechs.Interfaces;
using Newtonsoft.Json;

namespace PcTechs.dataspace
{
    public class JSONSerializer<T> : ISerializer<T>
    {
        public string Serialize(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public T Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public void SerializeToFile(T data, string filePath)
        {
            string jsonData = Serialize(data);
            File.WriteAllText(filePath, jsonData);
        }

        public T DeserializeFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return Deserialize(jsonData);
        }
    }
}