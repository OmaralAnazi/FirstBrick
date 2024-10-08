﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstBrick.data.migrations
{
    /// <inheritdoc />
    public partial class UpdateInvestmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Investments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Investments");
        }
    }
}
