using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Library.Migrations
{
    public partial class att11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodCards",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "CodFlowClosed",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "CodPayment",
                table: "Wallet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodCards",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodFlowClosed",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodPayment",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
