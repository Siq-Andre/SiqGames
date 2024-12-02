using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiqGames.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoInPlayerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Players",
                newName: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Players",
                newName: "GameId");
        }
    }
}
