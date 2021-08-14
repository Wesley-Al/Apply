using Microsoft.EntityFrameworkCore.Migrations;

namespace Apply.Core.Migrations
{
    public partial class Att_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Usuario_UsuarioNavigationCodUsuario",
                table: "Wallet");

            migrationBuilder.RenameColumn(
                name: "UsuarioNavigationCodUsuario",
                table: "Wallet",
                newName: "BankNavigationCodBank");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_UsuarioNavigationCodUsuario",
                table: "Wallet",
                newName: "IX_Wallet_BankNavigationCodBank");

            migrationBuilder.RenameColumn(
                name: "WalletCodWallet",
                table: "Payment",
                newName: "WalletNavigationCodWallet");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_WalletCodWallet",
                table: "Payment",
                newName: "IX_Payment_WalletNavigationCodWallet");

            migrationBuilder.RenameColumn(
                name: "WalletCodWallet",
                table: "FlowClosed",
                newName: "WalletNavigationCodWallet");

            migrationBuilder.RenameIndex(
                name: "IX_FlowClosed_WalletCodWallet",
                table: "FlowClosed",
                newName: "IX_FlowClosed_WalletNavigationCodWallet");

            migrationBuilder.RenameColumn(
                name: "WalletCodWallet",
                table: "Card",
                newName: "WalletNavigationCodWallet");

            migrationBuilder.RenameIndex(
                name: "IX_Card_WalletCodWallet",
                table: "Card",
                newName: "IX_Card_WalletNavigationCodWallet");

            migrationBuilder.AddColumn<long>(
                name: "CodBank",
                table: "Wallet",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CodWallet",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WalletNavigationCodWallet",
                table: "Usuario",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BankNavigationCodBank",
                table: "Payment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CodBank",
                table: "Payment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BankNavigationCodBank",
                table: "FlowClosed",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CodBank",
                table: "FlowClosed",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BankNavigationCodBank",
                table: "Card",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CodBank",
                table: "Card",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_WalletNavigationCodWallet",
                table: "Usuario",
                column: "WalletNavigationCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BankNavigationCodBank",
                table: "Payment",
                column: "BankNavigationCodBank");

            migrationBuilder.CreateIndex(
                name: "IX_FlowClosed_BankNavigationCodBank",
                table: "FlowClosed",
                column: "BankNavigationCodBank");

            migrationBuilder.CreateIndex(
                name: "IX_Card_BankNavigationCodBank",
                table: "Card",
                column: "BankNavigationCodBank");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Banks_BankNavigationCodBank",
                table: "Card",
                column: "BankNavigationCodBank",
                principalTable: "Banks",
                principalColumn: "CodBank",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Wallet_WalletNavigationCodWallet",
                table: "Card",
                column: "WalletNavigationCodWallet",
                principalTable: "Wallet",
                principalColumn: "CodWallet",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowClosed_Banks_BankNavigationCodBank",
                table: "FlowClosed",
                column: "BankNavigationCodBank",
                principalTable: "Banks",
                principalColumn: "CodBank",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowClosed_Wallet_WalletNavigationCodWallet",
                table: "FlowClosed",
                column: "WalletNavigationCodWallet",
                principalTable: "Wallet",
                principalColumn: "CodWallet",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Banks_BankNavigationCodBank",
                table: "Payment",
                column: "BankNavigationCodBank",
                principalTable: "Banks",
                principalColumn: "CodBank",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Wallet_WalletNavigationCodWallet",
                table: "Payment",
                column: "WalletNavigationCodWallet",
                principalTable: "Wallet",
                principalColumn: "CodWallet",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Wallet_WalletNavigationCodWallet",
                table: "Usuario",
                column: "WalletNavigationCodWallet",
                principalTable: "Wallet",
                principalColumn: "CodWallet",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Banks_BankNavigationCodBank",
                table: "Wallet",
                column: "BankNavigationCodBank",
                principalTable: "Banks",
                principalColumn: "CodBank",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Banks_BankNavigationCodBank",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Wallet_WalletNavigationCodWallet",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowClosed_Banks_BankNavigationCodBank",
                table: "FlowClosed");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowClosed_Wallet_WalletNavigationCodWallet",
                table: "FlowClosed");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Banks_BankNavigationCodBank",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Wallet_WalletNavigationCodWallet",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Wallet_WalletNavigationCodWallet",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Banks_BankNavigationCodBank",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_WalletNavigationCodWallet",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BankNavigationCodBank",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_FlowClosed_BankNavigationCodBank",
                table: "FlowClosed");

            migrationBuilder.DropIndex(
                name: "IX_Card_BankNavigationCodBank",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CodBank",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "CodWallet",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "WalletNavigationCodWallet",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "BankNavigationCodBank",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CodBank",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BankNavigationCodBank",
                table: "FlowClosed");

            migrationBuilder.DropColumn(
                name: "CodBank",
                table: "FlowClosed");

            migrationBuilder.DropColumn(
                name: "BankNavigationCodBank",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CodBank",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "BankNavigationCodBank",
                table: "Wallet",
                newName: "UsuarioNavigationCodUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_BankNavigationCodBank",
                table: "Wallet",
                newName: "IX_Wallet_UsuarioNavigationCodUsuario");

            migrationBuilder.RenameColumn(
                name: "WalletNavigationCodWallet",
                table: "Payment",
                newName: "WalletCodWallet");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_WalletNavigationCodWallet",
                table: "Payment",
                newName: "IX_Payment_WalletCodWallet");

            migrationBuilder.RenameColumn(
                name: "WalletNavigationCodWallet",
                table: "FlowClosed",
                newName: "WalletCodWallet");

            migrationBuilder.RenameIndex(
                name: "IX_FlowClosed_WalletNavigationCodWallet",
                table: "FlowClosed",
                newName: "IX_FlowClosed_WalletCodWallet");

            migrationBuilder.RenameColumn(
                name: "WalletNavigationCodWallet",
                table: "Card",
                newName: "WalletCodWallet");

            migrationBuilder.RenameIndex(
                name: "IX_Card_WalletNavigationCodWallet",
                table: "Card",
                newName: "IX_Card_WalletCodWallet");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Usuario_UsuarioNavigationCodUsuario",
                table: "Wallet",
                column: "UsuarioNavigationCodUsuario",
                principalTable: "Usuario",
                principalColumn: "CodUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
