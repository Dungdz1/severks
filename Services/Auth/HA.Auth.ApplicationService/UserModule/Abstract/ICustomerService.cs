using HA.Auth.Dtos.Customer;
using HA.Auth.Dtos.Sale;
using HA.Auth.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Abstract
{
    public interface ICustomerService
    {
        CustomerDto CreatenewCustomer(CreateCustomerDto input);
        void UpdateCustomer(UpdateCustomerDto input);
        void DeleteCustomer(int id);
        List<CustomerDto> GetAllCustomer();
        CustomerDto GetCustomerById(int id);
    }
}
