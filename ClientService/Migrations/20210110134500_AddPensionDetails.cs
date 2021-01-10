using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientService.Migrations
{
    public partial class AddPensionDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PensionTotal",
                table: "ClientDetails",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PensionType",
                table: "ClientDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PensionTotal",
                table: "ClientDetails");

            migrationBuilder.DropColumn(
                name: "PensionType",
                table: "ClientDetails");
        }
    }
}
