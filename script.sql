USE [master]
GO
/****** Object:  Database [ProjectASP]    Script Date: 8/30/2022 12:17:04 PM ******/
CREATE DATABASE [ProjectASP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectASP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjectASP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectASP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjectASP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectASP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectASP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectASP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectASP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectASP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectASP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectASP] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectASP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectASP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectASP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectASP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectASP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectASP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectASP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectASP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectASP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectASP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectASP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectASP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectASP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectASP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectASP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectASP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectASP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectASP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectASP] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectASP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectASP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectASP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectASP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectASP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectASP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProjectASP] SET QUERY_STORE = OFF
GO
USE [ProjectASP]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/30/2022 12:17:05 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumGenres]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumGenres](
	[GenreID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
 CONSTRAINT [PK_AlbumGenres] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC,
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Published] [datetime2](7) NOT NULL,
	[ArtistID] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](70) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
	[LikedAt] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLines]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CreditCard] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongArtists]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongArtists](
	[SongID] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
 CONSTRAINT [PK_SongArtists] PRIMARY KEY CLUSTERED 
(
	[SongID] ASC,
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AlbumID] [int] NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
	[Duration] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UseCaseName] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[Username] [nvarchar](max) NULL,
	[ExecutionTime] [datetime2](7) NOT NULL,
	[Data] [nvarchar](max) NULL,
	[IsAuthorized] [bit] NOT NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCases]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UseCaseID] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_UseCases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/30/2022 12:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](30) NOT NULL,
	[Lastname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](15) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220830101158_initial', N'5.0.17')
