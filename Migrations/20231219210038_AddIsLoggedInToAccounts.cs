using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sign_Me_In.Migrations
{
    /// <inheritdoc />
    public partial class AddIsLoggedInToAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Accounts");
        }
    }
}
