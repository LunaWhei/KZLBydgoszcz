using Microsoft.EntityFrameworkCore.Migrations;

namespace KZLBydgoszcz.Migrations
{
    public partial class Lesson_fix_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class_identificator",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class_identificator",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Lessons");
        }
    }
}
