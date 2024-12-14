using HA.Auth.Constan.Database;
using HA.Auth.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Domain
{
    [Table(nameof(ProdCart), Schema = DbSchema.Product)]
    public class ProdCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set;}
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
