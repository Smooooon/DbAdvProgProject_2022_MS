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

        public static TownDao ToDao(this TownDto townDto)
        {
            if (townDto == null)
                return null;

            TownDao townDao = new TownDao();
            townDao.Id = townDto.Id;
            townDao.PLZ = townDto.PLZ;
            townDao.Name = townDto.Name;
            townDao.CountryId = townDto.CountryId;
            townDao.Country = townDto.Country.ToDao();

            return townDao;
        }

        public static TownDto ToDto(this TownDao townDao)
        {
            if (townDao == null)
                return null;

            TownDto townDto = new TownDto();
            townDto.Id = townDao.Id;
            townDto.PLZ = townDao.PLZ;
            townDto.Name = townDao.Name;
            townDto.CountryId = townDao.CountryId;
            townDto.Country = townDao.Country.ToDto();

            return townDto;
        }

        public static CountryDao ToDao(this CountryDto countryDto)
        {
            if (countryDto == null)
                return null;

            CountryDao countryDao = new CountryDao();
            countryDao.Id = countryDto.Id;
            countryDao.Name = countryDto.Name;

            return countryDao;
        }

        public static CountryDto ToDto(this CountryDao countryDao)
        {
            if (countryDao == null)
                return null;

            CountryDto countryDto = new CountryDto();
            countryDto.Id = countryDao.Id;
            countryDto.Name = countryDao.Name;

            return countryDto;
        }
    }
}
