using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Address;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Address
{
    internal class AddressViewModel : BaseViewModel
    {
        public AddressModel AddressModel { get; set; }
        private AddressDomain _addressDomain;

        public IList<TownItemModel> TownList { get; set; }

        private SaveAllItemCommand _saveAllItemCommand = null;
        public ICommand SaveAllItemCommand
        {
            get
            {
                if (_saveAllItemCommand == null)
                    _saveAllItemCommand = new SaveAllItemCommand(this, _addressDomain);
                return _saveAllItemCommand;
            }
        }

        private AddNewItemCommand _addNewItemCommand = null;
        public ICommand AddNewItemCommand
        {
            get
            {
                if (_addNewItemCommand == null)
                    _addNewItemCommand = new AddNewItemCommand(this, _addressDomain);
                return _addNewItemCommand;
            }
        }

        private DeleteItemCommand _deleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                    _deleteItemCommand = new DeleteItemCommand(this, _addressDomain);
                return _deleteItemCommand;
            }
        }

        public AddressViewModel()
        {
            AddressModel = new AddressModel();
            _addressDomain = new AddressDomain();
            TownList = new List<TownItemModel>();
            IList<TownDto> towns = _addressDomain.GetTowns();

            foreach (TownDto townDto in towns)
                TownList.Add(townDto.ToModel());

            RefreshAddressList();

            ItemsView = CollectionViewSource.GetDefaultView(AddressModel.Addresses);
            ItemsView.Filter = x => Filter(x as AddressItemModel);
        }

        private bool Filter(AddressItemModel itemModel)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return itemModel != null &&
                 ((itemModel.Street ?? string.Empty).ToLower().Contains(searchstring) ||
                  (itemModel.Town.Name ?? string.Empty).ToLower().Contains(searchstring));
        }

        public void RefreshAddressList()
        {
            IList<AddressDto> addressDtoList = _addressDomain.GetAddresses();

            if (AddressModel.Addresses != null)
                AddressModel.Addresses.Clear();
            else
                AddressModel.Addresses = new ObservableCollection<AddressItemModel>();

            foreach (AddressDto addressDto in addressDtoList)
                AddressModel.Addresses.Add(addressDto.ToModel());
        }
    }
}
