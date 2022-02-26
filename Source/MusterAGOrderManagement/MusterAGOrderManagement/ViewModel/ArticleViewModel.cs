using Caliburn.Micro;
using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model;
using MusterAGOrderManagement.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAGOrderManagement.ViewModel
{
    internal class ArticleViewModel
    {
        public BindableCollection<ArticleModel> ArticleList { get; set; }

        public ArticleViewModel()
        {
            IList<ArticleModel> ArticleModelList = new List<ArticleModel>();
            ArticleDomain articleDomain = new ArticleDomain();
            IList<ArticleDto> articleDtoList = articleDomain.GetArticles();

            foreach (ArticleDto articleDto in articleDtoList)
                ArticleModelList.Add(articleDto.ToModel());

            ArticleList = new BindableCollection<ArticleModel>(ArticleModelList);
        }
    }
}
