using HA.Auth.Constan.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Domain
{
    [Table(nameof(ProdProductImage), Schema = DbSchema.Product)]
    public class ProdProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int ProductId { get; set;}
    }
}
