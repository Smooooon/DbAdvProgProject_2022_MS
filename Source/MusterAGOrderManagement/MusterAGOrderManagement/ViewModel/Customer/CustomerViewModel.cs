﻿using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Address;
using MusterAGOrderManagement.Model.Customer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Customer
{
    internal class CustomerViewModel : BaseViewModel
    {
        CustomerModel _customerModel = new CustomerModel();
        private CustomerDomain _customerDomain;
        private AddressDomain _addressDomain;

        public IList<AddressItemModel> AddressList { get; set; }

        public ObservableCollection<CustomerItemModel> CustomerList
        {
            get { return _customerModel.Customers; }
            set
            {
                _customerModel.Customers = value;
                OnPropertyChanged();
            }
        }

        public CustomerItemModel SelectedItem
        {
            get { return _customerModel.SelectedItem; }
            set
            {
                _customerModel.SelectedItem = value;
                OnPropertyChanged();
            }
        }

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

        public CustomerViewModel()
        {
            _customerDomain = new CustomerDomain();
            _addressDomain = new AddressDomain();
            AddressList = new List<AddressItemModel>();
            IList<AddressDto> addresses = _addressDomain.GetAddresses();

            foreach (AddressDto addressDto in addresses)
                AddressList.Add(addressDto.ToModel());

            RefreshCustomerList();
        }

        public void RefreshCustomerList()
        {
            IList<CustomerDto> customerDtoList = _customerDomain.GetCustomers();

            if (CustomerList != null)
                CustomerList.Clear();
            else
                CustomerList = new ObservableCollection<CustomerItemModel>();

            foreach (CustomerDto customerDto in customerDtoList)
                CustomerList.Add(customerDto.ToModel());
        }
    }
}
