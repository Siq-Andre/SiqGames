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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudioName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerFriends",
                columns: table => new
                {
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFriends", x => new { x.Player1Id, x.Player2Id });
                    table.CheckConstraint("CK_Player1Id_LessThan_Player2Id", "[Player1Id] < [Player2Id]");
                    table.ForeignKey(
                        name: "FK_PlayerFriends_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerFriends_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Studios_Id",
                        column: x => x.Id,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStudios",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    StudioId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStudios", x => new { x.PlayerId, x.StudioId });
                    table.ForeignKey(
                        name: "FK_PlayerStudios_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStudios_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
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
                        name: "FK_GameGenres_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePrices_Games_Id",
                        column: x => x.Id,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TimePlayed = table.Column<TimeOnly>(type: "time", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GamePriceId = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "money", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserModified = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "admin"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_GamePrices_GamePriceId",
                        column: x => x.GamePriceId,
                        principalTable: "GamePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Players_Id",
                        column: x => x.Id,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenresId",
                table: "GameGenres",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFriends_Player2Id",
                table: "PlayerFriends",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStudios_StudioId",
                table: "PlayerStudios",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_GamePriceId",
                table: "Sales",
                column: "GamePriceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "PlayerFriends");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "PlayerStudios");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "GamePrices");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
