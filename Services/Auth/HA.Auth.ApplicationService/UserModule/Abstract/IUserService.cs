using HA.Auth.Domain;
using HA.Auth.Dtos.Logg;
using HA.Auth.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Abstract
{
    public interface IUserService
    {
        Task<AuthUser> CreateUserAsync(CreateUserDto input);
        List<AuthUser> GetAll();
        void UpdateUser(UpdateUserDto input);
        void DeleteUser(int id);
        Task<LoginResponseDto> LoginAsync(LoginDto input);
    }
}
