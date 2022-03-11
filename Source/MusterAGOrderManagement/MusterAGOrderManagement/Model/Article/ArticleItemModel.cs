using MusterAGOrderManagement.Model.ArticleGroup;

namespace MusterAGOrderManagement.Model.Article
{
    internal class ArticleItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ArticleGroupId { get; set; }
        public ArticleGroupItemModel ArticleGroup { get; set; }
    }
}
