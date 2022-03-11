using MusterAG.BusinessLogic.Domain;
using System;
using System.Windows.Input;
using MusterAGOrderManagement.Mapping;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Customer;

namespace MusterAGOrderManagement.ViewModel.Customer
{
    internal class AddNewItemCommand : ICommand
    {
        private CustomerViewModel _customerViewModel;
        private CustomerDomain _customerDomain;

        public event EventHandler? CanExecuteChanged;

        public AddNewItemCommand(CustomerViewModel customerViewModel, CustomerDomain customerDomain)
        {
            _customerViewModel = customerViewModel;
            _customerDomain = customerDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;

        }

        public void Execute(object? parameter)
        {
            if(parameter == null)
                CreateNewEmptyItem(new CustomerItemModel());
            else if (parameter is CustomerItemModel)
                CreateNewEmptyItem((CustomerItemModel)parameter);
            else
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
        }

        /// <summary>
        /// Erstelle leeres Item
        /// </summary>
        /// <param name="customerItemModel"></param>
        private void CreateNewEmptyItem(CustomerItemModel customerItemModel)
        {
            customerItemModel.Id = 0;
            customerItemModel.Name = string.Empty;
            customerItemModel.Email = string.Empty;
            customerItemModel.Website = string.Empty;
            customerItemModel.Password = string.Empty;
            customerItemModel.AddressId = 1;
            CustomerDto newItemDto = _customerDomain.CreateCustomer(customerItemModel.ToDto());
            CustomerItemModel newItem = newItemDto.ToModel();

            _customerViewModel.RefreshData();

            CustomerItemModel newSelectedItem = new CustomerItemModel();
            newSelectedItem.Id = newItem.Id;
            newSelectedItem.Name = newItem.Name;
            newSelectedItem.Email = newItem.Email;
            newSelectedItem.Website = newItem.Website;
            newSelectedItem.Password = newItem.Password;
            newSelectedItem.AddressId = newItem.AddressId;

            _customerViewModel.CustomerModel.SelectedItem = newSelectedItem;
        }
    }
}
