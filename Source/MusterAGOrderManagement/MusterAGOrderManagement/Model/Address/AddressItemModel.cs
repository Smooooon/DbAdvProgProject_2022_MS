using MusterAG.DataAccessLayer.Dao;

namespace MusterAGOrderManagement.Model.Address
{
    internal class AddressItemModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int TownId { get; set; }
        public virtual TownItemModel Town { get; set; }
    }
}
