using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Domain
{
    public class ArticleGroupDomain
    {
        public ArticleGroupDataService _articleGroupDataService = new ArticleGroupDataService();

        public IList<ArticleGroupDto> GetArticleGroups()
        {
            IList<ArticleGroupDto> articleGroupDtoList = new List<ArticleGroupDto>();

            IList<ArticleGroupDao> articleGroupDaoList = _articleGroupDataService.GetAll();

            foreach (ArticleGroupDao articleGroupDao in articleGroupDaoList)
                articleGroupDtoList.Add(articleGroupDao.ToDto());

            return articleGroupDtoList;
        }

        public bool UpdateArticleGroups(IList<ArticleGroupDto> articleGroupDtoList)
        {
            bool success = true;

            foreach (ArticleGroupDto articleGroupDto in articleGroupDtoList)
            {
                ArticleGroupDao articleGroupDao = articleGroupDto.ToDao();
                ArticleGroupDao updatedArticleGroupDao = _articleGroupDataService.Update(articleGroupDao);

                if (updatedArticleGroupDao == null)
                    success = false;
            }

            return success;
        }

        public ArticleGroupDto CreateArticleGroup(ArticleGroupDto articleGroupDto)
        {
            ArticleGroupDao articleGroupDao = articleGroupDto.ToDao();
            ArticleGroupDao createdArticleGroupDao = _articleGroupDataService.Create(articleGroupDao);

            return createdArticleGroupDao.ToDto();
        }

        public bool DeleteArticleGroup(int articleGroupIdToDelete)
        {
            return _articleGroupDataService.Delete(articleGroupIdToDelete);
        }
    }
}
