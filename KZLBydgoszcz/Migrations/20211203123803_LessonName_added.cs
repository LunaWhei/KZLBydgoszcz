using Microsoft.EntityFrameworkCore.Migrations;

namespace KZLBydgoszcz.Migrations
{
    public partial class LessonName_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonsLessonID",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonsLessonID",
                table: "class_Names",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_classID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_LessonsLessonID",
                table: "Teachers",
                column: "LessonsLessonID");

            migrationBuilder.CreateIndex(
                name: "IX_class_Names_LessonsLessonID",
                table: "class_Names",
                column: "LessonsLessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_class_Names_Lessons_LessonsLessonID",
                table: "class_Names",
                column: "LessonsLessonID",
                principalTable: "Lessons",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Lessons_LessonsLessonID",
                table: "Teachers",
                column: "LessonsLessonID",
                principalTable: "Lessons",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_Names_Lessons_LessonsLessonID",
                table: "class_Names");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Lessons_LessonsLessonID",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_LessonsLessonID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_class_Names_LessonsLessonID",
                table: "class_Names");

            migrationBuilder.DropColumn(
                name: "LessonsLessonID",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LessonsLessonID",
                table: "class_Names");
        }
    }
}
