using Microsoft.EntityFrameworkCore.Migrations;

namespace collectIO.Services.Migrations
{
    public partial class add_likes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Items_LikedItemid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LikedItemid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LikedItemid",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_AppUserId",
                table: "Items",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_AppUserId",
                table: "Items",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_AppUserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_AppUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "LikedItemid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LikedItemid",
                table: "AspNetUsers",
                column: "LikedItemid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Items_LikedItemid",
                table: "AspNetUsers",
                column: "LikedItemid",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
