using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto_Aplicado_II_API.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonprem_migration_598 : Migration
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
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    tax_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "CNPJ"),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unity_of_measure",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    neighborhood = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    city = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    state = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    country = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    branch_size_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "product_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    tax_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    neighborhood = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    city = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    state = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    country = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    branch_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_branch", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_branch_branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    ean_13_bar_code = table.Column<string>(type: "nchar(13)", fixedLength: true, maxLength: 13, nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    product_category_id = table.Column<long>(type: "bigint", nullable: false),
                    unitary_selling_price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    unity_of_measure_id = table.Column<long>(type: "bigint", nullable: false),
                    minimal_inventory_quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 10),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "sale",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sale_date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    branch_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.id);
                    table.ForeignKey(
                        name: "FK_sale_branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sale_supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "supplier",
                        principalColumn: "id");
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
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_product", x => x.id);
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
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_sale_item_supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "supplier",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_in_inventory",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    ManufacturingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    sale_item_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    branch_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_in_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_sale_item_sale_item_id",
                        column: x => x.sale_item_id,
                        principalTable: "sale_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_in_inventory_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "branch_size",
                columns: new[] { "id", "created_at", "description", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), "Pequena", null },
                    { 2L, new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), "Média", null },
                    { 3L, new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), "Grande", null }
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "id", "business_name", "created_at", "email", "is_active", "legal_name", "phone", "tax_id", "updated_at" },
                values: new object[] { 1L, "Empresa Padrão LTDA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "empresa.padrao@company.com", true, "Empresa Padrão", "55 47 0001-0001", "00.000.000/0001-01", null });

            migrationBuilder.InsertData(
                table: "unity_of_measure",
                columns: new[] { "id", "created_at", "Description", "Symbol", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unidade", "UN", null },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quilograma", "kg", null },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grama", "g", null },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miligrama", "mg", null },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Litro", "L", null },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mililitro", "mL", null },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quilômetro", "km", null },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metro", "m", null },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milímetro", "ml", null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "created_at", "email", "is_active", "is_admin", "name", "password_hash", "password_salt_hash", "updated_at" },
                values: new object[] { 1L, new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), "admin@admin.com", true, true, "Admin", new byte[] { 106, 81, 44, 80, 75, 157, 220, 207, 185, 250, 202, 13, 10, 59, 117, 138, 172, 230, 74, 223, 189, 1, 152, 66, 146, 180, 174, 9, 104, 9, 3, 126 }, new byte[] { 99, 212, 93, 197, 93, 127, 86, 151, 50, 94, 80, 108, 64, 232, 22, 152 }, null });

            migrationBuilder.InsertData(
                table: "branch",
                columns: new[] { "id", "branch_size_id", "city", "company_id", "country", "created_at", "is_active", "name", "neighborhood", "number", "state", "street", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Filial Padrão 1", "Bairro Exemplo", "11", "EX", "Rua Exemplo 1", null },
                    { 2L, 2L, "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Filial Padrão 2", "Bairro Exemplo", "21", "EX", "Rua Exemplo 2", null },
                    { 3L, 3L, "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Filial Padrão 3", "Bairro Exemplo", "31", "EX", "Rua Exemplo 3", null }
                });

            migrationBuilder.InsertData(
                table: "product_category",
                columns: new[] { "id", "company_id", "created_at", "description", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hortifruti", null },
                    { 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bebidas", null },
                    { 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carnes, Aves e Peixes", null }
                });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "id", "business_name", "city", "company_id", "country", "created_at", "email", "is_active", "legal_name", "neighborhood", "number", "phone", "state", "street", "tax_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, "Fornecedor Padrão 1", "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fornecedor.padrao1@supplier.com", true, "Fornecedor Padrão 1", "Bairro Exemplo", "12", "55 47 0001-0002", "EX", "Rua Exemplo 1", "00.000.000/0001-02", null },
                    { 2L, "Fornecedor Padrão 2", "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fornecedor.padrao2@supplier.com", true, "Fornecedor Padrão 2", "Bairro Exemplo", "22", "55 47 0002-0002", "EX", "Rua Exemplo 2", "00.000.000/0002-02", null },
                    { 3L, "Fornecedor Padrão 3", "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fornecedor.padrao3@supplier.com", true, "Fornecedor Padrão 3", "Bairro Exemplo", "32", "55 47 0003-0002", "EX", "Rua Exemplo 3", "00.000.000/0003-02", null },
                    { 4L, "Fornecedor Padrão 4", "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fornecedor.padrao4@supplier.com", true, "Fornecedor Padrão 4", "Bairro Exemplo", "42", "55 47 0004-0002", "EX", "Rua Exemplo 4", "00.000.000/0004-02", null },
                    { 5L, "Fornecedor Padrão 5", "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fornecedor.padrao5@supplier.com", true, "Fornecedor Padrão 5", "Bairro Exemplo", "52", "55 47 0005-0002", "EX", "Rua Exemplo 5", "00.000.000/0005-02", null },
                    { 6L, "Fornecedor Padrão 6", "Cidade Exemplo", 1L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fornecedor.padrao6@supplier.com", true, "Fornecedor Padrão 6", "Bairro Exemplo", "62", "55 47 0006-0002", "EX", "Rua Exemplo 6", "00.000.000/0006-02", null }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "company_id", "created_at", "ean_13_bar_code", "image_url", "is_active", "minimal_inventory_quantity", "name", "product_category_id", "unitary_selling_price", "unity_of_measure_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7890000010016", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/152c5248ec73694bf1cf8be92c1d8e4720240227033525/450/banana-prata-kg_2019.jpg", true, 10, "Banana Prata", 1L, 6.89m, 2L, null },
                    { 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7890000010026", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/fb1a588af874d79db3c0c6ae8512a83e20240226225359/450/batata-inglesa-lavada-kg_7172.jpg", true, 10, "Batata Inglesa Lavada", 1L, 5.98m, 2L, null },
                    { 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7890000010036", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/d72ca3f78b35715d1308a4cb6a6fcba220250520141235/450/suco-integral-laranja-prats-garrafa-1-5l_2294.jpg", true, 10, "Suco Integral Laranja Prat's Garrafa 1,5l", 2L, 23.99m, 1L, null },
                    { 4L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7890000010046", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/e7e4a170a063c2102b4470ce991b714a20250409101224/450/vinho-chileno-cabernet-sauvignon-montes-reserva-garrafa-750ml_8040.jpg", true, 10, "Vinho Chileno Cabernet Sauvignon Montes Reserva Garrafa 750ml", 2L, 99.90m, 1L, null },
                    { 5L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7890000010056", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/620ec78bf82c5deb224d95c0544a8f1e20250514171231/450/costela-bovina-precoce-verdi-kg_2380.jpg", true, 10, "Costela Bovina Precoce Verdi", 3L, 36.98m, 2L, null },
                    { 6L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7890000010066", "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/8e15f72024db65d4faac6f3f07b2777920250509081238/450/file-simples-bovino-precoce-verdi-kg_4970.jpg", true, 10, "Filé Simples Bovino Precoce Verdi", 3L, 47.90m, 2L, null }
                });

            migrationBuilder.InsertData(
                table: "sale",
                columns: new[] { "id", "branch_id", "created_at", "sale_date_time", "SupplierId", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 4L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 5L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 6L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 7L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 8L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 9L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 10L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 11L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null },
                    { 12L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 6, 12, 30, 0, 0, DateTimeKind.Utc), null, null }
                });

            migrationBuilder.InsertData(
                table: "user_branch",
                columns: new[] { "id", "branch_id", "created_at", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1L },
                    { 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1L },
                    { 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1L }
                });

            migrationBuilder.InsertData(
                table: "product_in_inventory",
                columns: new[] { "id", "branch_id", "created_at", "ManufacturingDate", "product_id", "sale_item_id", "supplier_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 4L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 5L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 6L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 7L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 8L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 9L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 10L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, null, 1L, null },
                    { 11L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 12L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 13L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 14L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 15L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 16L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 17L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 18L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 19L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 20L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, null, 2L, null },
                    { 21L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 22L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 23L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 24L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 25L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 26L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 27L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 28L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 29L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 30L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, null, 3L, null },
                    { 31L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 32L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 33L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 34L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 35L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 36L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 37L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 38L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 39L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 40L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, null, 4L, null },
                    { 41L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 42L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 43L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 44L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 45L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 46L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 47L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 48L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 49L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 50L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, null, 5L, null },
                    { 51L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 52L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 53L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 54L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 55L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 56L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 57L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 58L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 59L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null },
                    { 60L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, null, 6L, null }
                });

            migrationBuilder.InsertData(
                table: "sale_item",
                columns: new[] { "id", "created_at", "product_id", "quantity", "sale_id", "SupplierId", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2, 1L, null, null },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2, 2L, null, null },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 2, 3L, null, null },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 2, 4L, null, null },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 2, 5L, null, null },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 2, 6L, null, null },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 2, 7L, null, null },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 2, 8L, null, null },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2, 9L, null, null },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2, 10L, null, null },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 2, 11L, null, null },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 2, 12L, null, null }
                });

            migrationBuilder.InsertData(
                table: "supplier_product",
                columns: new[] { "id", "created_at", "product_id", "supplier_id", "unitary_price", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, 0.99m, null },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 2L, 1.98m, null },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 3L, 2.97m, null },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 4L, 3.96m, null },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 5L, 4.95m, null },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 6L, 5.94m, null }
                });

            migrationBuilder.InsertData(
                table: "product_in_inventory",
                columns: new[] { "id", "branch_id", "created_at", "ManufacturingDate", "product_id", "sale_item_id", "supplier_id", "updated_at" },
                values: new object[,]
                {
                    { 61L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, 1L, 1L, null },
                    { 62L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, 1L, 1L, null },
                    { 63L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, 2L, 1L, null },
                    { 64L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 1L, 2L, 1L, null },
                    { 65L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, 3L, 2L, null },
                    { 66L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, 3L, 2L, null },
                    { 67L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, 4L, 2L, null },
                    { 68L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 2L, 4L, 2L, null },
                    { 69L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, 5L, 3L, null },
                    { 70L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, 5L, 3L, null },
                    { 71L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, 6L, 3L, null },
                    { 72L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 3L, 6L, 3L, null },
                    { 73L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, 7L, 4L, null },
                    { 74L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, 7L, 4L, null },
                    { 75L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, 8L, 4L, null },
                    { 76L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 4L, 8L, 4L, null },
                    { 77L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, 9L, 5L, null },
                    { 78L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, 9L, 5L, null },
                    { 79L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, 10L, 5L, null },
                    { 80L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 5L, 10L, 5L, null },
                    { 81L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, 11L, 6L, null },
                    { 82L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, 11L, 6L, null },
                    { 83L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, 12L, 6L, null },
                    { 84L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1, 1, 1), 6L, 12L, 6L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_branch_branch_size_id",
                table: "branch",
                column: "branch_size_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_company_id",
                table: "branch",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_tax_id",
                table: "company",
                column: "tax_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_company_id",
                table: "product",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_ean_13_bar_code",
                table: "product",
                column: "ean_13_bar_code",
                unique: true);

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
                name: "IX_product_in_inventory_branch_id",
                table: "product_in_inventory",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_product_id",
                table: "product_in_inventory",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_sale_item_id",
                table: "product_in_inventory",
                column: "sale_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_inventory_supplier_id",
                table: "product_in_inventory",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_branch_id",
                table: "sale",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_SupplierId",
                table: "sale",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_sale_item_product_id",
                table: "sale_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_item_sale_id",
                table: "sale_item",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_item_SupplierId",
                table: "sale_item",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_company_id",
                table: "supplier",
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
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_branch_branch_id",
                table: "user_branch",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_branch_user_id_branch_id",
                table: "user_branch",
                columns: new[] { "user_id", "branch_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_in_inventory");

            migrationBuilder.DropTable(
                name: "supplier_product");

            migrationBuilder.DropTable(
                name: "user_branch");

            migrationBuilder.DropTable(
                name: "sale_item");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "sale");

            migrationBuilder.DropTable(
                name: "product_category");

            migrationBuilder.DropTable(
                name: "unity_of_measure");

            migrationBuilder.DropTable(
                name: "branch");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "branch_size");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
