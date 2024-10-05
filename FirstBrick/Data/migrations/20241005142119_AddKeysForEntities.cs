using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstBrick.data.migrations
{
    /// <inheritdoc />
    public partial class AddKeysForEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Wallets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Transactions");
        }
    }
}
