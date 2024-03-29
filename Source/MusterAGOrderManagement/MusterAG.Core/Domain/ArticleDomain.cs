﻿using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Domain
{
    public class ArticleDomain
    {
        public ArticleDataService _articleDataService = new ArticleDataService();

        public IList<ArticleDto> GetArticles()
        {
            IList<ArticleDto> articleDtoList = new List<ArticleDto>();

            IList<ArticleDao> articleDaoList = _articleDataService.GetAll();

            foreach (ArticleDao articleDao in articleDaoList)
                articleDtoList.Add(articleDao.ToDto());

            return articleDtoList;
        }

        public bool UpdateArticles(IList<ArticleDto> articleDtoList)
        {
            bool success = true;

            foreach (ArticleDto articleDto in articleDtoList)
            {
                ArticleDao articleDao = articleDto.ToDao();
                ArticleDao updatedArticleDao = _articleDataService.Update(articleDao);

                if (updatedArticleDao == null)
                    success = false;
            }


            return success;
        }

        public ArticleDto CreateArticle(ArticleDto articleDto)
        {
            ArticleDao articleDao = articleDto.ToDao();
            ArticleDao createdArticleDao = _articleDataService.Create(articleDao);

            return createdArticleDao.ToDto();
        }

        public bool DeleteArticle(int articleIdToDelete)
        {
            return _articleDataService.Delete(articleIdToDelete);
        }
    }
}
