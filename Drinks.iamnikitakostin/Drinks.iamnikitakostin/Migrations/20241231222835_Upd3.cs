using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drinks.iamnikitakostin.Migrations
{
    /// <inheritdoc />
    public partial class Upd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StrInstructionsDf",
                table: "FavoriteCocktails",
                newName: "StrInstructionsDe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StrInstructionsDe",
                table: "FavoriteCocktails",
                newName: "StrInstructionsDf");
        }
    }
}
