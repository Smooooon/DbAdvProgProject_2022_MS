using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class TownDomainMapper
    {
        public static TownDao ToDao(this TownDto townDto)
        {
            if (townDto == null)
                return null;

            TownDao townDao = new TownDao();
            townDao.Id = townDto.Id;
            townDao.PLZ = townDto.PLZ;
            townDao.Name = townDto.Name;
            townDao.CountryId = townDto.CountryId;

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

            return townDto;
        }
    }
}
