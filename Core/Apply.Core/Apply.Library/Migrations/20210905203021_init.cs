using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Library.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    CodBank = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameBank = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.CodBank);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    CodWallet = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DtCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CodCard = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotPayment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Amount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlowClosed",
                columns: table => new
                {
                    CodFlowClosed = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    CodPayment = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CodUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DtCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioLogin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioWallet",
                columns: table => new
                {
                    UWCod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_UsuarioWallet_CodUsuario1",
                table: "UsuarioWallet",
                column: "CodUsuario1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioWallet_CodWallet1",
                table: "UsuarioWallet",
                column: "CodWallet1");

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
                name: "UsuarioWallet");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
