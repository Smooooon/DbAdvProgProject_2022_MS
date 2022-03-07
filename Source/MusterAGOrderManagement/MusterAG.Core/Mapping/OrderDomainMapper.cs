using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class OrderDomainMapper
    {
        public static OrderDao ToDao(this OrderDto orderDto)
        {
            if (orderDto == null)
                return null;

            OrderDao orderDao = new OrderDao();
            orderDao.Id = orderDto.Id;
            orderDao.Ordered = orderDto.Ordered;
            orderDao.CustomerId = orderDto.CustomerId;
            orderDao.Customer = orderDto.Customer.ToDao();

            return orderDao;
        }

        public static OrderDto ToDto(this OrderDao orderDao)
        {
            if (orderDao == null)
                return null;

            OrderDto orderDto = new OrderDto();
            orderDto.Id = orderDao.Id;
            orderDto.Ordered = orderDao.Ordered;
            orderDto.CustomerId = orderDao.CustomerId;
            orderDto.Customer = orderDao.Customer.ToDto();

            return orderDto;
        }
    }
}
