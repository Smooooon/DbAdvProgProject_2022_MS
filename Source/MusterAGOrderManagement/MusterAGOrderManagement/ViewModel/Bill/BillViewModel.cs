using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Mapping;
using MusterAGOrderManagement.Model.Address;
using MusterAGOrderManagement.Model.Bill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace MusterAGOrderManagement.ViewModel.Bill
{
    internal class BillViewModel : BaseViewModel
    {
        public BillModel BillModel { get; set; }
        private OrderDomain _orderDomain;
        private CustomerDomain _customerDomain;

        public BillViewModel()
        {
            BillModel = new BillModel();
            _customerDomain = new CustomerDomain();
            _orderDomain = new OrderDomain();

            RefreshData();

            ItemsView = CollectionViewSource.GetDefaultView(BillModel.Bills);
            ItemsView.Filter = x => Filter(x as BillItemModel);
        }

        private bool Filter(BillItemModel itemModel)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return itemModel != null &&
                 (itemModel.CustomerId.ToString().ToLower().Contains(searchstring) ||
                 (itemModel.Name ?? string.Empty).ToLower().Contains(searchstring) ||
                 (itemModel.Street ?? string.Empty).ToLower().Contains(searchstring) ||
                 itemModel.PLZ.ToString().ToLower().Contains(searchstring) ||
                 (itemModel.TownName ?? string.Empty).ToLower().Contains(searchstring) ||
                 (itemModel.CountryName ?? string.Empty).ToLower().Contains(searchstring) ||
                 itemModel.OrderId.ToString().ToLower().Contains(searchstring) ||
                 itemModel.Ordered.ToString().ToLower().Contains(searchstring) ||
                 itemModel.AmountNeto.ToString().ToLower().Contains(searchstring) ||
                 itemModel.AmountBrutto.ToString().ToLower().Contains(searchstring));
        }

        public void RefreshData()
        {
            decimal mwst = 7.77M;
            BillModel.Bills = new ObservableCollection<BillItemModel>();
            IList<CustomerDto> customerDtoList = new List<CustomerDto>();

            IList<OrderDto> orderDtoList = _orderDomain.GetOrders();
            foreach(OrderDto orderDto in orderDtoList)
            {
                CustomerDto customer = _customerDomain.GetCustomerTemporal(orderDto.CustomerId, orderDto.Ordered);

                //Berechnung Betrag
                decimal amountNeto = orderDto.Positions.Sum(p => p.Article.Price * p.Quantity);
                decimal amountBrutto = orderDto.Positions.Sum(p => (p.Article.Price + GetMwst(p.Article.Price, mwst)) * p.Quantity);

                BillItemModel billItem = new BillItemModel()
                {
                    CustomerId = orderDto.CustomerId,
                    Name = customer.Name,
                    Street = customer.Address?.Street,
                    PLZ = customer.Address?.Town?.PLZ ?? 0,
                    TownName = customer.Address?.Town?.Name,
                    CountryName = customer.Address?.Town?.Country?.Name,
                    OrderId = orderDto.Id,
                    Ordered = orderDto.Ordered,
                    AmountNeto = Math.Round(amountNeto, 2),
                    AmountBrutto = Math.Round(amountBrutto, 2),
                };

                BillModel.Bills.Add(billItem);
            }
        }

        private decimal GetMwst(decimal amountNeto, decimal rate)
        {
            return amountNeto / 100 * rate;
        }
    }
}
