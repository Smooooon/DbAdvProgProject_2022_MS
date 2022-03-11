using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Address;

namespace MusterAGOrderManagement.Mapping
{
    internal static class TownViewMapper
    {
        public static TownItemModel ToModel(this TownDto townDto)
        {
            if (townDto == null)
                return null;

            TownItemModel townModel = new TownItemModel();
            townModel.Id = townDto.Id;
            townModel.PLZ = townDto.PLZ;
            townModel.Name = townDto.Name;
            townModel.CountryId = townDto.CountryId;
            townModel.Country = townDto.Country.ToModel();

            return townModel;
        }

        public static TownDto ToDto(this TownItemModel townModel)
        {
            if (townModel == null)
                return null;

            TownDto townDto = new TownDto();
            townDto.Id = townModel.Id;
            townDto.PLZ = townModel.PLZ;
            townDto.Name = townModel.Name;
            townDto.CountryId = townModel.CountryId;
            townDto.Country = townModel.Country.ToDto();

            return townDto;
        }
    }
}
