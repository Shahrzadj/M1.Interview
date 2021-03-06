USE [SalesDb]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 5/24/2021 2:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[ReportDate] [datetime2](7) NULL,
	[SalesAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (2, 8, CAST(N'2020-11-02T00:00:00.0000000' AS DateTime2), CAST(70.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (3, 11, CAST(N'2020-01-11T00:00:00.0000000' AS DateTime2), CAST(65.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (5, 1011, CAST(N'2020-03-29T00:00:00.0000000' AS DateTime2), CAST(40.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (6, 8, CAST(N'2020-02-29T00:00:00.0000000' AS DateTime2), CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (7, 8, CAST(N'2020-04-29T00:00:00.0000000' AS DateTime2), CAST(20.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (8, 8, CAST(N'2020-04-29T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (9, 1011, CAST(N'2020-05-29T00:00:00.0000000' AS DateTime2), CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (10, 8, CAST(N'2020-06-29T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (11, 8, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (12, 8, CAST(N'2020-09-02T00:00:00.0000000' AS DateTime2), CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (1014, 1012, CAST(N'2020-05-29T00:00:00.0000000' AS DateTime2), CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (1015, 11, CAST(N'2020-06-29T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (1016, 8, CAST(N'2020-12-02T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (1017, 8, CAST(N'2020-09-02T00:00:00.0000000' AS DateTime2), CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (1018, 11, CAST(N'2020-10-02T00:00:00.0000000' AS DateTime2), CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (1019, 11, CAST(N'2020-08-02T00:00:00.0000000' AS DateTime2), CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[Sales] ([Id], [PersonnelId], [ReportDate], [SalesAmount]) VALUES (1020, 1012, CAST(N'2020-07-02T00:00:00.0000000' AS DateTime2), CAST(15.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Sales] OFF
