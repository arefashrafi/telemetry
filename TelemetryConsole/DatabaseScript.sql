USE [master]
GO
/****** Object:  Database [telemetry]    Script Date: 8/18/2019 3:56:07 PM ******/
CREATE DATABASE [telemetry]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'telemetry', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\telemetry.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'telemetry_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\telemetry_log.ldf' , SIZE = 401408KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [telemetry] SET COMPATIBILITY_LEVEL = 140
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
ALTER DATABASE [telemetry] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [telemetry] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [telemetry] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [telemetry] SET RECOVERY FULL 
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
EXEC sys.sp_db_vardecimal_storage_format N'telemetry', N'ON'
GO
ALTER DATABASE [telemetry] SET QUERY_STORE = OFF
GO
USE [telemetry]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/18/2019 3:56:08 PM ******/
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
/****** Object:  Table [dbo].[BatteryManagementSystems]    Script Date: 8/18/2019 3:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatteryManagementSystems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinVolt] [int] NOT NULL,
	[MinVoltId] [int] NOT NULL,
	[MaxVolt] [int] NOT NULL,
	[MaxVoltId] [int] NOT NULL,
	[Volt] [int] NOT NULL,
	[Current] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Soc] [int] NOT NULL,
	[MinTemp] [int] NOT NULL,
	[MinTempId] [int] NOT NULL,
	[MaxTemp] [int] NOT NULL,
	[MaxTempId] [int] NOT NULL,
	[FWVersion] [int] NOT NULL,
	[CycleTime] [int] NOT NULL,
	[MCUTemp] [int] NOT NULL,
	[RoundtripTm] [int] NOT NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_BatteryManagementSystems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Debugs]    Script Date: 8/18/2019 3:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Debugs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExceptionSource] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[Time] [nvarchar](max) NULL,
 CONSTRAINT [PK_Debugs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Errors]    Script Date: 8/18/2019 3:56:08 PM ******/
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
/****** Object:  Table [dbo].[GPSs]    Script Date: 8/18/2019 3:56:08 PM ******/
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
/****** Object:  Table [dbo].[Messages]    Script Date: 8/18/2019 3:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Prefix] [nvarchar](max) NULL,
	[MessageId] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[DateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motors]    Script Date: 8/18/2019 3:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BatteryVoltage] [int] NOT NULL,
	[BatteryCurrent] [int] NOT NULL,
	[MotorCurrentDir] [int] NOT NULL,
	[MotorCurrent] [int] NOT NULL,
	[TempControl] [int] NOT NULL,
	[TempMotor] [int] NOT NULL,
	[MotorRpm] [int] NOT NULL,
	[OutputDuty] [int] NOT NULL,
	[OutputDutyType] [int] NOT NULL,
	[MotorDriveMode] [int] NOT NULL,
	[TempErrLevel] [int] NOT NULL,
	[FailModeInfo2] [int] NOT NULL,
	[PresentCorePos] [int] NOT NULL,
	[FailModeInfo] [int] NOT NULL,
	[Time] [nvarchar](max) NULL,
	[Gear] [int] NOT NULL,
	[BatteryCurrentDir] [int] NOT NULL,
 CONSTRAINT [PK_Motors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MPPTs]    Script Date: 8/18/2019 3:56:08 PM ******/
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
/****** Object:  Table [dbo].[Routenotes]    Script Date: 8/18/2019 3:56:08 PM ******/
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
ALTER TABLE [dbo].[Motors] ADD  DEFAULT ((0)) FOR [Gear]
GO
ALTER TABLE [dbo].[Motors] ADD  DEFAULT ((0)) FOR [BatteryCurrentDir]
GO
USE [master]
GO
ALTER DATABASE [telemetry] SET  READ_WRITE 
GO