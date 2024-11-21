using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiqGames.Migrations
{
    /// <inheritdoc />
    public partial class AddDlcSaleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Dlc_Id",
                table: "Sales",
                column: "Id",
                principalTable: "Dlc",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Dlc_Id",
                table: "Sales");
        }
    }
}
