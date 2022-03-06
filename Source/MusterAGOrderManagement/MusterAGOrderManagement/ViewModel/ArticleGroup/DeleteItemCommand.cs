using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Model.ArticleGroup;
using System;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.ArticleGroup
{
    internal class DeleteItemCommand : ICommand
    {
        private ArticleGroupViewModel _articleGroupViewModel;
        private ArticleGroupDomain _articleGroupDomain;

        public event EventHandler? CanExecuteChanged;

        public DeleteItemCommand(ArticleGroupViewModel articleGroupViewModel, ArticleGroupDomain articleGroupDomain)
        {
            _articleGroupViewModel = articleGroupViewModel;
            _articleGroupDomain = articleGroupDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ArticleGroupItemModel)
            {
                ArticleGroupItemModel articleGroupItemModel = (ArticleGroupItemModel)parameter;
                _articleGroupDomain.DeleteArticleGroup(articleGroupItemModel.Id);

                _articleGroupViewModel.RefreshArticleList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
