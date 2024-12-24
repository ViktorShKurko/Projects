using System.Xml.Serialization;

namespace TestWorkTask.Helpers
{
    public class XmlHelper
    {
        public static T Deserialize<T>(string xmlData)
        {
            var deserializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xmlData);

            return (T)deserializer.Deserialize(new StringReader(xmlData));
        }
    }
}
