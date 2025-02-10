USE [master]
GO
/****** Object:  Database [Waracle.HotelBooking]    Script Date: 10/02/2025 01:21:17 ******/
CREATE DATABASE [Waracle.HotelBooking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Waracle.HotelBooking', FILENAME = N'/var/opt/mssql/data/Waracle.HotelBooking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Waracle.HotelBooking_log', FILENAME = N'/var/opt/mssql/data/Waracle.HotelBooking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Waracle.HotelBooking] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Waracle.HotelBooking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Waracle.HotelBooking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET ARITHABORT OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Waracle.HotelBooking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Waracle.HotelBooking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Waracle.HotelBooking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Waracle.HotelBooking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET RECOVERY FULL 
GO
ALTER DATABASE [Waracle.HotelBooking] SET  MULTI_USER 
GO
ALTER DATABASE [Waracle.HotelBooking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Waracle.HotelBooking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Waracle.HotelBooking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Waracle.HotelBooking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Waracle.HotelBooking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Waracle.HotelBooking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Waracle.HotelBooking', N'ON'
GO
ALTER DATABASE [Waracle.HotelBooking] SET QUERY_STORE = ON
GO
ALTER DATABASE [Waracle.HotelBooking] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Waracle.HotelBooking]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 10/02/2025 01:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[RoomId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[GuestName] [nvarchar](256) NOT NULL,
	[GuestTelNo] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 10/02/2025 01:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Address] [nvarchar](512) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 10/02/2025 01:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[HotelId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 10/02/2025 01:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Occupancy] [int] NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Booking] ([Id], [RoomId], [DateStart], [DateEnd], [GuestName], [GuestTelNo]) VALUES (N'a76bccd5-0a0f-4853-92d1-70819fbc9428', 0, CAST(N'2025-02-10' AS Date), CAST(N'2025-02-12' AS Date), N'Guy Manderson', N'123123123123')
GO
INSERT [dbo].[Booking] ([Id], [RoomId], [DateStart], [DateEnd], [GuestName], [GuestTelNo]) VALUES (N'5425b7b2-6a8b-4936-8d60-861171e31baf', 0, CAST(N'2025-02-13' AS Date), CAST(N'2025-02-14' AS Date), N'Joe Joeson', N'321321321')
GO
INSERT [dbo].[Booking] ([Id], [RoomId], [DateStart], [DateEnd], [GuestName], [GuestTelNo]) VALUES (N'3d8cfc45-a32c-4cf6-99ed-f678431f8525', 0, CAST(N'2025-02-09' AS Date), CAST(N'2025-02-09' AS Date), N'Manguy McDude', N'101101101')
GO
INSERT [dbo].[Hotel] ([Id], [Name], [Address]) VALUES (0, N'First Hotel', N'1 Hotel Ave.')
GO
INSERT [dbo].[Hotel] ([Id], [Name], [Address]) VALUES (1, N'Second Hotel', N'2 Hotel Ave.')
GO
INSERT [dbo].[Hotel] ([Id], [Name], [Address]) VALUES (2, N'Third Hotel', N'3 Hotel Ave.')
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (0, N'Room 2-1', 1, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (1, N'Room 2-2', 1, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (2, N'Room 2-3', 1, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (3, N'Room 2-4', 1, 0)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (4, N'Room 2-5', 1, 0)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (5, N'Royal Room', 1, 2)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (6, N'Room 3-1', 2, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (7, N'Room 3-2', 2, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (8, N'Room 3-3', 2, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (9, N'Room 3-4', 2, 0)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (10, N'Room 3-5', 2, 0)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (11, N'Royal Room', 2, 2)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (12, N'Room 1-1', 0, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (13, N'Room 1-2', 0, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (14, N'Room 1-3', 0, 1)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (15, N'Room 1-4', 0, 0)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (16, N'Room 1-5', 0, 0)
GO
INSERT [dbo].[Room] ([Id], [Name], [HotelId], [TypeId]) VALUES (17, N'Royal Room', 0, 2)
GO
INSERT [dbo].[RoomType] ([Id], [Name], [Occupancy]) VALUES (0, N'Single', 1)
GO
INSERT [dbo].[RoomType] ([Id], [Name], [Occupancy]) VALUES (1, N'Double', 2)
GO
INSERT [dbo].[RoomType] ([Id], [Name], [Occupancy]) VALUES (2, N'Deluxe', 2)
GO
ALTER TABLE [dbo].[Booking] ADD  CONSTRAINT [DF_Booking_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Booking] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Booking]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[RoomType] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
USE [master]
GO
ALTER DATABASE [Waracle.HotelBooking] SET  READ_WRITE 
GO
