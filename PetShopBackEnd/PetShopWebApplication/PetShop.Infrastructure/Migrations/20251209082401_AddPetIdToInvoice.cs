using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPetIdToInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d0d51cc-8318-4336-9c79-88c0eddc5be1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ad35b536-5f4a-4ea6-a338-f0402582f903"));

            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "Invoices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("774f831d-4b6b-4fcb-9bd2-a6f4f321066b"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" },
                    { new Guid("8f77b34f-6f28-408d-8169-2ce7af97a05b"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("774f831d-4b6b-4fcb-9bd2-a6f4f321066b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f77b34f-6f28-408d-8169-2ce7af97a05b"));

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("3d0d51cc-8318-4336-9c79-88c0eddc5be1"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" },
                    { new Guid("ad35b536-5f4a-4ea6-a338-f0402582f903"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" }
                });
        }
    }
}
