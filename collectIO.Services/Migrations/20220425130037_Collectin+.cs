using Microsoft.EntityFrameworkCore.Migrations;

namespace collectIO.Services.Migrations
{
    public partial class Collectin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_AppUserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_AppUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Collections");

            migrationBuilder.AddColumn<string>(
                name: "CollectionAuthorId",
                table: "Collections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CollectionAuthorId",
                table: "Collections",
                column: "CollectionAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_CollectionAuthorId",
                table: "Collections",
                column: "CollectionAuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_CollectionAuthorId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CollectionAuthorId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CollectionAuthorId",
                table: "Collections");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_AppUserId",
                table: "Collections",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_AppUserId",
                table: "Collections",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
