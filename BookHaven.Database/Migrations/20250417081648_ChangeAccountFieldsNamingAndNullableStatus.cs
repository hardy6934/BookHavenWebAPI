using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHaven.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAccountFieldsNamingAndNullableStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Accounts",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Accounts",
                newName: "Login");
        }
    }
}
