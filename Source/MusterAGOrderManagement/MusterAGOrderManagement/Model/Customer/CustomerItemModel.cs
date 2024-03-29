﻿using MusterAGOrderManagement.Model.Address;

namespace MusterAGOrderManagement.Model.Customer
{
    internal class CustomerItemModel
    {
        public int Id { get; set; }
        public string CustomerNr { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Password { get; set; }
        public int AddressId { get; set; }
        public AddressItemModel Address { get; set; }
    }
}
