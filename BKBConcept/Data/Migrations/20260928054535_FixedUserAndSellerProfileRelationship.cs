using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKBConcept.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserAndSellerProfileRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SellerProfiles_SellerProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SellerProfileId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SellerProfiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProductImgURL",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellerProfiles_UserId",
                table: "SellerProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerProfiles_AspNetUsers_UserId",
                table: "SellerProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerProfiles_AspNetUsers_UserId",
                table: "SellerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_SellerProfiles_UserId",
                table: "SellerProfiles");

            migrationBuilder.DropColumn(
                name: "ProductImgURL",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SellerProfiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SellerProfileId",
                table: "AspNetUsers",
                column: "SellerProfileId",
                unique: true,
                filter: "[SellerProfileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SellerProfiles_SellerProfileId",
                table: "AspNetUsers",
                column: "SellerProfileId",
                principalTable: "SellerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
