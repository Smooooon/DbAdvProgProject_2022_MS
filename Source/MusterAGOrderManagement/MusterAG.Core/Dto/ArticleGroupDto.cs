namespace MusterAG.BusinessLogic.Dto
{
    public class ArticleGroupDto : BaseDto
    {
        public string Name { get; set; }
        public int? HigherLevelArticleGroupId { get; set; }
        public ArticleGroupDto HigherLevelArticleGroup { get; set; }
    }
}
