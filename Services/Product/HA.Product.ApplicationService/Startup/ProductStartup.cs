using HA.Auth.Constan.Database;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Product.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.Startup
{
    public static class ProductStartup
    {
        public static void ConfigureProduct(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<ProductDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Product
                                );
                        }
                    );
                },
                ServiceLifetime.Scoped
            );
            //triển khai nốt các interface và service
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductSearchService, ProductSearchService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<ITypeService, TypeService>();
        }
    }
}
