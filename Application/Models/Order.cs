using System.Text;
using System.Xml.Serialization;

namespace TestWorkTask.Models
{
    [XmlRoot(ElementName = "orders")]
    public class OrdersModel
    {
        [XmlElement("order")]
        public required OrderModel[] Orders { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var order in Orders)
            {
                stringBuilder.AppendLine(order.ToString());
            }
            return stringBuilder.ToString();
        }
    }


    [XmlRoot("order")]
    public class OrderModel
    {
        [XmlElement("no")]
        public long Id { get; set; }

        [XmlElement("reg_date")]
        public string? CreatAt { get; set; }

        [XmlElement("sum")]
        public decimal Sum { get; set; }

        [XmlElement("user")]
        public required UserModel User { get; set; }

        [XmlElement("product")]
        public ProductModel[]? Products { get; set; }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append($"Order {Id}\n");
            strBuilder.Append($"CreateAt:{CreatAt} Sum:{Sum}\n");
            strBuilder.Append($"User: {User.FullName} {User.Email}\n");
            strBuilder.Append($"SUM:{Sum}\n");
            strBuilder.Append("Products:(\n");

            foreach (var product in Products)
            {
                strBuilder.Append($" Name:{product.Name} Quantity:{product.Quantity} Price:{product.Price}\n");
            }

            strBuilder.Append(")\n");
            return strBuilder.ToString();
        }
    }
}
