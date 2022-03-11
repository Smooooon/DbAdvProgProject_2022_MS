using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Domain
{
    public class OrderDomain
    {
        public OrderDataService _orderDataService = new OrderDataService();

        public IList<OrderDto> GetOrders()
        {
            IList<OrderDto> orderDtoList = new List<OrderDto>();

            IList<OrderDao> orderDaoList = _orderDataService.GetAll();

            foreach (OrderDao orderDao in orderDaoList)
            {
                //GetArticleToPosition(){

                //}

                orderDtoList.Add(orderDao.ToDto());
            }

            return orderDtoList;
        }

        public bool UpdateOrders(IList<OrderDto> orderDtoList)
        {
            bool success = true;

            foreach (OrderDto orderDto in orderDtoList)
            {
                OrderDao orderDao = orderDto.ToDao();
                OrderDao updatedOrderDao = _orderDataService.Update(orderDao);

                if (updatedOrderDao == null)
                    success = false;
            }

            return success;
        }

        public OrderDto CreateOrder(OrderDto orderDto)
        {
            OrderDao orderDao = orderDto.ToDao();
            OrderDao createdOrderDao = _orderDataService.Create(orderDao);

            return createdOrderDao.ToDto();
        }

        public bool DeleteOrder(int orderIdToDelete)
        {
            return _orderDataService.Delete(orderIdToDelete);
        }
    }
}
