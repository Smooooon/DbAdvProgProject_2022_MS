using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;


namespace MusterAG.BusinessLogic.Domain
{
    public class AddressDomain
    {
        public AddressDataService _addressDataService = new AddressDataService();

        public IList<AddressDto> GetAddresses()
        {
            IList<AddressDto> addressDtoList = new List<AddressDto>();

            IList<AddressDao> addressDaoList = _addressDataService.GetAll();

            foreach (AddressDao addressDao in addressDaoList)
                addressDtoList.Add(addressDao.ToDto());

            return addressDtoList;
        }

        public bool UpdateAddresses(IList<AddressDto> addressDtoList)
        {
            bool success = true;

            foreach (AddressDto addressDto in addressDtoList)
            {
                AddressDao addressDao = addressDto.ToDao();
                AddressDao updatedAddressDao = _addressDataService.Update(addressDao);

                if (updatedAddressDao == null)
                    success = false;
            }


            return success;
        }

        public AddressDto CreateAddress(AddressDto addressDto)
        {
            AddressDao addressDao = addressDto.ToDao();
            AddressDao createdAddressDao = _addressDataService.Create(addressDao);

            return createdAddressDao.ToDto();
        }

        public bool DeleteAddress(int addressIdToDelete)
        {
            return _addressDataService.Delete(addressIdToDelete);
        }
    }
}
