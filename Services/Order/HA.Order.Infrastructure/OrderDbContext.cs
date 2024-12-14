using HA.Auth.Domain;
using HA.Order.Domain;
using HA.Product.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public DbSet<OdOrder> Orders { get; set; }
        public DbSet<OdDetail> OrderDetails { get; set; }
        public DbSet<OrderUser> OrderUsers { get; set; }
        public DbSet<OdDiscount> Discounts { get; set; }
        public DbSet<OdOrderDiscount> OrderDiscounts { get; set; }
        public DbSet<OdPayment> Payments { get; set; }
        public DbSet<OdOrderPayment> OrderPayments { get; set; }
        public DbSet<OdDelivery> Deliverys { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OdOrder>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id") 
                    .ValueGeneratedOnAdd() 
                    .IsRequired();
            });
            modelBuilder.Entity<AuthUser>().ToTable("AuthUser");

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
