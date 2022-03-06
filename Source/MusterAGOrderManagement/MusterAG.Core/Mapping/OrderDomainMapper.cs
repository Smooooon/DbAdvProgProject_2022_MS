using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class OrderDomainMapper
    {
        public static OrderDao ToDao(this OrderDto orderDto)
        {
            OrderDao orderDao = new OrderDao();
            orderDao.Id = orderDto.Id;
            orderDao.Ordered = orderDto.Ordered;
            orderDao.CustomerId = orderDto.CustomerId;

            return orderDao;
        }

        public static OrderDto ToDto(this OrderDao orderDao)
        {
            OrderDto orderDto = new OrderDto();
            orderDto.Id = orderDao.Id;
            orderDto.Ordered = orderDao.Ordered;
            orderDto.CustomerId = orderDao.CustomerId;

            return orderDto;
        }
    }
}
