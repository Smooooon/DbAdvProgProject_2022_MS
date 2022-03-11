namespace MusterAG.DataAccessLayer.Dao
{
    public class ArticleGroupDao : BaseDao
    {
        public string Name { get; set; }
        public int? HigherLevelArticleGroupId { get; set; }
        public virtual ArticleGroupDao HigherLevelArticleGroup { get; set; }
        //public virtual ICollection<ArticleGroupDao> SameLevelArticleGroup { get; set; }
        public virtual ICollection<ArticleDao> Articles { get; set; }
    }
}
