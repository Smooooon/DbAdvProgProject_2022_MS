using MusterAG.BusinessLogic.Domain;
using System;
using System.Windows.Input;
using MusterAGOrderManagement.Mapping;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Address;

namespace MusterAGOrderManagement.ViewModel.Address
{
    internal class AddNewItemCommand : ICommand
    {
        private AddressViewModel _addressViewModel;
        private AddressDomain _addressDomain;

        public event EventHandler? CanExecuteChanged;

        public AddNewItemCommand(AddressViewModel addressViewModel, AddressDomain addressDomain)
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
            if(parameter == null)
                CreateNewEmptyItem(new AddressItemModel());
            else if (parameter is AddressItemModel)
                CreateNewEmptyItem((AddressItemModel)parameter);
            else
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
        }

        /// <summary>
        /// Erstelle leeres Item
        /// </summary>
        /// <param name="addressItemModel"></param>
        private void CreateNewEmptyItem(AddressItemModel addressItemModel)
        {
            addressItemModel.Id = 0;
            addressItemModel.Street = string.Empty;
            addressItemModel.TownId = 1;
            AddressDto newItemDto = _addressDomain.CreateAddress(addressItemModel.ToDto());
            AddressItemModel newItem = newItemDto.ToModel();

            _addressViewModel.RefreshAddressList();

            AddressItemModel newSelectedItem = new AddressItemModel();
            newSelectedItem.Id = newItem.Id;
            newSelectedItem.Street = newItem.Street;
            newSelectedItem.TownId = newItem.TownId;

            _addressViewModel.AddressModel.SelectedItem = newSelectedItem;
        }
    }
}
