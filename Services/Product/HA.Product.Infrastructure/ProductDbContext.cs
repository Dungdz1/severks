﻿using HA.Auth.Constan.Database;
using HA.Auth.Domain;
using HA.Product.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Infrastructure
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProdProduct> Products { get; set; }
        public DbSet<ProdCategory> Categories { get; set; }
        public DbSet<ProdProductCategory> ProductCategories { get; set;}
        public DbSet<ProdBrand> Brands { get; set; }
        public DbSet<ProdProductBrand> ProductBrands { get; set; }
        public DbSet<ProdType> Types { get; set; }
        public DbSet<ProdProductType> ProductTypes { get; set; }
        public DbSet<ProdImage> Images { get; set; }
        public DbSet<ProdProductImage> ProductImages { get; set; }
        public DbSet<ProdSale> ProductSales { get; set; }
        public DbSet<ProdCart> ProductCarts { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdProduct>().ToTable("Products");
            modelBuilder.Entity<ProdSale>().ToTable("ProdSales");

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
        }
    }
}
