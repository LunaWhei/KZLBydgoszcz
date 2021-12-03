using Microsoft.EntityFrameworkCore.Migrations;

namespace KZLBydgoszcz.Migrations
{
    public partial class Lesson_fix_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class_NameLessons");

            migrationBuilder.DropTable(
                name: "LessonsTeacher");

            migrationBuilder.AddColumn<int>(
                name: "TeachersId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "class_NamesStudent_classID",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_class_NamesStudent_classID",
                table: "Lessons",
                column: "class_NamesStudent_classID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeachersId",
                table: "Lessons",
                column: "TeachersId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeachersId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TeachersId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "class_NamesStudent_classID",
                table: "Lessons");

            migrationBuilder.CreateTable(
                name: "Class_NameLessons",
                columns: table => new
                {
                    LessonsLessonID = table.Column<int>(type: "int", nullable: false),
                    class_NamesStudent_classID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_NameLessons", x => new { x.LessonsLessonID, x.class_NamesStudent_classID });
                    table.ForeignKey(
                        name: "FK_Class_NameLessons_class_Names_class_NamesStudent_classID",
                        column: x => x.class_NamesStudent_classID,
                        principalTable: "class_Names",
                        principalColumn: "Student_classID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_NameLessons_Lessons_LessonsLessonID",
                        column: x => x.LessonsLessonID,
                        principalTable: "Lessons",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonsTeacher",
                columns: table => new
                {
                    LessonsLessonID = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonsTeacher", x => new { x.LessonsLessonID, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_LessonsTeacher_Lessons_LessonsLessonID",
                        column: x => x.LessonsLessonID,
                        principalTable: "Lessons",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonsTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_NameLessons_class_NamesStudent_classID",
                table: "Class_NameLessons",
                column: "class_NamesStudent_classID");

            migrationBuilder.CreateIndex(
                name: "IX_LessonsTeacher_TeachersId",
                table: "LessonsTeacher",
                column: "TeachersId");
        }
    }
}
