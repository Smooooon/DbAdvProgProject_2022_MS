using MusterAG.BusinessLogic.Domain;
using System;
using System.Windows.Input;
using MusterAGOrderManagement.Mapping;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Order;

namespace MusterAGOrderManagement.ViewModel.Order
{
    internal class AddNewItemCommand : ICommand
    {
        private OrderViewModel _orderViewModel;
        private OrderDomain _orderDomain;

        public event EventHandler? CanExecuteChanged;

        public AddNewItemCommand(OrderViewModel orderViewModel, OrderDomain orderDomain)
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
            if(parameter == null)
                CreateNewEmptyItem(new OrderItemModel());
            else if (parameter is OrderItemModel)
                CreateNewEmptyItem((OrderItemModel)parameter);
            else
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
        }

        /// <summary>
        /// Erstelle leeres Item
        /// </summary>
        /// <param name="orderItemModel"></param>
        private void CreateNewEmptyItem(OrderItemModel orderItemModel)
        {
            orderItemModel.Id = 0;
            orderItemModel.Ordered = DateTime.Now;
            orderItemModel.CustomerId = 1;
            OrderDto newItemDto = _orderDomain.CreateOrder(orderItemModel.ToDto());
            OrderItemModel newItem = newItemDto.ToModel();

            _orderViewModel.RefreshData();

            OrderItemModel newSelectedItem = new OrderItemModel();
            newSelectedItem.Id = newItem.Id;
            newSelectedItem.Ordered = newItem.Ordered;
            newSelectedItem.CustomerId = newItem.CustomerId;

            _orderViewModel.OrderModel.SelectedItem = newSelectedItem;
        }
    }
}
