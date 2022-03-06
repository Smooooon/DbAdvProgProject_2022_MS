namespace MusterAG.BusinessLogic.Dto
{
    public class OrderDto : BaseDto
    {
        public DateTime Ordered { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual ICollection<PositionDto> Positions { get; set; }
    }
}
