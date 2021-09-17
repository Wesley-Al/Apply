using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Library.Migrations
{
    public partial class att7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowClosed");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.AddColumn<string>(
                name: "TypeCard",
                table: "Card",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeCard",
                table: "Card");

            migrationBuilder.CreateTable(
                name: "FlowClosed",
                columns: table => new
                {
                    CodFlowClosed = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true),
                    CodBank = table.Column<long>(type: "bigint", nullable: false),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true)
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
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true),
                    CodBank = table.Column<long>(type: "bigint", nullable: false),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true)
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
        }
    }
}
