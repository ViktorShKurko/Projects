using System.Xml.Serialization;

namespace TestWorkTask.Models
{
    public class ProductModel
    {
        public long Id { get; set; }

        [XmlElement("name")]
        public required string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }
    }
}
