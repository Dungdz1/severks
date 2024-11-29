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

namespace HA.Auth.Infrastructure
{
    public class AuthDbContext : DbContext
    {
        public DbSet<AuthUser> Users { get; set; }
        public DbSet<AuthRole> Role { get; set; }
        public DbSet<AuthPermissions> Permissions { get; set; }
        public DbSet<AuthUserRoles> UserRoles { get; set; }
        public DbSet<AuthUserPermissions> UserPermissions { get; set; }
        public DbSet<AuthAddress> Addresses { get; set; }
        public DbSet<AuthAddressUser> AddressesUsers { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AuthRole>().HasData(
                new AuthRole { Id = 1, RoleName = "Admin", RoleDescription = "Administrator Role" },
                new AuthRole { Id = 2, RoleName = "Employee", RoleDescription = "Employee Role" },
                new AuthRole { Id = 3, RoleName = "Customer", RoleDescription = "Customer Role"}
            );

            modelBuilder.Entity<AuthPermissions>().HasData(
                new AuthPermissions { Id = 1, PermissionName = "Create", PermissionDescription = "Create permission" },
                new AuthPermissions { Id = 2, PermissionName = "Read", PermissionDescription = "Read permission" },
                new AuthPermissions { Id = 3, PermissionName = "Update", PermissionDescription = "Update permission" },
                new AuthPermissions { Id = 4, PermissionName = "Delete", PermissionDescription = "Delete permission" }
            );

            modelBuilder
                .Entity<AuthUserRoles>()
                .HasOne<AuthUser>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthUserRoles>()
                .HasOne<AuthRole>()
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<AuthUserPermissions>()
                .HasOne<AuthRole>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthUserPermissions>()
                .HasOne<AuthPermissions>()
                .WithMany()
                .HasForeignKey(e => e.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthAddressUser>()
                .HasOne<AuthUser>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<AuthAddressUser>()
                .HasOne<AuthAddress>()
                .WithMany()
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<AuthUser>()
                .HasKey(e => e.Id);

            modelBuilder
                .Entity<AuthRole>()
                .HasKey(e => e.Id);

            modelBuilder
                .Entity<AuthUserRoles>()
                .HasKey(e => e.Id);

            modelBuilder
                .Entity<AuthUserPermissions>()
                .HasKey(e => e.Id);

            modelBuilder
                .Entity<AuthAddress>()
                .HasKey(e => e.Id);
            base.OnModelCreating(modelBuilder);

        }
    }

}
