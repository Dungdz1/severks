using HA.Auth.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Abstract
{
    public interface IUserPermission
    {
        //Phan quyen cho user tai day method Add
        void GrandPermission(GrandPermission input);

    }
}
