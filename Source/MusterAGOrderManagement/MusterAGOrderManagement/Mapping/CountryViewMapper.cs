using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Address;

namespace MusterAGOrderManagement.Mapping
{
    internal static class CountryViewMapper
    {
        public static CountryItemModel ToModel(this CountryDto countryDto)
        {
            if (countryDto == null)
                return null;

            CountryItemModel countryModel = new CountryItemModel();
            countryModel.Id = countryDto.Id;
            countryModel.Name = countryDto.Name;

            return countryModel;
        }

        public static CountryDto ToDto(this CountryItemModel countryModel)
        {
            if (countryModel == null)
                return null;

            CountryDto countryDto = new CountryDto();
            countryDto.Id = countryModel.Id;
            countryDto.Name = countryModel.Name;

            return countryDto;
        }
    }
}
