using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiqGames.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudioName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPlayers_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerPlayers_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    StudioId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStudios",
                columns: table => new
                {
                    PlayersId = table.Column<int>(type: "int", nullable: false),
                    StudiosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStudios", x => new { x.PlayersId, x.StudiosId });
                    table.ForeignKey(
                        name: "FK_PlayerStudios_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStudios_Studios_StudiosId",
                        column: x => x.StudiosId,
                        principalTable: "Studios",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dlc",
                columns: table => new
                {
                    DlcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlc", x => x.DlcId);
                    table.ForeignKey(
                        name: "FK_Dlc_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GameGenres_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.GamesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    DlcId = table.Column<int>(type: "int", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "money", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Dlc_DlcId",
                        column: x => x.DlcId,
                        principalTable: "Dlc",
                        principalColumn: "DlcId");
                    table.ForeignKey(
                        name: "FK_Sales_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_Sales_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dlc_GameId",
                table: "Dlc",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_StudioId",
                table: "Game",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenresId",
                table: "GameGenres",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreName",
                table: "Genres",
                column: "GenreName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayersId",
                table: "PlayerGames",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPlayers_Player1Id",
                table: "PlayerPlayers",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPlayers_Player2Id",
                table: "PlayerPlayers",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Email",
                table: "Players",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Nickname",
                table: "Players",
                column: "Nickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStudios_StudiosId",
                table: "PlayerStudios",
                column: "StudiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DlcId",
                table: "Sales",
                column: "DlcId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_GameId",
                table: "Sales",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PlayerId",
                table: "Sales",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Studios_StudioName",
                table: "Studios",
                column: "StudioName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "PlayerPlayers");

            migrationBuilder.DropTable(
                name: "PlayerStudios");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Dlc");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
