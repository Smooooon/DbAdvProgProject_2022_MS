using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Model.Order;
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

        private ObservableCollection<ArticleItemModel>? _articleList { get; set; }
        public ObservableCollection<ArticleItemModel> ArticleList
        {
            get { return _articleList; }
            set
            {
                _articleList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<OrderItemModel>? _orderList { get; set; }
        public ObservableCollection<OrderItemModel> OrderList
        {
            get { return _orderList; }
            set
            {
                _orderList = value;
                OnPropertyChanged();
            }
        }
    }
}
