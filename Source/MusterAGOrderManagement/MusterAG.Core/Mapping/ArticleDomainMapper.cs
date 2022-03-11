using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class ArticleDomainMapper
    {
        public static ArticleDao ToDao(this ArticleDto articleDto)
        {
            if (articleDto == null)
                return null;

            ArticleDao articleDao = new ArticleDao();
            articleDao.Id = articleDto.Id;
            articleDao.Name = articleDto.Name;
            articleDao.Price = articleDto.Price;
            articleDao.ArticleGroupId = articleDto.ArticleGroupId;
            articleDao.ArticleGroup = articleDto.ArticleGroup.ToDao();

            return articleDao;
        }

        public static ArticleDto ToDto(this ArticleDao articleDao)
        {
            if (articleDao == null)
                return null;

            ArticleDto articleDto = new ArticleDto();
            articleDto.Id = articleDao.Id;
            articleDto.Name = articleDao.Name;
            articleDto.Price = articleDao.Price;
            articleDto.ArticleGroupId = articleDao.ArticleGroupId;
            articleDto.ArticleGroup = articleDao.ArticleGroup.ToDto();

            return articleDto;
        }
    }
}
