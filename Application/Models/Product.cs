using System.Xml.Serialization;

namespace TestWorkTask.Models
{
    public class ProductModel
    {
        [XmlElement("name")]
        public required string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }
    }
}
