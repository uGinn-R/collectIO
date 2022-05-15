using Microsoft.EntityFrameworkCore.Migrations;

namespace collectIO.Services.Migrations
{
    public partial class likes_counter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tags_Tagid",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Items_Tagid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Tagid",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "Tagid",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Tagid",
                table: "Items",
                column: "Tagid");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tags_Tagid",
                table: "Items",
                column: "Tagid",
                principalTable: "Tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
