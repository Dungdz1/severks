using HA.Auth.Constan.Database;
using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.ApplicationService.OrderModule.Implements;
using HA.Order.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.ApplicationService.Startup
{
    public static class OrderStartup
    {
        public static void ConfigureOrder(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<OrderDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Order
                                );
                        }
                    );
                },
                ServiceLifetime.Scoped
            );
            //triển khai nốt các interface và service
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
