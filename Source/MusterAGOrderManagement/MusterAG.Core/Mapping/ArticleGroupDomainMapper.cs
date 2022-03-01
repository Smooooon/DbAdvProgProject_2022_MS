using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class ArticleGroupDomainMapper
    {
        public static ArticleGroupDao ToDao(this ArticleGroupDto articleGroupDto)
        {
            ArticleGroupDao articleGroupDao = new ArticleGroupDao();
            articleGroupDao.Id = articleGroupDto.Id;
            articleGroupDao.Name = articleGroupDto.Name;
            articleGroupDao.HigherLevelArticleGroupId = articleGroupDto.HigherLevelArticleGroupId;
            return articleGroupDao;
        }

        public static ArticleGroupDto ToDto(this ArticleGroupDao articleGroupDao)
        {
            ArticleGroupDto articleGroupDto = new ArticleGroupDto();
            articleGroupDto.Id = articleGroupDao.Id;
            articleGroupDto.Name = articleGroupDao.Name;
            articleGroupDto.HigherLevelArticleGroupId = articleGroupDao.HigherLevelArticleGroupId;

            return articleGroupDto;
        }
    }
}
