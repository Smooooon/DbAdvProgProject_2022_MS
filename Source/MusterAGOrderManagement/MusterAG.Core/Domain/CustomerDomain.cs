using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;
using System.Text.RegularExpressions;

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

        public void ValidateCustomer(CustomerDto customerDto)
        {
            if (!ValidateCustomerNr(customerDto.CustomerNr))
            {
                throw new ArgumentException("The CustomerNr is not valide");
            }

            if (!ValidateEmail(customerDto.Email))
            {
                throw new ArgumentException("The Email is not valide");
            }

            if (!ValidateWebsite(customerDto.Website))
            {
                throw new ArgumentException("The Website is not valide");
            }

            if (!ValidatePassword(customerDto.Password))
            {
                throw new ArgumentException("The Password is not valide");
            }
        }

        private bool ValidateCustomerNr(string email)
        {
            string regex = @"^CU\d{5}$";
            Match? match = Regex.Match(email, regex);

            return match.Success;
        }

        //Die Email Domain-Endung kann beliebig sein z.B. ".xyz"
        private bool ValidateEmail(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            string regex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            Match ? match = Regex.Match(value, regex);

            return match.Success;
        }

        private bool ValidateWebsite(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            string regex = @"^((www\.)|(https:\/\/)|(https:\/\/))?.+\..+$";
            Match? match = Regex.Match(value, regex);

            return match.Success;
        }

        private bool ValidatePassword(string value)
        {
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            Match? match = Regex.Match(value, regex);

            return match.Success;
        }
    }
}