GO
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (1, 4)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (2, 1)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (2, 2)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (2, 6)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (2, 7)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (2, 8)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (2, 9)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (2, 11)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 1)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 2)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 6)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 7)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 8)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 9)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 10)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (3, 11)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (4, 2)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (4, 5)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (5, 3)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (6, 10)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 2)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 4)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 5)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 7)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 8)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 9)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 10)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (7, 11)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (8, 3)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (8, 5)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (8, 7)
INSERT [dbo].[AlbumGenres] ([GenreID], [AlbumID]) VALUES (8, 8)
GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (1, NULL, N'My Dear Melancholy', CAST(6.87 AS Decimal(18, 2)), CAST(N'2018-03-30T00:00:00.0000000' AS DateTime2), 5, CAST(N'2022-08-30T10:13:29.2044004' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (2, NULL, N'25', CAST(9.80 AS Decimal(18, 2)), CAST(N'2015-11-20T00:00:00.0000000' AS DateTime2), 1, CAST(N'2022-08-30T10:13:29.2043955' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (3, NULL, N'The Number of the Beast', CAST(9.99 AS Decimal(18, 2)), CAST(N'1982-03-22T00:00:00.0000000' AS DateTime2), 11, CAST(N'2022-08-30T10:13:29.2043961' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (4, NULL, N'Pretty Boy, Dirty Boy', CAST(45.82 AS Decimal(18, 2)), CAST(N'2015-10-30T00:00:00.0000000' AS DateTime2), 10, CAST(N'2022-08-30T10:13:29.2043966' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (5, NULL, N'A Star Is Born', CAST(12.94 AS Decimal(18, 2)), CAST(N'2018-10-05T00:00:00.0000000' AS DateTime2), 9, CAST(N'2022-08-30T10:13:29.2043970' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (6, NULL, N'After Hours', CAST(11.99 AS Decimal(18, 2)), CAST(N'2020-03-20T00:00:00.0000000' AS DateTime2), 5, CAST(N'2022-08-30T10:13:29.2043999' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (7, NULL, N'Pipes Of Peace', CAST(11.99 AS Decimal(18, 2)), CAST(N'1983-10-31T00:00:00.0000000' AS DateTime2), 8, CAST(N'2022-08-30T10:13:29.2043981' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (8, NULL, N'Mr. Bad Guy', CAST(18.89 AS Decimal(18, 2)), CAST(N'1985-04-29T00:00:00.0000000' AS DateTime2), 7, CAST(N'2022-08-30T10:13:29.2043984' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (9, NULL, N'Dangerous Woman', CAST(7.99 AS Decimal(18, 2)), CAST(N'2016-05-20T00:00:00.0000000' AS DateTime2), 6, CAST(N'2022-08-30T10:13:29.2043991' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (10, NULL, N'Thank U, Next', CAST(11.49 AS Decimal(18, 2)), CAST(N'2019-02-08T00:00:00.0000000' AS DateTime2), 6, CAST(N'2022-08-30T10:13:29.2043996' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Albums] ([Id], [ImagePath], [Name], [Price], [Published], [ArtistID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (11, NULL, N'Thriller', CAST(26.27 AS Decimal(18, 2)), CAST(N'1982-11-30T00:00:00.0000000' AS DateTime2), 8, CAST(N'2022-08-30T10:13:29.2043976' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Albums] OFF
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (1, N'Adele', CAST(N'2022-08-30T10:13:29.2043957' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (2, N'Ricky Martin', CAST(N'2022-08-30T10:13:29.2044011' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (3, N'Britney Spears', CAST(N'2022-08-30T10:13:29.2044008' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (4, N'ACDC', CAST(N'2022-08-30T10:13:29.2044006' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (5, N'The Weeknd', CAST(N'2022-08-30T10:13:29.2044001' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (6, N'Ariana Grande', CAST(N'2022-08-30T10:13:29.2043993' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (7, N'Freddie Mercury', CAST(N'2022-08-30T10:13:29.2043987' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (8, N'Michael Jackson', CAST(N'2022-08-30T10:13:29.2043978' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (9, N'Lady Gaga', CAST(N'2022-08-30T10:13:29.2043974' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (10, N'Maluma', CAST(N'2022-08-30T10:13:29.2043968' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (11, N'Iron Maiden', CAST(N'2022-08-30T10:13:29.2043964' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (12, N'Paul McCartney', CAST(N'2022-08-30T10:13:29.2044016' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Artists] ([Id], [Fullname], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (13, N'Bradley Cooper', CAST(N'2022-08-30T10:13:29.2044013' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Artists] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (1, N'Latino Urbano', CAST(N'2022-08-30T10:13:29.2043828' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (2, N'R&B', CAST(N'2022-08-30T10:13:29.2043825' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (3, N'Soul Music', CAST(N'2022-08-30T10:13:29.2043823' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (4, N'Folk', CAST(N'2022-08-30T10:13:29.2043819' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (5, N'Heavy Metal', CAST(N'2022-08-30T10:13:29.2043816' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (6, N'Hip Hop', CAST(N'2022-08-30T10:13:29.2043813' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (7, N'Pop', CAST(N'2022-08-30T10:13:29.2043808' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (8, N'Rock', CAST(N'2022-08-30T10:13:29.2043172' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Likes] ON 

INSERT [dbo].[Likes] ([Id], [UserID], [AlbumID], [LikedAt], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (1, 2, 8, CAST(N'2022-08-30T12:13:30.2966667' AS DateTime2), CAST(N'2022-08-30T10:13:29.2044145' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Likes] ([Id], [UserID], [AlbumID], [LikedAt], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (2, 1, 6, CAST(N'2022-08-30T12:13:30.2966667' AS DateTime2), CAST(N'2022-08-30T10:13:29.2044148' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Likes] ([Id], [UserID], [AlbumID], [LikedAt], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (3, 2, 7, CAST(N'2022-08-30T12:13:30.2966667' AS DateTime2), CAST(N'2022-08-30T10:13:29.2044143' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Likes] ([Id], [UserID], [AlbumID], [LikedAt], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (4, 1, 1, CAST(N'2022-08-30T12:13:30.2966667' AS DateTime2), CAST(N'2022-08-30T10:13:29.2044151' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Likes] ([Id], [UserID], [AlbumID], [LikedAt], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (5, 2, 2, CAST(N'2022-08-30T12:13:30.2966667' AS DateTime2), CAST(N'2022-08-30T10:13:29.2044141' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Likes] OFF
GO
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (9, 1)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (10, 1)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (17, 1)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (41, 1)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (26, 2)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (3, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (4, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (5, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (6, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (7, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (8, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (11, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (12, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (13, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (14, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (15, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (16, 5)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (20, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (21, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (31, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (32, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (33, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (34, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (38, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (39, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (40, 6)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (30, 7)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (1, 8)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (24, 8)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (30, 8)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (22, 9)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (23, 9)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (25, 9)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (8, 10)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (26, 10)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (27, 10)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (28, 10)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (29, 10)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (2, 11)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (18, 11)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (19, 11)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (35, 11)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (36, 11)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (37, 11)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (1, 12)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (24, 12)
INSERT [dbo].[SongArtists] ([SongID], [ArtistID]) VALUES (25, 13)
GO
SET IDENTITY_INSERT [dbo].[Songs] ON 

INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (1, 11, N'Say Say say', N'3:42', CAST(N'2022-08-30T10:13:29.2043890' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (2, 3, N'Inaders', N'3:24', CAST(N'2022-08-30T10:13:29.2043854' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (3, 6, N'Heartless', N'3:18', CAST(N'2022-08-30T10:13:29.2043919' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (4, 6, N'Blinding Lights', N'3:20', CAST(N'2022-08-30T10:13:29.2043922' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (5, 6, N'In Your Eyes', N'3:58', CAST(N'2022-08-30T10:13:29.2043924' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (6, 6, N'Alone Again', N'4:10', CAST(N'2022-08-30T10:13:29.2043926' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (7, 6, N'Faith', N'4:43', CAST(N'2022-08-30T10:13:29.2043928' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (8, 6, N'Hawai', N'4:21', CAST(N'2022-08-30T10:13:29.2043931' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (9, 2, N'Sweetest Devotion', N'4:12', CAST(N'2022-08-30T10:13:29.2043852' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (10, 2, N'I Miss You', N'5:49', CAST(N'2022-08-30T10:13:29.2043849' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (11, 1, N'Call Out My Name', N'3:48', CAST(N'2022-08-30T10:13:29.2043933' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (12, 1, N'Wasted Times', N'3:40', CAST(N'2022-08-30T10:13:29.2043935' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (13, 1, N'Hurt You', N'3:50', CAST(N'2022-08-30T10:13:29.2043938' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (14, 1, N'Try Me', N'3:41', CAST(N'2022-08-30T10:13:29.2043940' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (15, 1, N'I Was Never There', N'4:01', CAST(N'2022-08-30T10:13:29.2043943' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (16, 1, N'Privilege', N'2:51', CAST(N'2022-08-30T10:13:29.2043945' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (17, 2, N'When We Were Young', N'4:51', CAST(N'2022-08-30T10:13:29.2043846' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (18, 3, N'Run To The Hills', N'3:54', CAST(N'2022-08-30T10:13:29.2043856' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (19, 3, N'The Prisoner', N'6:02', CAST(N'2022-08-30T10:13:29.2043859' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (20, 10, N'Bad Idea', N'4:27', CAST(N'2022-08-30T10:13:29.2043917' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (21, 10, N'Thank U, Next', N'3:27', CAST(N'2022-08-30T10:13:29.2043915' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (22, 5, N'Black Eyes', N'3:04', CAST(N'2022-08-30T10:13:29.2043888' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (23, 5, N'La vie en rose', N'3:00', CAST(N'2022-08-30T10:13:29.2043886' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (24, 8, N'The Girl is Mine', N'3:22', CAST(N'2022-08-30T10:13:29.2043895' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (25, 5, N'Shallow', N'3:00', CAST(N'2022-08-30T10:13:29.2043883' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (26, 4, N'Vente Pa'' Ca', N'3:27', CAST(N'2022-08-30T10:13:29.2043881' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (27, 4, N'Solos', N'3:27', CAST(N'2022-08-30T10:13:29.2043879' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (28, 4, N'Una aventura', N'3:41', CAST(N'2022-08-30T10:13:29.2043871' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (29, 4, N'El Perdedor', N'3:27', CAST(N'2022-08-30T10:13:29.2043868' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (30, 7, N'There Must Be More To Life Than This', N'2:54', CAST(N'2022-08-30T10:13:29.2043892' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (31, 9, N'Side To Side', N'3:46', CAST(N'2022-08-30T10:13:29.2043897' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (32, 9, N'Into You', N'4:05', CAST(N'2022-08-30T10:13:29.2043903' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (33, 9, N'Dangerous Woman', N'3:56', CAST(N'2022-08-30T10:13:29.2043905' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (34, 9, N'Moonlight', N'3:22', CAST(N'2022-08-30T10:13:29.2043908' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (35, 3, N'Children Of The Damned', N'4:35', CAST(N'2022-08-30T10:13:29.2043866' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (36, 3, N'Gangland', N'3:49', CAST(N'2022-08-30T10:13:29.2043863' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (37, 3, N'The Number Of The Beast', N'4:51', CAST(N'2022-08-30T10:13:29.2043861' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (38, 10, N'7 rings', N'3:22', CAST(N'2022-08-30T10:13:29.2043910' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (39, 10, N'Break Up With Your Girlfriend', N'3:11', CAST(N'2022-08-30T10:13:29.2043912' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (40, 9, N'Leave Me Lonely', N'3:50', CAST(N'2022-08-30T10:13:29.2043901' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Songs] ([Id], [AlbumID], [Name], [Duration], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (41, 2, N'Hello', N'4:55', CAST(N'2022-08-30T10:13:29.2043843' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Songs] OFF
GO
SET IDENTITY_INSERT [dbo].[UseCases] ON 

INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (1, 2, 13, CAST(N'2022-08-30T10:13:29.2044248' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (2, 2, 14, CAST(N'2022-08-30T10:13:29.2044250' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (3, 2, 15, CAST(N'2022-08-30T10:13:29.2044252' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (4, 2, 27, CAST(N'2022-08-30T10:13:29.2044254' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (5, 2, 28, CAST(N'2022-08-30T10:13:29.2044257' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (6, 2, 11, CAST(N'2022-08-30T10:13:29.2044264' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (7, 2, 19, CAST(N'2022-08-30T10:13:29.2044265' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (8, 1, 2, CAST(N'2022-08-30T10:13:29.2044268' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (9, 1, 3, CAST(N'2022-08-30T10:13:29.2044270' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (10, 1, 8, CAST(N'2022-08-30T10:13:29.2044274' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (11, 1, 12, CAST(N'2022-08-30T10:13:29.2044277' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (12, 1, 13, CAST(N'2022-08-30T10:13:29.2044279' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (13, 2, 12, CAST(N'2022-08-30T10:13:29.2044245' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (14, 1, 15, CAST(N'2022-08-30T10:13:29.2044283' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (15, 1, 27, CAST(N'2022-08-30T10:13:29.2044286' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (16, 1, 28, CAST(N'2022-08-30T10:13:29.2044288' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (17, 1, 11, CAST(N'2022-08-30T10:13:29.2044290' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (18, 1, 19, CAST(N'2022-08-30T10:13:29.2044293' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (19, 1, 7, CAST(N'2022-08-30T10:13:29.2044272' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (20, 1, 14, CAST(N'2022-08-30T10:13:29.2044281' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (21, 2, 8, CAST(N'2022-08-30T10:13:29.2044243' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (22, 2, 3, CAST(N'2022-08-30T10:13:29.2044239' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (23, 3, 2, CAST(N'2022-08-30T10:13:29.2044157' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (24, 3, 3, CAST(N'2022-08-30T10:13:29.2044159' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (25, 3, 4, CAST(N'2022-08-30T10:13:29.2044179' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (26, 3, 5, CAST(N'2022-08-30T10:13:29.2044186' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (27, 3, 6, CAST(N'2022-08-30T10:13:29.2044188' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (28, 3, 7, CAST(N'2022-08-30T10:13:29.2044190' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (29, 3, 8, CAST(N'2022-08-30T10:13:29.2044193' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (30, 3, 9, CAST(N'2022-08-30T10:13:29.2044195' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (31, 3, 10, CAST(N'2022-08-30T10:13:29.2044197' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (32, 3, 12, CAST(N'2022-08-30T10:13:29.2044200' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (33, 3, 13, CAST(N'2022-08-30T10:13:29.2044202' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (34, 3, 14, CAST(N'2022-08-30T10:13:29.2044205' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (35, 3, 15, CAST(N'2022-08-30T10:13:29.2044207' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (36, 3, 16, CAST(N'2022-08-30T10:13:29.2044209' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (37, 3, 17, CAST(N'2022-08-30T10:13:29.2044211' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (38, 3, 18, CAST(N'2022-08-30T10:13:29.2044214' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (39, 3, 20, CAST(N'2022-08-30T10:13:29.2044216' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (40, 3, 21, CAST(N'2022-08-30T10:13:29.2044217' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (41, 3, 22, CAST(N'2022-08-30T10:13:29.2044220' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (42, 3, 23, CAST(N'2022-08-30T10:13:29.2044221' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (43, 3, 24, CAST(N'2022-08-30T10:13:29.2044224' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (44, 3, 25, CAST(N'2022-08-30T10:13:29.2044226' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (45, 3, 26, CAST(N'2022-08-30T10:13:29.2044227' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (46, 3, 29, CAST(N'2022-08-30T10:13:29.2044230' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (47, 3, 30, CAST(N'2022-08-30T10:13:29.2044232' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (48, 3, 31, CAST(N'2022-08-30T10:13:29.2044234' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (49, 2, 2, CAST(N'2022-08-30T10:13:29.2044237' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (50, 2, 7, CAST(N'2022-08-30T10:13:29.2044241' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UseCases] ([Id], [UserID], [UseCaseID], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (51, 3, 1, CAST(N'2022-08-30T10:13:29.2044154' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UseCases] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Firstname], [Lastname], [Email], [Password], [Username], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (1, N'Petar', N'Petrovic', N'petar@gmail.com', N'$2a$11$ArMNYdvBrs.VeH10/xz2huJaimUJE7gMoCw2AMg2BOo0O89T/SrQu', N'ppetrovic', CAST(N'2022-08-30T10:13:29.2043838' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Firstname], [Lastname], [Email], [Password], [Username], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (2, N'Marko', N'Markovic', N'marko@gmail.com', N'$2a$11$ixxKDDj95uaCKg/vfM15L.rdScJwOv6Hc1OnOrAIEASkynYo7zKu2', N'mmarkovic', CAST(N'2022-08-30T10:13:29.2043835' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Firstname], [Lastname], [Email], [Password], [Username], [CreatedAt], [CreateBy], [IsActive], [UpdatedAt], [UpdatedBy], [DeletedAt], [DeletedBy]) VALUES (3, N'User', N'Admin', N'admin@gmail.com', N'$2a$11$Y6nKFi8Q.SOguxRSJ6KOdetbOlzapE9PtUtHqHS1rFLZWNQ4pRgAy', N'adminuser', CAST(N'2022-08-30T10:13:29.2043831' AS DateTime2), N'Anonymous', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_AlbumGenres_GenreID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AlbumGenres_GenreID] ON [dbo].[AlbumGenres]
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Albums_ArtistID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Albums_ArtistID] ON [dbo].[Albums]
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Albums_Name]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Albums_Name] ON [dbo].[Albums]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Artists_Fullname]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Artists_Fullname] ON [dbo].[Artists]
(
	[Fullname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Genres_Name]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Genres_Name] ON [dbo].[Genres]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Likes_AlbumID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Likes_AlbumID] ON [dbo].[Likes]
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Likes_UserID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Likes_UserID] ON [dbo].[Likes]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderLines_AlbumID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderLines_AlbumID] ON [dbo].[OrderLines]
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderLines_OrderID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderLines_OrderID] ON [dbo].[OrderLines]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserID] ON [dbo].[Orders]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SongArtists_ArtistID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_SongArtists_ArtistID] ON [dbo].[SongArtists]
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Songs_AlbumID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Songs_AlbumID] ON [dbo].[Songs]
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Songs_Name]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Songs_Name] ON [dbo].[Songs]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UseCaseLogs_UserID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UseCaseLogs_UserID] ON [dbo].[UseCaseLogs]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UseCases_UserID]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_UseCases_UserID] ON [dbo].[UseCases]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 8/30/2022 12:17:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albums] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Artists] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Genres] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Likes] ADD  DEFAULT (getdate()) FOR [LikedAt]
GO
ALTER TABLE [dbo].[Likes] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Songs] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[AlbumGenres]  WITH CHECK ADD  CONSTRAINT [FK_AlbumGenres_Albums_AlbumID] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[AlbumGenres] CHECK CONSTRAINT [FK_AlbumGenres_Albums_AlbumID]
GO
ALTER TABLE [dbo].[AlbumGenres]  WITH CHECK ADD  CONSTRAINT [FK_AlbumGenres_Genres_GenreID] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[AlbumGenres] CHECK CONSTRAINT [FK_AlbumGenres_Genres_GenreID]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Artists_ArtistID] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Artists_ArtistID]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Albums_AlbumID] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Albums] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Albums_AlbumID]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Users_UserID]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Albums_AlbumID] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Albums] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Albums_AlbumID]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Orders_OrderID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserID]
GO
ALTER TABLE [dbo].[SongArtists]  WITH CHECK ADD  CONSTRAINT [FK_SongArtists_Artists_ArtistID] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artists] ([Id])
GO
ALTER TABLE [dbo].[SongArtists] CHECK CONSTRAINT [FK_SongArtists_Artists_ArtistID]
GO
ALTER TABLE [dbo].[SongArtists]  WITH CHECK ADD  CONSTRAINT [FK_SongArtists_Songs_SongID] FOREIGN KEY([SongID])
REFERENCES [dbo].[Songs] ([Id])
GO
ALTER TABLE [dbo].[SongArtists] CHECK CONSTRAINT [FK_SongArtists_Songs_SongID]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Albums_AlbumID] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Albums] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Albums_AlbumID]
GO
ALTER TABLE [dbo].[UseCaseLogs]  WITH CHECK ADD  CONSTRAINT [FK_UseCaseLogs_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UseCaseLogs] CHECK CONSTRAINT [FK_UseCaseLogs_Users_UserID]
GO
ALTER TABLE [dbo].[UseCases]  WITH CHECK ADD  CONSTRAINT [FK_UseCases_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UseCases] CHECK CONSTRAINT [FK_UseCases_Users_UserID]
GO
USE [master]
GO
ALTER DATABASE [ProjectASP] SET  READ_WRITE 
GO
