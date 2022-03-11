using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Model.Address;
using System;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Address
{
    internal class DeleteItemCommand : ICommand
    {
        private AddressViewModel _addressViewModel;
        private AddressDomain _addressDomain;

        public event EventHandler? CanExecuteChanged;

        public DeleteItemCommand(AddressViewModel addressViewModel, AddressDomain addressDomain)
        {
            _addressViewModel = addressViewModel;
            _addressDomain = addressDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is AddressItemModel)
            {
                AddressItemModel addressItemModel = (AddressItemModel)parameter;
                _addressDomain.DeleteAddress(addressItemModel.Id);

                _addressViewModel.RefreshAddressList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
