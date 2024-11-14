using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.ApplicationService.UserModule.Implements;
using HA.Auth.Constan.Database;
using HA.Auth.Domain;
using HA.Auth.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.Startup
{
    public static class AuthStartup
    {
        public static void ConfigureAuth(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<AuthDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                        options.MigrationsAssembly(assemblyName);
                        options.MigrationsHistoryTable(
                            DbSchema.TableMigrationsHistory,
                            DbSchema.Auth
                            );
                        }
                    );
                },
                ServiceLifetime.Scoped
            );
            //triển khai nốt các interface và service
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRole, UserRoleService>();
            builder.Services.AddScoped<IUserPermission, UserPermissionService>();
            builder.Services.AddScoped<CheckUser>();
            builder.Services.AddScoped<IPasswordHasher<AuthUser>, PasswordHasher<AuthUser>>();
        }
    }
}
