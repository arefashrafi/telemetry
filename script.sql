USE [telemetry]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019-07-15 14:52:36 ******/
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
/****** Object:  Table [dbo].[BatteryManagementSystems]    Script Date: 2019-07-15 14:52:37 ******/
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
/****** Object:  Table [dbo].[Errors]    Script Date: 2019-07-15 14:52:37 ******/
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
/****** Object:  Table [dbo].[GPSs]    Script Date: 2019-07-15 14:52:37 ******/
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
/****** Object:  Table [dbo].[Motors]    Script Date: 2019-07-15 14:52:37 ******/
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
/****** Object:  Table [dbo].[MPPTs]    Script Date: 2019-07-15 14:52:37 ******/
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
/****** Object:  Table [dbo].[Routenotes]    Script Date: 2019-07-15 14:52:37 ******/
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
