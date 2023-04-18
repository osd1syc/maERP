﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace maERP.Server.Migrations
{
    /// <inheritdoc />
    public partial class initDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    country_code = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    customer_status = table.Column<int>(type: "integer", nullable: false),
                    enrollment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shipping_provider",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_provider", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tax_class",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tax_rate = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tax_class", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "warehouse",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "text", nullable: false),
                    house_nr = table.Column<string>(type: "text", nullable: false),
                    zip = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_address_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_address_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    order_status = table.Column<int>(type: "integer", nullable: false),
                    order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipping_provider_rate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    max_length = table.Column<decimal>(type: "numeric", nullable: false),
                    max_width = table.Column<decimal>(type: "numeric", nullable: false),
                    max_height = table.Column<decimal>(type: "numeric", nullable: false),
                    max_weight = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ShippingProviderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_provider_rate", x => x.id);
                    table.ForeignKey(
                        name: "FK_shipping_provider_rate_shipping_provider_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "shipping_provider",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sku = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ean = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    asin = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    description = table.Column<string>(type: "character varying(64000)", maxLength: 64000, nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    msrp = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxClassId = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_tax_class_TaxClassId",
                        column: x => x.TaxClassId,
                        principalTable: "tax_class",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales_channel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    import_products = table.Column<bool>(type: "boolean", nullable: false),
                    import_customers = table.Column<bool>(type: "boolean", nullable: false),
                    import_orders = table.Column<bool>(type: "boolean", nullable: false),
                    export_products = table.Column<bool>(type: "boolean", nullable: false),
                    export_customers = table.Column<bool>(type: "boolean", nullable: false),
                    export_orders = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_channel", x => x.id);
                    table.ForeignKey(
                        name: "FK_sales_channel_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_stock",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_stock", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_stock_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_stock_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "warehouse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_sales_channel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalesChannelId = table.Column<int>(type: "integer", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    remote_product_id = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    product_import = table.Column<bool>(type: "boolean", nullable: false),
                    product_export = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_sales_channel", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_sales_channel_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_product_sales_channel_sales_channel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "sales_channel",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "Admin", "ADMIN" },
                    { "e82b2dfe-c982-485e-8ce8-35bdc4ae5ceb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "id", "country_code", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, "de", new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3010), "Deutschland", new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3010) },
                    { 2, "at", new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3010), "Österreich", new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3010) },
                    { 3, "ch", new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3010), "Schweiz", new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3010) }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "asin", "created_at", "description", "ean", "msrp", "name", "price", "sku", "TaxClassId", "updated_at" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 4, 7, 23, 2, 23, 945, DateTimeKind.Local).AddTicks(3150), "Beschreibung 1", null, 0m, "Testprodukt 1", 100m, "1001", null, new DateTime(2023, 4, 7, 23, 2, 23, 945, DateTimeKind.Local).AddTicks(3200) },
                    { 2, null, new DateTime(2023, 4, 7, 23, 2, 23, 945, DateTimeKind.Local).AddTicks(3210), "Beschreibung 2", null, 0m, "Testprodukt 2", 100m, "1002", null, new DateTime(2023, 4, 7, 23, 2, 23, 945, DateTimeKind.Local).AddTicks(3210) },
                    { 3, null, new DateTime(2023, 4, 7, 23, 2, 23, 945, DateTimeKind.Local).AddTicks(3210), "Beschreibung 3", null, 0m, "Testprodukt 3", 100m, "1003", null, new DateTime(2023, 4, 7, 23, 2, 23, 945, DateTimeKind.Local).AddTicks(3210) }
                });

            migrationBuilder.InsertData(
                table: "sales_channel",
                columns: new[] { "id", "created_at", "export_customers", "export_orders", "export_products", "import_customers", "import_orders", "import_products", "name", "password", "type", "url", "updated_at", "username", "WarehouseId" },
                values: new object[] { 1, new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3310), false, false, false, false, false, true, "Shopware Demo Shop", "demopass", 10, "https://www.example.com/", new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3310), "demouser", null });

            migrationBuilder.InsertData(
                table: "tax_class",
                columns: new[] { "id", "created_at", "tax_rate", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3370), 0.0, new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3370) },
                    { 2, new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3370), 7.0, new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3370) },
                    { 3, new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3370), 19.0, new DateTime(2023, 4, 7, 21, 2, 23, 945, DateTimeKind.Utc).AddTicks(3370) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "e4df8f35-40b3-4927-82fc-0477fa066354", "admin@localhost.com", false, "Admin", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAECqCwxT72XS8JPGl4oXFuHD5pyY1k0KbFiHnDIYdEw1aPcjZQCaq0hvIJZXe5sSkxg==", null, false, "a5fa61df-9b94-422b-a90c-86491c7a48f4", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_CountryId",
                table: "customer_address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_CustomerId",
                table: "customer_address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_TaxClassId",
                table: "product",
                column: "TaxClassId");

            migrationBuilder.CreateIndex(
                name: "IX_product_sales_channel_ProductId",
                table: "product_sales_channel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_sales_channel_SalesChannelId",
                table: "product_sales_channel",
                column: "SalesChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_product_stock_ProductId",
                table: "product_stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_stock_WarehouseId",
                table: "product_stock",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_channel_WarehouseId",
                table: "sales_channel",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_provider_rate_ShippingProviderId",
                table: "shipping_provider_rate",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "customer_address");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product_sales_channel");

            migrationBuilder.DropTable(
                name: "product_stock");

            migrationBuilder.DropTable(
                name: "shipping_provider_rate");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "sales_channel");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "shipping_provider");

            migrationBuilder.DropTable(
                name: "warehouse");

            migrationBuilder.DropTable(
                name: "tax_class");
        }
    }
}