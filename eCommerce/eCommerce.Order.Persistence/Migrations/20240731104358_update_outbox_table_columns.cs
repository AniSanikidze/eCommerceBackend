using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Order.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_outbox_table_columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Error",
                table: "OutboxMessages");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OutboxMessages",
                newName: "Payload");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "OutboxMessages",
                newName: "EventType");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessedOn",
                table: "OutboxMessages",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessedOn",
                table: "OutboxMessages");

            migrationBuilder.RenameColumn(
                name: "Payload",
                table: "OutboxMessages",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "EventType",
                table: "OutboxMessages",
                newName: "Content");

            migrationBuilder.AddColumn<string>(
                name: "Error",
                table: "OutboxMessages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
