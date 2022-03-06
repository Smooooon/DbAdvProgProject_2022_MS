using Caliburn.Micro;
using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using MusterAGOrderManagement.ViewModel;
using MusterAGOrderManagement.Model.ArticleGroup;

namespace MusterAGOrderManagement.Article.ViewModel
{
    internal class ArticleViewModel : BaseViewModel
    {
        ArticleModel _articleModel = new ArticleModel();
        private ArticleDomain _articleDomain;
        private ArticleGroupDomain _articleGroupDomain;

        public IList<ArticleGroupItemModel> ArticleGroupList { get; set; }

        public ObservableCollection<ArticleItemModel> ArticleList 
        {
            get { return _articleModel.Articles; }
            set
            {
                _articleModel.Articles = value;
                OnPropertyChanged();
            }
        }

        public ArticleItemModel SelectedItem
        {
            get { return _articleModel.SelectedItem; }
            set
            {
                _articleModel.SelectedItem = value;
                OnPropertyChanged();
            }
        }

        public ArticleItemModel NewItem
        {
            get { return _articleModel.NewItem; }
            set
            {
                _articleModel.NewItem = value;
                OnPropertyChanged();
            }
        }

        public bool IsValide
        {
            get
            {
                return SelectedItem != null &&
                    !string.IsNullOrWhiteSpace(SelectedItem.Name) &&
                     SelectedItem.Price != 0;
            }
        }

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
            _articleDomain = new ArticleDomain();
            _articleGroupDomain = new ArticleGroupDomain();
            ArticleGroupList = new List<ArticleGroupItemModel>();
            IList <ArticleGroupDto> articleGroups = _articleGroupDomain.LoadArticleGroups();

            foreach (ArticleGroupDto articleGroupDto in articleGroups)
                ArticleGroupList.Add(articleGroupDto.ToModel());

            RefreshArticleList();
        }

        public void RefreshArticleList()
        {
            IList<ArticleDto> articleDtoList = _articleDomain.GetArticles();

            if (ArticleList != null)
                ArticleList.Clear();
            else
                ArticleList = new ObservableCollection<ArticleItemModel>();

            NewItem = new ArticleItemModel();

            foreach (ArticleDto articleDto in articleDtoList)
                ArticleList.Add(articleDto.ToModel());
        }
    }
}
