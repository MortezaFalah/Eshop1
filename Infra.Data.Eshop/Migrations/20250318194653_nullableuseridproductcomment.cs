﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Eshop.Migrations
{
    /// <inheritdoc />
    public partial class nullableuseridproductcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComment_Users_UserId",
                table: "ProductComment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProductComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComment_Users_UserId",
                table: "ProductComment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComment_Users_UserId",
                table: "ProductComment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProductComment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComment_Users_UserId",
                table: "ProductComment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
