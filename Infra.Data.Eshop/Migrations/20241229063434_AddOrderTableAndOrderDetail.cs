using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Eshop.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTableAndOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsFinally = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdcutColorOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdcutColorOrderDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orderid = table.Column<int>(type: "int", nullable: false),
                    ProducId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ColorIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProducId",
                        column: x => x.ProducId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdcutColorOrderDetailProductColor",
                columns: table => new
                {
                    ProdcutColorOrderDetailsId = table.Column<int>(type: "int", nullable: false),
                    ProductColorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdcutColorOrderDetailProductColor", x => new { x.ProdcutColorOrderDetailsId, x.ProductColorsId });
                    table.ForeignKey(
                        name: "FK_ProdcutColorOrderDetailProductColor_ProdcutColorOrderDetail_ProdcutColorOrderDetailsId",
                        column: x => x.ProdcutColorOrderDetailsId,
                        principalTable: "ProdcutColorOrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdcutColorOrderDetailProductColor_ProductColor_ProductColorsId",
                        column: x => x.ProductColorsId,
                        principalTable: "ProductColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailProdcutColorOrderDetail",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false),
                    ProdcutColorOrderDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailProdcutColorOrderDetail", x => new { x.OrderDetailsId, x.ProdcutColorOrderDetailsId });
                    table.ForeignKey(
                        name: "FK_OrderDetailProdcutColorOrderDetail_OrderDetail_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailProdcutColorOrderDetail_ProdcutColorOrderDetail_ProdcutColorOrderDetailsId",
                        column: x => x.ProdcutColorOrderDetailsId,
                        principalTable: "ProdcutColorOrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_Orderid",
                table: "OrderDetail",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProducId",
                table: "OrderDetail",
                column: "ProducId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailProdcutColorOrderDetail_ProdcutColorOrderDetailsId",
                table: "OrderDetailProdcutColorOrderDetail",
                column: "ProdcutColorOrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdcutColorOrderDetailProductColor_ProductColorsId",
                table: "ProdcutColorOrderDetailProductColor",
                column: "ProductColorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailProdcutColorOrderDetail");

            migrationBuilder.DropTable(
                name: "ProdcutColorOrderDetailProductColor");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProdcutColorOrderDetail");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
