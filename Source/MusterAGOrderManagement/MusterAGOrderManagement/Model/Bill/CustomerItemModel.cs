using System;

namespace MusterAGOrderManagement.Model.Bill
{
    internal class BillItemModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string? Street { get; set; }
        public int PLZ { get; set; }
        public string? TownName { get; set; }
        public string? CountryName { get; set; }
        public DateTime Ordered { get; set; }
        public int OrderId { get; set; }
        public decimal AmountNeto { get; set; }
        public decimal AmountBrutto { get; set; }
    }
}
