using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Library.Migrations
{
    public partial class att9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioWallet",
                columns: table => new
                {
                    UWCod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodUsuario1 = table.Column<long>(type: "bigint", nullable: true),
                    CodWallet1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioWallet", x => x.UWCod);
                    table.ForeignKey(
                        name: "FK_UsuarioWallet_Usuario_CodUsuario1",
                        column: x => x.CodUsuario1,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioWallet_Wallet_CodWallet1",
                        column: x => x.CodWallet1,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioWallet_CodUsuario1",
                table: "UsuarioWallet",
                column: "CodUsuario1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioWallet_CodWallet1",
                table: "UsuarioWallet",
                column: "CodWallet1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioWallet");
        }
    }
}
