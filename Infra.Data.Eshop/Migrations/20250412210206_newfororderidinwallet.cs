using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Eshop.Migrations
{
    /// <inheritdoc />
    public partial class newfororderidinwallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Wallet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_OrderId",
                table: "Wallet",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Order_OrderId",
                table: "Wallet",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Order_OrderId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_OrderId",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Wallet");
        }
    }
}
