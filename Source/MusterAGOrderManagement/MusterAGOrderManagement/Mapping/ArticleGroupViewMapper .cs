using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.ArticleGroup;

namespace MusterAGOrderManagement.Mapping
{
    internal static class ArticleGroupViewMapper
    {
        public static ArticleGroupItemModel ToModel(this ArticleGroupDto articleGroupDto)
        {
            if(articleGroupDto == null)
                return null;

            ArticleGroupItemModel articleGroupModel = new ArticleGroupItemModel();
            articleGroupModel.Id = articleGroupDto.Id;
            articleGroupModel.Name = articleGroupDto.Name;
            articleGroupModel.HigherLevelArticleGroupId = articleGroupDto.HigherLevelArticleGroupId;
            articleGroupModel.HigherLevelArticleGroup = articleGroupDto.HigherLevelArticleGroup.ToModel();
            return articleGroupModel;
        }

        public static ArticleGroupDto ToDto(this ArticleGroupItemModel articleGroupModel)
        {
            if (articleGroupModel == null)
                return null;

            ArticleGroupDto articleGroupDto = new ArticleGroupDto();
            articleGroupDto.Id = articleGroupModel.Id;
            articleGroupDto.Name = articleGroupModel.Name;
            articleGroupDto.HigherLevelArticleGroupId = articleGroupModel.HigherLevelArticleGroupId;
            articleGroupDto.HigherLevelArticleGroup = articleGroupModel.HigherLevelArticleGroup.ToDto();
            return articleGroupDto;
        }
    }
}
