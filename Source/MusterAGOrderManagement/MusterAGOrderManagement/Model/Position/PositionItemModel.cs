using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Model.Order;

namespace MusterAGOrderManagement.Model.Position
{
    internal class PositionItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ArticleId { get; set; }
        public ArticleItemModel Article { get; set; }
        public int OrderId { get; set; }
        public OrderItemModel Order { get; set; }
    }
}
