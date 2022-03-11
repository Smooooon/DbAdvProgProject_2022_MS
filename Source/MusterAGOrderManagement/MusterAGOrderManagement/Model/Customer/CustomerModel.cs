using MusterAGOrderManagement.Model.Address;
using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Customer
{
    internal class CustomerModel : BaseModel
    {
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
        private CustomerItemModel _selectedItem { get; set; }
        public CustomerItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AddressItemModel>? _addressList { get; set; }
        public ObservableCollection<AddressItemModel> AddressList
        {
            get { return _addressList; }
            set
            {
                _addressList = value;
                OnPropertyChanged();
            }
        }
    }
}
