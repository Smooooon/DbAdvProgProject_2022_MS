using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Article;

namespace MusterAGOrderManagement.Mapping
{
    internal static class ArticleViewMapper
    {
        public static ArticleItemModel ToModel(this ArticleDto articleDto)
        {
            if (articleDto == null)
                return null;

            ArticleItemModel articleModel = new ArticleItemModel();
            articleModel.Id = articleDto.Id;
            articleModel.Name = articleDto.Name;
            articleModel.Price = articleDto.Price;
            articleModel.ArticleGroupId = articleDto.ArticleGroupId;
            articleModel.ArticleGroup = articleDto.ArticleGroup.ToModel();

            return articleModel;
        }

        public static ArticleDto ToDto(this ArticleItemModel articleModel)
        {
            if (articleModel == null)
                return null;

            ArticleDto articleDto = new ArticleDto();
            articleDto.Id = articleModel.Id;
            articleDto.Name = articleModel.Name;
            articleDto.Price = articleModel.Price;
            articleDto.ArticleGroupId = articleModel.ArticleGroupId;
            articleDto.ArticleGroup = articleModel.ArticleGroup.ToDto();

            return articleDto;
        }
    }
}
