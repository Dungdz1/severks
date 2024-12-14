using HA.Auth.Dtos.Sale;
using HA.Auth.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Abstract
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
