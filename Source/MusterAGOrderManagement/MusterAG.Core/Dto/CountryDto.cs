namespace MusterAG.BusinessLogic.Dto
{
    public class CountryDto : BaseDto
    {
        public CountryDto()
        {
            this.TownDto = new HashSet<TownDto>();
        }
        public string Name { get; set; }
        public virtual ICollection<TownDto> TownDto { get; set; }
    }
}
