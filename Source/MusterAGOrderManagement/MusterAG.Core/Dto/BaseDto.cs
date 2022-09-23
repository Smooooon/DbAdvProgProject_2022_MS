using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MusterAG.BusinessLogic.Dto
{
    public  class BaseDto
    {
        [XmlIgnore][JsonIgnore]
        public int Id { get; set; }
    }
}
