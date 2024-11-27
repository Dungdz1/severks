using Microsoft.AspNetCore.Authentication.JwtBearer;
using HA.Auth.ApplicationService.Startup;
using HA.Auth.Domain;
using HA.Auth.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HA.Product.ApplicationService.Startup;

namespace HA.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            ConfigureAuthentication(builder);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.ConfigureAuth(typeof(Program).Namespace);
            builder.ConfigureProduct(typeof(Program).Namespace);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseAuthentication();


            app.MapControllers();

            app.Run();
        }

        private static void ConfigureAuthentication(WebApplicationBuilder builder)
        {
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }

            private void SeedData(AuthDbContext context)
        {
            if (!context.Role.Any())
            {
                context.Role.AddRange(
                    new AuthRole { Id = 1, RoleName = "Admin", RoleDescription = "Administrator Role" },
                    new AuthRole { Id = 2, RoleName = "Employee", RoleDescription = "Employee Role" },
                    new AuthRole { Id = 3, RoleName = "Customer", RoleDescription = "Customer"}
                );
                context.SaveChanges();
            }

            if (!context.Permissions.Any())
            {
                context.Permissions.AddRange(
                    new AuthPermissions { Id = 1, PermissionName = "Create", PermissionDescription = "Create permission" },
                    new AuthPermissions { Id = 2, PermissionName = "Read", PermissionDescription = "Read permission" },
                    new AuthPermissions { Id = 3, PermissionName = "Update", PermissionDescription = "Update permission" },
                    new AuthPermissions { Id = 4, PermissionName = "Delete", PermissionDescription = "Delete permission" }
                );
                context.SaveChanges();
            }
        }
    }
}
