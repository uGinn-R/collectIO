using Microsoft.EntityFrameworkCore.Migrations;

namespace collectIO.Services.Migrations
{
    public partial class add_likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikedItemid",
                table: "AspNetUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
