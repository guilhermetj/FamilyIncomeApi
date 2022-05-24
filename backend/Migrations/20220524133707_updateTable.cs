using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyIncomeApi.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_expenditures",
                table: "expenditures");

            migrationBuilder.RenameTable(
                name: "expenditures",
                newName: "tb_familyIcome");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "tb_familyIcome",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tb_familyIcome",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "tb_familyIcome",
                newName: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_familyIcome",
                table: "tb_familyIcome",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_familyIcome",
                table: "tb_familyIcome");

            migrationBuilder.RenameTable(
                name: "tb_familyIcome",
                newName: "expenditures");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "expenditures",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "expenditures",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "expenditures",
                newName: "Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenditures",
                table: "expenditures",
                column: "id");
        }
    }
}
