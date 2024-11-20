using HA.Product.Domain;
using HA.Product.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.Common
{
    public  abstract class ProductServiceBase
    {
        protected readonly ILogger _logger;
        protected readonly ProductDbContext _dbContext;

        protected ProductServiceBase(ILogger logger, ProductDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        protected ProdProduct FindProductById(int productId)
        {
            var productFind = _dbContext.Products.FirstOrDefault(s => s.Id == productId && !s.IsDelete);
            if (productFind == null)
            {
                _logger.LogInformation($"Khong tim thay san pham co id {productId}");
            }

            return productFind;
        }
    }
}
