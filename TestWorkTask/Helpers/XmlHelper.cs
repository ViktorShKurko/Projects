using System.Xml.Serialization;

namespace TestWorkTask.Helpers
{
    public class XmlHelper
    {
        /// <summary>
        /// Возвращает десериализованный экземпляр указаного типа
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого экземпляра</typeparam>
        /// <param name="xmlData">Строка с данными в формате XML</param>
        /// <returns>Десериализованный экземпляр</returns>
        public static T Deserialize<T>(string xmlData)
        {
            var deserializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xmlData);

            return (T)deserializer.Deserialize(new StringReader(xmlData));
        }
    }
}
