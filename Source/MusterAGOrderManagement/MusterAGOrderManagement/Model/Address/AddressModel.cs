using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Address
{
    internal class AddressModel
    {
        public ObservableCollection<AddressItemModel>? Addresses { get; set; }
        public AddressItemModel SelectedItem { get; set; }
    }
}
