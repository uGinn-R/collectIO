using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace collectIO.Services.Migrations
{
    public partial class _test_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "optionBoolValue1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionBoolValue2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionBoolValue3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionDateValue1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionDateValue2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionDateValue3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionNumberValue1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionNumberValue2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionNumberValue3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionStringValue1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionStringValue2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionStringValue3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionTextValue1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionTextValue2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionTextValue3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionBoolName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionBoolName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionBoolName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionDateName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionDateName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionDateName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionNumberName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionNumberName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionNumberName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionStringName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionStringName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionStringName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionTextName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionTextName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionTextName3",
                table: "Collections");

            migrationBuilder.AddColumn<bool>(
                name: "optionBool1",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "optionBool2",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "optionBool3",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "optionDate1",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "optionDate2",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "optionDate3",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "optionNumber1",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "optionNumber2",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "optionNumber3",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "optionString1",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionString2",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionString3",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionText1",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionText2",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionText3",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionBOOLs",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionDate1",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionDate2",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionDate3",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionNumber1",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionNumber2",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionNumber3",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionString1",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionString2",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionString3",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionText1",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionText2",
                table: "Collections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionText3",
                table: "Collections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "optionBool1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionBool2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionBool3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionDate1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionDate2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionDate3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionNumber1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionNumber2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionNumber3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionString1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionString2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionString3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionText1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionText2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionText3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "optionBOOLs",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionDate1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionDate2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionDate3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionNumber1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionNumber2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionNumber3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionString1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionString2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionString3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionText1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionText2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "optionText3",
                table: "Collections");

            migrationBuilder.AddColumn<bool>(
                name: "optionBoolValue1",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "optionBoolValue2",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "optionBoolValue3",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "optionDateValue1",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "optionDateValue2",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "optionDateValue3",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "optionNumberValue1",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "optionNumberValue2",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "optionNumberValue3",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "optionStringValue1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionStringValue2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionStringValue3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionTextValue1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionTextValue2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionTextValue3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionBoolName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionBoolName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionBoolName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionDateName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionDateName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionDateName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionNumberName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionNumberName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionNumberName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionStringName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionStringName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionStringName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionTextName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionTextName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionTextName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
