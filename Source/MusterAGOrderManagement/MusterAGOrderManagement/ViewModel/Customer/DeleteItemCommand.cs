using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Model.Customer;
using System;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Customer
{
    internal class DeleteItemCommand : ICommand
    {
        private CustomerViewModel _customerViewModel;
        private CustomerDomain _customerDomain;

        public event EventHandler? CanExecuteChanged;

        public DeleteItemCommand(CustomerViewModel customerViewModel, CustomerDomain customerDomain)
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
            if (parameter is CustomerItemModel)
            {
                CustomerItemModel customerItemModel = (CustomerItemModel)parameter;
                _customerDomain.DeleteCustomer(customerItemModel.Id);

                _customerViewModel.RefreshCustomerList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
