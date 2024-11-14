using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.UserModule
{
    public class CreateUserDto
    {
        private string _username;
        public string UserName
        {
            get => _username;
            set => _username = value?.Trim();
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => _password = value?.Trim();
        }

        private string _phone;
        public string PhoneNumber
        {
            get => _phone;
            set => _phone = value?.Trim();
        }

        private string _add;
        public string Address
        {
            get => _add;
            set => _add = value?.Trim();
        }

        public DateTime CreatedDate { get; set; }

        public List<int> RoleIds { get; set; }

        public List<int> PermissionIds { get; set; }
    }
}
