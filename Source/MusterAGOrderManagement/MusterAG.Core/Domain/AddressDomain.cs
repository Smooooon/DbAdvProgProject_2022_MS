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

        public AddressDto GetAddress(int id)
        {
            AddressDao addressDao = _addressDataService.Get(id);

            return addressDao.ToDto();
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

        public IList<TownDto> GetTowns()
        {
            IList<TownDto> townDtoList = new List<TownDto>();

            IList<TownDao> townDaoList = _addressDataService.GetAllTown();

            foreach (TownDao townDao in townDaoList)
                townDtoList.Add(townDao.ToDto());

            return townDtoList;
        }
    }
}
