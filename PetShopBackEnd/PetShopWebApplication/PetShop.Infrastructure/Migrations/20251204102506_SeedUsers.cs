using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("3d0d51cc-8318-4336-9c79-88c0eddc5be1"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" },
                    { new Guid("ad35b536-5f4a-4ea6-a338-f0402582f903"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d0d51cc-8318-4336-9c79-88c0eddc5be1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ad35b536-5f4a-4ea6-a338-f0402582f903"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
