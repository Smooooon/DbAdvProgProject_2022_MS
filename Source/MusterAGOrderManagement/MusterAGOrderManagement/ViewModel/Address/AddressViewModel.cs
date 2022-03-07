using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Address;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Address
{
    internal class AddressViewModel : BaseViewModel
    {
        AddressModel _addressModel = new AddressModel();
        private AddressDomain _addressDomain;

        public IList<TownItemModel> TownList { get; set; }

        public ObservableCollection<AddressItemModel> AddressList
        {
            get { return _addressModel.Addresses; }
            set
            {
                _addressModel.Addresses = value;
                OnPropertyChanged();
            }
        }

        public AddressItemModel SelectedItem
        {
            get { return _addressModel.SelectedItem; }
            set
            {
                _addressModel.SelectedItem = value;
                OnPropertyChanged();
            }
        }

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
            _addressDomain = new AddressDomain();
            TownList = new List<TownItemModel>();
            IList<TownDto> towns = _addressDomain.GetTowns();

            foreach (TownDto townDto in towns)
                TownList.Add(townDto.ToModel());

            RefreshAddressList();
        }

        public void RefreshAddressList()
        {
            IList<AddressDto> addressDtoList = _addressDomain.GetAddresses();

            if (AddressList != null)
                AddressList.Clear();
            else
                AddressList = new ObservableCollection<AddressItemModel>();

            foreach (AddressDto addressDto in addressDtoList)
                AddressList.Add(addressDto.ToModel());
        }
    }
}
