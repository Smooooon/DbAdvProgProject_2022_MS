namespace MusterAG.BusinessLogic.Dto
{
    public class CustomerDto : BaseDto
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Password { get; set; }
        public int AddressId { get; set; }
        public virtual AddressDto Address { get; set; }
    }
}
