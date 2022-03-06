namespace MusterAG.BusinessLogic.Dto
{
    public class PositionDto : BaseDto
    {
        public int Quantity { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleDto Article { get; set; }
        public int OrderId { get; set; }
        public virtual OrderDto Order { get; set; }
    }
}
