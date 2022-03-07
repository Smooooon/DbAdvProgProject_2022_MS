using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Customer;
using MusterAGOrderManagement.Model.Order;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Order
{
    internal class OrderViewModel : BaseViewModel
    {
        OrderModel _orderModel = new OrderModel();
        private OrderDomain _orderDomain;
        private CustomerDomain _customerDomain;

        public IList<CustomerItemModel> CustomerList { get; set; }

        public ObservableCollection<OrderItemModel> OrderList
        {
            get { return _orderModel.Orders; }
            set
            {
                _orderModel.Orders = value;
                OnPropertyChanged();
            }
        }

        public OrderItemModel SelectedItem
        {
            get { return _orderModel.SelectedItem; }
            set
            {
                _orderModel.SelectedItem = value;
                OnPropertyChanged();
            }
        }

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
            _orderDomain = new OrderDomain();
            _customerDomain = new CustomerDomain();
            CustomerList = new List<CustomerItemModel>();
            IList<CustomerDto> customers = _customerDomain.GetCustomers();

            foreach (CustomerDto customerDto in customers)
                CustomerList.Add(customerDto.ToModel());

            RefreshOrderList();
        }

        public void RefreshOrderList()
        {
            IList<OrderDto> orderDtoList = _orderDomain.GetOrders();

            if (OrderList != null)
                OrderList.Clear();
            else
                OrderList = new ObservableCollection<OrderItemModel>();

            foreach (OrderDto orderDto in orderDtoList)
                OrderList.Add(orderDto.ToModel());
        }
    }
}
