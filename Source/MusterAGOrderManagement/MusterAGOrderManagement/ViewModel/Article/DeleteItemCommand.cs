using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusterAGOrderManagement.Article.ViewModel
{
    internal class DeleteItemCommand : ICommand
    {
        private ArticleViewModel _articleViewModel;
        private ArticleDomain _articleDomain;

        public event EventHandler? CanExecuteChanged;

        public DeleteItemCommand(ArticleViewModel articleViewModel, ArticleDomain articleDomain)
        {
            _articleViewModel = articleViewModel;
            _articleDomain = articleDomain;
        }

        public bool CanExecute(object? parameter)
        {
            //return (_articleViewModel.SelectedItem != null);
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ArticleItemModel)
            {
                ArticleItemModel articleItemModel = (ArticleItemModel)parameter;
                _articleDomain.DeleteArticle(articleItemModel.Id);

                _articleViewModel.RefreshData();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
