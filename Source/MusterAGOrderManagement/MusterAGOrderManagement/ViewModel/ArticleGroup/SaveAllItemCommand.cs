using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.ArticleGroup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.ArticleGroup
{
    internal class SaveAllItemCommand : ICommand
    {
        private ArticleGroupViewModel _articleGroupViewModel;
        private ArticleGroupDomain _articleGroupDomain;

        public event EventHandler? CanExecuteChanged;

        public SaveAllItemCommand(ArticleGroupViewModel articleViewModel, ArticleGroupDomain articleGroupDomain)
        {
            _articleGroupViewModel = articleViewModel;
            _articleGroupDomain = articleGroupDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;

        }

        public void Execute(object? parameter)
        {
            if (parameter is ObservableCollection<ArticleGroupItemModel>)
            {
                IList<ArticleGroupDto> articleGroupDtoList = new List<ArticleGroupDto>();
                IList<ArticleGroupItemModel> articleGroupItems = (IList<ArticleGroupItemModel>)parameter;

                foreach (ArticleGroupItemModel articleGroupItemModel in articleGroupItems)
                    articleGroupDtoList.Add(articleGroupItemModel.ToDto());

                _articleGroupDomain.UpdateArticleGroups(articleGroupDtoList);

                _articleGroupViewModel.RefreshArticleList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
