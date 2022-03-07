using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class CustomerDomainMapper
    {
        public static CustomerDao ToDao(this CustomerDto customerDto)
        {
            if (customerDto == null)
                return null;

            CustomerDao customerDao = new CustomerDao();
            customerDao.Id = customerDto.Id;
            customerDao.Name = customerDto.Name;
            customerDao.Email = customerDto.Email;
            customerDao.Website = customerDto.Website;
            customerDao.Password = customerDto.Password;
            customerDao.AddressId = customerDto.AddressId;
            customerDao.Address = customerDto.Address.ToDao();

            return customerDao;
        }

        public static CustomerDto ToDto(this CustomerDao customerDao)
        {
            if (customerDao == null)
                return null;

            CustomerDto customerDto = new CustomerDto();
            customerDto.Id = customerDao.Id;
            customerDto.Name = customerDao.Name;
            customerDto.Email = customerDao.Email;
            customerDto.Website = customerDao.Website;
            customerDto.Password = customerDao.Password;
            customerDto.AddressId = customerDao.AddressId;
            customerDto.Address = customerDao.Address.ToDto();

            return customerDto;
        }
    }
}
