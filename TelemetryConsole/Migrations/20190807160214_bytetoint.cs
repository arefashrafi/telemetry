using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetryConsole.Migrations
{
    public partial class bytetoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                "MessageId",
                "Messages",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                "Length",
                "Messages",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                "MessageId",
                "Messages",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                "Length",
                "Messages",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}