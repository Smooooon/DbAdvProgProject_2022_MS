using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Mapping;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MusterAGOrderManagement.ViewModel;
using MusterAGOrderManagement.Model.ArticleGroup;
using System.ComponentModel;
using System.Windows.Data;

namespace MusterAGOrderManagement.Article.ViewModel
{
    internal class ArticleViewModel : BaseViewModel
    {
        public ArticleModel ArticleModel { get; set; }
        private ArticleDomain _articleDomain;
        private ArticleGroupDomain _articleGroupDomain;

        public IList<ArticleGroupItemModel> ArticleGroupList { get; set; }

        private SaveAllItemCommand _saveAllItemCommand = null;
        public ICommand SaveAllItemCommand
        {
            get
            {
                if (_saveAllItemCommand == null)
                    _saveAllItemCommand = new SaveAllItemCommand(this, _articleDomain);
                return _saveAllItemCommand;
            }
        }

        private AddNewItemCommand _addNewItemCommand = null;
        public ICommand AddNewItemCommand
        {
            get
            {
                if (_addNewItemCommand == null)
                    _addNewItemCommand = new AddNewItemCommand(this, _articleDomain);
                return _addNewItemCommand;
            }
        }

        private DeleteItemCommand _deleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                    _deleteItemCommand = new DeleteItemCommand(this, _articleDomain);
                return _deleteItemCommand;
            }
        }

        public ArticleViewModel()
        {
            ArticleModel = new ArticleModel();
            _articleDomain = new ArticleDomain();
            _articleGroupDomain = new ArticleGroupDomain();
            ArticleGroupList = new List<ArticleGroupItemModel>();
            IList <ArticleGroupDto> articleGroups = _articleGroupDomain.GetArticleGroups();

            foreach (ArticleGroupDto articleGroupDto in articleGroups)
                ArticleGroupList.Add(articleGroupDto.ToModel());

            RefreshArticleList();

            ItemsView = CollectionViewSource.GetDefaultView(ArticleModel.Articles);
            ItemsView.Filter = x => Filter(x as ArticleItemModel);
        }

        private bool Filter(ArticleItemModel articleItemModel)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return articleItemModel != null &&
                 ((articleItemModel.Name ?? string.Empty).ToLower().Contains(searchstring) ||
                  (articleItemModel.Price.ToString() == searchstring) ||
                  (articleItemModel.ArticleGroup.Name ?? string.Empty).ToLower().Contains(searchstring));
        }

        public void RefreshArticleList()
        {
            IList<ArticleDto> articleDtoList = _articleDomain.GetArticles();

            if (ArticleModel.Articles != null)
                ArticleModel.Articles.Clear();
            else
                ArticleModel.Articles = new ObservableCollection<ArticleItemModel>();

            foreach (ArticleDto articleDto in articleDtoList)
                ArticleModel.Articles.Add(articleDto.ToModel());
        }
    }
}
