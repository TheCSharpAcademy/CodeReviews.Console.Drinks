using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drinks.iamnikitakostin.Migrations
{
    /// <inheritdoc />
    public partial class Upd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StrInstructionsZHHANT",
                table: "FavoriteCocktails",
                newName: "StrInstructionsZhhant");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsZHHANS",
                table: "FavoriteCocktails",
                newName: "StrInstructionsZhhans");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsIT",
                table: "FavoriteCocktails",
                newName: "StrInstructionsIt");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsFR",
                table: "FavoriteCocktails",
                newName: "StrInstructionsFr");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsES",
                table: "FavoriteCocktails",
                newName: "StrInstructionsEs");

            migrationBuilder.RenameColumn(
                name: "StrIBA",
                table: "FavoriteCocktails",
                newName: "StrIba");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsDE",
                table: "FavoriteCocktails",
                newName: "StrInstructionsDf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StrInstructionsZhhant",
                table: "FavoriteCocktails",
                newName: "StrInstructionsZHHANT");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsZhhans",
                table: "FavoriteCocktails",
                newName: "StrInstructionsZHHANS");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsIt",
                table: "FavoriteCocktails",
                newName: "StrInstructionsIT");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsFr",
                table: "FavoriteCocktails",
                newName: "StrInstructionsFR");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsEs",
                table: "FavoriteCocktails",
                newName: "StrInstructionsES");

            migrationBuilder.RenameColumn(
                name: "StrIba",
                table: "FavoriteCocktails",
                newName: "StrIBA");

            migrationBuilder.RenameColumn(
                name: "StrInstructionsDf",
                table: "FavoriteCocktails",
                newName: "StrInstructionsDE");
        }
    }
}
