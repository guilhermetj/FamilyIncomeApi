using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyIncomeApi.Migrations
{
    public partial class addCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "tb_revenue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "tb_expenditure",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "tb_revenue");

            migrationBuilder.DropColumn(
                name: "category",
                table: "tb_expenditure");
        }
    }
}
