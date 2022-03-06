using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.ArticleGroup;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.ArticleGroup
{
    internal class ArticleGroupViewModel : BaseViewModel
    {
        ArticleGroupModel _articleGroupModel = new ArticleGroupModel();
        private ArticleGroupDomain _articleGroupDomain;

        //public IList<ArticleGroupItemModel> ArticleGroupList { get; set; }

        public ObservableCollection<ArticleGroupItemModel> ArticleGroupList
        {
            get { return _articleGroupModel.ArticleGroups; }
            set
            {
                _articleGroupModel.ArticleGroups = value;
                OnPropertyChanged();
            }
        }

        public ArticleGroupItemModel SelectedItem
        {
            get { return _articleGroupModel.SelectedItem; }
            set
            {
                _articleGroupModel.SelectedItem = value;
                OnPropertyChanged();
            }
        }

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
            _articleGroupDomain = new ArticleGroupDomain();

            RefreshArticleList();
        }

        public void RefreshArticleList()
        {
            IList<ArticleGroupDto> articleGroupDtoList = _articleGroupDomain.GetArticleGroups();

            if (ArticleGroupList != null)
                ArticleGroupList.Clear();
            else
                ArticleGroupList = new ObservableCollection<ArticleGroupItemModel>();

            foreach (ArticleGroupDto articleGroupDto in articleGroupDtoList)
                ArticleGroupList.Add(articleGroupDto.ToModel());
        }
    }
}
