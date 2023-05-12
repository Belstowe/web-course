using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCourse.Migrations
{
    /// <inheritdoc />
    public partial class AnswersDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariableAnswer_Questions_QuestionRefID",
                table: "VariableAnswer");

            migrationBuilder.DropTable(
                name: "ChoicesAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariableAnswer",
                table: "VariableAnswer");

            migrationBuilder.RenameTable(
                name: "VariableAnswer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_VariableAnswer_QuestionRefID",
                table: "Answers",
                newName: "IX_Answers_QuestionRefID");

            migrationBuilder.AlterColumn<string>(
                name: "Input",
                table: "Answers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Choices",
                table: "Answers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Answers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "AnswerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionRefID",
                table: "Answers",
                column: "QuestionRefID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionRefID",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Choices",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "VariableAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionRefID",
                table: "VariableAnswer",
                newName: "IX_VariableAnswer_QuestionRefID");

            migrationBuilder.AlterColumn<string>(
                name: "Input",
                table: "VariableAnswer",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariableAnswer",
                table: "VariableAnswer",
                column: "AnswerID");

            migrationBuilder.CreateTable(
                name: "ChoicesAnswer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionRefID = table.Column<int>(type: "INTEGER", nullable: false),
                    Choices = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ChoicesAnswer_QuestionRefID",
                table: "ChoicesAnswer",
                column: "QuestionRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_VariableAnswer_Questions_QuestionRefID",
                table: "VariableAnswer",
                column: "QuestionRefID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
