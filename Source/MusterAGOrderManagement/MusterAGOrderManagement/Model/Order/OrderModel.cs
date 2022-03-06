using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Order
{
    internal class OrderModel
    {
        public ObservableCollection<OrderItemModel>? Orders { get; set; }
        public OrderItemModel SelectedItem { get; set; }
    }
}
