﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelemetryConsole;

namespace TelemetryConsole.Migrations
{
    [DbContext(typeof(TelemetryContext))]
    partial class TelemetryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TelemetryDependencies.Models.Bms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Current");

                    b.Property<long>("CycleTime");

                    b.Property<long>("FWVersion");

                    b.Property<int>("MCUTemp");

                    b.Property<int>("MaxTemp");

                    b.Property<int>("MaxTempId");

                    b.Property<long>("MaxVolt");

                    b.Property<long>("MaxVoltId");

                    b.Property<int>("MinTemp");

                    b.Property<int>("MinTempId");

                    b.Property<long>("MinVolt");

                    b.Property<long>("MinVoltId");

                    b.Property<long>("RoundtripTm");

                    b.Property<long>("Soc");

                    b.Property<long>("Status");

                    b.Property<string>("Time");

                    b.Property<long>("Volt");

                    b.HasKey("Id");

                    b.ToTable("BatteryManagementSystems");
                });

            modelBuilder.Entity("TelemetryDependencies.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExceptionSource");

                    b.Property<string>("Message");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("TelemetryDependencies.Models.Gps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ACCX");

                    b.Property<double>("ACCY");

                    b.Property<double>("ACCZ");

                    b.Property<double>("ALT");

                    b.Property<double>("DIST");

                    b.Property<int>("DeviceId");

                    b.Property<double>("GPSFIX");

                    b.Property<double>("GYRX");

                    b.Property<double>("GYRY");

                    b.Property<double>("GYRZ");

                    b.Property<double>("HEADING");

                    b.Property<double>("LAT");

                    b.Property<double>("LONG");

                    b.Property<double>("SPEED");

                    b.Property<double>("TDIST");

                    b.Property<string>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("GPSs");
                });

            modelBuilder.Entity("TelemetryDependencies.Models.MPPT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ControllerTemp");

                    b.Property<int>("DeviceId");

                    b.Property<int>("InputCurrent");

                    b.Property<int>("InputVoltage");

                    b.Property<int>("OutputVoltage");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.ToTable("MPPTs");
                });

            modelBuilder.Entity("TelemetryDependencies.Models.Motor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatteryCurrent");

                    b.Property<int>("BatteryVoltage");

                    b.Property<int>("CurrentDirection");

                    b.Property<int>("FailModeInfo");

                    b.Property<int>("FailModeInfo1");

                    b.Property<int>("FailModeInfo2");

                    b.Property<int>("MotorCurrent");

                    b.Property<int>("MotorDriveMode");

                    b.Property<int>("MotorRPM");

                    b.Property<int>("OutputDuty");

                    b.Property<int>("OutputDutyType");

                    b.Property<int>("PresentCorePos");

                    b.Property<int>("TempControl");

                    b.Property<int>("TempMotor");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.ToTable("Motors");
                });
#pragma warning restore 612, 618
        }
    }
}
