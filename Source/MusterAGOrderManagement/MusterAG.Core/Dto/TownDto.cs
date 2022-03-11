namespace MusterAG.BusinessLogic.Dto
{
    public class TownDto : BaseDto
    {
        public int PLZ { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual CountryDto Country { get; set; }
    }
}
