namespace MusterAG.BusinessLogic.Dto
{
    public class AddressDto : BaseDto
    {
        public string Street { get; set; }
        public int TownId { get; set; }
        public virtual TownDto Town { get; set; }
    }
}
