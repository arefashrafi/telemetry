using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetryConsole.Migrations
{
    public partial class bytetoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "MessageId",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "Length",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
