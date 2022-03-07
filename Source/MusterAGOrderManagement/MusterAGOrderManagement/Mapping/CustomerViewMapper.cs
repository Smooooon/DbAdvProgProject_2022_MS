using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Customer;

namespace MusterAGOrderManagement.Mapping
{
    internal static class CustomerViewMapper
    {
        public static CustomerItemModel ToModel(this CustomerDto customerDto)
        {
            CustomerItemModel customerModel = new CustomerItemModel();
            customerModel.Id = customerDto.Id;
            customerModel.Name = customerDto.Name;
            customerModel.Email = customerDto.Email;
            customerModel.Website = customerDto.Website;
            customerModel.Password = customerDto.Password;
            customerModel.AddressId = customerDto.AddressId;

            return customerModel;
        }

        public static CustomerDto ToDto(this CustomerItemModel customerModel)
        {
            CustomerDto customerDto = new CustomerDto();
            customerDto.Id = customerModel.Id;
            customerDto.Name = customerModel.Name;
            customerDto.Email = customerModel.Email;
            customerDto.Website = customerModel.Website;
            customerDto.Password = customerModel.Password;
            customerDto.AddressId = customerModel.AddressId;

            return customerDto;
        }
    }
}
