using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Auth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_roles_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("20475fb2-61ff-472a-99e9-25f96f0c122e"), null, "Admin", "ADMIN" },
                    { new Guid("6a5d4753-c1fc-403c-8d35-d0c86b945093"), null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("20475fb2-61ff-472a-99e9-25f96f0c122e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a5d4753-c1fc-403c-8d35-d0c86b945093"));
        }
    }
}
