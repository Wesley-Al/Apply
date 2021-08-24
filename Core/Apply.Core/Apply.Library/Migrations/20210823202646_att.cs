using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Library.Migrations
{
    public partial class att : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    CodBank = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.CodBank);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    CodWallet = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodUsuario = table.Column<int>(type: "int", nullable: false),
                    CodPayment = table.Column<int>(type: "int", nullable: false),
                    CodCards = table.Column<int>(type: "int", nullable: false),
                    CodFlowClosed = table.Column<int>(type: "int", nullable: false),
                    CodBank = table.Column<long>(type: "bigint", nullable: false),
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.CodWallet);
                    table.ForeignKey(
                        name: "FK_Wallet_Banks_BankNavigationCodBank",
                        column: x => x.BankNavigationCodBank,
                        principalTable: "Banks",
                        principalColumn: "CodBank",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CodCard = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotPayment = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true),
                    CodBank = table.Column<long>(type: "bigint", nullable: false),
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CodCard);
                    table.ForeignKey(
                        name: "FK_Card_Banks_BankNavigationCodBank",
                        column: x => x.BankNavigationCodBank,
                        principalTable: "Banks",
                        principalColumn: "CodBank",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Wallet_WalletNavigationCodWallet",
                        column: x => x.WalletNavigationCodWallet,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlowClosed",
                columns: table => new
                {
                    CodFlowClosed = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true),
                    CodBank = table.Column<long>(type: "bigint", nullable: false),
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowClosed", x => x.CodFlowClosed);
                    table.ForeignKey(
                        name: "FK_FlowClosed_Banks_BankNavigationCodBank",
                        column: x => x.BankNavigationCodBank,
                        principalTable: "Banks",
                        principalColumn: "CodBank",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlowClosed_Wallet_WalletNavigationCodWallet",
                        column: x => x.WalletNavigationCodWallet,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    CodPayment = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true),
                    CodBank = table.Column<long>(type: "bigint", nullable: false),
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.CodPayment);
                    table.ForeignKey(
                        name: "FK_Payment_Banks_BankNavigationCodBank",
                        column: x => x.BankNavigationCodBank,
                        principalTable: "Banks",
                        principalColumn: "CodBank",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Wallet_WalletNavigationCodWallet",
                        column: x => x.WalletNavigationCodWallet,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CodUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CodUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Wallet_WalletNavigationCodWallet",
                        column: x => x.WalletNavigationCodWallet,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_BankNavigationCodBank",
                table: "Card",
                column: "BankNavigationCodBank");

            migrationBuilder.CreateIndex(
                name: "IX_Card_WalletNavigationCodWallet",
                table: "Card",
                column: "WalletNavigationCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_FlowClosed_BankNavigationCodBank",
                table: "FlowClosed",
                column: "BankNavigationCodBank");

            migrationBuilder.CreateIndex(
                name: "IX_FlowClosed_WalletNavigationCodWallet",
                table: "FlowClosed",
                column: "WalletNavigationCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BankNavigationCodBank",
                table: "Payment",
                column: "BankNavigationCodBank");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_WalletNavigationCodWallet",
                table: "Payment",
                column: "WalletNavigationCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_WalletNavigationCodWallet",
                table: "Usuario",
                column: "WalletNavigationCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_BankNavigationCodBank",
                table: "Wallet",
                column: "BankNavigationCodBank");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "FlowClosed");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
