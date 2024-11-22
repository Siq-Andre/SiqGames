using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiqGames.Migrations
{
    /// <inheritdoc />
    public partial class SalesRequirePlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Players_PlayerId",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Players_PlayerId",
                table: "Sales",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Players_PlayerId",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Players_PlayerId",
                table: "Sales",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "GameId");
        }
    }
}
