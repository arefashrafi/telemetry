USE [master]
GO
/****** Object:  Database [telemetry]    Script Date: 2019-07-15 14:53:23 ******/
CREATE DATABASE [telemetry]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TelemetryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TelemetryDB.mdf' , SIZE = 2236416KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TelemetryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TelemetryDB_log.ldf' , SIZE = 335872KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [telemetry] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [telemetry].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [telemetry] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [telemetry] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [telemetry] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [telemetry] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [telemetry] SET ARITHABORT OFF 
GO
ALTER DATABASE [telemetry] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [telemetry] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [telemetry] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [telemetry] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [telemetry] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [telemetry] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [telemetry] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [telemetry] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [telemetry] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [telemetry] SET  ENABLE_BROKER 
GO
ALTER DATABASE [telemetry] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [telemetry] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [telemetry] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [telemetry] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [telemetry] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [telemetry] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [telemetry] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [telemetry] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [telemetry] SET  MULTI_USER 
GO
ALTER DATABASE [telemetry] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [telemetry] SET DB_CHAINING OFF 
GO
ALTER DATABASE [telemetry] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [telemetry] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [telemetry] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [telemetry] SET QUERY_STORE = OFF
GO
USE [telemetry]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BatteryManagementSystems]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatteryManagementSystems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinVolt] [bigint] NOT NULL,
	[MinVoltId] [bigint] NOT NULL,
	[MaxVolt] [bigint] NOT NULL,
	[MaxVoltId] [bigint] NOT NULL,
	[Volt] [bigint] NOT NULL,
	[Current] [int] NOT NULL,
	[Status] [bigint] NOT NULL,
	[Soc] [bigint] NOT NULL,
	[MinTemp] [int] NOT NULL,
	[MinTempId] [int] NOT NULL,
	[MaxTemp] [int] NOT NULL,
	[MaxTempId] [int] NOT NULL,
	[FWVersion] [bigint] NOT NULL,
	[CycleTime] [bigint] NOT NULL,
	[MCUTemp] [int] NOT NULL,
	[RoundtripTm] [bigint] NOT NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_BatteryManagementSystems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Errors]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Errors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExceptionSource] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GPSs]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPSs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[LAT] [float] NOT NULL,
	[LONG] [float] NOT NULL,
	[ALT] [float] NOT NULL,
	[SPEED] [float] NOT NULL,
	[HEADING] [float] NOT NULL,
	[GPSFIX] [float] NOT NULL,
	[DIST] [float] NOT NULL,
	[TDIST] [float] NOT NULL,
	[ACCX] [float] NOT NULL,
	[ACCY] [float] NOT NULL,
	[ACCZ] [float] NOT NULL,
	[GYRX] [float] NOT NULL,
	[GYRY] [float] NOT NULL,
	[GYRZ] [float] NOT NULL,
	[TimeStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_GPSs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motors]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BatteryVoltage] [int] NOT NULL,
	[BatteryCurrent] [int] NOT NULL,
	[CurrentDirection] [int] NOT NULL,
	[MotorCurrent] [int] NOT NULL,
	[TempControl] [int] NOT NULL,
	[TempMotor] [int] NOT NULL,
	[MotorRPM] [int] NOT NULL,
	[OutputDuty] [int] NOT NULL,
	[OutputDutyType] [int] NOT NULL,
	[MotorDriveMode] [int] NOT NULL,
	[FailModeInfo1] [int] NOT NULL,
	[FailModeInfo2] [int] NOT NULL,
	[PresentCorePos] [int] NOT NULL,
	[FailModeInfo] [int] NOT NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_Motors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MPPTs]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MPPTs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[InputCurrent] [int] NOT NULL,
	[InputVoltage] [int] NOT NULL,
	[OutputVoltage] [int] NOT NULL,
	[ControllerTemp] [int] NOT NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_MPPTs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routenotes]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routenotes](
	[ID] [int] NOT NULL,
	[UNIX_TIME] [int] NOT NULL,
	[TIME] [varchar](24) NOT NULL,
	[LAT] [numeric](10, 6) NOT NULL,
	[LONG] [numeric](10, 6) NOT NULL,
	[ALT] [numeric](7, 3) NOT NULL,
	[DIST] [numeric](11, 7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_QueueActivationSender]    Script Date: 2019-07-15 14:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_QueueActivationSender] AS 
