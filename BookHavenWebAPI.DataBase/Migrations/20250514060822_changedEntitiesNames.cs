using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHavenWebAPI.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class changedEntitiesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Accounts_AccountId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionBook_Collection_CollectionId",
                table: "CollectionBook");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionBook_Roles_BookId",
                table: "CollectionBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Genre_GenreId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionBook",
                table: "CollectionBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collection",
                table: "Collection");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "CollectionBook",
                newName: "CollectionBooks");

            migrationBuilder.RenameTable(
                name: "Collection",
                newName: "Collections");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_GenreId",
                table: "Books",
                newName: "IX_Books_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionBook_CollectionId",
                table: "CollectionBooks",
                newName: "IX_CollectionBooks_CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionBook_BookId",
                table: "CollectionBooks",
                newName: "IX_CollectionBooks_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Collection_AccountId",
                table: "Collections",
                newName: "IX_Collections_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionBooks",
                table: "CollectionBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collections",
                table: "Collections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genre_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionBooks_Books_BookId",
                table: "CollectionBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionBooks_Collections_CollectionId",
                table: "CollectionBooks",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Accounts_AccountId",
                table: "Collections",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genre_GenreId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionBooks_Books_BookId",
                table: "CollectionBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionBooks_Collections_CollectionId",
                table: "CollectionBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Accounts_AccountId",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collections",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionBooks",
                table: "CollectionBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Collections",
                newName: "Collection");

            migrationBuilder.RenameTable(
                name: "CollectionBooks",
                newName: "CollectionBook");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_Collections_AccountId",
                table: "Collection",
                newName: "IX_Collection_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionBooks_CollectionId",
                table: "CollectionBook",
                newName: "IX_CollectionBook_CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionBooks_BookId",
                table: "CollectionBook",
                newName: "IX_CollectionBook_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenreId",
                table: "Roles",
                newName: "IX_Roles_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collection",
                table: "Collection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionBook",
                table: "CollectionBook",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Accounts_AccountId",
                table: "Collection",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionBook_Collection_CollectionId",
                table: "CollectionBook",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionBook_Roles_BookId",
                table: "CollectionBook",
                column: "BookId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Genre_GenreId",
                table: "Roles",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
