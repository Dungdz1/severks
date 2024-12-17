using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Auth.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Data;
using HA.Product.Domain;
using HA.Auth.Constan.Database;

namespace HA.Auth.Infrastructure
{
    public class AuthDbContext : DbContext
    {
        public DbSet<AuthUser> Users { get; set; }
        public DbSet<AuthPermissions> Permissions { get; set; }
        public DbSet<AuthAddress> Addresses { get; set; }
        public DbSet<AuthAddressUser> AddressesUsers { get; set; }
        public DbSet<AuthCustomer> Customers { get; set; }
        public DbSet<AuthSale> Sales { get; set; }
        public DbSet<AuthUserSale> SalesUsers { get; set; }
        public DbSet<AuthPermissionCustomer> CustomersPermissions { get; set; }
        public DbSet<AuthPermissionSale> SalePermissions { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AuthUser>().ToTable("Users");
            modelBuilder.Entity<AuthSale>().ToTable("Sales");

            modelBuilder
                .Entity<AuthAddressUser>()
                .HasOne<AuthAddress>()
                .WithMany()
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<AuthAddressUser>()
                .HasOne<AuthCustomer>()
                .WithMany()
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthUserSale>()
                .HasOne<AuthUser>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthUserSale>()
                .HasOne<AuthSale>()
                .WithMany()
                .HasForeignKey(e => e.SaleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthCustomerUser>()
                .HasOne<AuthUser>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<AuthCustomerUser>()
                .HasOne<AuthCustomer>()
                .WithMany()
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthSale>()
                .HasMany<ProdSale>()
                .WithOne()
                .HasForeignKey(e => e.SaleId);

            modelBuilder
                .Entity<ProdCart>()
                .HasOne<AuthCustomer>()
                .WithMany()  
                .HasForeignKey(e => e.CustomerId)  
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
