using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Model.Order;
using MusterAGOrderManagement.Model.Position;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Position
{
    internal class PositionViewModel : BaseViewModel
    {
        PositionModel _positionModel = new PositionModel();
        private PositionDomain _positionDomain;
        private ArticleDomain _articleDomain;
        private OrderDomain _orderDomain;

        public IList<ArticleItemModel> ArticleList { get; set; }
        public IList<OrderItemModel> OrderList { get; set; }

        public ObservableCollection<PositionItemModel> PositionList
        {
            get { return _positionModel.Positions; }
            set
            {
                _positionModel.Positions = value;
                OnPropertyChanged();
            }
        }

        public PositionItemModel SelectedItem
        {
            get { return _positionModel.SelectedItem; }
            set
            {
                _positionModel.SelectedItem = value;
                OnPropertyChanged();
            }
        }

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
            _positionDomain = new PositionDomain();

            //Artikel
            _articleDomain = new ArticleDomain();
            ArticleList = new List<ArticleItemModel>();
            IList<ArticleDto> article = _articleDomain.GetArticles();

            foreach (ArticleDto articleDto in article)
                ArticleList.Add(articleDto.ToModel());

            //Order
            _orderDomain = new OrderDomain();
            OrderList = new List<OrderItemModel>();
            IList<OrderDto> orders = _orderDomain.GetOrders();

            foreach (OrderDto orderDto in orders)
                OrderList.Add(orderDto.ToModel());

            RefreshPositionList();
        }

        public void RefreshPositionList()
        {
            IList<PositionDto> positionDtoList = _positionDomain.GetPositions();

            if (PositionList != null)
                PositionList.Clear();
            else
                PositionList = new ObservableCollection<PositionItemModel>();

            foreach (PositionDto positionDto in positionDtoList)
                PositionList.Add(positionDto.ToModel());
        }
    }
}
