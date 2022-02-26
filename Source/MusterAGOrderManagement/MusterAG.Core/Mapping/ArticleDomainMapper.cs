using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class ArticleDomainMapper
    {
        public static ArticleDao ToDao(this ArticleDto articleDto)
        {
            ArticleDao articleDao = new ArticleDao();
            articleDao.Id = articleDto.Id;
            articleDao.Name = articleDto.Name;
            articleDao.Price = articleDto.Price;
            articleDao.ArticleGroupId = articleDto.ArticleGroupId;

            return articleDao;
        }

        public static ArticleDto ToDto(this ArticleDao articleDao)
        {
            ArticleDto articleDto = new ArticleDto();
            articleDto.Id = articleDao.Id;
            articleDto.Name = articleDao.Name;
            articleDto.Price = articleDao.Price;
            articleDto.ArticleGroupId = articleDao.ArticleGroupId;

            return articleDto;
        }
    }
}
