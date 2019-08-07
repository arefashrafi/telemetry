﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telemetry.App;

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

                    b.Property<int>("CycleTime");

                    b.Property<int>("FWVersion");

                    b.Property<int>("MCUTemp");

                    b.Property<int>("MaxTemp");

                    b.Property<int>("MaxTempId");

                    b.Property<int>("MaxVolt");

                    b.Property<int>("MaxVoltId");

                    b.Property<int>("MinTemp");

                    b.Property<int>("MinTempId");

                    b.Property<int>("MinVolt");

                    b.Property<int>("MinVoltId");

                    b.Property<int>("RoundtripTm");

                    b.Property<int>("Soc");

                    b.Property<int>("Status");

                    b.Property<string>("Time");

                    b.Property<int>("Volt");

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

            modelBuilder.Entity("TelemetryDependencies.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("Length");

                    b.Property<int>("MessageId");

                    b.Property<string>("Prefix");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TelemetryDependencies.Models.Motor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatteryCurrent");

                    b.Property<int>("BatteryCurrentDir");

                    b.Property<int>("BatteryVoltage");

                    b.Property<int>("FailModeInfo");

                    b.Property<int>("FailModeInfo2");

                    b.Property<int>("Gear");

                    b.Property<int>("MotorCurrent");

                    b.Property<int>("MotorCurrentDir");

                    b.Property<int>("MotorDriveMode");

                    b.Property<int>("MotorRpm");

                    b.Property<int>("OutputDuty");

                    b.Property<int>("OutputDutyType");

                    b.Property<int>("PresentCorePos");

                    b.Property<int>("TempControl");

                    b.Property<int>("TempErrLevel");

                    b.Property<int>("TempMotor");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.ToTable("Motors");
                });

            modelBuilder.Entity("TelemetryDependencies.Models.Routenote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ALT");

                    b.Property<decimal>("DIST");

                    b.Property<decimal>("LAT");

                    b.Property<decimal>("LONG");

                    b.Property<string>("TIME");

                    b.Property<int>("UNIX_TIME");

                    b.HasKey("ID");

                    b.ToTable("Routenotes");
                });
#pragma warning restore 612, 618
        }
    }
}
