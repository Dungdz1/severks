using HA.Auth.Domain;
using HA.Order.Domain;
using HA.Product.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Shared.ApplicationService
{
    public class BasethDbContext : DbContext
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
        public DbSet<ProdProduct> Products { get; set; }
        public DbSet<ProdCategory> Categories { get; set; }
        public DbSet<ProdProductCategory> ProductCategories { get; set; }
        public DbSet<ProdBrand> Brands { get; set; }
        public DbSet<ProdProductBrand> ProductBrands { get; set; }
        public DbSet<ProdType> Types { get; set; }
        public DbSet<ProdProductType> ProductTypes { get; set; }
        public DbSet<ProdImage> Images { get; set; }
        public DbSet<ProdProductImage> ProductImages { get; set; }
        public DbSet<ProdSale> ProductSales { get; set; }
        public DbSet<ProdCart> ProductCarts { get; set; }
        public DbSet<OdOrder> Orders { get; set; }
        public DbSet<OdDetail> OrderDetails { get; set; }
        public DbSet<OrderUser> OrderUsers { get; set; }
        public DbSet<OdDiscount> Discounts { get; set; }
        public DbSet<OdOrderDiscount> OrderDiscounts { get; set; }
        public DbSet<OdPayment> Payments { get; set; }
        public DbSet<OdOrderPayment> OrderPayments { get; set; }
        public DbSet<OdDelivery> Deliverys { get; set; }

        public BasethDbContext(DbContextOptions<BasethDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .Entity<ProdProductCategory>()
                .HasOne<ProdProduct>()
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<ProdProductCategory>()
                .HasOne<ProdCategory>()
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProdProductBrand>()
                .HasOne<ProdProduct>()
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<ProdProductBrand>()
                .HasOne<ProdBrand>()
                .WithMany()
                .HasForeignKey(e => e.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProdProductType>()
                .HasOne<ProdProduct>()
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<ProdProductType>()
                .HasOne<ProdType>()
                .WithMany()
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProdProductImage>()
                .HasOne<ProdProduct>()
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<ProdProductImage>()
                .HasOne<ProdImage>()
                .WithMany()
                .HasForeignKey(e => e.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProdSale>()
                .HasOne<ProdProduct>()
                .WithMany()
                .HasForeignKey(e => e.ProductId);
            modelBuilder
                .Entity<ProdSale>()
                .HasOne<AuthSale>()
                .WithMany()
                .HasForeignKey(e => e.SaleId);

            modelBuilder
                .Entity<ProdCart>()
                .HasOne<ProdProduct>()
                .WithMany()
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<ProdCart>()
                .HasOne<AuthCustomer>()
                .WithMany()
                .HasForeignKey(e => e.CustomerId);

            modelBuilder
                .Entity<OdDetail>()
                .HasOne<OdOrder>()
                .WithMany()
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<OdDetail>()
                .HasOne<ProdProduct>()
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<OrderUser>()
                .HasOne<OdOrder>()
                .WithMany()
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<OrderUser>()
                .HasOne<AuthUser>()
                .WithOne()
                .HasForeignKey<OrderUser>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<OdOrderDiscount>()
                .HasOne<OdOrder>()
                .WithMany()
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<OdOrderDiscount>()
                .HasOne<OdDiscount>()
                .WithMany()
                .HasForeignKey(e => e.DiscountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<OdOrderPayment>()
                .HasOne<OdOrder>()
                .WithMany()
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<OdOrderPayment>()
                .HasOne<OdPayment>()
                .WithMany()
                .HasForeignKey(e => e.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<OdDelivery>()
                .HasOne<OdOrder>()
                .WithMany()
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<OdDelivery>()
                .HasOne<AuthAddress>()
                .WithMany()
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
