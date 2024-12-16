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
    [Table(nameof(ProdProduct), Schema = DbSchema.Product)]
    public class ProdProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProdPrice { get; set; }
        public string ProdImg { get; set; }
        public string ProdDescription { get; set; }
        public string ProdStock { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<ProdSale> SaleProducts { get; set; }
    }
}
