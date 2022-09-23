using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MusterAG.BusinessLogic.Dto
{
    public class AddressDto : BaseDto
    {
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [XmlIgnore][JsonIgnore]
        public int TownId { get; set; }

        [JsonProperty(PropertyName = "town")]
        public virtual TownDto Town { get; set; }
    }
}
