using MusterAGOrderManagement.Model.Customer;
using System;

namespace MusterAGOrderManagement.Model.Order
{
    internal class OrderItemModel
    {
        public int Id { get; set; }
        public DateTime Ordered { get; set; }
        public int CustomerId { get; set; }
        public CustomerItemModel Customer { get; set; }
    }
}
