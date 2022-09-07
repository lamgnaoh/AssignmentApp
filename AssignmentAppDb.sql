USE [master]
GO
/****** Object:  Database [AssignmentAppDb]    Script Date: 07/09/2022 12:01:29 ******/
CREATE DATABASE [AssignmentAppDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssignmentAppDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LAMLH\MSSQL\DATA\AssignmentAppDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AssignmentAppDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LAMLH\MSSQL\DATA\AssignmentAppDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AssignmentAppDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssignmentAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AssignmentAppDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AssignmentAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AssignmentAppDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AssignmentAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AssignmentAppDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AssignmentAppDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET RECOVERY FULL 
GO
ALTER DATABASE [AssignmentAppDb] SET  MULTI_USER 
GO
ALTER DATABASE [AssignmentAppDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AssignmentAppDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AssignmentAppDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AssignmentAppDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AssignmentAppDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AssignmentAppDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AssignmentAppDb', N'ON'
GO
ALTER DATABASE [AssignmentAppDb] SET QUERY_STORE = OFF
GO
USE [AssignmentAppDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/09/2022 12:01:29 ******/
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
/****** Object:  Table [dbo].[AppRoles]    Script Date: 07/09/2022 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 07/09/2022 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[AssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[DueTo] [datetime2](7) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 07/09/2022 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAssignments]    Script Date: 07/09/2022 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAssignments](
	[AssignmentId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Submitted] [bit] NOT NULL,
	[Grade] [float] NOT NULL,
	[SubmittedAt] [datetime2](7) NOT NULL,
	[Feedback] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_StudentAssignments] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

alter table [StudentAssignments]
alter column [Grade] [float] null

alter table [StudentAssignments]
alter column [SubmittedAt] [datetime2](7) null

alter table [StudentAssignments]
alter column [Feedback] [nvarchar](500) null
GO
/****** Object:  Table [dbo].[UserClasses]    Script Date: 07/09/2022 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClasses](
	[UserId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_UserClasses] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 07/09/2022 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/09/2022 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](60) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[PhoneNumber] [char](15) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[MSSV] [varchar](10) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
alter table [Users]
alter column [MSSV] varchar(10) null
GO
/****** Object:  Index [IX_Assignments_ClassId]    Script Date: 07/09/2022 12:01:29 ******/
CREATE NONCLUSTERED INDEX [IX_Assignments_ClassId] ON [dbo].[Assignments]
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentAssignments_StudentId]    Script Date: 07/09/2022 12:01:29 ******/
CREATE NONCLUSTERED INDEX [IX_StudentAssignments_StudentId] ON [dbo].[StudentAssignments]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserClasses_ClassId]    Script Date: 07/09/2022 12:01:29 ******/
CREATE NONCLUSTERED INDEX [IX_UserClasses_ClassId] ON [dbo].[UserClasses]
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 07/09/2022 12:01:29 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StudentAssignments] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Grade]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Classes_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Classes_ClassId]
GO
ALTER TABLE [dbo].[StudentAssignments]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignments_Assignments_AssignmentId] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignments] ([AssignmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAssignments] CHECK CONSTRAINT [FK_StudentAssignments_Assignments_AssignmentId]
GO
ALTER TABLE [dbo].[StudentAssignments]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignments_Users_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAssignments] CHECK CONSTRAINT [FK_StudentAssignments_Users_StudentId]
GO
ALTER TABLE [dbo].[UserClasses]  WITH CHECK ADD  CONSTRAINT [FK_UserClasses_Classes_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClasses] CHECK CONSTRAINT [FK_UserClasses_Classes_ClassId]
GO
ALTER TABLE [dbo].[UserClasses]  WITH CHECK ADD  CONSTRAINT [FK_UserClasses_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClasses] CHECK CONSTRAINT [FK_UserClasses_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_AppRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AppRoles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_AppRoles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [CK_DueTo_CreateAt] CHECK  ((datediff(minute,[CreateAt],[DueTo])>(0)))
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [CK_DueTo_CreateAt]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Username] CHECK  (([Username]=(([Fullname]+' ')+[MSSV]) AND [MSSV] IS NOT NULL OR [Username]=[Fullname] AND [MSSV] IS NULL))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_Username]
GO
USE [master]
GO
ALTER DATABASE [AssignmentAppDb] SET  READ_WRITE 
GO
