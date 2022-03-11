using MusterAGOrderManagement.Model.Customer;
using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Order
{
    internal class OrderModel : BaseModel
    {
        private ObservableCollection<OrderItemModel>? _orders { get; set; }
        public ObservableCollection<OrderItemModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }
        private OrderItemModel _selectedItem { get; set; }
        public OrderItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CustomerItemModel>? _customerList { get; set; }
        public ObservableCollection<CustomerItemModel> CustomerList
        {
            get { return _customerList; }
            set
            {
                _customerList = value;
                OnPropertyChanged();
            }
        }
    }
}
