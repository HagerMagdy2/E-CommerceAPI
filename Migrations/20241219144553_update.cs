using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90d2960-6437-4c8d-977f-3f2f132f5205");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f17461bf-f95a-4719-acef-d6f1f880a390");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01095b8a-490c-4500-b55d-7127618298de", null, "customer", "CUSTOMER" },
                    { "aa0bba6e-c7e8-4809-a603-187be28d2d35", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01095b8a-490c-4500-b55d-7127618298de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa0bba6e-c7e8-4809-a603-187be28d2d35");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b90d2960-6437-4c8d-977f-3f2f132f5205", null, "admin", "ADMIN" },
                    { "f17461bf-f95a-4719-acef-d6f1f880a390", null, "customer", "CUSTOMER" }
                });
        }
    }
}
