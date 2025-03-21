﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Eshop.Migrations
{
    /// <inheritdoc />
    public partial class addUseravatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarName",
                table: "Users",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarName",
                table: "Users");
        }
    }
}
