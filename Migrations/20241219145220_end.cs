using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class end : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01095b8a-490c-4500-b55d-7127618298de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa0bba6e-c7e8-4809-a603-187be28d2d35");

            migrationBuilder.RenameColumn(
                name: "producr_name",
                table: "Products",
                newName: "product_name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7537d183-d0ba-4867-afa0-089be7f2c031", null, "admin", "ADMIN" },
                    { "e358f6e1-8a8a-4ad7-90ad-18766b5e8f3e", null, "customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7537d183-d0ba-4867-afa0-089be7f2c031");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e358f6e1-8a8a-4ad7-90ad-18766b5e8f3e");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Products",
                newName: "producr_name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01095b8a-490c-4500-b55d-7127618298de", null, "customer", "CUSTOMER" },
                    { "aa0bba6e-c7e8-4809-a603-187be28d2d35", null, "admin", "ADMIN" }
                });
        }
    }
}
