namespace MusterAG.DataAccessLayer.Dao
{
    public class PositionDao : BaseDao
    {
        public int Quantity { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleDao Article { get; set; }
        public int OrderId { get; set; }
        public virtual OrderDao Order { get; set; }
    }
}
