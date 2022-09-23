using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Domain
{
    public class CustomerDomain
    {
        private CustomerDataService _customerDataService = new CustomerDataService();
        private AddressDomain _addressDomain = new AddressDomain();

        public IList<CustomerDto> GetCustomers()
        {
            IList<CustomerDto> customerDtoList = new List<CustomerDto>();

            IList<CustomerDao> customerDaoList = _customerDataService.GetAll();

            foreach (CustomerDao customerDao in customerDaoList)
                customerDtoList.Add(customerDao.ToDto());

            return customerDtoList;
        }

        public CustomerDto GetCustomerTemporal(int id, DateTime temporalQueryTime)
        {
            CustomerDao customerDao = _customerDataService.Get(id, temporalQueryTime);

            //Addresse ist nicht Temporal, desswegen muss sie separat geladen werden
            customerDao.Address = _addressDomain.GetAddress(customerDao.AddressId).ToDao();

            return customerDao.ToDto();
        }

        public IList<CustomerDto> GetCustomersTemporal(DateTime temporalQueryTime)
        {
            IList<CustomerDto> customerDtoList = new List<CustomerDto>();

            IList<CustomerDao> customerDaoList = _customerDataService.GetAllTemporal(temporalQueryTime);

            foreach (CustomerDao customerDao in customerDaoList)
            {
                //Addresse ist nicht Temporal, desswegen muss sie separat geladen werden
                customerDao.Address = _addressDomain.GetAddress(customerDao.AddressId).ToDao();
                customerDtoList.Add(customerDao.ToDto());
            }

            return customerDtoList;
        }

        public bool UpdateCustomers(IList<CustomerDto> customerDtoList)
        {
            bool success = true;

            foreach (CustomerDto customerDto in customerDtoList)
            {
                CustomerDao customerDao = customerDto.ToDao();
                CustomerDao updatedCustomerDao = _customerDataService.Update(customerDao);

                if (updatedCustomerDao == null)
                    success = false;
            }


            return success;
        }

        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            CustomerDao customerDao = customerDto.ToDao();
            CustomerDao createdCustomerDao = _customerDataService.Create(customerDao);

            return createdCustomerDao.ToDto();
        }

        public bool DeleteCustomer(int customerIdToDelete)
        {
            return _customerDataService.Delete(customerIdToDelete);
        }
    }
}
