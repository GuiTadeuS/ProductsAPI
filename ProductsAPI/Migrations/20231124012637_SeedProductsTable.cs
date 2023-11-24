using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 23, 22, 26, 37, 150, DateTimeKind.Local).AddTicks(7460), "Luva tamanho 9", "https://img.irroba.com.br/filters:fill(fff):quality(80)/soaquife/catalog/luva-profissional-ldi/luva-mecanico-02safetytato-alta-sensibilidade-pu-8010.jpg", "Luva", 25f },
                    { 2, new DateTime(2023, 11, 23, 22, 26, 37, 150, DateTimeKind.Local).AddTicks(7473), "Mascara descartavel", "https://cdn.awsli.com.br/2126/2126528/produto/135495613/f871fa1a82.jpg", "Mascara", 5f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
