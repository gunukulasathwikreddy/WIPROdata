﻿USE [master]
GO
/****** Object:  Database [bank]    Script Date: 02-08-2025 10:11:23 ******/
CREATE DATABASE Bank
GO
ALTER DATABASE [bank] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [bank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bank] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bank] SET RECOVERY FULL 
GO
ALTER DATABASE [bank] SET  MULTI_USER 
GO
ALTER DATABASE [bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bank] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'bank', N'ON'
GO
ALTER DATABASE [bank] SET QUERY_STORE = ON
GO
ALTER DATABASE [bank] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [bank]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 02-08-2025 10:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountNo] [int] NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[City] [varchar](30) NULL,
	[State] [varchar](30) NULL,
	[Amount] [numeric](9, 2) NULL,
	[AccountType] [varchar](10) NULL,
	[CheqFacil] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trans]    Script Date: 02-08-2025 10:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trans](
	[TranId] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [int] NULL,
	[TranAmount] [numeric](9, 2) NULL,
	[TranType] [varchar](5) NULL,
	[TranDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TranId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02-08-2025 10:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NULL,
	[Passcode] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (1, N'Venkata', N'Gayathri', N'Hyderabad', N'TS', CAST(108222.00 AS Numeric(9, 2)), N'Savings', N'Yes')
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (2, N'Raj', N'Kishore', N'Hyd', N'TS', CAST(99222.00 AS Numeric(9, 2)), N'Savings', N'Yes')
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (3, N'Ranjan', N'Kishore', N'Hyd', N'TS', CAST(99222.00 AS Numeric(9, 2)), N'Savings', N'Yes')
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (4, N'Ram', N'Kishan', N'Hyderabad', N'TS', CAST(90222.00 AS Numeric(9, 2)), N'Savings', N'Yes')
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (5, N'Gayathri', N'Venkata', N'Chennai', N'TN', CAST(88222.00 AS Numeric(9, 2)), N'Savings', N'Yes')
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (6, N'Abhishek', N'Prabhakar', N'Delhi', N'UP', CAST(99234.00 AS Numeric(9, 2)), N'Savings', N'Yes')
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (7, N'Ajay', N'Kumar', N'Chennai', N'TN', CAST(90233.00 AS Numeric(9, 2)), N'Savings', N'Yes')
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES (8, N'Shri', N'Hari', N'Chennai', N'TN', CAST(90233.00 AS Numeric(9, 2)), N'Savings', N'Yes')
GO
SET IDENTITY_INSERT [dbo].[Trans] ON 

INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (1, 1, CAST(2000.00 AS Numeric(9, 2)), N'C', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (2, 1, CAST(2000.00 AS Numeric(9, 2)), N'C', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (3, 1, CAST(2500.00 AS Numeric(9, 2)), N'C', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (4, 1, CAST(2500.00 AS Numeric(9, 2)), N'D', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (5, 1, CAST(5000.00 AS Numeric(9, 2)), N'C', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (6, 1, CAST(10000.00 AS Numeric(9, 2)), N'D', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (7, 1, CAST(20000.00 AS Numeric(9, 2)), N'C', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (8, 1, CAST(800.00 AS Numeric(9, 2)), N'C', CAST(N'2025-08-02' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (9, 1, CAST(800.00 AS Numeric(9, 2)), N'D', CAST(N'2025-08-02' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (10, 7, CAST(10000.00 AS Numeric(9, 2)), N'C', CAST(N'2025-08-02' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (11, 7, CAST(8000.00 AS Numeric(9, 2)), N'D', CAST(N'2025-08-02' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (12, 8, CAST(9000.00 AS Numeric(9, 2)), N'C', CAST(N'2025-08-02' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (13, 8, CAST(7000.00 AS Numeric(9, 2)), N'D', CAST(N'2025-08-02' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (14, 8, CAST(8000.00 AS Numeric(9, 2)), N'C', CAST(N'2025-08-02' AS Date))
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES (15, 8, CAST(8000.00 AS Numeric(9, 2)), N'D', CAST(N'2025-08-02' AS Date))
SET IDENTITY_INSERT [dbo].[Trans] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Passcode]) VALUES (1, N'Gayathri', N'Krishna')
INSERT [dbo].[Users] ([Id], [Username], [Passcode]) VALUES (2, N'Isha', N'Ghosh')
INSERT [dbo].[Users] ([Id], [Username], [Passcode]) VALUES (3, N'Laksha', N'Katara')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E4E1398159]    Script Date: 02-08-2025 10:11:24 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Trans] ADD  DEFAULT (getdate()) FOR [TranDate]
GO
USE [master]
GO
ALTER DATABASE [bank] SET  READ_WRITE 
GO