namespace MusterAGOrderManagement.Model.Position
{
    internal class PositionItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ArticleId { get; set; }
        //public virtual ArticleDao Article { get; set; }
        public int OrderId { get; set; }
        //public virtual OrderDao Order { get; set; }
    }
}
