using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sign_Me_In.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSecurityQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityAnswers");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "SecurityQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AnswerHash",
                table: "SecurityQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_AccountID",
                table: "SecurityQuestions",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityQuestions_Accounts_AccountID",
                table: "SecurityQuestions",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityQuestions_Accounts_AccountID",
                table: "SecurityQuestions");

            migrationBuilder.DropIndex(
                name: "IX_SecurityQuestions_AccountID",
                table: "SecurityQuestions");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "SecurityQuestions");

            migrationBuilder.DropColumn(
                name: "AnswerHash",
                table: "SecurityQuestions");

            migrationBuilder.CreateTable(
                name: "SecurityAnswers",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    AnswerHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityAnswers", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_SecurityAnswers_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAnswers_AccountID",
                table: "SecurityAnswers",
                column: "AccountID");
        }
    }
}
