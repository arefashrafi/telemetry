using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetryConsole.Migrations
{
    public partial class dadad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotorRPM",
                table: "Motors",
                newName: "MotorRpm");

            migrationBuilder.RenameColumn(
                name: "FailModeInfo1",
                table: "Motors",
                newName: "TempErrLevel");

            migrationBuilder.RenameColumn(
                name: "CurrentDirection",
                table: "Motors",
                newName: "MotorCurrentDir");

            migrationBuilder.AddColumn<int>(
                name: "BatteryCurrentDir",
                table: "Motors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryCurrentDir",
                table: "Motors");

            migrationBuilder.RenameColumn(
                name: "MotorRpm",
                table: "Motors",
                newName: "MotorRPM");

            migrationBuilder.RenameColumn(
                name: "TempErrLevel",
                table: "Motors",
                newName: "FailModeInfo1");

            migrationBuilder.RenameColumn(
                name: "MotorCurrentDir",
                table: "Motors",
                newName: "CurrentDirection");
        }
    }
}
