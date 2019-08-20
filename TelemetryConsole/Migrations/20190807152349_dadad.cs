using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetryConsole.Migrations
{
    public partial class dadad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "MotorRPM",
                "Motors",
                "MotorRpm");

            migrationBuilder.RenameColumn(
                "FailModeInfo1",
                "Motors",
                "TempErrLevel");

            migrationBuilder.RenameColumn(
                "CurrentDirection",
                "Motors",
                "MotorCurrentDir");

            migrationBuilder.AddColumn<int>(
                "BatteryCurrentDir",
                "Motors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "BatteryCurrentDir",
                "Motors");

            migrationBuilder.RenameColumn(
                "MotorRpm",
                "Motors",
                "MotorRPM");

            migrationBuilder.RenameColumn(
                "TempErrLevel",
                "Motors",
                "FailModeInfo1");

            migrationBuilder.RenameColumn(
                "MotorCurrentDir",
                "Motors",
                "CurrentDirection");
        }
    }
}