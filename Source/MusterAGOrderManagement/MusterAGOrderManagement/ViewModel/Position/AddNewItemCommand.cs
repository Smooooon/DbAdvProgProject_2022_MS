using MusterAG.BusinessLogic.Domain;
using System;
using System.Windows.Input;
using MusterAGOrderManagement.Mapping;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Position;

namespace MusterAGOrderManagement.ViewModel.Position
{
    internal class AddNewItemCommand : ICommand
    {
        private PositionViewModel _positionViewModel;
        private PositionDomain _positionDomain;

        public event EventHandler? CanExecuteChanged;

        public AddNewItemCommand(PositionViewModel positionViewModel, PositionDomain positionDomain)
        {
            _positionViewModel = positionViewModel;
            _positionDomain = positionDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;

        }

        public void Execute(object? parameter)
        {
            if(parameter == null)
                CreateNewEmptyItem(new PositionItemModel());
            else if (parameter is PositionItemModel)
                CreateNewEmptyItem((PositionItemModel)parameter);
            else
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
        }

        /// <summary>
        /// Erstelle leeres Item
        /// </summary>
        /// <param name="positionItemModel"></param>
        private void CreateNewEmptyItem(PositionItemModel positionItemModel)
        {
            positionItemModel.Id = 0;
            positionItemModel.Quantity = 0;
            positionItemModel.OrderId = 1;
            positionItemModel.ArticleId = 1;
            PositionDto newItemDto = _positionDomain.CreatePosition(positionItemModel.ToDto());
            PositionItemModel newItem = newItemDto.ToModel();

            _positionViewModel.RefreshPositionList();

            PositionItemModel newSelectedItem = new PositionItemModel();
            newSelectedItem.Id = newItem.Id;
            newSelectedItem.Quantity = newItem.Quantity;
            newSelectedItem.OrderId = newItem.OrderId;
            newSelectedItem.ArticleId = newItem.ArticleId;

            _positionViewModel.PositionModel.SelectedItem = newSelectedItem;
        }
    }
}
