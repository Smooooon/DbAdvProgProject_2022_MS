using MusterAGOrderManagement.Model.Customer;
using MusterAGOrderManagement.Model.Order;
using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Bill 
{ 
    internal class BillModel : BaseModel
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

        private ObservableCollection<CustomerItemModel>? _customers { get; set; }
        public ObservableCollection<CustomerItemModel> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BillItemModel>? _bills { get; set; }
        public ObservableCollection<BillItemModel> Bills
        {
            get { return _bills; }
            set
            {
                _bills = value;
                OnPropertyChanged();
            }
        }
    }
}
