using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHavenWebAPI.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class IsFavoriteAndCustomDescriptionFieldsAddedToCollectionBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomDescription",
                table: "CollectionBooks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "CollectionBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomDescription",
                table: "CollectionBooks");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "CollectionBooks");
        }
    }
}
