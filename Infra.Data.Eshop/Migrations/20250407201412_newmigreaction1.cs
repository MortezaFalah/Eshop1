using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Eshop.Migrations
{
    /// <inheritdoc />
    public partial class newmigreaction1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislike",
                table: "ProductComment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "ProductComment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommentReaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProductCommentId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReaction_ProductComment_ProductCommentId",
                        column: x => x.ProductCommentId,
                        principalTable: "ProductComment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentReaction_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentReaction_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_ProductCommentId",
                table: "CommentReaction",
                column: "ProductCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_ProductId",
                table: "CommentReaction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_UserId",
                table: "CommentReaction",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentReaction");

            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "ProductComment");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "ProductComment");
        }
    }
}
