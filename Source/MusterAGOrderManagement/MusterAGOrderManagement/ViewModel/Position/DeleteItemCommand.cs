using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Model.Position;
using System;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Position
{
    internal class DeleteItemCommand : ICommand
    {
        private PositionViewModel _positionViewModel;
        private PositionDomain _positionDomain;

        public event EventHandler? CanExecuteChanged;

        public DeleteItemCommand(PositionViewModel positionViewModel, PositionDomain positionDomain)
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
            if (parameter is PositionItemModel)
            {
                PositionItemModel positionItemModel = (PositionItemModel)parameter;
                _positionDomain.DeletePosition(positionItemModel.Id);

                _positionViewModel.RefreshPositionList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
