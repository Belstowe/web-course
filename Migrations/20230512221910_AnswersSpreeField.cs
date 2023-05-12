using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCourse.Migrations
{
    /// <inheritdoc />
    public partial class AnswersSpreeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AnswerSpree",
                table: "Answers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerSpree",
                table: "Answers",
                column: "AnswerSpree");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Answers_AnswerSpree",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "AnswerSpree",
                table: "Answers");
        }
    }
}
