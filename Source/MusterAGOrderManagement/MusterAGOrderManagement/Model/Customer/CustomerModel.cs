using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Customer
{
    internal class CustomerModel
    {
        public ObservableCollection<CustomerItemModel>? Customers { get; set; }
        public CustomerItemModel SelectedItem { get; set; }
    }
}
