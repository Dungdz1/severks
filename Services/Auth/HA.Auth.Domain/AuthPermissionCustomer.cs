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
    [Table(nameof(AuthPermissionCustomer), Schema = DbSchema.Auth)]
    public class AuthPermissionCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PermissionId { get; set; }
    }
}
