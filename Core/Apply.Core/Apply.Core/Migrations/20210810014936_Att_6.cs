using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Core.Migrations
{
    public partial class Att_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Card_CardsNavigationCodCard",
                table: "Wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_FlowClosed_FlowClosedNavigationCodFlowClosed",
                table: "Wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Payment_PaymentNavigationCodPayment",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_CardsNavigationCodCard",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_FlowClosedNavigationCodFlowClosed",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_PaymentNavigationCodPayment",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "CardsNavigationCodCard",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "FlowClosedNavigationCodFlowClosed",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "PaymentNavigationCodPayment",
                table: "Wallet");

            migrationBuilder.AddColumn<long>(
                name: "WalletCodWallet",
                table: "Payment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WalletCodWallet",
                table: "FlowClosed",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WalletCodWallet",
                table: "Card",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_WalletCodWallet",
                table: "Payment",
                column: "WalletCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_FlowClosed_WalletCodWallet",
                table: "FlowClosed",
                column: "WalletCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_Card_WalletCodWallet",
                table: "Card",
                column: "WalletCodWallet");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Wallet_WalletCodWallet",
                table: "Card",
                column: "WalletCodWallet",
                principalTable: "Wallet",
                principalColumn: "CodWallet",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowClosed_Wallet_WalletCodWallet",
                table: "FlowClosed",
                column: "WalletCodWallet",
                principalTable: "Wallet",
                principalColumn: "CodWallet",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Wallet_WalletCodWallet",
                table: "Payment",
                column: "WalletCodWallet",
                principalTable: "Wallet",
                principalColumn: "CodWallet",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Wallet_WalletCodWallet",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowClosed_Wallet_WalletCodWallet",
                table: "FlowClosed");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Wallet_WalletCodWallet",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_WalletCodWallet",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_FlowClosed_WalletCodWallet",
                table: "FlowClosed");

            migrationBuilder.DropIndex(
                name: "IX_Card_WalletCodWallet",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "WalletCodWallet",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "WalletCodWallet",
                table: "FlowClosed");

            migrationBuilder.DropColumn(
                name: "WalletCodWallet",
                table: "Card");

            migrationBuilder.AddColumn<long>(
                name: "CardsNavigationCodCard",
                table: "Wallet",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FlowClosedNavigationCodFlowClosed",
                table: "Wallet",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentNavigationCodPayment",
                table: "Wallet",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Card_CardsNavigationCodCard",
                table: "Wallet",
                column: "CardsNavigationCodCard",
                principalTable: "Card",
                principalColumn: "CodCard",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_FlowClosed_FlowClosedNavigationCodFlowClosed",
                table: "Wallet",
                column: "FlowClosedNavigationCodFlowClosed",
                principalTable: "FlowClosed",
                principalColumn: "CodFlowClosed",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Payment_PaymentNavigationCodPayment",
                table: "Wallet",
                column: "PaymentNavigationCodPayment",
                principalTable: "Payment",
                principalColumn: "CodPayment",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
