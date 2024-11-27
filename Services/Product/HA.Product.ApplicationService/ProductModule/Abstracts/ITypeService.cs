using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Product.Dtos.ProductModule.Type;

namespace HA.Product.ApplicationService.ProductModule.Abstracts
{
    public interface ITypeService
    {
        TypeDto CreateType(CreateTypeDto input);
        void UpdateType(UpdateTypeDto input);
        void DeleteType(int id);
        List<TypeDto> GetAllTypes();
        TypeDto GetTypeById(int id);
    }
}
