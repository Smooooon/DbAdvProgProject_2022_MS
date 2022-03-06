using MusterAG.BusinessLogic.Domain;
using MusterAGOrderManagement.Model.Order;
using System;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Order
{
    internal class DeleteItemCommand : ICommand
    {
        private OrderViewModel _orderViewModel;
        private OrderDomain _orderDomain;

        public event EventHandler? CanExecuteChanged;

        public DeleteItemCommand(OrderViewModel orderViewModel, OrderDomain orderDomain)
        {
            _orderViewModel = orderViewModel;
            _orderDomain = orderDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is OrderItemModel)
            {
                OrderItemModel articleItemModel = (OrderItemModel)parameter;
                _orderDomain.DeleteOrder(articleItemModel.Id);

                _orderViewModel.RefreshOrderList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
