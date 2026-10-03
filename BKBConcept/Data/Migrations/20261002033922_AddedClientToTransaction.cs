using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKBConcept.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedClientToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "WalletTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "WalletTransactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_ClientId",
                table: "WalletTransactions",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_AspNetUsers_ClientId",
                table: "WalletTransactions",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_AspNetUsers_ClientId",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_ClientId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "WalletTransactions");
        }
    }
}
