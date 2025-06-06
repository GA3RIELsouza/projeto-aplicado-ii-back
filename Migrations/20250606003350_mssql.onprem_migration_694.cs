using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto_Aplicado_II_API.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonprem_migration_694 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branch_size",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_size", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    legal_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "Razão Social"),
                    business_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "Nome Fantasia"),
                    phone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    tax_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "CNPJ"),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unity_of_measure",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unity_of_measure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    password_hash = table.Column<byte[]>(type: "binary(32)", fixedLength: true, maxLength: 32, nullable: false),
                    password_salt_hash = table.Column<byte[]>(type: "binary(16)", fixedLength: true, maxLength: 16, nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "branch",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    neighborhood = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    city = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    state = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    country = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    branch_size_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch", x => x.id);
                    table.ForeignKey(
                        name: "FK_branch_branch_size_branch_size_id",
                        column: x => x.branch_size_id,
                        principalTable: "branch_size",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_branch_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    tax_id = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false, comment: "CPF"),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    neighborhood = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    city = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    state = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    country = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    legal_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    business_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    neighborhood = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    city = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    state = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    country = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    tax_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                    table.ForeignKey(
                        name: "FK_supplier_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_branch",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_branch", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_branch_branch_BranchId1",
                        column: x => x.BranchId1,
                        principalTable: "branch",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_branch_branch_company_id",
                        column: x => x.company_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_branch_user_UserId1",
                        column: x => x.UserId1,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_branch_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    product_category_id = table.Column<long>(type: "bigint", nullable: false),
                    unitary_selling_price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    unity_of_measure_id = table.Column<long>(type: "bigint", nullable: false),
                    minimal_stock_quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 10),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_product_category_product_category_id",
                        column: x => x.product_category_id,
                        principalTable: "product_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_unity_of_measure_unity_of_measure_id",
                        column: x => x.unity_of_measure_id,
                        principalTable: "unity_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    order_date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delivery_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_status_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_branch_company_id",
                        column: x => x.company_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_order_status_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    client_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.id);
                    table.ForeignKey(
                        name: "FK_sale_branch_company_id",
                        column: x => x.company_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sale_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sale_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "batch",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    batch_date = table.Column<DateOnly>(type: "date", nullable: false),
                    expiration_date = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_batch", x => x.id);
                    table.ForeignKey(
                        name: "FK_batch_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplier_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    unitary_price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    unity_of_measure_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_supplier_product_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_supplier_product_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplier_product_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplier_product_unity_of_measure_unity_of_measure_id",
                        column: x => x.unity_of_measure_id,
                        principalTable: "unity_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_item_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_item_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sale_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sale_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_sale_item_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sale_item_sale_sale_id",
                        column: x => x.sale_id,
                        principalTable: "sale",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_in_inventory",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    batch_id = table.Column<long>(type: "bigint", nullable: false),
                    bar_code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    is_sold = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    branch_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_in_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_batch_batch_id",
                        column: x => x.batch_id,
                        principalTable: "batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "branch_size",
                columns: new[] { "id", "created_at", "description", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pequena", null },
                    { 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Média", null },
                    { 3L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Grande", null }
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "id", "business_name", "is_active", "legal_name", "phone", "tax_id", "updated_at" },
                values: new object[] { 1L, "Empresa Padrão LTDA", true, "Empresa Padrão", "55 47 0001-0001", "00.000.000/0001-01", null });

            migrationBuilder.InsertData(
                table: "order_status",
                columns: new[] { "id", "created_at", "Description", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Solicitado", null },
                    { 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A caminho", null },
                    { 3L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Concluído", null }
                });

            migrationBuilder.InsertData(
                table: "unity_of_measure",
                columns: new[] { "id", "Description", "Symbol", "updated_at" },
                values: new object[,]
                {
                    { 1L, "Unidade", "UN", null },
                    { 2L, "Quilograma", "kg", null },
                    { 3L, "Grama", "g", null },
                    { 4L, "Miligrama", "mg", null },
                    { 5L, "Litro", "L", null },
                    { 6L, "Mililitro", "mL", null },
                    { 7L, "Quilômetro", "km", null },
                    { 8L, "Metro", "m", null },
                    { 9L, "Milímetro", "ml", null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "created_at", "email", "is_active", "is_admin", "name", "password_hash", "password_salt_hash", "updated_at" },
                values: new object[] { 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@admin.com", true, true, "Admin", new byte[] { 106, 81, 44, 80, 75, 157, 220, 207, 185, 250, 202, 13, 10, 59, 117, 138, 172, 230, 74, 223, 189, 1, 152, 66, 146, 180, 174, 9, 104, 9, 3, 126 }, new byte[] { 99, 212, 93, 197, 93, 127, 86, 151, 50, 94, 80, 108, 64, 232, 22, 152 }, null });

            migrationBuilder.InsertData(
                table: "branch",
                columns: new[] { "id", "branch_size_id", "city", "company_id", "country", "is_active", "Name", "neighborhood", "number", "state", "street", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, "Cidade Exemplo", 1L, "Brasil", true, "Filial Padrão 1", "Bairro Exemplo", "11", "EX", "Rua Exemplo 1", null },
                    { 2L, 2L, "Cidade Exemplo", 1L, "Brasil", true, "Filial Padrão 2", "Bairro Exemplo", "21", "EX", "Rua Exemplo 2", null },
                    { 3L, 3L, "Cidade Exemplo", 1L, "Brasil", true, "Filial Padrão 3", "Bairro Exemplo", "31", "EX", "Rua Exemplo 3", null }
                });

            migrationBuilder.InsertData(
                table: "product_category",
                columns: new[] { "id", "company_id", "description", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, "Hortifruti", null },
                    { 2L, 1L, "Bebidas", null },
                    { 3L, 1L, "Carnes, Aves e Peixes", null }
                });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "id", "business_name", "city", "company_id", "country", "is_active", "legal_name", "neighborhood", "number", "phone", "state", "street", "tax_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, "Fornecedor Padrão {i}", "Cidade Exemplo", 1L, "Brasil", true, "Fornecedor Padrão 1", "Bairro Exemplo", "12", "55 47 0001-0002", "EX", "Rua Exemplo 1", "00.000.000/0001-02", null },
                    { 2L, "Fornecedor Padrão {i}", "Cidade Exemplo", 1L, "Brasil", true, "Fornecedor Padrão 2", "Bairro Exemplo", "22", "55 47 0002-0002", "EX", "Rua Exemplo 2", "00.000.000/0002-02", null },
                    { 3L, "Fornecedor Padrão {i}", "Cidade Exemplo", 1L, "Brasil", true, "Fornecedor Padrão 3", "Bairro Exemplo", "32", "55 47 0003-0002", "EX", "Rua Exemplo 3", "00.000.000/0003-02", null },
                    { 4L, "Fornecedor Padrão {i}", "Cidade Exemplo", 1L, "Brasil", true, "Fornecedor Padrão 4", "Bairro Exemplo", "42", "55 47 0004-0002", "EX", "Rua Exemplo 4", "00.000.000/0004-02", null },
                    { 5L, "Fornecedor Padrão {i}", "Cidade Exemplo", 1L, "Brasil", true, "Fornecedor Padrão 5", "Bairro Exemplo", "52", "55 47 0005-0002", "EX", "Rua Exemplo 5", "00.000.000/0005-02", null },
                    { 6L, "Fornecedor Padrão {i}", "Cidade Exemplo", 1L, "Brasil", true, "Fornecedor Padrão 6", "Bairro Exemplo", "62", "55 47 0006-0002", "EX", "Rua Exemplo 6", "00.000.000/0006-02", null }
                });

            migrationBuilder.InsertData(
                table: "order",
                columns: new[] { "id", "company_id", "delivery_date_time", "order_date_time", "order_status_id", "supplier_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, 1L, null },
                    { 2L, 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, 2L, null },
                    { 3L, 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, 3L, null },
                    { 4L, 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, 4L, null },
                    { 5L, 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, 5L, null },
                    { 6L, 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, 6L, null }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "company_id", "description", "image_url", "minimal_stock_quantity", "name", "product_category_id", "unitary_selling_price", "unity_of_measure_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, "Banana Prata", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/152c5248ec73694bf1cf8be92c1d8e4720240227033525/450/banana-prata-kg_2019.jpg", 10, "Banana Prata", 1L, 6.89m, 2L, null },
                    { 2L, 1L, "Batata Inglesa Lavada", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/fb1a588af874d79db3c0c6ae8512a83e20240226225359/450/batata-inglesa-lavada-kg_7172.jpg", 10, "Batata Inglesa Lavada", 1L, 5.98m, 2L, null },
                    { 3L, 1L, "Suco Integral Laranja Prat's Garrafa 1,5l", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/0b2f3c4a5e6f7b8c9d0e1f2a3b4c5d6e20240226225359/450/suco-integral-laranja-prats-garrafa-15l_7172.jpg", 10, "Suco Integral Laranja Prat's Garrafa 1,5l", 2L, 23.99m, 1L, null },
                    { 4L, 1L, "Vinho Chileno Cabernet Sauvignon Montes Reserva Garrafa 750ml", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/e7e4a170a063c2102b4470ce991b714a20250409101224/450/vinho-chileno-cabernet-sauvignon-montes-reserva-garrafa-750ml_8040.jpg", 10, "Vinho Chileno Cabernet Sauvignon Montes Reserva Garrafa 750ml", 2L, 99.90m, 1L, null },
                    { 5L, 1L, "Costela Bovina Precoce Verdi", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/620ec78bf82c5deb224d95c0544a8f1e20250514171231/450/costela-bovina-precoce-verdi-kg_2380.jpg", 10, "Costela Bovina Precoce Verdi", 3L, 36.98m, 2L, null },
                    { 6L, 1L, "Filé Simples Bovino Precoce Verdi", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/8e15f72024db65d4faac6f3f07b2777920250509081238/450/file-simples-bovino-precoce-verdi-kg_4970.jpg", 10, "Filé Simples Bovino Precoce Verdi", 3L, 47.90m, 2L, null }
                });

            migrationBuilder.InsertData(
                table: "user_branch",
                columns: new[] { "id", "company_id", "BranchId1", "updated_at", "user_id", "UserId1" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, 1L, null },
                    { 2L, 2L, null, null, 1L, null },
                    { 3L, 3L, null, null, 1L, null }
                });

            migrationBuilder.InsertData(
                table: "batch",
                columns: new[] { "id", "batch_date", "expiration_date", "product_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 1), 1L, null },
                    { 2L, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 1), 2L, null },
                    { 3L, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 1), 3L, null },
                    { 4L, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 1), 4L, null },
                    { 5L, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 1), 5L, null },
                    { 6L, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 1), 6L, null }
                });

            migrationBuilder.InsertData(
                table: "product_in_inventory",
                columns: new[] { "id", "bar_code", "batch_id", "branch_id", "is_sold", "order_id", "product_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, "1234567890121", 1L, 1L, false, 1L, 1L, null },
                    { 2L, "1234567890122", 1L, 1L, false, 1L, 1L, null },
                    { 3L, "1234567890123", 1L, 1L, false, 1L, 1L, null },
                    { 4L, "1234567890124", 1L, 1L, false, 1L, 1L, null },
                    { 5L, "1234567890125", 1L, 1L, false, 1L, 1L, null },
                    { 6L, "1234567890126", 1L, 1L, false, 1L, 1L, null },
                    { 7L, "1234567890127", 1L, 1L, false, 1L, 1L, null },
                    { 8L, "1234567890128", 1L, 1L, false, 1L, 1L, null },
                    { 9L, "1234567890129", 1L, 1L, false, 1L, 1L, null },
                    { 10L, "12345678901210", 1L, 1L, false, 1L, 1L, null },
                    { 11L, "12345678901211", 2L, 1L, false, 2L, 2L, null },
                    { 12L, "12345678901212", 2L, 1L, false, 2L, 2L, null },
                    { 13L, "12345678901213", 2L, 1L, false, 2L, 2L, null },
                    { 14L, "12345678901214", 2L, 1L, false, 2L, 2L, null },
                    { 15L, "12345678901215", 2L, 1L, false, 2L, 2L, null },
                    { 16L, "12345678901216", 2L, 1L, false, 2L, 2L, null },
                    { 17L, "12345678901217", 2L, 1L, false, 2L, 2L, null },
                    { 18L, "12345678901218", 2L, 1L, false, 2L, 2L, null },
                    { 19L, "12345678901219", 2L, 1L, false, 2L, 2L, null },
                    { 20L, "12345678901220", 2L, 1L, false, 2L, 2L, null },
                    { 21L, "12345678901221", 3L, 1L, false, 3L, 3L, null },
                    { 22L, "12345678901222", 3L, 1L, false, 3L, 3L, null },
                    { 23L, "12345678901223", 3L, 1L, false, 3L, 3L, null },
                    { 24L, "12345678901224", 3L, 1L, false, 3L, 3L, null },
                    { 25L, "12345678901225", 3L, 1L, false, 3L, 3L, null },
                    { 26L, "12345678901226", 3L, 1L, false, 3L, 3L, null },
                    { 27L, "12345678901227", 3L, 1L, false, 3L, 3L, null },
                    { 28L, "12345678901228", 3L, 1L, false, 3L, 3L, null },
                    { 29L, "12345678901229", 3L, 1L, false, 3L, 3L, null },
                    { 30L, "12345678901230", 3L, 1L, false, 3L, 3L, null },
                    { 31L, "12345678901231", 4L, 1L, false, 4L, 4L, null },
                    { 32L, "12345678901232", 4L, 1L, false, 4L, 4L, null },
                    { 33L, "12345678901233", 4L, 1L, false, 4L, 4L, null },
                    { 34L, "12345678901234", 4L, 1L, false, 4L, 4L, null },
                    { 35L, "12345678901235", 4L, 1L, false, 4L, 4L, null },
                    { 36L, "12345678901236", 4L, 1L, false, 4L, 4L, null },
                    { 37L, "12345678901237", 4L, 1L, false, 4L, 4L, null },
                    { 38L, "12345678901238", 4L, 1L, false, 4L, 4L, null },
                    { 39L, "12345678901239", 4L, 1L, false, 4L, 4L, null },
                    { 40L, "12345678901240", 4L, 1L, false, 4L, 4L, null },
                    { 41L, "12345678901241", 5L, 1L, false, 5L, 5L, null },
                    { 42L, "12345678901242", 5L, 1L, false, 5L, 5L, null },
                    { 43L, "12345678901243", 5L, 1L, false, 5L, 5L, null },
                    { 44L, "12345678901244", 5L, 1L, false, 5L, 5L, null },
                    { 45L, "12345678901245", 5L, 1L, false, 5L, 5L, null },
                    { 46L, "12345678901246", 5L, 1L, false, 5L, 5L, null },
                    { 47L, "12345678901247", 5L, 1L, false, 5L, 5L, null },
                    { 48L, "12345678901248", 5L, 1L, false, 5L, 5L, null },
                    { 49L, "12345678901249", 5L, 1L, false, 5L, 5L, null },
                    { 50L, "12345678901250", 5L, 1L, false, 5L, 5L, null },
                    { 51L, "12345678901251", 6L, 1L, false, 6L, 6L, null },
                    { 52L, "12345678901252", 6L, 1L, false, 6L, 6L, null },
                    { 53L, "12345678901253", 6L, 1L, false, 6L, 6L, null },
                    { 54L, "12345678901254", 6L, 1L, false, 6L, 6L, null },
                    { 55L, "12345678901255", 6L, 1L, false, 6L, 6L, null },
                    { 56L, "12345678901256", 6L, 1L, false, 6L, 6L, null },
                    { 57L, "12345678901257", 6L, 1L, false, 6L, 6L, null },
                    { 58L, "12345678901258", 6L, 1L, false, 6L, 6L, null },
                    { 59L, "12345678901259", 6L, 1L, false, 6L, 6L, null },
                    { 60L, "12345678901260", 6L, 1L, false, 6L, 6L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_batch_product_id",
                table: "batch",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_branch_size_id",
                table: "branch",
                column: "branch_size_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_company_id",
                table: "branch",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_company_id",
                table: "client",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_tax_id",
                table: "company",
                column: "tax_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_company_id",
                table: "order",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_order_status_id",
                table: "order",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_supplier_id",
                table: "order",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_order_id_product_id",
                table: "order_item",
                columns: new[] { "order_id", "product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_item_product_id",
                table: "order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_company_id",
                table: "product",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_category_id",
                table: "product",
                column: "product_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_unity_of_measure_id",
                table: "product",
                column: "unity_of_measure_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_company_id",
                table: "product_category",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_batch_id",
                table: "product_in_inventory",
                column: "batch_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_branch_id",
                table: "product_in_inventory",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_order_id",
                table: "product_in_inventory",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_product_id",
                table: "product_in_inventory",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_client_id",
                table: "sale",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_company_id",
                table: "sale",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_supplier_id",
                table: "sale",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_item_product_id",
                table: "sale_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_item_sale_id",
                table: "sale_item",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_company_id",
                table: "supplier",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_product_company_id",
                table: "supplier_product",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_product_product_id",
                table: "supplier_product",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_product_supplier_id_product_id",
                table: "supplier_product",
                columns: new[] { "supplier_id", "product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_supplier_product_unity_of_measure_id",
                table: "supplier_product",
                column: "unity_of_measure_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_branch_BranchId1",
                table: "user_branch",
                column: "BranchId1");

            migrationBuilder.CreateIndex(
                name: "IX_user_branch_company_id",
                table: "user_branch",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_branch_user_id_company_id",
                table: "user_branch",
                columns: new[] { "user_id", "company_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_branch_UserId1",
                table: "user_branch",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "product_in_inventory");

            migrationBuilder.DropTable(
                name: "sale_item");

            migrationBuilder.DropTable(
                name: "supplier_product");

            migrationBuilder.DropTable(
                name: "user_branch");

            migrationBuilder.DropTable(
                name: "batch");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "sale");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropTable(
                name: "branch");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "product_category");

            migrationBuilder.DropTable(
                name: "unity_of_measure");

            migrationBuilder.DropTable(
                name: "branch_size");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
