using MusterAG.BusinessLogic.Dto;

namespace MusterAGOrderManagement.Model.Address
{
    internal class TownItemModel
    {
        public int Id { get; set; }
        public int PLZ { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual CountryDto Country { get; set; }
    }
}
