using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiqGames.Migrations
{
    /// <inheritdoc />
    public partial class fixDlcContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dlc_Game_GameId",
                table: "Dlc");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Studios_StudioId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Game_GamesId",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGames_Game_GamesId",
                table: "PlayerGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Dlc_DlcId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Game_GameId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dlc",
                table: "Dlc");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "Dlc",
                newName: "Dlcs");

            migrationBuilder.RenameIndex(
                name: "IX_Game_StudioId",
                table: "Games",
                newName: "IX_Games_StudioId");

            migrationBuilder.RenameIndex(
                name: "IX_Dlc_GameId",
                table: "Dlcs",
                newName: "IX_Dlcs_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dlcs",
                table: "Dlcs",
                column: "DlcId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dlcs_Games_GameId",
                table: "Dlcs",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Games_GamesId",
                table: "GameGenres",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Studios_StudioId",
                table: "Games",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGames_Games_GamesId",
                table: "PlayerGames",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Dlcs_DlcId",
                table: "Sales",
                column: "DlcId",
                principalTable: "Dlcs",
                principalColumn: "DlcId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Games_GameId",
                table: "Sales",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dlcs_Games_GameId",
                table: "Dlcs");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Games_GamesId",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Studios_StudioId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGames_Games_GamesId",
                table: "PlayerGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Dlcs_DlcId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Games_GameId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dlcs",
                table: "Dlcs");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "Dlcs",
                newName: "Dlc");

            migrationBuilder.RenameIndex(
                name: "IX_Games_StudioId",
                table: "Game",
                newName: "IX_Game_StudioId");

            migrationBuilder.RenameIndex(
                name: "IX_Dlcs_GameId",
                table: "Dlc",
                newName: "IX_Dlc_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dlc",
                table: "Dlc",
                column: "DlcId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dlc_Game_GameId",
                table: "Dlc",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Studios_StudioId",
                table: "Game",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Game_GamesId",
                table: "GameGenres",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGames_Game_GamesId",
                table: "PlayerGames",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Dlc_DlcId",
                table: "Sales",
                column: "DlcId",
                principalTable: "Dlc",
                principalColumn: "DlcId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Game_GameId",
                table: "Sales",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId");
        }
    }
}
