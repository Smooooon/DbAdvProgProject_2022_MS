using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MusterAG.BusinessLogic.Dto
{
    [XmlType(TypeName = "Kunde")]
    public class CustomerDto : BaseDto
    {
        private string _customerNr = String.Empty;
        [XmlAttribute]
        [JsonProperty(PropertyName = "customerNr")]
        public String CustomerNr
        {
            get { return _customerNr; }

            set { _customerNr = value; }
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string? Website { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; }


        [XmlIgnore][JsonIgnore]
        public int AddressId { get; set; }

        [JsonProperty(PropertyName = "address")]
        public virtual AddressDto Address { get; set; }
    }
}
