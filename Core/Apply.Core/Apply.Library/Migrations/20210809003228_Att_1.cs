using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Library.Migrations
{
    public partial class Att_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CodCard = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotPayment = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CodCard);
                });

            migrationBuilder.CreateTable(
                name: "FlowClosed",
                columns: table => new
                {
                    CodFlowClosed = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowClosed", x => x.CodFlowClosed);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    CodPayment = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.CodPayment);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CodUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CodUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    CodWallet = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioNavigationCodUsuario = table.Column<long>(type: "bigint", nullable: true),
                    CodPayment = table.Column<int>(type: "int", nullable: false),
                    PaymentNavigationCodPayment = table.Column<long>(type: "bigint", nullable: true),
                    CodCards = table.Column<int>(type: "int", nullable: false),
                    CardsNavigationCodCard = table.Column<long>(type: "bigint", nullable: true),
                    CodFlowClosed = table.Column<int>(type: "int", nullable: false),
                    FlowClosedNavigationCodFlowClosed = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.CodWallet);
                    table.ForeignKey(
                        name: "FK_Wallet_Card_CardsNavigationCodCard",
                        column: x => x.CardsNavigationCodCard,
                        principalTable: "Card",
                        principalColumn: "CodCard",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wallet_FlowClosed_FlowClosedNavigationCodFlowClosed",
                        column: x => x.FlowClosedNavigationCodFlowClosed,
                        principalTable: "FlowClosed",
                        principalColumn: "CodFlowClosed",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wallet_Payment_PaymentNavigationCodPayment",
                        column: x => x.PaymentNavigationCodPayment,
                        principalTable: "Payment",
                        principalColumn: "CodPayment",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wallet_Usuario_UsuarioNavigationCodUsuario",
                        column: x => x.UsuarioNavigationCodUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_CardsNavigationCodCard",
                table: "Wallet",
                column: "CardsNavigationCodCard");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_FlowClosedNavigationCodFlowClosed",
                table: "Wallet",
                column: "FlowClosedNavigationCodFlowClosed");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_PaymentNavigationCodPayment",
                table: "Wallet",
                column: "PaymentNavigationCodPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UsuarioNavigationCodUsuario",
                table: "Wallet",
                column: "UsuarioNavigationCodUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "FlowClosed");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
