using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientDataHarvester.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientDataSchema_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientData_ClientName_DataType",
                table: "ClientData");

            migrationBuilder.CreateIndex(
                name: "IX_ClientData_ClientName_DataType_TimeAdded",
                table: "ClientData",
                columns: new[] { "ClientName", "DataType", "TimeAdded" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientData_ClientName_DataType_TimeAdded",
                table: "ClientData");

            migrationBuilder.CreateIndex(
                name: "IX_ClientData_ClientName_DataType",
                table: "ClientData",
                columns: new[] { "ClientName", "DataType" },
                unique: true);
        }
    }
}
