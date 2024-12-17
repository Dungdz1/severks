using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.ApplicationService.UserModule.Implements;
using HA.Auth.Constan.Database;
using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.ApplicationService.OrderModule.Implements;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Shared.ApplicationService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Shared.Connects.Startup
{
    public static class BasethStartup
    {
        public static void ConfigureBaseth(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<BasethDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Baseth
                            );
                        }
                    );
                },
                ServiceLifetime.Scoped
            );
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductSearchService, ProductSearchService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<ITypeService, TypeService>();
            builder.Services.AddScoped<IImageService, ImageService>();
        }
    }
}
