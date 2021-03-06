USE [PersonnelDb]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 5/24/2021 2:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Personnel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Personnel] ON 

INSERT [dbo].[Personnel] ([Id], [Name], [Age], [Phone]) VALUES (8, N'Shahrzad', 28, N'00989191677925')
INSERT [dbo].[Personnel] ([Id], [Name], [Age], [Phone]) VALUES (11, N'Mark', 30, N'00989124565841')
INSERT [dbo].[Personnel] ([Id], [Name], [Age], [Phone]) VALUES (1011, N'Sara', 35, N'00989354569225')
INSERT [dbo].[Personnel] ([Id], [Name], [Age], [Phone]) VALUES (1012, N'Tony', 45, N'00989124569251')
SET IDENTITY_INSERT [dbo].[Personnel] OFF
