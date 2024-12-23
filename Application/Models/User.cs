using System.Xml.Serialization;

namespace TestWorkTask.Models
{
    [XmlRoot("user")]
    public class UserModel
    {
        [XmlElement("fio")]
        public required string FullName { get; set; }

        [XmlElement("email")]
        public required string Email { get; set; }
    }
}
