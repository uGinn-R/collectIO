using Microsoft.EntityFrameworkCore.Migrations;

namespace collectIO.Services.Migrations
{
    public partial class _test2_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "optionBOOLs",
                table: "Collections");

            migrationBuilder.AddColumn<string>(
                name: "optionBool1",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionBool2",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionBool3",
                table: "Collections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "optionBool1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionBool2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionBool3",
                table: "Collections");

            migrationBuilder.AddColumn<string>(
                name: "optionBOOLs",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
