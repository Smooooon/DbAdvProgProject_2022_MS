using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class ArticleGroupDomainMapper
    {
        public static ArticleGroupDao ToDao(this ArticleGroupDto articleGroupDto)
        {
            if (articleGroupDto == null)
                return null;

            ArticleGroupDao articleGroupDao = new ArticleGroupDao();
            articleGroupDao.Id = articleGroupDto.Id;
            articleGroupDao.Name = articleGroupDto.Name;
            articleGroupDao.HigherLevelArticleGroupId = articleGroupDto.HigherLevelArticleGroupId;
            articleGroupDao.HigherLevelArticleGroup = articleGroupDto.HigherLevelArticleGroup.ToDao();
            return articleGroupDao;
        }

        public static ArticleGroupDto ToDto(this ArticleGroupDao articleGroupDao)
        {
            if(articleGroupDao == null)
                return null;

            ArticleGroupDto articleGroupDto = new ArticleGroupDto();
            articleGroupDto.Id = articleGroupDao.Id;
            articleGroupDto.Name = articleGroupDao.Name;
            articleGroupDto.HigherLevelArticleGroupId = articleGroupDao.HigherLevelArticleGroupId;
            articleGroupDto.HigherLevelArticleGroup = articleGroupDao.HigherLevelArticleGroup.ToDto();

            return articleGroupDto;
        }
    }
}
