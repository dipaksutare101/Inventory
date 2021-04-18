/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4259)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2008 R2
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
/****** Object:  Table [dbo].[Saledetail]    Script Date: 16/04/2021 11:11:00 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Saledetail]') AND type in (N'U'))
DROP TABLE [dbo].[Saledetail]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 16/04/2021 11:11:00 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sale]') AND type in (N'U'))
DROP TABLE [dbo].[Sale]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 16/04/2021 11:11:00 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registration]') AND type in (N'U'))
DROP TABLE [dbo].[Registration]
GO
/****** Object:  Table [dbo].[city]    Script Date: 16/04/2021 11:11:00 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[city]') AND type in (N'U'))
DROP TABLE [dbo].[city]
GO
/****** Object:  Table [dbo].[city]    Script Date: 16/04/2021 11:11:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[city]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[city](
	[cityid] [int] IDENTITY(1,1) NOT NULL,
	[cityname] [nvarchar](50) NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[cityid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 16/04/2021 11:11:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registration]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Registration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[cityid] [int] NULL,
	[isstudent] [bit] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 16/04/2021 11:11:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sale]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sale](
	[Saleid] [int] IDENTITY(1,1) NOT NULL,
	[Customerid] [int] NULL,
	[Saledate] [datetime] NULL,
	[SaleNo] [int] NULL,
	[Remark] [nvarchar](500) NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[Saleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Saledetail]    Script Date: 16/04/2021 11:11:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Saledetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Saledetail](
	[Saledetailid] [int] NOT NULL,
	[Saleid] [int] NULL,
	[ItemName] [nvarchar](50) NULL,
	[Qty] [int] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [nchar](10) NULL,
 CONSTRAINT [PK_Saledetail] PRIMARY KEY CLUSTERED 
(
	[Saledetailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[city] ON 

INSERT [dbo].[city] ([cityid], [cityname]) VALUES (1, N'Surat')
INSERT [dbo].[city] ([cityid], [cityname]) VALUES (2, N'Ahmdabad')
INSERT [dbo].[city] ([cityid], [cityname]) VALUES (3, N'Bhuj')
INSERT [dbo].[city] ([cityid], [cityname]) VALUES (4, N'Mumbai')
SET IDENTITY_INSERT [dbo].[city] OFF
SET IDENTITY_INSERT [dbo].[Sale] ON 

INSERT [dbo].[Sale] ([Saleid], [Customerid], [Saledate], [SaleNo], [Remark], [Amount]) VALUES (1, 1, CAST(N'2021-02-08T00:00:00.000' AS DateTime), 11, N'TEST', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Sale] ([Saleid], [Customerid], [Saledate], [SaleNo], [Remark], [Amount]) VALUES (2, 1, CAST(N'2021-02-08T00:00:00.000' AS DateTime), 11, N'TEST', CAST(50.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Sale] OFF
