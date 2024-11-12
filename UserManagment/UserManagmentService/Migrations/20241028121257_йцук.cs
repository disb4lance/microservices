using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagmentService.Migrations
{
    /// <inheritdoc />
    public partial class йцук : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "530e931d-a7ec-4c1c-b00d-836e84f64014");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c181c01-f0da-47a0-a861-74f1bd209d9a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a15be05a-0842-46b8-bb78-6d36ef461e78", null, "Administrator", "ADMINISTRATOR" },
                    { "d9ac7554-109b-41ff-a66a-ba7a68a2262b", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a15be05a-0842-46b8-bb78-6d36ef461e78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9ac7554-109b-41ff-a66a-ba7a68a2262b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "530e931d-a7ec-4c1c-b00d-836e84f64014", null, "Administrator", "ADMINISTRATOR" },
                    { "8c181c01-f0da-47a0-a861-74f1bd209d9a", null, "Manager", "MANAGER" }
                });
        }
    }
}
