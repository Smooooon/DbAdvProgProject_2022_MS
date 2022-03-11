using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Order;

namespace MusterAGOrderManagement.Mapping
{
    internal static class OrderViewMapper
    {
        public static OrderItemModel ToModel(this OrderDto orderDto)
        {
            if (orderDto == null)
                return null;

            OrderItemModel orderModel = new OrderItemModel();
            orderModel.Id = orderDto.Id;
            orderModel.Ordered = orderDto.Ordered;
            orderModel.CustomerId = orderDto.CustomerId;
            orderModel.Customer = orderDto.Customer.ToModel();

            return orderModel;
        }

        public static OrderDto ToDto(this OrderItemModel orderModel)
        {
            if (orderModel == null)
                return null;

            OrderDto orderDto = new OrderDto();
            orderDto.Id = orderModel.Id;
            orderDto.Ordered = orderModel.Ordered;
            orderDto.CustomerId = orderModel.CustomerId;
            orderDto.Customer = orderModel.Customer.ToDto();

            return orderDto;
        }
    }
}
