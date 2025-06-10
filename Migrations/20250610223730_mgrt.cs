using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Aplicado_II_API.Migrations
{
    /// <inheritdoc />
    public partial class mgrt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_in_inventory_supplier_SupplierId",
                table: "product_in_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_branch_company_id",
                table: "sale");

            migrationBuilder.DropForeignKey(
                name: "FK_user_branch_branch_company_id",
                table: "user_branch");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "user_branch",
                newName: "branch_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_branch_user_id_company_id",
                table: "user_branch",
                newName: "IX_user_branch_user_id_branch_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_branch_company_id",
                table: "user_branch",
                newName: "IX_user_branch_branch_id");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "sale",
                newName: "branch_id");

            migrationBuilder.RenameIndex(
                name: "IX_sale_company_id",
                table: "sale",
                newName: "IX_sale_branch_id");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "product_in_inventory",
                newName: "supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_in_inventory_SupplierId",
                table: "product_in_inventory",
                newName: "IX_product_in_inventory_supplier_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "user_branch",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "user",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "unity_of_measure",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "supplier_product",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "supplier",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "sale_item",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "sale",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_in_inventory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_category",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "company",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "branch_size",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "branch",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_product_in_inventory_supplier_supplier_id",
                table: "product_in_inventory",
                column: "supplier_id",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_branch_branch_id",
                table: "sale",
                column: "branch_id",
                principalTable: "branch",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_branch_branch_branch_id",
                table: "user_branch",
                column: "branch_id",
                principalTable: "branch",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_in_inventory_supplier_supplier_id",
                table: "product_in_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_branch_branch_id",
                table: "sale");

            migrationBuilder.DropForeignKey(
                name: "FK_user_branch_branch_branch_id",
                table: "user_branch");

            migrationBuilder.RenameColumn(
                name: "branch_id",
                table: "user_branch",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_branch_user_id_branch_id",
                table: "user_branch",
                newName: "IX_user_branch_user_id_company_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_branch_branch_id",
                table: "user_branch",
                newName: "IX_user_branch_company_id");

            migrationBuilder.RenameColumn(
                name: "branch_id",
                table: "sale",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_sale_branch_id",
                table: "sale",
                newName: "IX_sale_company_id");

            migrationBuilder.RenameColumn(
                name: "supplier_id",
                table: "product_in_inventory",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_product_in_inventory_supplier_id",
                table: "product_in_inventory",
                newName: "IX_product_in_inventory_SupplierId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "user_branch",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "unity_of_measure",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "supplier_product",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "supplier",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "sale_item",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "sale",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_in_inventory",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_category",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "company",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "branch_size",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "branch",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_product_in_inventory_supplier_SupplierId",
                table: "product_in_inventory",
                column: "SupplierId",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_branch_company_id",
                table: "sale",
                column: "company_id",
                principalTable: "branch",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_branch_branch_company_id",
                table: "user_branch",
                column: "company_id",
                principalTable: "branch",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
