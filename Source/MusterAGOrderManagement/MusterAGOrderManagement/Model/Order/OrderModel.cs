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
    }
}
