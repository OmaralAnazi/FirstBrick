using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstBrick.data.migrations
{
    /// <inheritdoc />
    public partial class UpdateFloatToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Wallets",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                table: "Wallets",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
