using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyIncomeApi.Migrations
{
    public partial class updateFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_expenditure_tb_categories_category_id",
                table: "tb_expenditure");

            migrationBuilder.DropIndex(
                name: "IX_tb_expenditure_category_id",
                table: "tb_expenditure");

            migrationBuilder.CreateIndex(
                name: "IX_tb_expenditure_category_id",
                table: "tb_expenditure",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_expenditure_tb_categories_category_id",
                table: "tb_expenditure",
                column: "category_id",
                principalTable: "tb_categories",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_expenditure_tb_categories_category_id",
                table: "tb_expenditure");

            migrationBuilder.DropIndex(
                name: "IX_tb_expenditure_category_id",
                table: "tb_expenditure");

            migrationBuilder.CreateIndex(
                name: "IX_tb_expenditure_category_id",
                table: "tb_expenditure",
                column: "category_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_expenditure_tb_categories_category_id",
                table: "tb_expenditure",
                column: "category_id",
                principalTable: "tb_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
