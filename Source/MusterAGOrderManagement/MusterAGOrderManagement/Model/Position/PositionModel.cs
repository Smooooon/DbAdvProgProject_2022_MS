using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.Position
{
    internal class PositionModel
    {
        public ObservableCollection<PositionItemModel>? Positions { get; set; }
        public PositionItemModel SelectedItem { get; set; }
    }
}
