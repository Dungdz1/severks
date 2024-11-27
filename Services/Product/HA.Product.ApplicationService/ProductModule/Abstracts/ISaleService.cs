using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Product.Dtos.ProductModule.Sale;

namespace HA.Product.ApplicationService.ProductModule.Abstracts
{
    public interface ISaleService
    {
        SaleDto CreatenewSale(CreateSaleDto input);
        void UpdateSale(UpdateSaleDto input);
        void DeleteSale(int id);
        List<SaleDto> GetAllSale();
        SaleDto GetSaleById(int id);
    }
}
