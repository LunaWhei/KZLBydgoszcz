using Microsoft.EntityFrameworkCore.Migrations;

namespace KZLBydgoszcz.Migrations
{
    public partial class Lesson_fix_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_class_Names_class_NamesStudent_classID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeachersId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_class_NamesStudent_classID",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Class_identificator",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "class_NamesStudent_classID",
                table: "Lessons");

            migrationBuilder.AlterColumn<int>(
                name: "TeachersId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Student_classID",
                table: "Lessons",
                column: "Student_classID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_class_Names_Student_classID",
                table: "Lessons",
                column: "Student_classID",
                principalTable: "class_Names",
                principalColumn: "Student_classID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeachersId",
                table: "Lessons",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_class_Names_Student_classID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeachersId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_Student_classID",
                table: "Lessons");

            migrationBuilder.AlterColumn<int>(
                name: "TeachersId",
                table: "Lessons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Class_identificator",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "class_NamesStudent_classID",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_class_NamesStudent_classID",
                table: "Lessons",
                column: "class_NamesStudent_classID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_class_Names_class_NamesStudent_classID",
                table: "Lessons",
                column: "class_NamesStudent_classID",
                principalTable: "class_Names",
                principalColumn: "Student_classID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeachersId",
                table: "Lessons",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
