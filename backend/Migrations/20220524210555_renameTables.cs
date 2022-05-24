using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyIncomeApi.Migrations
{
    public partial class renameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_familyIcome",
                table: "tb_familyIcome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_revenues",
                table: "revenues");

            migrationBuilder.RenameTable(
                name: "tb_familyIcome",
                newName: "tb_expenditure");

            migrationBuilder.RenameTable(
                name: "revenues",
                newName: "tb_revenue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_expenditure",
                table: "tb_expenditure",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_revenue",
                table: "tb_revenue",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_revenue",
                table: "tb_revenue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_expenditure",
                table: "tb_expenditure");

            migrationBuilder.RenameTable(
                name: "tb_revenue",
                newName: "revenues");

            migrationBuilder.RenameTable(
                name: "tb_expenditure",
                newName: "tb_familyIcome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_revenues",
                table: "revenues",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_familyIcome",
                table: "tb_familyIcome",
                column: "id");
        }
    }
}
