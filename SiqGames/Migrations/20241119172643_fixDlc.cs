using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiqGames.Migrations
{
    /// <inheritdoc />
    public partial class fixDlc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dlc_Games_Id",
                table: "Dlc");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Games_GamesId",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Studios_Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGames_Games_GamesId",
                table: "PlayerGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Games_Id",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                table: "Dlc",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                table: "Dlc",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Dlc",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dlc",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Dlc",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeModified",
                table: "Dlc",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Dlc",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dlc_Game_Id",
                table: "Dlc",
                column: "Id",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Studios_Id",
                table: "Game",
                column: "Id",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Game_GamesId",
                table: "GameGenres",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGames_Game_GamesId",
                table: "PlayerGames",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Game_Id",
                table: "Sales",
                column: "Id",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dlc_Game_Id",
                table: "Dlc");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Studios_Id",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Game_GamesId",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGames_Game_GamesId",
                table: "PlayerGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Game_Id",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                table: "Dlc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                table: "Dlc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Dlc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dlc",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Dlc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeModified",
                table: "Dlc",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Dlc",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dlc_Games_Id",
                table: "Dlc",
                column: "Id",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Games_GamesId",
                table: "GameGenres",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Studios_Id",
                table: "Games",
                column: "Id",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGames_Games_GamesId",
                table: "PlayerGames",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Games_Id",
                table: "Sales",
                column: "Id",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
