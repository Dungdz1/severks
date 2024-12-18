using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HA.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class finals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.EnsureSchema(
                name: "prod");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthAddress",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthCustomer",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthPermissionCustomer",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthPermissionCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthPermissions",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthPermissionSale",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthPermissionSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthSale",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleDes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthUser",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountValue = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdBrand",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdCategory",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdImage",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdProduct",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProdDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdStock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdType",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthAddressUser",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthAddressUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthAddressUser_AuthAddress_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "auth",
                        principalTable: "AuthAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthAddressUser_AuthCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "auth",
                        principalTable: "AuthCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUsers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdminUsers_AuthUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthCustomerUser",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthCustomerUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthCustomerUser_AuthCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "auth",
                        principalTable: "AuthCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthCustomerUser_AuthUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthUserSale",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUserSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthUserSale_AuthSale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "auth",
                        principalTable: "AuthSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthUserSale_AuthUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deliverys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliverys_AuthAddress_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "auth",
                        principalTable: "AuthAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliverys_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDiscounts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrders_AuthUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPayments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdCart",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdCart_AuthCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "auth",
                        principalTable: "AuthCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdCart_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdProductBrand",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProductBrand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdProductBrand_ProdBrand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "prod",
                        principalTable: "ProdBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdProductBrand_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdProductCategory",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdProductCategory_ProdCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "prod",
                        principalTable: "ProdCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdProductCategory_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdProductImage",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdProductImage_ProdImage_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "prod",
                        principalTable: "ProdImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdProductImage_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdSale",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdSale_AuthSale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "auth",
                        principalTable: "AuthSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdSale_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdProductType",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdProductType_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdProductType_ProdType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "prod",
                        principalTable: "ProdType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_AdminId",
                table: "AdminUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_UserId",
                table: "AdminUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthAddressUser_AddressId",
                schema: "auth",
                table: "AuthAddressUser",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthAddressUser_CustomerId",
                schema: "auth",
                table: "AuthAddressUser",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthCustomerUser_CustomerId",
                schema: "auth",
                table: "AuthCustomerUser",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthCustomerUser_UserId",
                schema: "auth",
                table: "AuthCustomerUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserSale_SaleId",
                schema: "auth",
                table: "AuthUserSale",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserSale_UserId",
                schema: "auth",
                table: "AuthUserSale",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverys_AddressId",
                table: "Deliverys",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverys_OrderId",
                table: "Deliverys",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscounts_DiscountId",
                table: "OrderDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscounts_OrderId",
                table: "OrderDiscounts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_OrderId",
                table: "OrderPayments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_PaymentId",
                table: "OrderPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCart_CustomerId",
                schema: "prod",
                table: "ProdCart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCart_ProductId",
                schema: "prod",
                table: "ProdCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductBrand_BrandId",
                schema: "prod",
                table: "ProdProductBrand",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductBrand_ProductId",
                schema: "prod",
                table: "ProdProductBrand",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductCategory_CategoryId",
                schema: "prod",
                table: "ProdProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductCategory_ProductId",
                schema: "prod",
                table: "ProdProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductImage_ImageId",
                schema: "prod",
                table: "ProdProductImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductImage_ProductId",
                schema: "prod",
                table: "ProdProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductType_ProductId",
                schema: "prod",
                table: "ProdProductType",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductType_TypeId",
                schema: "prod",
                table: "ProdProductType",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdSale_ProductId",
                schema: "prod",
                table: "ProdSale",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdSale_SaleId",
                schema: "prod",
                table: "ProdSale",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "AuthAddressUser",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AuthCustomerUser",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AuthPermissionCustomer",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AuthPermissions",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AuthPermissionSale",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AuthUserSale",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Deliverys");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderDiscounts");

            migrationBuilder.DropTable(
                name: "OrderPayments");

            migrationBuilder.DropTable(
                name: "ProdCart",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdProductBrand",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdProductCategory",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdProductImage",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdProductType",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdSale",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AuthAddress",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AuthCustomer",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "ProdBrand",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdCategory",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdImage",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdType",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "AuthSale",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "ProdProduct",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "AuthUser",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
