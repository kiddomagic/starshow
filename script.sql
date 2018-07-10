USE [master]
GO
/****** Object:  Database [CinemaBookingTicket]    Script Date: 07/10/2018 12:38:46 PM ******/
CREATE DATABASE [CinemaBookingTicket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CinemaBookingTicket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CinemaBookingTicket.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CinemaBookingTicket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CinemaBookingTicket_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CinemaBookingTicket] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinemaBookingTicket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinemaBookingTicket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CinemaBookingTicket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinemaBookingTicket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinemaBookingTicket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinemaBookingTicket] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CinemaBookingTicket] SET  MULTI_USER 
GO
ALTER DATABASE [CinemaBookingTicket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CinemaBookingTicket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CinemaBookingTicket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CinemaBookingTicket] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CinemaBookingTicket] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CinemaBookingTicket]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 07/10/2018 12:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NULL,
	[address] [nchar](10) NULL,
 CONSTRAINT [PK_Cinema] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 07/10/2018 12:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [nvarchar](50) NOT NULL,
	[userId] [nvarchar](50) NULL,
	[ticketQuantity] [int] NULL,
	[buyTime] [datetime] NULL,
	[buyAt] [nchar](10) NULL,
	[totalMoney] [float] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Show]    Script Date: 07/10/2018 12:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show](
	[id] [nvarchar](50) NOT NULL,
	[title] [nvarchar](100) NULL,
	[description] [nvarchar](1000) NULL,
	[releaseDate] [date] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slot]    Script Date: 07/10/2018 12:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slot](
	[id] [nvarchar](50) NOT NULL,
	[date] [date] NULL,
	[startTime] [time](7) NULL,
	[endTime] [time](7) NULL,
	[locationId] [nvarchar](50) NULL,
	[showId] [nvarchar](50) NULL,
	[guest] [nvarchar](max) NULL,
 CONSTRAINT [PK_Slot] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 07/10/2018 12:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[id] [nvarchar](50) NOT NULL,
	[code] [nvarchar](50) NULL,
	[orderId] [nvarchar](50) NULL,
	[slotId] [nvarchar](50) NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 07/10/2018 12:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[gender] [int] NULL,
	[birthday] [date] NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[enable] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Slot]  WITH CHECK ADD  CONSTRAINT [FK_Slot_Location] FOREIGN KEY([locationId])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[Slot] CHECK CONSTRAINT [FK_Slot_Location]
GO
ALTER TABLE [dbo].[Slot]  WITH CHECK ADD  CONSTRAINT [FK_Slot_Show] FOREIGN KEY([showId])
REFERENCES [dbo].[Show] ([id])
GO
ALTER TABLE [dbo].[Slot] CHECK CONSTRAINT [FK_Slot_Show]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Order]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Slot] FOREIGN KEY([slotId])
REFERENCES [dbo].[Slot] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Slot]
GO
USE [master]
GO
ALTER DATABASE [CinemaBookingTicket] SET  READ_WRITE 
GO
