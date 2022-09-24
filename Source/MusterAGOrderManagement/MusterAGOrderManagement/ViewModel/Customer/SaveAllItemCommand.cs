using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Customer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Customer
{
    internal class SaveAllItemCommand : ICommand
    {
        private CustomerViewModel _customerViewModel;
        private CustomerDomain _customerDomain;

        public event EventHandler? CanExecuteChanged;

        public SaveAllItemCommand(CustomerViewModel customerViewModel, CustomerDomain customerDomain)
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
            try
            {
                if (parameter is ObservableCollection<CustomerItemModel>)
                {
                    IList<CustomerDto> customerDtoList = new List<CustomerDto>();
                    IList<CustomerItemModel> customerItems = (IList<CustomerItemModel>)parameter;

                    foreach (CustomerItemModel customerItemModel in customerItems)
                    {
                        CustomerDto customerDto = customerItemModel.ToDto();
                        _customerDomain.ValidateCustomer(customerDto);

                        customerDtoList.Add(customerDto);
                    }

                    _customerDomain.UpdateCustomers(customerDtoList);

                    _customerViewModel.RefreshData();
                }
                else
                {
                    throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Eingabe entspricht nicht der Vorgabe! {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern! {ex}");
            }
        }
    }
}
