using HA.Auth.Dtos.Address;
using HA.Auth.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Abstract
{
    public interface IAddressService
    {
        AddressDto CreateNewAddress(CreateAddressDto input);
        void UpdateAddress(UpdateAddressDto input);
        void DeleteAddress(int id);
        List<AddressDto> GetAllAddress();
        AddressDto GetAddressById(int id);
    }
}
