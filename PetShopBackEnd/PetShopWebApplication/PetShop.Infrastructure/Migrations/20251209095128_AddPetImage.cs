using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPetImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("774f831d-4b6b-4fcb-9bd2-a6f4f321066b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f77b34f-6f28-408d-8169-2ce7af97a05b"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pets",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("0b8bbef4-5719-4bbf-bb5f-506482f902a2"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" },
                    { new Guid("257b910f-a26e-4c38-8721-a99be9e961c1"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b8bbef4-5719-4bbf-bb5f-506482f902a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("257b910f-a26e-4c38-8721-a99be9e961c1"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pets");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("774f831d-4b6b-4fcb-9bd2-a6f4f321066b"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" },
                    { new Guid("8f77b34f-6f28-408d-8169-2ce7af97a05b"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" }
                });
        }
    }
}
