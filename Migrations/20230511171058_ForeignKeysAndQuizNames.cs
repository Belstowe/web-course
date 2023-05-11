using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCourse.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAndQuizNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuizID",
                table: "Questions",
                newName: "QuizRefID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuizID",
                table: "Questions",
                newName: "IX_Questions_QuizRefID");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quizzes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizRefID",
                table: "Questions",
                column: "QuizRefID",
                principalTable: "Quizzes",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizRefID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "QuizRefID",
                table: "Questions",
                newName: "QuizID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuizRefID",
                table: "Questions",
                newName: "IX_Questions_QuizID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizID",
                table: "Questions",
                column: "QuizID",
                principalTable: "Quizzes",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
