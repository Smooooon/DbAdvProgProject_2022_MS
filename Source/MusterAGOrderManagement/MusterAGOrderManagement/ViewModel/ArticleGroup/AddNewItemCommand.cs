using MusterAG.BusinessLogic.Domain;
using System;
using System.Windows.Input;
using MusterAGOrderManagement.Mapping;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.ArticleGroup;

namespace MusterAGOrderManagement.ViewModel.ArticleGroup
{
    internal class AddNewItemCommand : ICommand
    {
        private ArticleGroupViewModel _articleGroupViewModel;
        private ArticleGroupDomain _articleGroupDomain;

        public event EventHandler? CanExecuteChanged;

        public AddNewItemCommand(ArticleGroupViewModel articleGroupViewModel, ArticleGroupDomain articleGroupDomain)
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
            if(parameter == null)
                CreateNewEmptyItem(new ArticleGroupItemModel());
            else if (parameter is ArticleGroupItemModel)
                CreateNewEmptyItem((ArticleGroupItemModel)parameter);
            else
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
        }

        /// <summary>
        /// Erstelle leeres Item
        /// </summary>
        /// <param name="articleGroupItemModel"></param>
        private void CreateNewEmptyItem(ArticleGroupItemModel articleGroupItemModel)
        {
            articleGroupItemModel.Id = 0;
            articleGroupItemModel.Name = string.Empty;
            articleGroupItemModel.HigherLevelArticleGroupId = 1;
            ArticleGroupDto newItemDto = _articleGroupDomain.CreateArticleGroup(articleGroupItemModel.ToDto());
            ArticleGroupItemModel newItem = newItemDto.ToModel();

            _articleGroupViewModel.RefreshArticleList();

            ArticleGroupItemModel newSelectedItem = new ArticleGroupItemModel();
            newSelectedItem.Id = newItem.Id;
            newSelectedItem.Name = newItem.Name;
            newSelectedItem.HigherLevelArticleGroupId = newItem.HigherLevelArticleGroupId;

            _articleGroupViewModel.SelectedItem = newSelectedItem;
        }
    }
}
