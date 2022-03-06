using System;

namespace MusterAGOrderManagement.Model.Order
{
    internal class OrderItemModel
    {
        public int Id { get; set; }
        public DateTime Ordered { get; set; }
        public int CustomerId { get; set; }
    }
}
