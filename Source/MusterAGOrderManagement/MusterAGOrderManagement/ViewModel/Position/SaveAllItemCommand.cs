using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Position;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Position
{
    internal class SaveAllItemCommand : ICommand
    {
        private PositionViewModel _positionViewModel;
        private PositionDomain _positionDomain;

        public event EventHandler? CanExecuteChanged;

        public SaveAllItemCommand(PositionViewModel positionViewModel, PositionDomain positionDomain)
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
            if (parameter is ObservableCollection<PositionItemModel>)
            {
                IList<PositionDto> positionDtoList = new List<PositionDto>();
                IList<PositionItemModel> positionItems = (IList<PositionItemModel>)parameter;

                foreach (PositionItemModel positionItemModel in positionItems)
                    positionDtoList.Add(positionItemModel.ToDto());

                _positionDomain.UpdatePositions(positionDtoList);

                _positionViewModel.RefreshPositionList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
