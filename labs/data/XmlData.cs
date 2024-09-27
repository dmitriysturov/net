using System.Xml.Serialization;
using System.IO;
using PcTechs.Interfaces;


namespace PcTechs.dataspace
{
    public class XMLSerializer<T> : ISerializer<T>
    {
        public string Serialize(T data)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, data);
                return textWriter.ToString();
            }
        }

        public T Deserialize(string data)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(data))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public void SerializeToFile(T data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, data);
            }
        }

        public T DeserializeFromFile(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }
    }

}