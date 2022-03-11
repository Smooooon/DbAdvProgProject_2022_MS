using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Address;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Address
{
    internal class SaveAllItemCommand : ICommand
    {
        private AddressViewModel _addressViewModel;
        private AddressDomain _addressDomain;

        public event EventHandler? CanExecuteChanged;

        public SaveAllItemCommand(AddressViewModel addressViewModel, AddressDomain addressDomain)
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
            if (parameter is ObservableCollection<AddressItemModel>)
            {
                IList<AddressDto> addressDtoList = new List<AddressDto>();
                IList<AddressItemModel> addressItems = (IList<AddressItemModel>)parameter;

                foreach (AddressItemModel addressItemModel in addressItems)
                    addressDtoList.Add(addressItemModel.ToDto());

                _addressDomain.UpdateAddresses(addressDtoList);

                _addressViewModel.RefreshAddressList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
