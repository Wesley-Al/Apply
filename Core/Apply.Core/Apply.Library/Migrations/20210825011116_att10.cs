using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Library.Migrations
{
    public partial class att10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodUsuario",
                table: "Wallet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodUsuario",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
