using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Eshop.Migrations
{
    /// <inheritdoc />
    public partial class addorderdetailproductcolor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProdcutColorOrderDetail_ProdcutColorOrderDetail_ProdcutColorOrderDetailsId",
                table: "OrderDetailProdcutColorOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdcutColorOrderDetailProductColor_ProdcutColorOrderDetail_ProdcutColorOrderDetailsId",
                table: "ProdcutColorOrderDetailProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdcutColorOrderDetail",
                table: "ProdcutColorOrderDetail");

            migrationBuilder.RenameTable(
                name: "ProdcutColorOrderDetail",
                newName: "OrderDetailProductColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailProductColor",
                table: "OrderDetailProductColor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProdcutColorOrderDetail_OrderDetailProductColor_ProdcutColorOrderDetailsId",
                table: "OrderDetailProdcutColorOrderDetail",
                column: "ProdcutColorOrderDetailsId",
                principalTable: "OrderDetailProductColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdcutColorOrderDetailProductColor_OrderDetailProductColor_ProdcutColorOrderDetailsId",
                table: "ProdcutColorOrderDetailProductColor",
                column: "ProdcutColorOrderDetailsId",
                principalTable: "OrderDetailProductColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProdcutColorOrderDetail_OrderDetailProductColor_ProdcutColorOrderDetailsId",
                table: "OrderDetailProdcutColorOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdcutColorOrderDetailProductColor_OrderDetailProductColor_ProdcutColorOrderDetailsId",
                table: "ProdcutColorOrderDetailProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailProductColor",
                table: "OrderDetailProductColor");

            migrationBuilder.RenameTable(
                name: "OrderDetailProductColor",
                newName: "ProdcutColorOrderDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdcutColorOrderDetail",
                table: "ProdcutColorOrderDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProdcutColorOrderDetail_ProdcutColorOrderDetail_ProdcutColorOrderDetailsId",
                table: "OrderDetailProdcutColorOrderDetail",
                column: "ProdcutColorOrderDetailsId",
                principalTable: "ProdcutColorOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdcutColorOrderDetailProductColor_ProdcutColorOrderDetail_ProdcutColorOrderDetailsId",
                table: "ProdcutColorOrderDetailProductColor",
                column: "ProdcutColorOrderDetailsId",
                principalTable: "ProdcutColorOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
