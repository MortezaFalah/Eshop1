using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Eshop.Migrations
{
    /// <inheritdoc />
    public partial class addcontactustable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_ProductComment_ProductCommentId",
                table: "CommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_Product_ProductId",
                table: "CommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_Users_UserId",
                table: "CommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Users_Userid",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_CommentReaction_ProductCommentId",
                table: "CommentReaction");

            migrationBuilder.DropColumn(
                name: "ProductCommentId",
                table: "CommentReaction");

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AnswerUserId = table.Column<int>(type: "int", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_Users_AnswerUserId",
                        column: x => x.AnswerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_CommentId",
                table: "CommentReaction",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_AnswerUserId",
                table: "ContactUs",
                column: "AnswerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_ProductComment_CommentId",
                table: "CommentReaction",
                column: "CommentId",
                principalTable: "ProductComment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_Product_ProductId",
                table: "CommentReaction",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_Users_UserId",
                table: "CommentReaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Users_Userid",
                table: "Wallet",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_ProductComment_CommentId",
                table: "CommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_Product_ProductId",
                table: "CommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_Users_UserId",
                table: "CommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Users_Userid",
                table: "Wallet");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropIndex(
                name: "IX_CommentReaction_CommentId",
                table: "CommentReaction");

            migrationBuilder.AddColumn<int>(
                name: "ProductCommentId",
                table: "CommentReaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_ProductCommentId",
                table: "CommentReaction",
                column: "ProductCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_ProductComment_ProductCommentId",
                table: "CommentReaction",
                column: "ProductCommentId",
                principalTable: "ProductComment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_Product_ProductId",
                table: "CommentReaction",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_Users_UserId",
                table: "CommentReaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Users_Userid",
                table: "Wallet",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
