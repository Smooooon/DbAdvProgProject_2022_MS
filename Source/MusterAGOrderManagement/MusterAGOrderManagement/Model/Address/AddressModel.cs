using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Address
{
    internal class AddressModel : BaseModel
    {
        private ObservableCollection<AddressItemModel>? _addresses { get; set; }
        public ObservableCollection<AddressItemModel> Addresses
        {
            get { return _addresses; }
            set
            {
                _addresses = value;
                OnPropertyChanged();
            }
        }
        private AddressItemModel _selectedItem { get; set; }
        public AddressItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TownItemModel>? _townList { get; set; }
        public ObservableCollection<TownItemModel> TownList
        {
            get { return _townList; }
            set
            {
                _townList = value;
                OnPropertyChanged();
            }
        }
    }
}
