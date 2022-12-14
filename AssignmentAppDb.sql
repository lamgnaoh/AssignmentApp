USE [master]
GO
/****** Object:  Database [AssignmentAppDb]    Script Date: 01/10/2022 15:39:38 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/10/2022 15:39:38 ******/
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
/****** Object:  Table [dbo].[AppRoles]    Script Date: 01/10/2022 15:39:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 01/10/2022 15:39:38 ******/
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
/****** Object:  Table [dbo].[Classes]    Script Date: 01/10/2022 15:39:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 01/10/2022 15:39:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[FileId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Path] [nvarchar](200) NOT NULL,
	[StudentAssignmentAssignmentId] [int] NOT NULL,
	[StudentAssignmentStudentId] [int] NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAssignments]    Script Date: 01/10/2022 15:39:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAssignments](
	[AssignmentId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Submitted] [bit] NOT NULL,
	[Grade] [float] NULL,
	[SubmittedAt] [datetime2](7) NULL,
	[Feedback] [nvarchar](500) NULL,
 CONSTRAINT [PK_StudentAssignments] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClasses]    Script Date: 01/10/2022 15:39:38 ******/
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
/****** Object:  Table [dbo].[UserRoles]    Script Date: 01/10/2022 15:39:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/10/2022 15:39:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](60) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[MSSV] [varchar](10) NULL,
	[FullName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220928073210_initial database', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930175735_table files', N'6.0.8')
GO
SET IDENTITY_INSERT [dbo].[AppRoles] ON 

INSERT [dbo].[AppRoles] ([RoleId], [Name]) VALUES (1, N'admin')
INSERT [dbo].[AppRoles] ([RoleId], [Name]) VALUES (2, N'teacher')
INSERT [dbo].[AppRoles] ([RoleId], [Name]) VALUES (3, N'student')
SET IDENTITY_INSERT [dbo].[AppRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([AssignmentId], [ClassId], [CreateAt], [DueTo], [Title], [Content]) VALUES (1, 1, CAST(N'2022-09-06T23:30:00.0000000' AS DateTime2), CAST(N'2022-09-08T23:30:00.0000000' AS DateTime2), N'Báo cáo tuần 1', N'Nộp báo cáo tuần 1 ')
INSERT [dbo].[Assignments] ([AssignmentId], [ClassId], [CreateAt], [DueTo], [Title], [Content]) VALUES (2, 2, CAST(N'2022-09-08T23:30:00.0000000' AS DateTime2), CAST(N'2022-09-09T23:30:00.0000000' AS DateTime2), N'.NET WEB API', N'Lập trình .NET WEB API')
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassId], [CreateAt], [Name]) VALUES (1, CAST(N'2022-06-08T23:30:00.0000000' AS DateTime2), N'project 20213')
INSERT [dbo].[Classes] ([ClassId], [CreateAt], [Name]) VALUES (2, CAST(N'2022-05-11T15:30:00.0000000' AS DateTime2), N'Lap trinh .NET Core')
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[Files] ON 

INSERT [dbo].[Files] ([FileId], [Name], [Path], [StudentAssignmentAssignmentId], [StudentAssignmentStudentId]) VALUES (1, N'test.txt', N'AssignmentApp.API/Static/UploadFiles/test.txt', 1, 1)
INSERT [dbo].[Files] ([FileId], [Name], [Path], [StudentAssignmentAssignmentId], [StudentAssignmentStudentId]) VALUES (2, N'Question Bank.docx', N'AssignmentApp.API/Static/UploadFiles/Question Bank.docx', 2, 1)
INSERT [dbo].[Files] ([FileId], [Name], [Path], [StudentAssignmentAssignmentId], [StudentAssignmentStudentId]) VALUES (13, N'test.txt', N'AssignmentApp.API/Static/UploadFiles/test.txt', 1, 6)
INSERT [dbo].[Files] ([FileId], [Name], [Path], [StudentAssignmentAssignmentId], [StudentAssignmentStudentId]) VALUES (14, N'test2.txt', N'AssignmentApp.API/Static/UploadFiles/test2.txt', 1, 6)
INSERT [dbo].[Files] ([FileId], [Name], [Path], [StudentAssignmentAssignmentId], [StudentAssignmentStudentId]) VALUES (15, N'test2.txt', N'AssignmentApp.API/Static/UploadFiles/test2.txt', 1, 7)
SET IDENTITY_INSERT [dbo].[Files] OFF
GO
INSERT [dbo].[StudentAssignments] ([AssignmentId], [StudentId], [Submitted], [Grade], [SubmittedAt], [Feedback]) VALUES (1, 1, 1, 10, CAST(N'2022-10-01T10:41:15.9808177' AS DateTime2), N'Tốt')
INSERT [dbo].[StudentAssignments] ([AssignmentId], [StudentId], [Submitted], [Grade], [SubmittedAt], [Feedback]) VALUES (1, 2, 1, 5, CAST(N'2022-10-01T11:04:08.2986201' AS DateTime2), N'test')
INSERT [dbo].[StudentAssignments] ([AssignmentId], [StudentId], [Submitted], [Grade], [SubmittedAt], [Feedback]) VALUES (1, 6, 1, NULL, CAST(N'2022-10-01T11:10:14.2418674' AS DateTime2), NULL)
INSERT [dbo].[StudentAssignments] ([AssignmentId], [StudentId], [Submitted], [Grade], [SubmittedAt], [Feedback]) VALUES (1, 7, 1, NULL, CAST(N'2022-10-01T12:22:16.9900545' AS DateTime2), NULL)
INSERT [dbo].[StudentAssignments] ([AssignmentId], [StudentId], [Submitted], [Grade], [SubmittedAt], [Feedback]) VALUES (2, 1, 1, NULL, CAST(N'2022-09-30T00:05:33.9502854' AS DateTime2), NULL)
GO
INSERT [dbo].[UserClasses] ([UserId], [ClassId]) VALUES (1, 1)
INSERT [dbo].[UserClasses] ([UserId], [ClassId]) VALUES (2, 1)
INSERT [dbo].[UserClasses] ([UserId], [ClassId]) VALUES (3, 1)
INSERT [dbo].[UserClasses] ([UserId], [ClassId]) VALUES (6, 1)
INSERT [dbo].[UserClasses] ([UserId], [ClassId]) VALUES (7, 1)
INSERT [dbo].[UserClasses] ([UserId], [ClassId]) VALUES (1, 2)
INSERT [dbo].[UserClasses] ([UserId], [ClassId]) VALUES (3, 2)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (3, 1)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (4, 1)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (3, 2)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (6, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (7, 3)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [PhoneNumber], [Email], [MSSV], [FullName]) VALUES (1, N'Luong Hoang Lam 20183780', N'12345678', N'0123123xxx', N'lam.lh183780@sis.hust.edu.vn', N'20183780', N'Luong Hoang Lam')
INSERT [dbo].[Users] ([Id], [Username], [Password], [PhoneNumber], [Email], [MSSV], [FullName]) VALUES (2, N'Dang Bao Lam 20183779', N'12345678', N'0456456xxx', N'lam.db183779@sis.hust.edu.vn', N'20183779', N'Dang Bao Lam')
INSERT [dbo].[Users] ([Id], [Username], [Password], [PhoneNumber], [Email], [MSSV], [FullName]) VALUES (3, N'Nguyen Dinh Thuan', N'12345678', N'0789789xxx', N'thuan.nguyendinh@hust.edu.vn', NULL, N'Nguyen Dinh Thuan')
INSERT [dbo].[Users] ([Id], [Username], [Password], [PhoneNumber], [Email], [MSSV], [FullName]) VALUES (4, N'admin', N'admin', N'0456789xxx', N'admin@hust.edu.vn', NULL, N'admin')
INSERT [dbo].[Users] ([Id], [Username], [Password], [PhoneNumber], [Email], [MSSV], [FullName]) VALUES (6, N'student3', N'12345678', N'12345678', N'student3@sis.hust.edu.vn', N'test', N'student3')
INSERT [dbo].[Users] ([Id], [Username], [Password], [PhoneNumber], [Email], [MSSV], [FullName]) VALUES (7, N'student4', N'12345678', N'string', N'student4@sis.hust.edu.vn', N'test', N'student4')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Assignments_ClassId]    Script Date: 01/10/2022 15:39:38 ******/
CREATE NONCLUSTERED INDEX [IX_Assignments_ClassId] ON [dbo].[Assignments]
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Files_StudentAssignmentAssignmentId_StudentAssignmentStudentId]    Script Date: 01/10/2022 15:39:38 ******/
CREATE NONCLUSTERED INDEX [IX_Files_StudentAssignmentAssignmentId_StudentAssignmentStudentId] ON [dbo].[Files]
(
	[StudentAssignmentAssignmentId] ASC,
	[StudentAssignmentStudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentAssignments_StudentId]    Script Date: 01/10/2022 15:39:38 ******/
CREATE NONCLUSTERED INDEX [IX_StudentAssignments_StudentId] ON [dbo].[StudentAssignments]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserClasses_ClassId]    Script Date: 01/10/2022 15:39:38 ******/
CREATE NONCLUSTERED INDEX [IX_UserClasses_ClassId] ON [dbo].[UserClasses]
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 01/10/2022 15:39:38 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Classes_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Classes_ClassId]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_StudentAssignments_StudentAssignmentAssignmentId_StudentAssignmentStudentId] FOREIGN KEY([StudentAssignmentAssignmentId], [StudentAssignmentStudentId])
REFERENCES [dbo].[StudentAssignments] ([AssignmentId], [StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_StudentAssignments_StudentAssignmentAssignmentId_StudentAssignmentStudentId]
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
USE [master]
GO
ALTER DATABASE [AssignmentAppDb] SET  READ_WRITE 
GO
