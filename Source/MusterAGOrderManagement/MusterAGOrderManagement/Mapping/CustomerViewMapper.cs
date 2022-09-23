using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Customer;

namespace MusterAGOrderManagement.Mapping
{
    internal static class CustomerViewMapper
    {
        public static CustomerItemModel ToModel(this CustomerDto customerDto)
        {
            if (customerDto == null)
                return null;

            CustomerItemModel customerModel = new CustomerItemModel();
            customerModel.Id = customerDto.Id;
            customerModel.CustomerNr = customerDto.CustomerNr;
            customerModel.Name = customerDto.Name;
            customerModel.Email = customerDto.Email;
            customerModel.Website = customerDto.Website;
            customerModel.Password = customerDto.Password;
            customerModel.AddressId = customerDto.AddressId;
            customerModel.Address = customerDto.Address.ToModel();

            return customerModel;
        }

        public static CustomerDto ToDto(this CustomerItemModel customerModel)
        {
            if (customerModel == null)
                return null;

            CustomerDto customerDto = new CustomerDto();
            customerDto.Id = customerModel.Id;
            customerDto.CustomerNr = customerModel.CustomerNr;
            customerDto.Name = customerModel.Name;
            customerDto.Email = customerModel.Email;
            customerDto.Website = customerModel.Website;
            customerDto.Password = customerModel.Password;
            customerDto.AddressId = customerModel.AddressId;
            customerDto.Address = customerModel.Address.ToDto();

            return customerDto;
        }
    }
}
