using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Model.Order;
using MusterAGOrderManagement.Model.Position;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Position
{
    internal class PositionViewModel : BaseViewModel
    {
        public PositionModel PositionModel { get; set; }
        private PositionDomain _positionDomain;
        private ArticleDomain _articleDomain;
        private OrderDomain _orderDomain;

        private SaveAllItemCommand _saveAllItemCommand = null;
        public ICommand SaveAllItemCommand
        {
            get
            {
                if (_saveAllItemCommand == null)
                    _saveAllItemCommand = new SaveAllItemCommand(this, _positionDomain);
                return _saveAllItemCommand;
            }
        }

        private AddNewItemCommand _addNewItemCommand = null;
        public ICommand AddNewItemCommand
        {
            get
            {
                if (_addNewItemCommand == null)
                    _addNewItemCommand = new AddNewItemCommand(this, _positionDomain);
                return _addNewItemCommand;
            }
        }

        private DeleteItemCommand _deleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                    _deleteItemCommand = new DeleteItemCommand(this, _positionDomain);
                return _deleteItemCommand;
            }
        }

        public PositionViewModel()
        {
            PositionModel = new PositionModel();
            _positionDomain = new PositionDomain();
            _articleDomain = new ArticleDomain();
            _orderDomain = new OrderDomain();

            RefreshData();

            ItemsView = CollectionViewSource.GetDefaultView(PositionModel.Positions);
            ItemsView.Filter = x => Filter(x as PositionItemModel);
        }

        private bool Filter(PositionItemModel itemModel)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return itemModel != null &&
                 (itemModel.Quantity.ToString().ToLower().Contains(searchstring) ||
                  (itemModel.Article.Name ?? string.Empty).ToLower().Contains(searchstring) ||
                  (itemModel.Order.Id.ToString().ToLower().Contains(searchstring)));
        }

        public void RefreshData()
        {
            //Position
            IList<PositionDto> positionDtoList = _positionDomain.GetPositions();

            if (PositionModel.Positions != null)
                PositionModel.Positions.Clear();
            else
                PositionModel.Positions = new ObservableCollection<PositionItemModel>();

            foreach (PositionDto positionDto in positionDtoList)
                PositionModel.Positions.Add(positionDto.ToModel());

            //Artikel
            PositionModel.ArticleList = new ObservableCollection<ArticleItemModel>();
            IList<ArticleDto> article = _articleDomain.GetArticles();

            foreach (ArticleDto articleDto in article)
                PositionModel.ArticleList.Add(articleDto.ToModel());

            //Order
            PositionModel.OrderList = new ObservableCollection<OrderItemModel>();
            IList<OrderDto> orders = _orderDomain.GetOrders();

            foreach (OrderDto orderDto in orders)
                PositionModel.OrderList.Add(orderDto.ToModel());
        }
    }
}
