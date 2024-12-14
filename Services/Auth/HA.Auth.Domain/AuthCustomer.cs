using HA.Auth.Constan.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Domain
{
    [Table(nameof(AuthCustomer), Schema = DbSchema.Auth)]
    public class AuthCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Password { get; set; }
    }
}
