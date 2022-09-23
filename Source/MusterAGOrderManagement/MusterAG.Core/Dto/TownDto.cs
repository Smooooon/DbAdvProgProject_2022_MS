using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MusterAG.BusinessLogic.Dto
{
    public class TownDto : BaseDto
    {
        [XmlElement(ElementName = "PostalCode")]
        [JsonProperty(PropertyName = "postalCode")]
        public int PLZ { get; set; }

        [XmlIgnore][JsonIgnore]
        public string Name { get; set; }

        [XmlIgnore][JsonIgnore]
        public int CountryId { get; set; }
        [XmlIgnore][JsonIgnore]
        public virtual CountryDto Country { get; set; }
    }
}