BEGIN 
    SET NOCOUNT ON;
    DECLARE @h AS UNIQUEIDENTIFIER;
    DECLARE @mt NVARCHAR(200);

    RECEIVE TOP(1) @h = conversation_handle, @mt = message_type_name FROM [dbo].[dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender];

    IF @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog'
    BEGIN
        END CONVERSATION @h;
    END

    IF @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer' OR @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/Error'
    BEGIN 
        

        END CONVERSATION @h;

        DECLARE @conversation_handle UNIQUEIDENTIFIER;
        DECLARE @schema_id INT;
        SELECT @schema_id = schema_id FROM sys.schemas WITH (NOLOCK) WHERE name = N'dbo';

        
        IF EXISTS (SELECT * FROM sys.triggers WITH (NOLOCK) WHERE object_id = OBJECT_ID(N'[dbo].[tr_dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender]')) DROP TRIGGER [dbo].[tr_dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender') EXEC (N'ALTER QUEUE [dbo].[dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender] WITH ACTIVATION (STATUS = OFF)');

        
        SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoints WITH (NOLOCK) WHERE far_service LIKE N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_%' ORDER BY is_initiator ASC;
        DECLARE conversation_cursor CURSOR FAST_FORWARD FOR SELECT conversation_handle FROM #Conversations;
        OPEN conversation_cursor;
        FETCH NEXT FROM conversation_cursor INTO @conversation_handle;
        WHILE @@FETCH_STATUS = 0 
        BEGIN
            END CONVERSATION @conversation_handle WITH CLEANUP;
            FETCH NEXT FROM conversation_cursor INTO @conversation_handle;
        END
        CLOSE conversation_cursor;
        DEALLOCATE conversation_cursor;
        DROP TABLE #Conversations;

        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Receiver') DROP SERVICE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Receiver];
        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender') DROP SERVICE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Receiver') DROP QUEUE [dbo].[dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Receiver];
        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender') DROP QUEUE [dbo].[dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_contracts WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a') DROP CONTRACT [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a];
        
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/StartMessage/Insert') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/StartMessage/Insert];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/StartMessage/Update') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/StartMessage/Update];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/StartMessage/Delete') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/StartMessage/Delete];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/Id') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/Id];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/BatteryVoltage') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/BatteryVoltage];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/BatteryCurrent') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/BatteryCurrent];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/CurrentDirection') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/CurrentDirection];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/MotorCurrent') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/MotorCurrent];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/TempControl') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/TempControl];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/TempMotor') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/TempMotor];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/MotorRPM') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/MotorRPM];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/OutputDuty') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/OutputDuty];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/OutputDutyType') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/OutputDutyType];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/MotorDriveMode') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/MotorDriveMode];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/FailModeInfo1') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/FailModeInfo1];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/FailModeInfo2') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/FailModeInfo2];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/PresentCorePos') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/PresentCorePos];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/FailModeInfo') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/FailModeInfo];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/Time') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/Time];
IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/EndMessage') DROP MESSAGE TYPE [dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a/EndMessage];

        
        IF EXISTS (SELECT * FROM sys.objects WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_QueueActivationSender') DROP PROCEDURE [dbo].[dbo_Motors_0d13cd9d-fb53-422e-8952-a82b717c4b0a_QueueActivationSender];

        
    END
END
GO
USE [master]
GO
ALTER DATABASE [telemetry] SET  READ_WRITE 
GO
