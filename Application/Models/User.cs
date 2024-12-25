using System.Xml.Serialization;

namespace TestWorkTask.Models
{
    [XmlRoot("user")]
    public class UserModel
    {
        public long Id { get; set; }

        [XmlElement("fio")]
        public string FullName { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }
    }
}
