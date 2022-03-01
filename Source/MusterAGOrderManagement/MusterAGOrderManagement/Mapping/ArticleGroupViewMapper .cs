using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;
using MusterAGOrderManagement.Model;
using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Model.ArticleGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAGOrderManagement.Mapping
{
    internal static class ArticleGroupViewMapper
    {
        public static ArticleGroupItemModel ToModel(this ArticleGroupDto articleGroupDto)
        {
            ArticleGroupItemModel articleGroupModel = new ArticleGroupItemModel();
            articleGroupModel.Id = articleGroupDto.Id;
            articleGroupModel.Name = articleGroupDto.Name;
            articleGroupModel.HigherLevelArticleGroupId = articleGroupDto.HigherLevelArticleGroupId;
            return articleGroupModel;
        }

        public static ArticleGroupDto ToDto(this ArticleGroupItemModel articleGroupModel)
        {
            ArticleGroupDto articleGroupDto = new ArticleGroupDto();
            articleGroupDto.Id = articleGroupModel.Id;
            articleGroupDto.Name = articleGroupModel.Name;
            articleGroupDto.HigherLevelArticleGroupId = articleGroupModel.HigherLevelArticleGroupId;
            return articleGroupDto;
        }
    }
}
