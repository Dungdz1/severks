using HA.Product.ApplicationService.Common;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule;
using HA.Product.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Product.Dtos.ProductModule.Type;

namespace HA.Product.ApplicationService.ProductModule.Implement
{
    public class TypeService : ProductServiceBase, ITypeService
    {
        private readonly ILogger<TypeService> _logger;
        private readonly ProductDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public TypeService(ILogger<TypeService> logger, ProductDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public TypeDto CreateType(CreateTypeDto input)
        {
            var type = new ProdType
            {
                TypeName = input.TypeName,
                TypeDescription = input.TypeDescription
            };

            _dbContext.Types.Add(type);
            _dbContext.SaveChanges();

            return new TypeDto
            {
                Id = type.Id,
                TypeName = type.TypeName,
                TypeDescription = type.TypeDescription
            };
        }

        public void DeleteType(int id)
        {
            var type = _dbContext.Types.FirstOrDefault(c => c.Id == id);
            if (type == null)
                throw new KeyNotFoundException("Category not found");

            _dbContext.Types.Remove(type);
            _dbContext.SaveChanges();
        }

        public List<TypeDto> GetAllTypes()
        {
            return _dbContext.Types.Select(c => new TypeDto
            {
                Id = c.Id,
                TypeName = c.TypeName,
                TypeDescription = c.TypeDescription
            }).ToList();
        }

        public TypeDto GetTypeById(int id)
        {
            var type = _dbContext.Types.FirstOrDefault(c => c.Id == id);
            if (type == null)
                throw new KeyNotFoundException("Type not found");

            return new TypeDto
            {
                Id = type.Id,
                TypeName = type.TypeName,
                TypeDescription = type.TypeDescription,
            };
        }

        public void UpdateType(UpdateTypeDto input)
        {
            var type = _dbContext.Types.FirstOrDefault(c => c.Id == input.Id);
            if (type == null)
                throw new KeyNotFoundException("Type not found");

            type.TypeName = input.TypeName;
            type.TypeDescription = input.TypeDescription;

            _dbContext.SaveChanges();
        }
    }
}
