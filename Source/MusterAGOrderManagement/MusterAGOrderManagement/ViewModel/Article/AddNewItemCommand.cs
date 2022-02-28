using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusterAGOrderManagement.Mapping;

namespace MusterAGOrderManagement.Article.ViewModel
{
    internal class AddNewItemCommand : ICommand
    {
        private ArticleViewModel _articleViewModel;
        private ArticleDomain _articleDomain;

        public event EventHandler? CanExecuteChanged;

        public AddNewItemCommand(ArticleViewModel articleViewModel, ArticleDomain articleDomain)
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
            if (parameter is ArticleItemModel)
            {
                ArticleItemModel articleItemModel = (ArticleItemModel)parameter;
                _articleDomain.CreateArticle(articleItemModel.ToDto());

                _articleViewModel.RefreshArticleList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
