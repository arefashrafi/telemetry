using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetryConsole.Migrations
{
    public partial class SmallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TIME",
                table: "Routenotes",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "LONG",
                table: "Routenotes",
                newName: "Long");

            migrationBuilder.RenameColumn(
                name: "LAT",
                table: "Routenotes",
                newName: "Lat");

            migrationBuilder.RenameColumn(
                name: "DIST",
                table: "Routenotes",
                newName: "Dist");

            migrationBuilder.RenameColumn(
                name: "ALT",
                table: "Routenotes",
                newName: "Alt");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Routenotes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UNIX_TIME",
                table: "Routenotes",
                newName: "UnixTime");

            migrationBuilder.RenameColumn(
                name: "TDIST",
                table: "GPSs",
                newName: "Tdist");

            migrationBuilder.RenameColumn(
                name: "SPEED",
                table: "GPSs",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "LONG",
                table: "GPSs",
                newName: "Long");

            migrationBuilder.RenameColumn(
                name: "LAT",
                table: "GPSs",
                newName: "Lat");

            migrationBuilder.RenameColumn(
                name: "HEADING",
                table: "GPSs",
                newName: "Heading");

            migrationBuilder.RenameColumn(
                name: "GYRZ",
                table: "GPSs",
                newName: "Gyrz");

            migrationBuilder.RenameColumn(
                name: "GYRY",
                table: "GPSs",
                newName: "Gyry");

            migrationBuilder.RenameColumn(
                name: "GYRX",
                table: "GPSs",
                newName: "Gyrx");

            migrationBuilder.RenameColumn(
                name: "GPSFIX",
                table: "GPSs",
                newName: "Gpsfix");

            migrationBuilder.RenameColumn(
                name: "DIST",
                table: "GPSs",
                newName: "Dist");

            migrationBuilder.RenameColumn(
                name: "ALT",
                table: "GPSs",
                newName: "Alt");

            migrationBuilder.RenameColumn(
                name: "ACCZ",
                table: "GPSs",
                newName: "Accz");

            migrationBuilder.RenameColumn(
                name: "ACCY",
                table: "GPSs",
                newName: "Accy");

            migrationBuilder.RenameColumn(
                name: "ACCX",
                table: "GPSs",
                newName: "Accx");

            migrationBuilder.AddColumn<int>(
                name: "OutputCurrent",
                table: "MPPTs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Debugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExceptionSource = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debugs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debugs");

            migrationBuilder.DropColumn(
                name: "OutputCurrent",
                table: "MPPTs");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Routenotes",
                newName: "TIME");

            migrationBuilder.RenameColumn(
                name: "Long",
                table: "Routenotes",
                newName: "LONG");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "Routenotes",
                newName: "LAT");

            migrationBuilder.RenameColumn(
                name: "Dist",
                table: "Routenotes",
                newName: "DIST");

            migrationBuilder.RenameColumn(
                name: "Alt",
                table: "Routenotes",
                newName: "ALT");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Routenotes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UnixTime",
                table: "Routenotes",
                newName: "UNIX_TIME");

            migrationBuilder.RenameColumn(
                name: "Tdist",
                table: "GPSs",
                newName: "TDIST");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "GPSs",
                newName: "SPEED");

            migrationBuilder.RenameColumn(
                name: "Long",
                table: "GPSs",
                newName: "LONG");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "GPSs",
                newName: "LAT");

            migrationBuilder.RenameColumn(
                name: "Heading",
                table: "GPSs",
                newName: "HEADING");

            migrationBuilder.RenameColumn(
                name: "Gyrz",
                table: "GPSs",
                newName: "GYRZ");

            migrationBuilder.RenameColumn(
                name: "Gyry",
                table: "GPSs",
                newName: "GYRY");

            migrationBuilder.RenameColumn(
                name: "Gyrx",
                table: "GPSs",
                newName: "GYRX");

            migrationBuilder.RenameColumn(
                name: "Gpsfix",
                table: "GPSs",
                newName: "GPSFIX");

            migrationBuilder.RenameColumn(
                name: "Dist",
                table: "GPSs",
                newName: "DIST");

            migrationBuilder.RenameColumn(
                name: "Alt",
                table: "GPSs",
                newName: "ALT");

            migrationBuilder.RenameColumn(
                name: "Accz",
                table: "GPSs",
                newName: "ACCZ");

            migrationBuilder.RenameColumn(
                name: "Accy",
                table: "GPSs",
                newName: "ACCY");

            migrationBuilder.RenameColumn(
                name: "Accx",
                table: "GPSs",
                newName: "ACCX");
        }
    }
}
