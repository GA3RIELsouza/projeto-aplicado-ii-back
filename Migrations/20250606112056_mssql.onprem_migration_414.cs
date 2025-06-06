using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto_Aplicado_II_API.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonprem_migration_414 : Migration
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
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    BatchId = table.Column<long>(type: "bigint", nullable: false),
                    bar_code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    is_sold = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    branch_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_in_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { 1L, "Empresa Padrão LTDA", true, "Empresa Padrão", "0000-0000", "00.000.000/0001-91", null });

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
                    { 1L, 1L, "Cidade Exemplo", 1L, "Brasil", true, "Filial Padrão 1", "Bairro Exemplo", "123", "EX", "Rua Exemplo 1", null },
                    { 2L, 2L, "Cidade Exemplo", 1L, "Brasil", true, "Filial Padrão 2", "Bairro Exemplo", "124", "EX", "Rua Exemplo 2", null },
                    { 3L, 3L, "Cidade Exemplo", 1L, "Brasil", true, "Filial Padrão 3", "Bairro Exemplo", "125", "EX", "Rua Exemplo 3", null }
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
                name: "IX_product_in_inventory_BatchId",
                table: "product_in_inventory",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_branch_id",
                table: "product_in_inventory",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_OrderId",
                table: "product_in_inventory",
                column: "OrderId");

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
