using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientDataHarvester.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientDataSchema_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeModified",
                table: "ClientData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeModified",
                table: "ClientData",
                type: "datetime2",
                nullable: true);
        }
    }
}
