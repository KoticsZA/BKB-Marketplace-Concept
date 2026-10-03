using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKBConcept.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedGroupEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "SellerProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "HarvestDate",
                table: "Products",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    WalletId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Wallets_WalletId1",
                        column: x => x.WalletId1,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_GroupId",
                table: "Wallets",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GroupId",
                table: "Orders",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_WalletId1",
                table: "Groups",
                column: "WalletId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId1",
                table: "UserGroups",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Groups_GroupId",
                table: "Orders",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_UserGroups_GroupId",
                table: "Wallets",
                column: "GroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Groups_GroupId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_UserGroups_GroupId",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_GroupId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GroupId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "SellerProfiles");

            migrationBuilder.DropColumn(
                name: "HarvestDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
