using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class AddressDomainMapper
    {
        public static AddressDao ToDao(this AddressDto addressDto)
        {
            if (addressDto == null)
                return null;

            AddressDao addressDao = new AddressDao();
            addressDao.Id = addressDto.Id;
            addressDao.Street = addressDto.Street;
            addressDao.TownId = addressDto.TownId;
            addressDao.Town = addressDto.Town.ToDao();

            return addressDao;
        }

        public static AddressDto ToDto(this AddressDao addressDao)
        {
            if (addressDao == null)
                return null;

            AddressDto addressDto = new AddressDto();
            addressDto.Id = addressDao.Id;
            addressDto.Street = addressDao.Street;
            addressDto.TownId = addressDao.TownId;
            addressDto.Town = addressDao.Town.ToDto();

            return addressDto;
        }
    }
}
