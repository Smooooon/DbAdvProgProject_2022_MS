using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Address;
using MusterAGOrderManagement.Model.Customer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Customer
{
    internal class CustomerViewModel : BaseViewModel
    {
        public CustomerModel CustomerModel { get; set; }
        private CustomerDomain _customerDomain;
        private AddressDomain _addressDomain;

        private SaveAllItemCommand _saveAllItemCommand = null;
        public ICommand SaveAllItemCommand
        {
            get
            {
                if (_saveAllItemCommand == null)
                    _saveAllItemCommand = new SaveAllItemCommand(this, _customerDomain);
                return _saveAllItemCommand;
            }
        }

        private AddNewItemCommand _addNewItemCommand = null;
        public ICommand AddNewItemCommand
        {
            get
            {
                if (_addNewItemCommand == null)
                    _addNewItemCommand = new AddNewItemCommand(this, _customerDomain);
                return _addNewItemCommand;
            }
        }

        private DeleteItemCommand _deleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                    _deleteItemCommand = new DeleteItemCommand(this, _customerDomain);
                return _deleteItemCommand;
            }
        }

        private ImportCommand _importCommand = null;
        public ICommand ImportCommand
        {
            get
            {
                if (_importCommand == null)
                    _importCommand = new ImportCommand(this, _customerDomain);
                return _importCommand;
            }
        }

        private ExportCommand _exportCommand = null;
        public ICommand ExportCommand
        {
            get
            {
                if (_exportCommand == null)
                    _exportCommand = new ExportCommand(this, _customerDomain);
                return _exportCommand;
            }
        }

        private DateTime? _datetimeForTemporal = null;
        public DateTime? DateTimeForTemporal
        {
            get
            {

                return _datetimeForTemporal;
            }
            set
            {
                _datetimeForTemporal = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            CustomerModel = new CustomerModel();
            _customerDomain = new CustomerDomain();
            _addressDomain = new AddressDomain();

            RefreshData();

            ItemsView = CollectionViewSource.GetDefaultView(CustomerModel.Customers);
            ItemsView.Filter = x => Filter(x as CustomerItemModel);
        }

        private bool Filter(CustomerItemModel itemModel)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return itemModel != null &&
                 ((itemModel.Name ?? string.Empty).ToLower().Contains(searchstring) ||
                 (itemModel.Email ?? string.Empty).ToLower().Contains(searchstring) ||
                 (itemModel.Website ?? string.Empty).ToLower().Contains(searchstring) ||
                  (itemModel.Address.Street ?? string.Empty).ToLower().Contains(searchstring));
        }

        public void RefreshData()
        {
            //Customer
            IList<CustomerDto> customerDtoList = _customerDomain.GetCustomers();

            if (CustomerModel.Customers != null)
                CustomerModel.Customers.Clear();
            else
                CustomerModel.Customers = new ObservableCollection<CustomerItemModel>();

            foreach (CustomerDto customerDto in customerDtoList)
                CustomerModel.Customers.Add(customerDto.ToModel());

            //Address
            CustomerModel.AddressList = new ObservableCollection<AddressItemModel>();
            IList<AddressDto> addresses = _addressDomain.GetAddresses();

            foreach (AddressDto addressDto in addresses)
                CustomerModel.AddressList.Add(addressDto.ToModel());
        }
    }
}
