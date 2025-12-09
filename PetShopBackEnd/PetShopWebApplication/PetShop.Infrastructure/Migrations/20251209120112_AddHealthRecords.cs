using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHealthRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b8bbef4-5719-4bbf-bb5f-506482f902a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("257b910f-a26e-4c38-8721-a99be9e961c1"));

            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordType = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    RecorderBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("518dc5af-c567-49e8-b8e0-1c1a9c83909e"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" },
                    { new Guid("9d662964-1979-4e52-a6fc-66105bd6570b"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_PetId",
                table: "HealthRecords",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthRecords");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("518dc5af-c567-49e8-b8e0-1c1a9c83909e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d662964-1979-4e52-a6fc-66105bd6570b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("0b8bbef4-5719-4bbf-bb5f-506482f902a2"), "Default", "Seller", "2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0", 0, "seller" },
                    { new Guid("257b910f-a26e-4c38-8721-a99be9e961c1"), "Main", "Manager", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 1, "manager" }
                });
        }
    }
}
