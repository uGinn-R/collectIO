using Microsoft.EntityFrameworkCore.Migrations;

namespace collectIO.Services.Migrations
{
    public partial class _comment_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommentAuthorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentAuthorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentAuthorId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "CommentAuthor",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentAuthor",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "CommentAuthorId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentAuthorId",
                table: "Comments",
                column: "CommentAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommentAuthorId",
                table: "Comments",
                column: "CommentAuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
