using HA.Order.Domain;
using HA.Order.Infrastructure;
using HA.Shared.ApplicationService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.ApplicationService.Common
{
    public abstract class OrderServiceBase
    {
        protected readonly ILogger _logger;
        protected readonly BasethDbContext _dbContext;

        protected OrderServiceBase(ILogger logger, BasethDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        protected OdOrder FindOrderById(int orderId)
        {
            var orderFind = _dbContext.Orders.FirstOrDefault(s => s.Id == orderId && !s.IsDelete);
            if (orderFind == null)
            {
                _logger.LogInformation($"Khong tim thay gio hang co id {orderId}");
            }

            return orderFind;
        }
    }
}
