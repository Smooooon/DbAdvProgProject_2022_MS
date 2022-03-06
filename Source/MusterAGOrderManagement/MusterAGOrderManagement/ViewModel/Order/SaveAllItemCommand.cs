using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Order
{
    internal class SaveAllItemCommand : ICommand
    {
        private OrderViewModel _orderViewModel;
        private OrderDomain _orderDomain;

        public event EventHandler? CanExecuteChanged;

        public SaveAllItemCommand(OrderViewModel orderViewModel, OrderDomain orderDomain)
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
            if (parameter is ObservableCollection<OrderItemModel>)
            {
                IList<OrderDto> orderDtoList = new List<OrderDto>();
                IList<OrderItemModel> orderItems = (IList<OrderItemModel>)parameter;

                foreach (OrderItemModel orderItemModel in orderItems)
                    orderDtoList.Add(orderItemModel.ToDto());

                _orderDomain.UpdateOrders(orderDtoList);

                _orderViewModel.RefreshOrderList();
            }
            else
            {
                throw new ArgumentException($"Button Fehlfunktion, keine korrekten Daten verfügbar {parameter}");
            }
        }
    }
}
