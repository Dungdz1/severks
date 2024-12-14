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
    [Table(nameof(AuthAddress), Schema = DbSchema.Auth)]
    public class AuthAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
