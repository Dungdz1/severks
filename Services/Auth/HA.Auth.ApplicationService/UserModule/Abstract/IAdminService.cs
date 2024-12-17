using HA.Auth.Dtos.Admins;
using HA.Auth.Dtos.Sale;
using HA.Auth.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Abstract
{
    public interface IAdminService
    {
        AdminDto CreatenewAdmin(CreateAdminDto input);
        void UpdateAdmin(UpdateAdmin input);
        void DeleteAdmin(int id);
    }
}
