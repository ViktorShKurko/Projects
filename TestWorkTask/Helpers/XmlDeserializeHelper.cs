using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestWorkTask.Helpers
{
    public class XmlDeserializeHelper
    {
        public static T GetModel<T>(string xmlData)
        {
            var deserializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xmlData);

            return (T)deserializer.Deserialize(new StringReader(xmlData));
        }

        //public static T GetModel<T>(string file)
        //{
        //    return GetModel<T>("");
        //}
    }
}
