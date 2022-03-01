using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.BusinessLogic.Domain
{
    public class ArticleGroupDomain
    {
        public ArticleGroupDataService _articleGroupDataService = new ArticleGroupDataService();

        public IList<ArticleGroupDto> LoadArticleGroups()
        {
            IList<ArticleGroupDto> articleGroupDtoList = new List<ArticleGroupDto>();

            IList<ArticleGroupDao> articleGroupDaoList = _articleGroupDataService.GetAll();

            foreach (ArticleGroupDao articleGroupDao in articleGroupDaoList)
                articleGroupDtoList.Add(articleGroupDao.ToDto());

            return articleGroupDtoList;
        }
    }
}
