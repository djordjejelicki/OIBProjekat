using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("21632c49-2db6-4288-913d-5b3c4760b713"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95e89e79-8e85-42ac-84e4-0af0c4d71069"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("17253a67-a9e5-4b39-b802-77956ef38617"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" },
                    { new Guid("321744ee-fc6e-47ec-9dbe-0ae8639c9d66"), "Mina", "Dragic", "0d1052fc10403c863f8185f741e9c0d40ca64239a32f470b83ff7b203b356da2", 1, "minamng" },
                    { new Guid("3761a30e-a052-4e07-8dd0-be0305252ba0"), "Bojan", "Koledin", "548dff74c328bebbfbafb3800a2f3b78d024bc4a7bd1258eb4974a1e92948df9", 0, "bojansell" },
                    { new Guid("990e3b97-f433-4af8-a5bc-9c399d5dfecd"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("17253a67-a9e5-4b39-b802-77956ef38617"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("321744ee-fc6e-47ec-9dbe-0ae8639c9d66"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3761a30e-a052-4e07-8dd0-be0305252ba0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("990e3b97-f433-4af8-a5bc-9c399d5dfecd"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("21632c49-2db6-4288-913d-5b3c4760b713"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" },
                    { new Guid("95e89e79-8e85-42ac-84e4-0af0c4d71069"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" }
                });
        }
    }
}
