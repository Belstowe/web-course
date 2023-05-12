using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCourse.Migrations
{
    /// <inheritdoc />
    public partial class AnswersModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChoicesAnswer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Choices = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionRefID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoicesAnswer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_ChoicesAnswer_Questions_QuestionRefID",
                        column: x => x.QuestionRefID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariableAnswer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Input = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionRefID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableAnswer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_VariableAnswer_Questions_QuestionRefID",
                        column: x => x.QuestionRefID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoicesAnswer_QuestionRefID",
                table: "ChoicesAnswer",
                column: "QuestionRefID");

            migrationBuilder.CreateIndex(
                name: "IX_VariableAnswer_QuestionRefID",
                table: "VariableAnswer",
                column: "QuestionRefID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoicesAnswer");

            migrationBuilder.DropTable(
                name: "VariableAnswer");
        }
    }
}
