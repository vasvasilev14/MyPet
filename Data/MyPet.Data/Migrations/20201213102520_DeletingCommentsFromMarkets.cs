using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPet.Data.Migrations
{
    public partial class DeletingCommentsFromMarkets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_LoveMarkets_LoveMarketId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SellMarkets_SellMarketId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_LoveMarketId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SellMarketId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LoveMarketId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SellMarketId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoveMarketId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellMarketId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LoveMarketId",
                table: "Comments",
                column: "LoveMarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SellMarketId",
                table: "Comments",
                column: "SellMarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_LoveMarkets_LoveMarketId",
                table: "Comments",
                column: "LoveMarketId",
                principalTable: "LoveMarkets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SellMarkets_SellMarketId",
                table: "Comments",
                column: "SellMarketId",
                principalTable: "SellMarkets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
