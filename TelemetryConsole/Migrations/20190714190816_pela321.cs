using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetryConsole.Migrations
{
    public partial class pela321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryManagementSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MinVolt = table.Column<long>(nullable: false),
                    MinVoltId = table.Column<long>(nullable: false),
                    MaxVolt = table.Column<long>(nullable: false),
                    MaxVoltId = table.Column<long>(nullable: false),
                    Volt = table.Column<long>(nullable: false),
                    Current = table.Column<int>(nullable: false),
                    Status = table.Column<long>(nullable: false),
                    Soc = table.Column<long>(nullable: false),
                    MinTemp = table.Column<int>(nullable: false),
                    MinTempId = table.Column<int>(nullable: false),
                    MaxTemp = table.Column<int>(nullable: false),
                    MaxTempId = table.Column<int>(nullable: false),
                    FWVersion = table.Column<long>(nullable: false),
                    CycleTime = table.Column<long>(nullable: false),
                    MCUTemp = table.Column<int>(nullable: false),
                    RoundtripTm = table.Column<long>(nullable: false),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryManagementSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Errors",
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
                    table.PrimaryKey("PK_Errors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    LAT = table.Column<double>(nullable: false),
                    LONG = table.Column<double>(nullable: false),
                    ALT = table.Column<double>(nullable: false),
                    SPEED = table.Column<double>(nullable: false),
                    HEADING = table.Column<double>(nullable: false),
                    GPSFIX = table.Column<double>(nullable: false),
                    DIST = table.Column<double>(nullable: false),
                    TDIST = table.Column<double>(nullable: false),
                    ACCX = table.Column<double>(nullable: false),
                    ACCY = table.Column<double>(nullable: false),
                    ACCZ = table.Column<double>(nullable: false),
                    GYRX = table.Column<double>(nullable: false),
                    GYRY = table.Column<double>(nullable: false),
                    GYRZ = table.Column<double>(nullable: false),
                    TimeStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatteryVoltage = table.Column<int>(nullable: false),
                    BatteryCurrent = table.Column<int>(nullable: false),
                    CurrentDirection = table.Column<int>(nullable: false),
                    MotorCurrent = table.Column<int>(nullable: false),
                    TempControl = table.Column<int>(nullable: false),
                    TempMotor = table.Column<int>(nullable: false),
                    MotorRPM = table.Column<int>(nullable: false),
                    OutputDuty = table.Column<int>(nullable: false),
                    OutputDutyType = table.Column<int>(nullable: false),
                    MotorDriveMode = table.Column<int>(nullable: false),
                    FailModeInfo1 = table.Column<int>(nullable: false),
                    FailModeInfo2 = table.Column<int>(nullable: false),
                    PresentCorePos = table.Column<int>(nullable: false),
                    FailModeInfo = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MPPTs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    InputCurrent = table.Column<int>(nullable: false),
                    InputVoltage = table.Column<int>(nullable: false),
                    OutputVoltage = table.Column<int>(nullable: false),
                    ControllerTemp = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPPTs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryManagementSystems");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "GPSs");

            migrationBuilder.DropTable(
                name: "Motors");

            migrationBuilder.DropTable(
                name: "MPPTs");
        }
    }
}
