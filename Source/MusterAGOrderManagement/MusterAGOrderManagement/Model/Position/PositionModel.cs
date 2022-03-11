using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Position
{
    internal class PositionModel : BaseModel
    {
        private ObservableCollection<PositionItemModel>? _positions { get; set; }
        public ObservableCollection<PositionItemModel> Positions
        {
            get { return _positions; }
            set
            {
                _positions = value;
                OnPropertyChanged();
            }
        }
        private PositionItemModel _selectedItem { get; set; }
        public PositionItemModel SelectedItem
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
