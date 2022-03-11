using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Model.Article;
using System;
using System.Windows.Input;
using MusterAGOrderManagement.Mapping;
using MusterAG.BusinessLogic.Dto;

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
            if(parameter == null)
                CreateNewEmptyItem(new ArticleItemModel());
            else if (parameter is ArticleItemModel)
                CreateNewEmptyItem((ArticleItemModel)parameter);
            else
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
        }

        /// <summary>
        /// Erstelle leeres Item
        /// </summary>
        /// <param name="articleItemModel"></param>
        private void CreateNewEmptyItem(ArticleItemModel articleItemModel)
        {
            articleItemModel.Id = 0;
            articleItemModel.Name = string.Empty;
            articleItemModel.Price = 0.00M;
            articleItemModel.ArticleGroupId = 1;
            ArticleDto newItemDto = _articleDomain.CreateArticle(articleItemModel.ToDto());
            ArticleItemModel newItem = newItemDto.ToModel();

            _articleViewModel.RefreshArticleList();

            ArticleItemModel newSelectedItem = new ArticleItemModel();
            newSelectedItem.Id = newItem.Id;
            newSelectedItem.Name = newItem.Name;
            newSelectedItem.Price = newItem.Price;
            newSelectedItem.ArticleGroupId = newItem.ArticleGroupId;

            _articleViewModel.ArticleModel.SelectedItem = newSelectedItem;
        }
    }
}
