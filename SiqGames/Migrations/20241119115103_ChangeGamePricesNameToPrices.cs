using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiqGames.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGamePricesNameToPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "GamePrices",
                newName: "Prices");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Prices",
                newName: "Cost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Prices",
                newName: "Price");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "GamePrices");
        }
    }
}
