using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Order;

namespace MusterAGOrderManagement.Mapping
{
    internal static class OrderViewMapper
    {
        public static OrderItemModel ToModel(this OrderDto orderDto)
        {
            OrderItemModel orderModel = new OrderItemModel();
            orderModel.Id = orderDto.Id;
            orderModel.Ordered = orderDto.Ordered;
            orderModel.CustomerId = orderDto.CustomerId;

            return orderModel;
        }

        public static OrderDto ToDto(this OrderItemModel orderModel)
        {
            OrderDto orderDto = new OrderDto();
            orderDto.Id = orderModel.Id;
            orderDto.Ordered = orderModel.Ordered;
            orderDto.CustomerId = orderModel.CustomerId;

            return orderDto;
        }
    }
}
