using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Address;

namespace MusterAGOrderManagement.Mapping
{
    internal static class AddressViewMapper
    {
        public static AddressItemModel ToModel(this AddressDto addressDto)
        {
            if (addressDto == null)
                return null;

            AddressItemModel addressModel = new AddressItemModel();
            addressModel.Id = addressDto.Id;
            addressModel.Street = addressDto.Street;
            addressModel.TownId = addressDto.TownId;

            return addressModel;
        }

        public static AddressDto ToDto(this AddressItemModel addressModel)
        {
            if (addressModel == null)
                return null;

            AddressDto addressDto = new AddressDto();
            addressDto.Id = addressModel.Id;
            addressDto.Street = addressModel.Street;
            addressDto.TownId = addressModel.TownId;

            return addressDto;
        }
    }
}
