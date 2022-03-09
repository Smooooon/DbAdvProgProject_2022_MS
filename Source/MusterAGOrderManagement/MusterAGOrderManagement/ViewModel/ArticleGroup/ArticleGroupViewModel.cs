using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.ArticleGroup;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.ArticleGroup
{
    internal class ArticleGroupViewModel : BaseViewModel
    {
        public  ArticleGroupModel ArticleGroupModel { get; set; }
        private ArticleGroupDomain _articleGroupDomain;

        private SaveAllItemCommand _saveAllItemCommand = null;
        public ICommand SaveAllItemCommand
        {
            get
            {
                if (_saveAllItemCommand == null)
                    _saveAllItemCommand = new SaveAllItemCommand(this, _articleGroupDomain);
                return _saveAllItemCommand;
            }
        }

        private AddNewItemCommand _addNewItemCommand = null;
        public ICommand AddNewItemCommand
        {
            get
            {
                if (_addNewItemCommand == null)
                    _addNewItemCommand = new AddNewItemCommand(this, _articleGroupDomain);
                return _addNewItemCommand;
            }
        }

        private DeleteItemCommand _deleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                    _deleteItemCommand = new DeleteItemCommand(this, _articleGroupDomain);
                return _deleteItemCommand;
            }
        }

        public ArticleGroupViewModel()
        {
            ArticleGroupModel = new ArticleGroupModel();
            _articleGroupDomain = new ArticleGroupDomain();

            RefreshArticleList();

            ItemsView = CollectionViewSource.GetDefaultView(ArticleGroupModel.ArticleGroups);
            ItemsView.Filter = x => Filter(x as ArticleGroupItemModel);
        }

        private bool Filter(ArticleGroupItemModel itemModel)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return itemModel != null &&
                 ((itemModel.Name ?? string.Empty).ToLower().Contains(searchstring) ||
                  (itemModel.HigherLevelArticleGroup?.Name ?? string.Empty).ToLower().Contains(searchstring));
        }

        public void RefreshArticleList()
        {
            IList<ArticleGroupDto> articleGroupDtoList = _articleGroupDomain.GetArticleGroups();

            if (ArticleGroupModel.ArticleGroups != null)
                ArticleGroupModel.ArticleGroups.Clear();
            else
                ArticleGroupModel.ArticleGroups = new ObservableCollection<ArticleGroupItemModel>();

            foreach (ArticleGroupDto articleGroupDto in articleGroupDtoList)
                ArticleGroupModel.ArticleGroups.Add(articleGroupDto.ToModel());
        }
    }
}
