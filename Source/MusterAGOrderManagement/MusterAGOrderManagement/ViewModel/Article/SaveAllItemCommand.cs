using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Article;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusterAGOrderManagement.Article.ViewModel
{
    internal class SaveAllItemCommand : ICommand
    {
        private ArticleViewModel _articleViewModel;
        private ArticleDomain _articleDomain;

        public event EventHandler? CanExecuteChanged;

        public SaveAllItemCommand(ArticleViewModel articleViewModel, ArticleDomain articleDomain)
        {
            _articleViewModel = articleViewModel;
            _articleDomain = articleDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;

        }

        public void Execute(object? parameter)
        {
            if (parameter is ObservableCollection<ArticleItemModel>)
            {
                IList<ArticleDto> articleDtoList = new List<ArticleDto>();
                IList<ArticleItemModel> articleItems = (IList<ArticleItemModel>)parameter;

                foreach (ArticleItemModel articleItemModel in articleItems)
                    articleDtoList.Add(articleItemModel.ToDto());

                _articleDomain.UpdateArticles(articleDtoList);

                _articleViewModel.RefreshArticleList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
