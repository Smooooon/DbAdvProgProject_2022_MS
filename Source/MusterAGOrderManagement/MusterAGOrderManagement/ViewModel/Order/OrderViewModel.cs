using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Customer;
using MusterAGOrderManagement.Model.Order;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Order
{
    internal class OrderViewModel : BaseViewModel
    {
        public OrderModel OrderModel { get; set; }
        private OrderDomain _orderDomain;
        private CustomerDomain _customerDomain;

        public IList<CustomerItemModel> CustomerList { get; set; }

        private SaveAllItemCommand _saveAllItemCommand = null;
        public ICommand SaveAllItemCommand
        {
            get
            {
                if (_saveAllItemCommand == null)
                    _saveAllItemCommand = new SaveAllItemCommand(this, _orderDomain);
                return _saveAllItemCommand;
            }
        }

        private AddNewItemCommand _addNewItemCommand = null;
        public ICommand AddNewItemCommand
        {
            get
            {
                if (_addNewItemCommand == null)
                    _addNewItemCommand = new AddNewItemCommand(this, _orderDomain);
                return _addNewItemCommand;
            }
        }

        private DeleteItemCommand _deleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                    _deleteItemCommand = new DeleteItemCommand(this, _orderDomain);
                return _deleteItemCommand;
            }
        }

        public OrderViewModel()
        {
            OrderModel = new OrderModel();
            _orderDomain = new OrderDomain();
            _customerDomain = new CustomerDomain();
            CustomerList = new List<CustomerItemModel>();
            IList<CustomerDto> customers = _customerDomain.GetCustomers();

            foreach (CustomerDto customerDto in customers)
                CustomerList.Add(customerDto.ToModel());

            RefreshOrderList();

            ItemsView = CollectionViewSource.GetDefaultView(OrderModel.Orders);
            ItemsView.Filter = x => Filter(x as OrderItemModel);
        }

        private bool Filter(OrderItemModel itemModel)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return itemModel != null &&
                 (itemModel.Ordered.ToString().ToLower().Contains(searchstring) ||
                  (itemModel.Customer.Name ?? string.Empty).ToLower().Contains(searchstring));
        }

        public void RefreshOrderList()
        {
            IList<OrderDto> orderDtoList = _orderDomain.GetOrders();

            if (OrderModel.Orders != null)
                OrderModel.Orders.Clear();
            else
                OrderModel.Orders = new ObservableCollection<OrderItemModel>();

            foreach (OrderDto orderDto in orderDtoList)
                OrderModel.Orders.Add(orderDto.ToModel());
        }
    }
}
