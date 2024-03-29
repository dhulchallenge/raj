/****** Object:  Table [dbo].[CarManufacturerDetails]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarManufacturerDetails](
	[CarManufacturerId] [uniqueidentifier] NOT NULL,
	[ManufacturerName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CarManufacturerDetails] PRIMARY KEY CLUSTERED 
(
	[CarManufacturerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[CarModels]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarModels](
	[CarModelId] [uniqueidentifier] NOT NULL,
	[CarManufacturerId] [uniqueidentifier] NULL,
	[ModelName] [varchar](100) NULL,
	[RentalTariff] [int] NULL,
	[AvailabilityStartDate] [datetime] NULL,
	[AvailabilityEndDate] [datetime] NULL,
	[Status] [bit] NULL,
	[CarCount] [int] NULL,
 CONSTRAINT [PK_CarModels] PRIMARY KEY CLUSTERED 
(
	[CarModelId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[CarRentalAvailablityCountView]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRentalAvailablityCountView](
	[AvailablityId] [int] IDENTITY(1,1) NOT NULL,
	[CarModelId] [uniqueidentifier] NOT NULL,
	[CarModelName] [varchar](100) NULL,
	[CarCount] [int] NOT NULL,
 CONSTRAINT [PK_CarRentalAvailablityCountView_1] PRIMARY KEY CLUSTERED 
(
	[AvailablityId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[CarRentalAvailablityView]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRentalAvailablityView](
	[AvailablityId] [int] IDENTITY(1,1) NOT NULL,
	[RentalId] [uniqueidentifier] NOT NULL,
	[CarModelId] [uniqueidentifier] NULL,
	[CarModelName] [varchar](100) NULL,
	[CarRentalStartDate] [datetime] NULL,
	[CarRentalEndDate] [datetime] NULL,
	[LocationId] [uniqueidentifier] NULL,
	[LicenseneNumber] [varchar](50) NULL,
	[ContactNumber] [int] NULL,
	[EmailId] [varchar](50) NULL,
 CONSTRAINT [PK_CarRentalAvailablityView_1] PRIMARY KEY CLUSTERED 
(
	[AvailablityId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[CarRentalDetails]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRentalDetails](
	[RentalId] [uniqueidentifier] NOT NULL,
	[CarModelId] [uniqueidentifier] NOT NULL,
	[CarRentalStartDate] [datetime] NOT NULL,
	[CarRentalEndDate] [datetime] NOT NULL,
	[LocationId] [uniqueidentifier] NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[TotalCost] [int] NOT NULL,
	[DriverName] [varchar](50) NOT NULL,
	[LicenseneNumber] [varchar](50) NOT NULL,
	[ContactNumber] [int] NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[Address] [varchar](max) NULL,
 CONSTRAINT [PK_CarRentalDetails] PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[CarRentalDetailsHistory]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRentalDetailsHistory](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[RentalId] [uniqueidentifier] NOT NULL,
	[CarModelId] [uniqueidentifier] NOT NULL,
	[CarRentalStartDate] [datetime] NOT NULL,
	[CarRentalEndDate] [datetime] NOT NULL,
	[LocationId] [uniqueidentifier] NOT NULL,
	[Status] [varchar](100) NULL,
	[TotalCost] [int] NOT NULL,
	[DriverName] [varchar](50) NULL,
	[LicenseneNumber] [varchar](50) NULL,
	[ContactNumber] [int] NOT NULL,
	[EmailId] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CarRentalDetailsHistory_1] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[City]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [uniqueidentifier] NOT NULL,
	[CityName] [varchar](100) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[LeastExpenseCarModelView]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeastExpenseCarModelView](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RentalId] [uniqueidentifier] NOT NULL,
	[CarModelId] [uniqueidentifier] NULL,
	[CarModelName] [varchar](100) NULL,
	[Cost] [int] NOT NULL,
 CONSTRAINT [PK_LeastExpenseCarModelView_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Location]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [uniqueidentifier] NOT NULL,
	[CityId] [uniqueidentifier] NOT NULL,
	[LocationName] [varchar](100) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[PreferredCarModelView]    Script Date: 5/9/2014 7:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreferredCarModelView](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarModelId] [uniqueidentifier] NOT NULL,
	[CarModelName] [varchar](100) NULL,
	[RentedCount] [int] NOT NULL,
 CONSTRAINT [PK_PreferredCarModelView_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
INSERT [dbo].[CarManufacturerDetails] ([CarManufacturerId], [ManufacturerName]) VALUES (N'3a7914ed-8486-4d6f-849c-20006479067c', N'TATA')
INSERT [dbo].[CarManufacturerDetails] ([CarManufacturerId], [ManufacturerName]) VALUES (N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Honda')
INSERT [dbo].[CarModels] ([CarModelId], [CarManufacturerId], [ModelName], [RentalTariff], [AvailabilityStartDate], [AvailabilityEndDate], [Status], [CarCount]) VALUES (N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'3a7914ed-8486-4d6f-849c-20006479067c', N'Indica', 2, CAST(0x0000A32201410AB7 AS DateTime), CAST(0x0000A3BB01410AB7 AS DateTime), 1, 3)
INSERT [dbo].[CarModels] ([CarModelId], [CarManufacturerId], [ModelName], [RentalTariff], [AvailabilityStartDate], [AvailabilityEndDate], [Status], [CarCount]) VALUES (N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Jazz', 7, CAST(0x0000A2AA01410AB7 AS DateTime), CAST(0x0000A3F801410AB7 AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[CarRentalAvailablityCountView] ON 

INSERT [dbo].[CarRentalAvailablityCountView] ([AvailablityId], [CarModelId], [CarModelName], [CarCount]) VALUES (1, N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 3)
INSERT [dbo].[CarRentalAvailablityCountView] ([AvailablityId], [CarModelId], [CarModelName], [CarCount]) VALUES (3, N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Jazz', 2)
SET IDENTITY_INSERT [dbo].[CarRentalAvailablityCountView] OFF
SET IDENTITY_INSERT [dbo].[CarRentalAvailablityView] ON 

INSERT [dbo].[CarRentalAvailablityView] ([AvailablityId], [RentalId], [CarModelId], [CarModelName], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [LicenseneNumber], [ContactNumber], [EmailId]) VALUES (21, N'861b9faa-4dd9-4f9b-b72b-c9bf62967534', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Jazz', CAST(0x0000A32600F72103 AS DateTime), CAST(0x0000A32600F72103 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'testnumbernew', 1232413434, N'jkv@gmail.com')
SET IDENTITY_INSERT [dbo].[CarRentalAvailablityView] OFF
INSERT [dbo].[CarRentalDetails] ([RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address]) VALUES (N'475e25ef-8e38-40df-8143-24591005ee05', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', CAST(0x0000A32600AAA88D AS DateTime), CAST(0x0000A32B00ACE11A AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Canceled', 7, N'jkvrajbnew', N'testnumbernew', 1232413434, N'jkv@gmail.com', N'testnewadress')
INSERT [dbo].[CarRentalDetails] ([RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address]) VALUES (N'6b666e0f-2421-43c0-ba4d-5fcc5b33b51b', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A3260084B7B3 AS DateTime), CAST(0x0000A32B0088701F AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Canceled', 5, N'jkvraj', N'testnumber', 1232413434, N'jkvraj@gmail.com', N'testadress')
INSERT [dbo].[CarRentalDetails] ([RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address]) VALUES (N'b15e3ad7-2165-4770-9d2b-7b7d003dbf6e', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A32601369515 AS DateTime), CAST(0x0000A32E01369515 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Canceled', 5, N'vikki', N'JRQS208678', 12332443, N'vikki@hotmail.com', N'spinfocity,Chennai')
INSERT [dbo].[CarRentalDetails] ([RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address]) VALUES (N'861b9faa-4dd9-4f9b-b72b-c9bf62967534', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', CAST(0x0000A32600F72103 AS DateTime), CAST(0x0000A32600F72103 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Active', 7, N'jkvrajbnew', N'testnumbernew', 1232413434, N'jkv@gmail.com', N'testnewadress')
SET IDENTITY_INSERT [dbo].[CarRentalDetailsHistory] ON 

INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (5, N'6b666e0f-2421-43c0-ba4d-5fcc5b33b51b', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A3260084B7B3 AS DateTime), CAST(0x0000A3290084B7B3 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCreatedEvent', 5, N'jkvraj', N'testnumber', 1232413434, N'jkvraj@gmail.com', N'testadress', CAST(0x0000A3260084BDA5 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (6, N'6b666e0f-2421-43c0-ba4d-5fcc5b33b51b', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A3260084B7B3 AS DateTime), CAST(0x0000A32B0088701F AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingChangedEvent', 5, N'jkvraj', N'testnumber', 1232413434, N'jkvraj@gmail.com', N'testadress', CAST(0x0000A3260088AB25 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (7, N'6b666e0f-2421-43c0-ba4d-5fcc5b33b51b', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A3260084B7B3 AS DateTime), CAST(0x0000A32B0088701F AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCanceledEvent', 5, N'jkvraj', N'testnumber', 1232413434, N'jkvraj@gmail.com', N'testadress', CAST(0x0000A32600899E83 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (8, N'6b666e0f-2421-43c0-ba4d-5fcc5b33b51b', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A3260084B7B3 AS DateTime), CAST(0x0000A32B0088701F AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCanceledEvent', 5, N'jkvraj', N'testnumber', 1232413434, N'jkvraj@gmail.com', N'testadress', CAST(0x0000A326008CE6AB AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (9, N'6b666e0f-2421-43c0-ba4d-5fcc5b33b51b', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A3260084B7B3 AS DateTime), CAST(0x0000A32B0088701F AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCanceledEvent', 5, N'jkvraj', N'testnumber', 1232413434, N'jkvraj@gmail.com', N'testadress', CAST(0x0000A32600904821 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (10, N'475e25ef-8e38-40df-8143-24591005ee05', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', CAST(0x0000A32600AAA88D AS DateTime), CAST(0x0000A32900AAA88D AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCreatedEvent', 7, N'jkvrajbnew', N'testnumbernew', 1232413434, N'jkv@gmail.com', N'testnewadress', CAST(0x0000A32600AAB0CE AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (11, N'475e25ef-8e38-40df-8143-24591005ee05', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', CAST(0x0000A32600AAA88D AS DateTime), CAST(0x0000A32B00ACE11A AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingChangedEvent', 7, N'jkvrajbnew', N'testnumbernew', 1232413434, N'jkv@gmail.com', N'testnewadress', CAST(0x0000A32600ACE364 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (12, N'475e25ef-8e38-40df-8143-24591005ee05', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', CAST(0x0000A32600AAA88D AS DateTime), CAST(0x0000A32B00ACE11A AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCanceledEvent', 7, N'jkvrajbnew', N'testnumbernew', 1232413434, N'jkv@gmail.com', N'testnewadress', CAST(0x0000A32600AF14E6 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (13, N'861b9faa-4dd9-4f9b-b72b-c9bf62967534', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', CAST(0x0000A32600F72103 AS DateTime), CAST(0x0000A32600F72103 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCreatedEvent', 7, N'jkvrajbnew', N'testnumbernew', 1232413434, N'jkv@gmail.com', N'testnewadress', CAST(0x0000A32600F72462 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (14, N'b15e3ad7-2165-4770-9d2b-7b7d003dbf6e', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A32601369515 AS DateTime), CAST(0x0000A32901369515 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCreatedEvent', 5, N'vikki', N'JRQS208678', 12332443, N'vikki@hotmail.com', N'spinfocity,Chennai', CAST(0x0000A32601458806 AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (15, N'b15e3ad7-2165-4770-9d2b-7b7d003dbf6e', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A32601369515 AS DateTime), CAST(0x0000A32E01369515 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingChangedEvent', 5, N'vikki', N'JRQS208678', 12332443, N'vikki@hotmail.com', N'spinfocity,Chennai', CAST(0x0000A326014798DC AS DateTime))
INSERT [dbo].[CarRentalDetailsHistory] ([HistoryId], [RentalId], [CarModelId], [CarRentalStartDate], [CarRentalEndDate], [LocationId], [Status], [TotalCost], [DriverName], [LicenseneNumber], [ContactNumber], [EmailId], [Address], [CreatedDate]) VALUES (16, N'b15e3ad7-2165-4770-9d2b-7b7d003dbf6e', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', CAST(0x0000A32601369515 AS DateTime), CAST(0x0000A32E01369515 AS DateTime), N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'CarBookingCanceledEvent', 5, N'vikki', N'JRQS208678', 12332443, N'vikki@hotmail.com', N'spinfocity,Chennai', CAST(0x0000A3260147FE16 AS DateTime))
SET IDENTITY_INSERT [dbo].[CarRentalDetailsHistory] OFF
INSERT [dbo].[City] ([CityId], [CityName]) VALUES (N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Chennai')
SET IDENTITY_INSERT [dbo].[LeastExpenseCarModelView] ON 

INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (2, N'f99851dc-b2ca-4279-bcf6-f65443330c8f', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (3, N'af6411a8-a13f-4106-82d3-845d9cbfb99e', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (4, N'de43e1ed-2a02-4f4d-8f49-fd5b1833306e', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (5, N'517f453a-848d-420b-99cc-50f2b9e31c34', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (6, N'75d95e23-f7c0-46c1-963a-8ceb53e677a3', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (7, N'55809215-8433-45f5-8231-edf25cc8d68f', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (8, N'134148ba-5be9-47d9-806a-120b4f0e6475', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (9, N'7588f86a-5af2-433e-bf11-cadec254fd16', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (10, N'6b666e0f-2421-43c0-ba4d-5fcc5b33b51b', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (11, N'475e25ef-8e38-40df-8143-24591005ee05', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Jazz', 7)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (12, N'861b9faa-4dd9-4f9b-b72b-c9bf62967534', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Jazz', 7)
INSERT [dbo].[LeastExpenseCarModelView] ([Id], [RentalId], [CarModelId], [CarModelName], [Cost]) VALUES (13, N'b15e3ad7-2165-4770-9d2b-7b7d003dbf6e', N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 5)
SET IDENTITY_INSERT [dbo].[LeastExpenseCarModelView] OFF
INSERT [dbo].[Location] ([LocationId], [CityId], [LocationName]) VALUES (N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Airport')
SET IDENTITY_INSERT [dbo].[PreferredCarModelView] ON 

INSERT [dbo].[PreferredCarModelView] ([Id], [CarModelId], [CarModelName], [RentedCount]) VALUES (2, N'985bb43f-07bb-4d99-8d83-18c1dca715fb', N'Indica', 10)
INSERT [dbo].[PreferredCarModelView] ([Id], [CarModelId], [CarModelName], [RentedCount]) VALUES (3, N'782f5a69-02e5-4da4-a52e-ddf06a0c97b2', N'Jazz', 2)
SET IDENTITY_INSERT [dbo].[PreferredCarModelView] OFF
ALTER TABLE [dbo].[CarModels]  WITH CHECK ADD  CONSTRAINT [FK_CarModels_CarManufacturerDetails] FOREIGN KEY([CarManufacturerId])
REFERENCES [dbo].[CarManufacturerDetails] ([CarManufacturerId])
GO
ALTER TABLE [dbo].[CarModels] CHECK CONSTRAINT [FK_CarModels_CarManufacturerDetails]
GO
ALTER TABLE [dbo].[CarRentalDetails]  WITH CHECK ADD  CONSTRAINT [FK_CarRentalDetails_CarModels] FOREIGN KEY([CarModelId])
REFERENCES [dbo].[CarModels] ([CarModelId])
GO
ALTER TABLE [dbo].[CarRentalDetails] CHECK CONSTRAINT [FK_CarRentalDetails_CarModels]
GO
ALTER TABLE [dbo].[CarRentalDetails]  WITH CHECK ADD  CONSTRAINT [FK_CarRentalDetails_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[CarRentalDetails] CHECK CONSTRAINT [FK_CarRentalDetails_Location]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_City]
GO
