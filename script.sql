USE [Agenstvo]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 16.06.2022 15:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoomsCount] [int] NULL,
	[Adres] [nvarchar](100) NULL,
	[Cost] [int] NULL,
	[City] [nvarchar](50) NULL,
	[LivingSpace] [int] NULL,
	[Floor] [int] NULL,
	[ApartmentsPhoto] [nvarchar](100) NULL,
	[OwnerId] [int] NULL,
 CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 16.06.2022 15:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchasers]    Script Date: 16.06.2022 15:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchasers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nchar](10) NULL,
	[Phone] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Purchasers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Apartments] ON 

INSERT [dbo].[Apartments] ([id], [RoomsCount], [Adres], [Cost], [City], [LivingSpace], [Floor], [ApartmentsPhoto], [OwnerId]) VALUES (5, 24, N'3gfd', 33, N'321423', 443, 33, N'C:\Users\Danila\Documents\клыки2.jpg', 1)
INSERT [dbo].[Apartments] ([id], [RoomsCount], [Adres], [Cost], [City], [LivingSpace], [Floor], [ApartmentsPhoto], [OwnerId]) VALUES (8, 2, N'2', 2, N'ывфыва', 2, 2, N'C:\Users\Danila\source\repos\SachkoKursovaya\SachkoKursovaya\Apartments\photo.jpg', 2)
SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO
SET IDENTITY_INSERT [dbo].[Owners] ON 

INSERT [dbo].[Owners] ([id], [Name], [Login], [Password], [Phone], [Gender]) VALUES (1, N'Иванов Иван Иванович', N'1', N'1', N'89192231224', N'Мужской')
INSERT [dbo].[Owners] ([id], [Name], [Login], [Password], [Phone], [Gender]) VALUES (2, N'Петров Пётр Петрович', N'2', N'2', N'89502391952', N'Мужской')
SET IDENTITY_INSERT [dbo].[Owners] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchasers] ON 

INSERT [dbo].[Purchasers] ([id], [Name], [Gender], [Phone], [Login], [Password]) VALUES (1, N'Жмышенко Валерий Альбертович', N'Женский   ', N'+71234567890', N'3', N'3')
INSERT [dbo].[Purchasers] ([id], [Name], [Gender], [Phone], [Login], [Password]) VALUES (2, N'Рогозина Екатерина Викторовна', N'Женский   ', N'+71293342941', N'login', N'password')
SET IDENTITY_INSERT [dbo].[Purchasers] OFF
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Owners] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owners] ([id])
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Owners]
GO
