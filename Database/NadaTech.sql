
USE [NadaTech]
GO
/****** Object:  Table [dbo].[AssetCategoryMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetCategoryMaster](
	[AssetCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[AssetTypeId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetCategoryMaster] PRIMARY KEY CLUSTERED 
(
	[AssetCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetImages]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetImages](
	[AssetImgId] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetId] [bigint] NULL,
	[AssetImage] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetImages] PRIMARY KEY CLUSTERED 
(
	[AssetImgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetMaster](
	[AssetId] [bigint] IDENTITY(1,1) NOT NULL,
	[PartId] [bigint] NOT NULL,
	[AssetName] [nvarchar](250) NULL,
	[SerialNumber] [nvarchar](250) NULL,
	[ExpiryDate] [datetime] NULL,
	[Notes] [nvarchar](max) NULL,
	[AssetImage] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[IsMoveable] [bit] NOT NULL,
 CONSTRAINT [PK_AssetMaster] PRIMARY KEY CLUSTERED 
(
	[AssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetTagDetail]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTagDetail](
	[AssetTagId] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetId] [bigint] NOT NULL,
	[TagData] [nvarchar](350) NULL,
	[LocationId] [int] NULL,
	[LastLocationId] [int] NULL,
	[AssetStatus] [nvarchar](20) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetTagDetail] PRIMARY KEY CLUSTERED 
(
	[AssetTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetTypeMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTypeMaster](
	[AssetTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetType] PRIMARY KEY CLUSTERED 
(
	[AssetTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AUTToken]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTToken](
	[AUTTokenId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Token] [nvarchar](max) NULL,
 CONSTRAINT [PK_AUTToken] PRIMARY KEY CLUSTERED 
(
	[AUTTokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigMaster](
	[ConfigId] [int] IDENTITY(1,1) NOT NULL,
	[ConfigKey] [nvarchar](150) NOT NULL,
	[ConfigValues] [nvarchar](max) NOT NULL,
	[IsShow] [bit] NULL,
 CONSTRAINT [PK_ConfigMaster] PRIMARY KEY CLUSTERED 
(
	[ConfigId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceConfiguration]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceConfiguration](
	[DeviceConId] [int] IDENTITY(1,1) NOT NULL,
	[DeviceCode] [nvarchar](max) NOT NULL,
	[DeviceName] [nvarchar](200) NULL,
	[DeviceType] [nvarchar](200) NULL,
	[DeviceIP] [nvarchar](200) NULL,
	[DevicePort] [nvarchar](100) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DeviceConfiguration] PRIMARY KEY CLUSTERED 
(
	[DeviceConId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceDetail]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceDetail](
	[DeviceId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Puch_Token] [nvarchar](max) NULL,
	[DeviceType] [nvarchar](50) NULL,
	[DeviceInfo] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[LastLogin] [datetime] NULL,
 CONSTRAINT [PK_DeviceDetail] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormMaster](
	[FormId] [int] IDENTITY(1,1) NOT NULL,
	[Module] [nvarchar](250) NULL,
	[FormName] [nvarchar](250) NOT NULL,
	[MenuName] [nvarchar](250) NOT NULL,
	[SortBy] [int] NULL,
 CONSTRAINT [PK_FormName] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationMaster](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LocationMaster] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManufacturerMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManufacturerMaster](
	[ManufacturerId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ManufacturerMaster] PRIMARY KEY CLUSTERED 
(
	[ManufacturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartMaster](
	[PartId] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetTypeId] [int] NOT NULL,
	[AssetCategoryId] [int] NOT NULL,
	[ManufacturerId] [int] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsExpire] [bit] NOT NULL,
	[IsSerial] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PartMaster] PRIMARY KEY CLUSTERED 
(
	[PartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionDetail]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionDetail](
	[TraDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionId] [bigint] NULL,
	[AssetTagId] [bigint] NULL,
	[LocationId] [int] NULL,
	[LastLocationId] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TransactionDetail] PRIMARY KEY CLUSTERED 
(
	[TraDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHeader]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHeader](
	[TransactionId] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionType] [int] NULL,
	[TransactionDate] [datetime] NULL,
	[Notes] [nvarchar](max) NULL,
	[ScanType] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[Status] [nvarchar](10) NULL,
	[Person] [nvarchar](150) NULL,
 CONSTRAINT [PK_TransactionHeader] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroupMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupMaster](
	[UserGroupId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserGroupMaster] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupId] [int] NULL,
	[Name] [nvarchar](250) NULL,
	[UserName] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[UserType] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[DeviceID] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[UPId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserGroupId] [int] NOT NULL,
	[FormId] [int] NOT NULL,
 CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED 
(
	[UPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AssetCategoryMaster] ON 
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, N'AC 01', NULL, 0, 1, CAST(N'2022-04-20T18:47:42.813' AS DateTime), 1, CAST(N'2022-04-20T18:47:42.813' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 4, N'AAV 12', NULL, 0, 1, CAST(N'2022-04-20T18:47:51.283' AS DateTime), 1, CAST(N'2022-05-11T14:13:08.493' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 7, N'AC 0050', NULL, 0, 1, CAST(N'2022-04-25T19:18:29.863' AS DateTime), 1, CAST(N'2022-04-25T19:18:41.597' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1003, 4, N'ABC 123', NULL, 0, 1, CAST(N'2022-05-11T14:04:50.627' AS DateTime), 1, CAST(N'2022-05-11T14:04:50.627' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1004, 4, N'1542121', NULL, 0, 1, CAST(N'2022-05-11T14:06:58.303' AS DateTime), 1, CAST(N'2022-05-11T14:06:58.303' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1005, 1008, N'12312', NULL, 0, 1, CAST(N'2022-05-11T14:20:09.457' AS DateTime), 1, CAST(N'2022-05-11T14:20:09.457' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1006, 1009, N'8888', NULL, 1, 1, CAST(N'2022-05-11T15:42:25.720' AS DateTime), 1, CAST(N'2022-05-11T16:44:34.413' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1007, 1010, N'AC 879', NULL, 0, 1, CAST(N'2022-05-11T15:53:02.157' AS DateTime), 1, CAST(N'2022-05-11T15:53:02.157' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2003, 1010, N'Monitor', NULL, 0, 1, CAST(N'2022-05-12T11:27:39.460' AS DateTime), 1, CAST(N'2022-05-12T11:27:39.460' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2004, 1010, N'SMPS', NULL, 1, 1, CAST(N'2022-05-12T11:27:53.010' AS DateTime), 1, CAST(N'2022-05-12T11:28:03.700' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2005, 1010, N'CPU', NULL, 0, 1, CAST(N'2022-05-12T11:28:13.660' AS DateTime), 1, CAST(N'2022-05-12T11:28:13.660' AS DateTime))
GO
INSERT [dbo].[AssetCategoryMaster] ([AssetCategoryId], [AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2006, 1010, N'Test Asset Category 01', NULL, 1, 1, CAST(N'2022-10-04T14:56:26.063' AS DateTime), 1, CAST(N'2022-10-04T15:02:47.320' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AssetCategoryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetImages] ON 
GO
INSERT [dbo].[AssetImages] ([AssetImgId], [AssetId], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10023, 10025, N'IMGASSET1180520221540041650.jpg', 0, 1, CAST(N'2022-05-18T15:40:04.270' AS DateTime), 1, CAST(N'2022-05-18T15:40:04.270' AS DateTime))
GO
INSERT [dbo].[AssetImages] ([AssetImgId], [AssetId], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10024, 10025, N'IMGASSET1180520221809408180.jpg', 1, 1, CAST(N'2022-05-18T18:09:40.940' AS DateTime), 1, CAST(N'2022-05-18T19:14:57.720' AS DateTime))
GO
INSERT [dbo].[AssetImages] ([AssetImgId], [AssetId], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10025, 10029, N'IMGASSET121240520221026121687.png', 0, 1, CAST(N'2022-05-24T10:26:12.170' AS DateTime), 1, CAST(N'2022-05-24T10:26:12.170' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AssetImages] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetMaster] ON 
GO
INSERT [dbo].[AssetMaster] ([AssetId], [PartId], [AssetName], [SerialNumber], [ExpiryDate], [Notes], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsMoveable]) VALUES (10025, 20004, N'Asset 7789', N'', NULL, N'', NULL, 0, 1, CAST(N'2022-05-18T15:40:03.337' AS DateTime), 1, CAST(N'2022-05-23T13:30:05.660' AS DateTime), 0)
GO
INSERT [dbo].[AssetMaster] ([AssetId], [PartId], [AssetName], [SerialNumber], [ExpiryDate], [Notes], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsMoveable]) VALUES (10026, 20005, N'Asset 001', N'', NULL, N'', NULL, 0, 1, CAST(N'2022-05-18T15:39:48.567' AS DateTime), 1, CAST(N'2022-05-18T15:39:48.570' AS DateTime), 1)
GO
INSERT [dbo].[AssetMaster] ([AssetId], [PartId], [AssetName], [SerialNumber], [ExpiryDate], [Notes], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsMoveable]) VALUES (10027, 20004, N'Assert 5844', N'as', NULL, N'', NULL, 0, 1, CAST(N'2022-05-18T16:23:48.153' AS DateTime), 1, CAST(N'2022-05-18T16:23:48.163' AS DateTime), 1)
GO
INSERT [dbo].[AssetMaster] ([AssetId], [PartId], [AssetName], [SerialNumber], [ExpiryDate], [Notes], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsMoveable]) VALUES (10028, 20004, N'Asset 0584545', N'', NULL, N'', NULL, 0, 1, CAST(N'2022-05-19T12:20:12.620' AS DateTime), 1, CAST(N'2022-05-23T13:29:52.757' AS DateTime), 1)
GO
INSERT [dbo].[AssetMaster] ([AssetId], [PartId], [AssetName], [SerialNumber], [ExpiryDate], [Notes], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsMoveable]) VALUES (10029, 2, N'ABC 8978', N'7877878787', CAST(N'2022-05-20T00:00:00.000' AS DateTime), N'asdasd 12145454as asdasdasd', NULL, 0, 1, CAST(N'2022-05-24T10:26:02.733' AS DateTime), 1, CAST(N'2022-05-24T10:26:02.733' AS DateTime), 1)
GO
INSERT [dbo].[AssetMaster] ([AssetId], [PartId], [AssetName], [SerialNumber], [ExpiryDate], [Notes], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsMoveable]) VALUES (10030, 20004, N'ASSET 121', N'21', NULL, N'', NULL, 0, 1, CAST(N'2022-08-08T10:43:11.440' AS DateTime), 1, CAST(N'2022-08-08T10:43:11.467' AS DateTime), 1)
GO
INSERT [dbo].[AssetMaster] ([AssetId], [PartId], [AssetName], [SerialNumber], [ExpiryDate], [Notes], [AssetImage], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsMoveable]) VALUES (10031, 20005, N'Asset 41212', N'', CAST(N'2022-11-21T18:11:57.960' AS DateTime), N'', NULL, 0, 1, CAST(N'2022-08-08T11:06:07.193' AS DateTime), 1, CAST(N'2022-11-21T18:12:00.407' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[AssetMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetTagDetail] ON 
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10038, 10025, N'E28068940000500B9C91F454', 1, 1002, N'1', 0, 1, CAST(N'2022-05-18T15:40:03.343' AS DateTime), 1, CAST(N'2022-08-31T16:32:16.777' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10039, 10027, N'E28068940000500B9C93A4D7', 1, NULL, N'1', 1, 1, CAST(N'2022-05-18T16:23:48.713' AS DateTime), 1, CAST(N'2022-05-18T16:30:45.230' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10040, 10028, N'E280689400004017EF259117', 1007, 1, N'1', 0, 1, CAST(N'2022-05-19T12:20:12.697' AS DateTime), 1, CAST(N'2022-09-30T14:57:58.077' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10041, 10028, N'E28068940000400B9C956862', NULL, 1, N'2', 0, 1, CAST(N'2022-05-19T12:20:12.700' AS DateTime), 1, CAST(N'2022-09-30T13:02:41.017' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10042, 10028, N'E280689400005017EF2250F4', 1007, 1, N'1', 0, 1, CAST(N'2022-05-19T12:20:12.700' AS DateTime), 1, CAST(N'2022-10-12T17:45:15.037' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10043, 10028, N'E28068940000500B9C93A4D7', 1007, NULL, N'1', 0, 1, CAST(N'2022-05-19T12:20:12.700' AS DateTime), 1, CAST(N'2022-10-12T17:45:15.037' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10044, 10029, N'1874545786546156231', NULL, NULL, N'2', 0, 1, CAST(N'2022-05-24T10:26:02.737' AS DateTime), 1, CAST(N'2022-06-03T13:14:42.930' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10045, 10030, N'E28068942000400B9C956862', 1, 1, N'1', 0, 1, CAST(N'2022-08-08T10:43:11.537' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10046, 10030, N'E280689420005017EF2250F4', 1, 1, N'1', 0, 1, CAST(N'2022-08-08T10:43:11.540' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10047, 10030, N'E28068942000500B9C91F454', 1, 1, N'1', 0, 1, CAST(N'2022-08-08T10:43:11.540' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10048, 10030, N'E28068942000500B9C93A4D7', 1, 1, N'1', 0, 1, CAST(N'2022-08-08T10:43:11.547' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10049, 10031, N'4E414441523648574448444C', NULL, 1, N'2', 0, 1, CAST(N'2022-08-08T11:06:07.267' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10050, 10031, N'4E41444141325A5441434749', 1, 1, N'1', 0, 1, CAST(N'2022-08-08T11:06:07.267' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10051, 10031, N'4E41444158564A41494B4857', NULL, 1, N'2', 0, 1, CAST(N'2022-08-08T11:06:07.270' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.150' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10052, 10031, N'4E414441474255334B4F5858', NULL, 1, N'2', 0, 1, CAST(N'2022-08-08T11:06:07.270' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10053, 10031, N'4E41444143574F424F583052', 1007, 1, N'1', 0, 1, CAST(N'2022-08-08T11:06:07.270' AS DateTime), 1, CAST(N'2022-10-12T17:48:43.073' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10054, 10031, N'4E4144414256514855594454', 1007, 1, N'1', 0, 1, CAST(N'2022-08-08T11:06:07.273' AS DateTime), 1, CAST(N'2022-10-12T17:48:43.073' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10055, 10031, N'4E4144415057384D5942464E', NULL, 1, N'2', 0, 1, CAST(N'2022-08-08T11:06:07.273' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10056, 10031, N'4E414441424D4B58344B475A', NULL, 1, N'2', 0, 1, CAST(N'2022-08-08T11:06:07.277' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime))
GO
INSERT [dbo].[AssetTagDetail] ([AssetTagId], [AssetId], [TagData], [LocationId], [LastLocationId], [AssetStatus], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10057, 10031, N'4E4144414A55374F55455043', NULL, NULL, N'2', 0, 1, CAST(N'2022-08-08T11:06:07.277' AS DateTime), 1, CAST(N'2023-01-05T12:30:36.823' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AssetTagDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetTypeMaster] ON 
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Air Conditioner Parts', NULL, 0, 1, CAST(N'2022-04-20T15:58:20.087' AS DateTime), 1, CAST(N'2022-05-12T11:25:12.717' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'ABc', NULL, 1, 1, CAST(N'2022-04-20T15:59:49.847' AS DateTime), 1, CAST(N'2022-04-20T16:56:02.187' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'ABBB', NULL, 1, 1, CAST(N'2022-04-20T16:55:55.713' AS DateTime), 1, CAST(N'2022-04-20T16:55:59.197' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Washing Machine Parts', NULL, 0, 1, CAST(N'2022-04-20T17:03:33.937' AS DateTime), 1, CAST(N'2022-05-12T11:24:51.627' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Asset 1', NULL, 1, 1, CAST(N'2022-04-20T17:09:06.053' AS DateTime), 1, CAST(N'2022-04-29T14:21:16.083' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'RRR', NULL, 1, 1, CAST(N'2022-04-20T18:49:49.593' AS DateTime), 1, CAST(N'2022-04-25T19:18:06.460' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'TV Parts', NULL, 0, 1, CAST(N'2022-04-25T19:17:49.827' AS DateTime), 1, CAST(N'2022-05-12T11:24:26.387' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (8, N'Test', NULL, 1, 1, CAST(N'2022-04-29T14:20:15.790' AS DateTime), 0, CAST(N'2022-05-05T17:50:26.240' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1007, N'12542', NULL, 1, 0, CAST(N'2022-05-05T18:02:46.443' AS DateTime), 0, CAST(N'2022-05-06T20:05:47.733' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1008, N'Mobile parts', NULL, 0, 0, CAST(N'2022-05-05T18:03:47.657' AS DateTime), 1, CAST(N'2022-05-12T11:24:09.597' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1009, N'VBHGG', NULL, 1, 0, CAST(N'2022-05-06T10:26:46.403' AS DateTime), 1, CAST(N'2022-05-11T16:44:39.220' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1010, N'Computer Parts', NULL, 0, 0, CAST(N'2022-05-09T11:55:41.790' AS DateTime), 1, CAST(N'2022-05-12T11:23:55.567' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1011, N'Music Player Parts', NULL, 0, 1, CAST(N'2022-05-12T11:25:42.980' AS DateTime), 1, CAST(N'2022-05-12T11:25:42.997' AS DateTime))
GO
INSERT [dbo].[AssetTypeMaster] ([AssetTypeId], [Name], [Description], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1012, N'Test Asset 01', NULL, 1, 1, CAST(N'2022-10-04T14:52:44.230' AS DateTime), 1, CAST(N'2022-10-04T14:54:19.013' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AssetTypeMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[AUTToken] ON 
GO
INSERT [dbo].[AUTToken] ([AUTTokenId], [UserId], [Token]) VALUES (1, 2, N'800f2309f7b04b66b8202acbcc1d77eb')
GO
INSERT [dbo].[AUTToken] ([AUTTokenId], [UserId], [Token]) VALUES (2, 5, N'7621fecc019b475c9e3b0eaaca4dc2a9')
GO
INSERT [dbo].[AUTToken] ([AUTTokenId], [UserId], [Token]) VALUES (3, 1, N'7913024098254cd6a9d12dc37815f48c')
GO
SET IDENTITY_INSERT [dbo].[AUTToken] OFF
GO
SET IDENTITY_INSERT [dbo].[ConfigMaster] ON 
GO
INSERT [dbo].[ConfigMaster] ([ConfigId], [ConfigKey], [ConfigValues], [IsShow]) VALUES (2, N'AssertimgUploadurl', N'http://localhost:55934', 0)
GO
INSERT [dbo].[ConfigMaster] ([ConfigId], [ConfigKey], [ConfigValues], [IsShow]) VALUES (3, N'TAGPREFIX', N'NADA', 1)
GO
INSERT [dbo].[ConfigMaster] ([ConfigId], [ConfigKey], [ConfigValues], [IsShow]) VALUES (4, N'SYSIOTFIXEDREIP', N'192.168.1.30', 1)
GO
INSERT [dbo].[ConfigMaster] ([ConfigId], [ConfigKey], [ConfigValues], [IsShow]) VALUES (5, N'SYSIOTFIXEDREPORT', N'200', 1)
GO
INSERT [dbo].[ConfigMaster] ([ConfigId], [ConfigKey], [ConfigValues], [IsShow]) VALUES (6, N'CIRFIDFIXEDREIP', N'192.168.1.30', 1)
GO
INSERT [dbo].[ConfigMaster] ([ConfigId], [ConfigKey], [ConfigValues], [IsShow]) VALUES (7, N'CIRFIDFIXEDREPORT', N'20058', 1)
GO
INSERT [dbo].[ConfigMaster] ([ConfigId], [ConfigKey], [ConfigValues], [IsShow]) VALUES (1003, N'ReaderAntennaPower', N'18', 1)
GO
SET IDENTITY_INSERT [dbo].[ConfigMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[DeviceDetail] ON 
GO
INSERT [dbo].[DeviceDetail] ([DeviceId], [UserId], [Puch_Token], [DeviceType], [DeviceInfo], [CreateDate], [LastLogin]) VALUES (1, 2, N'as5d5a4sd54as5d4as5d4', N'Android', N'asdasdsa dsfsd', CAST(N'2022-04-26T18:54:56.330' AS DateTime), CAST(N'2022-04-26T18:54:56.333' AS DateTime))
GO
INSERT [dbo].[DeviceDetail] ([DeviceId], [UserId], [Puch_Token], [DeviceType], [DeviceInfo], [CreateDate], [LastLogin]) VALUES (2, 5, N'as5d5a4sd54as5d4as5d4', N'Android', N'', CAST(N'2022-05-12T18:22:00.447' AS DateTime), CAST(N'2022-05-12T18:22:00.453' AS DateTime))
GO
INSERT [dbo].[DeviceDetail] ([DeviceId], [UserId], [Puch_Token], [DeviceType], [DeviceInfo], [CreateDate], [LastLogin]) VALUES (3, 1, N'as5d5a4sd54as5d4as5d4', N'Android', N'', CAST(N'2022-05-23T19:21:37.857' AS DateTime), CAST(N'2022-11-22T12:00:16.587' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[DeviceDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[FormMaster] ON 
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (2, N'HOME', N'Dashbord', N'Dashbord', 1)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (3, N'MANAGE ASSET', N'Create Asset', N'Create Asset', 2)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (4, N'MANAGE ASSET', N'Manage Asset', N'Manage Asset', 3)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (5, N'ADMIN', N'Part Master', N'Part Master', 4)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (6, N'ADMIN', N'Location', N'Location', 5)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (7, N'ADMIN', N'Employee', N'Employee', 6)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (8, N'ADMIN', N'Employee Role', N'Employee Role', 7)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (9, N'TRANSACTION', N'Check In', N'Check In', 8)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (10, N'REPORTS', N'Asset', N'Asset', 10)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (11, N'REPORTS', N'Transaction', N'Transaction', 11)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (12, N'TRANSACTION', N'Check Out', N'Check Out', 9)
GO
INSERT [dbo].[FormMaster] ([FormId], [Module], [FormName], [MenuName], [SortBy]) VALUES (13, N'ADMIN', N'Configuration', N'Configuration', 8)
GO
SET IDENTITY_INSERT [dbo].[FormMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[LocationMaster] ON 
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'000462261101', N'Location 01', 0, 1, CAST(N'2022-04-21T12:02:40.530' AS DateTime), 1, CAST(N'2022-11-24T14:21:15.213' AS DateTime))
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'L002', N'ABC 2', 1, 1, CAST(N'2022-04-21T12:02:58.363' AS DateTime), 1, CAST(N'2022-04-21T12:03:04.760' AS DateTime))
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1002, N'000412241502', N'Location 02', 0, 1, CAST(N'2022-04-25T19:20:01.547' AS DateTime), 1, CAST(N'2022-11-24T14:26:17.400' AS DateTime))
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1003, N'L003', N'LOC 058', 1, 0, CAST(N'2022-05-06T18:43:59.573' AS DateTime), 1, CAST(N'2022-05-12T11:32:34.307' AS DateTime))
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1004, N'PRODUCTION', N'PRODUCTION', 1, 1, CAST(N'2022-05-12T11:31:02.310' AS DateTime), 5, CAST(N'2022-05-12T12:20:20.640' AS DateTime))
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1005, N'221', N'Location 221', 1, 1, CAST(N'2022-08-25T12:48:19.570' AS DateTime), 1, CAST(N'2022-08-25T12:50:33.917' AS DateTime))
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1006, N'221', N'Location 221', 1, 1, CAST(N'2022-08-25T12:50:50.563' AS DateTime), 1, CAST(N'2022-08-25T13:00:06.057' AS DateTime))
GO
INSERT [dbo].[LocationMaster] ([LocationId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1007, N'555', N'Location 555', 0, 1, CAST(N'2022-08-25T13:00:26.347' AS DateTime), 1, CAST(N'2022-08-25T13:00:26.350' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[LocationMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ManufacturerMaster] ON 
GO
INSERT [dbo].[ManufacturerMaster] ([ManufacturerId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'M01', N'ABC', 0, 1, CAST(N'2022-04-20T19:14:00.317' AS DateTime), 1, CAST(N'2022-04-20T19:14:00.317' AS DateTime))
GO
INSERT [dbo].[ManufacturerMaster] ([ManufacturerId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'M02', N'ABC 21', 0, 1, CAST(N'2022-04-20T19:14:14.537' AS DateTime), 1, CAST(N'2022-04-20T19:14:26.490' AS DateTime))
GO
INSERT [dbo].[ManufacturerMaster] ([ManufacturerId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'M03', N'MAN0051', 1, 1, CAST(N'2022-04-25T19:19:29.893' AS DateTime), 1, CAST(N'2022-04-25T19:19:38.390' AS DateTime))
GO
INSERT [dbo].[ManufacturerMaster] ([ManufacturerId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1003, N'M003', N'003', 0, 1, CAST(N'2022-05-11T14:38:26.230' AS DateTime), 1, CAST(N'2022-05-11T14:43:37.183' AS DateTime))
GO
INSERT [dbo].[ManufacturerMaster] ([ManufacturerId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1004, N'M004', N'004', 0, 1, CAST(N'2022-05-11T15:42:49.707' AS DateTime), 1, CAST(N'2022-05-11T15:42:49.707' AS DateTime))
GO
INSERT [dbo].[ManufacturerMaster] ([ManufacturerId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2003, N'SATA', N'SATA', 0, 1, CAST(N'2022-05-12T11:30:20.830' AS DateTime), 1, CAST(N'2022-05-12T11:30:20.830' AS DateTime))
GO
INSERT [dbo].[ManufacturerMaster] ([ManufacturerId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2004, N'Manuf 011', N'Test Manuf 011', 1, 1, CAST(N'2022-10-04T15:04:16.413' AS DateTime), 1, CAST(N'2022-10-04T15:05:12.617' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ManufacturerMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PartMaster] ON 
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, 1, 2, N'P001', N'ABC', N'B', 1, 0, 1, 1, CAST(N'2022-04-21T15:47:50.873' AS DateTime), 1, CAST(N'2022-04-21T16:08:35.083' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 4, 2, 1, N'AB', N'asd', N'', 1, 1, 1, 1, CAST(N'2022-04-21T16:10:28.100' AS DateTime), 5, CAST(N'2022-05-12T12:20:10.720' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 4, 2, 2, N'asjdq', N'jkh', N'j', 0, 1, 1, 1, CAST(N'2022-04-21T16:13:35.493' AS DateTime), 5, CAST(N'2022-05-12T12:20:13.427' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 4, 2, 2, N'kjkasd', N'sdf', N'', 1, 0, 1, 1, CAST(N'2022-04-21T16:13:48.630' AS DateTime), 1, CAST(N'2022-04-21T16:13:54.737' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10002, 4, 1003, 1, N'Part 0021', N'Part 0021', N'542as5d54as5d45as4d', 1, 1, 1, 1, CAST(N'2022-04-25T19:20:33.783' AS DateTime), 5, CAST(N'2022-05-12T12:20:07.810' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10003, 4, 1003, 1003, N'78789', N'78789', N'asdas', 0, 1, 1, 1, CAST(N'2022-05-11T15:14:42.853' AS DateTime), 1, CAST(N'2022-05-11T15:21:20.047' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10004, 1009, 1006, 1004, N'PN 00895', N'PN 00895', N'asd', 1, 1, 1, 1, CAST(N'2022-05-11T15:42:57.083' AS DateTime), 1, CAST(N'2022-05-11T16:44:04.093' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20003, 1010, 2005, 2003, N'RAM', N'RAM', N'Read Only Memory Chips', 0, 1, 1, 1, CAST(N'2022-05-12T11:30:29.277' AS DateTime), 5, CAST(N'2022-05-12T12:20:15.857' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20004, 1010, 2003, 2, N'P001', N'P001', N'asdasdasd', 0, 0, 0, 1, CAST(N'2022-05-12T16:00:33.623' AS DateTime), 1, CAST(N'2022-05-12T16:36:19.893' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20005, 1, 1, 2, N'Part 021', N'Part 021', N'', 1, 0, 0, 1, CAST(N'2022-05-17T18:24:40.390' AS DateTime), 1, CAST(N'2022-05-19T11:15:48.473' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30005, 1, 1, 2, N'a', N'a', N'a', 0, 0, 0, 1, CAST(N'2022-06-02T15:48:28.670' AS DateTime), 1, CAST(N'2022-06-02T15:48:28.670' AS DateTime))
GO
INSERT [dbo].[PartMaster] ([PartId], [AssetTypeId], [AssetCategoryId], [ManufacturerId], [Code], [Name], [Description], [IsExpire], [IsSerial], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40005, 1, 1, 1, N'Test Part 011', N'Test Part 011', N'Test Part 01 5555', 1, 1, 1, 1, CAST(N'2022-10-04T15:47:05.823' AS DateTime), 1, CAST(N'2022-10-04T15:49:02.110' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[PartMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionDetail] ON 
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10117, 10117, 10038, 1002, 1, 0, 1, CAST(N'2022-05-23T16:11:00.393' AS DateTime), 1, CAST(N'2022-05-23T16:11:00.393' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10118, 10118, 10043, 1, 1, 0, 1, CAST(N'2022-05-23T16:13:27.797' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.797' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10119, 10119, 10041, 1, 1, 0, 1, CAST(N'2022-05-23T16:13:27.823' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.823' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10120, 10120, 10038, 1002, 1002, 0, 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10121, 10121, 10040, 1, 1, 0, 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10122, 10122, 10042, 1, 1, 0, 1, CAST(N'2022-05-23T16:13:27.830' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.830' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10123, 10123, 10043, 1, 1, 0, 1, CAST(N'2022-05-23T16:44:11.867' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.867' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10124, 10124, 10042, 1, 1, 0, 1, CAST(N'2022-05-23T16:44:11.890' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.890' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10125, 10125, 10041, 1, 1, 0, 1, CAST(N'2022-05-23T16:44:11.893' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.893' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10126, 10126, 10038, 1, 1002, 0, 1, CAST(N'2022-05-23T16:44:11.893' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.893' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10127, 10127, 10040, 1, 1, 0, 1, CAST(N'2022-05-23T16:44:11.897' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.897' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10128, 10128, 10040, 1, 1, 0, 1, CAST(N'2022-05-23T16:46:32.540' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.540' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10129, 10129, 10038, 1, 1002, 0, 1, CAST(N'2022-05-23T16:46:32.543' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.543' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10130, 10130, 10041, 1, 1, 0, 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10131, 10131, 10043, 1, 1, 0, 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10132, 10132, 10042, 1, 1, 0, 1, CAST(N'2022-05-23T16:46:32.550' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.550' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10133, 10133, 10042, 1, 1, 0, 1, CAST(N'2022-05-31T14:49:33.167' AS DateTime), 1, CAST(N'2022-05-31T14:49:33.167' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10134, 10134, 10042, 1002, 1, 0, 1, CAST(N'2022-05-31T14:49:51.340' AS DateTime), 1, CAST(N'2022-05-31T14:49:51.340' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10135, 10135, 10041, 1, 1, 0, 1, CAST(N'2022-05-31T14:50:11.453' AS DateTime), 1, CAST(N'2022-05-31T14:50:11.453' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20133, 20133, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T12:40:37.280' AS DateTime), 1, CAST(N'2022-06-01T12:40:37.280' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20134, 20134, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T12:40:37.310' AS DateTime), 1, CAST(N'2022-06-01T12:40:37.310' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20135, 20135, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T13:03:54.980' AS DateTime), 1, CAST(N'2022-06-01T13:03:54.980' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20136, 20136, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T13:03:55.003' AS DateTime), 1, CAST(N'2022-06-01T13:03:55.003' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20137, 20137, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T13:03:55.007' AS DateTime), 1, CAST(N'2022-06-01T13:03:55.007' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20138, 20138, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:13:42.887' AS DateTime), 1, CAST(N'2022-06-01T14:13:42.887' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20139, 20139, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:13:42.910' AS DateTime), 1, CAST(N'2022-06-01T14:13:42.910' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20140, 20140, 10042, 1002, 1002, 0, 1, CAST(N'2022-06-01T14:13:42.910' AS DateTime), 1, CAST(N'2022-06-01T14:13:42.910' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20141, 20141, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:09.403' AS DateTime), 1, CAST(N'2022-06-01T14:20:09.403' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20142, 20142, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:09.423' AS DateTime), 1, CAST(N'2022-06-01T14:20:09.423' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20143, 20143, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20144, 20144, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20145, 20145, 10042, 1, 1002, 0, 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20146, 20146, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20147, 20147, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:48.237' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.237' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20148, 20148, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:48.240' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.240' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20149, 20149, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:48.243' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.243' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20150, 20150, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:20:48.247' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.247' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20151, 20151, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20152, 20152, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20153, 20153, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:23:09.533' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.533' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20154, 20154, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:23:09.533' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.533' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20155, 20155, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:24:06.603' AS DateTime), 1, CAST(N'2022-06-01T14:24:06.603' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20156, 20156, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:25:44.983' AS DateTime), 1, CAST(N'2022-06-01T14:25:44.983' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20157, 20157, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:27:33.610' AS DateTime), 1, CAST(N'2022-06-01T14:27:33.610' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20158, 20158, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:27:33.613' AS DateTime), 1, CAST(N'2022-06-01T14:27:33.613' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20159, 20159, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:27:33.613' AS DateTime), 1, CAST(N'2022-06-01T14:27:33.613' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20160, 20160, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:29:11.660' AS DateTime), 1, CAST(N'2022-06-01T14:29:11.660' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20161, 20161, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:31:39.230' AS DateTime), 1, CAST(N'2022-06-01T14:31:39.230' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20162, 20162, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:33:49.117' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.117' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20163, 20163, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20164, 20164, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20165, 20165, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20166, 20166, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:35:03.753' AS DateTime), 1, CAST(N'2022-06-01T14:35:03.753' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20167, 20167, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:35:03.773' AS DateTime), 1, CAST(N'2022-06-01T14:35:03.773' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20168, 20168, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:35:32.477' AS DateTime), 1, CAST(N'2022-06-01T14:35:32.477' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20169, 20169, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:37:09.543' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.543' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20170, 20170, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20171, 20171, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20172, 20172, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20173, 20173, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:42:38.747' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.747' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20174, 20174, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:42:38.770' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.770' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20175, 20175, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20176, 20176, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20177, 20177, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20178, 20178, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:43:10.060' AS DateTime), 1, CAST(N'2022-06-01T14:43:10.060' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20179, 20179, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:43:10.063' AS DateTime), 1, CAST(N'2022-06-01T14:43:10.063' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20180, 20180, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:43:10.067' AS DateTime), 1, CAST(N'2022-06-01T14:43:10.067' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20181, 20181, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:43:27.977' AS DateTime), 1, CAST(N'2022-06-01T14:43:27.977' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20182, 20182, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:43:27.980' AS DateTime), 1, CAST(N'2022-06-01T14:43:27.980' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20183, 20183, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:43:45.763' AS DateTime), 1, CAST(N'2022-06-01T14:43:45.763' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20184, 20184, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20185, 20185, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20186, 20186, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20187, 20187, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20188, 20188, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20189, 20189, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20190, 20190, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:54:33.630' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.630' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20191, 20191, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:55:23.200' AS DateTime), 1, CAST(N'2022-06-01T14:55:23.200' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20192, 20192, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:55:23.200' AS DateTime), 1, CAST(N'2022-06-01T14:55:23.200' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20193, 20193, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:56:45.940' AS DateTime), 1, CAST(N'2022-06-01T14:56:45.940' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20194, 20194, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:59:08.617' AS DateTime), 1, CAST(N'2022-06-01T14:59:08.617' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20195, 20195, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T14:59:08.640' AS DateTime), 1, CAST(N'2022-06-01T14:59:08.640' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20196, 20196, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20197, 20197, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20198, 20198, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T14:59:39.733' AS DateTime), 1, CAST(N'2022-06-01T14:59:39.733' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20199, 20199, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime), 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20200, 20200, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime), 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20201, 20201, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T15:01:12.760' AS DateTime), 1, CAST(N'2022-06-01T15:01:12.760' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20202, 20202, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:01:42.273' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.273' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20203, 20203, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:01:42.277' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.277' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20204, 20204, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T15:01:42.277' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.277' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20205, 20205, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T15:01:42.280' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.280' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20206, 20206, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20207, 20207, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20208, 20208, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20209, 20209, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20210, 20210, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:02:15.643' AS DateTime), 1, CAST(N'2022-06-01T15:02:15.643' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20211, 20211, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime), 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20212, 20212, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime), 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20213, 20213, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20214, 20214, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20215, 20215, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:12.233' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.233' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20216, 20216, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:12.237' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.237' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20217, 20217, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20218, 20218, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20219, 20219, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20220, 20220, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20221, 20221, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20222, 20222, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20223, 20223, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20224, 20224, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20225, 20225, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T15:07:54.247' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.247' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20226, 20226, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:08:15.853' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.853' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20227, 20227, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20228, 20228, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20229, 20229, 10038, 1, 1, 0, 1, CAST(N'2022-06-01T15:08:15.860' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.860' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20230, 20230, 10041, 1, 1, 0, 1, CAST(N'2022-06-01T15:08:32.097' AS DateTime), 1, CAST(N'2022-06-01T15:08:32.097' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20231, 20231, 10040, 1, 1, 0, 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20232, 20232, 10043, 1, 1, 0, 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20233, 20233, 10042, 1, 1, 0, 1, CAST(N'2022-06-01T15:17:03.940' AS DateTime), 1, CAST(N'2022-06-01T15:17:03.940' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30133, 30133, 10043, 1, 1, 0, 1, CAST(N'2022-06-02T12:14:43.430' AS DateTime), 1, CAST(N'2022-06-02T12:14:43.430' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30134, 30134, 10042, 1, 1, 0, 1, CAST(N'2022-06-02T12:14:43.450' AS DateTime), 1, CAST(N'2022-06-02T12:14:43.450' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30135, 30135, 10040, 1002, 1, 0, 1, CAST(N'2022-06-02T12:40:14.287' AS DateTime), 1, CAST(N'2022-06-02T12:40:14.287' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30136, 30136, 10042, 1, 1, 0, 1, CAST(N'2022-06-02T12:40:43.990' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.990' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30137, 30137, 10041, 1, 1, 0, 1, CAST(N'2022-06-02T12:40:43.993' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.993' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30138, 30138, 10043, 1, 1, 0, 1, CAST(N'2022-06-02T12:40:43.997' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.997' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30139, 30139, 10040, 1002, 1002, 0, 1, CAST(N'2022-06-02T12:40:43.997' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.997' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30140, 30140, 10043, 1, 1, 0, 1, CAST(N'2022-06-03T10:57:58.577' AS DateTime), 1, CAST(N'2022-06-03T10:57:58.577' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30141, 30141, 10041, 1, 1, 0, 1, CAST(N'2022-06-03T10:58:36.447' AS DateTime), 1, CAST(N'2022-06-03T10:58:36.447' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30142, 30142, 10040, 1, 1002, 0, 1, CAST(N'2022-06-03T10:58:36.460' AS DateTime), 1, CAST(N'2022-06-03T10:58:36.460' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30143, 30143, 10040, 1, 1, 0, 1, CAST(N'2022-06-03T11:19:37.407' AS DateTime), 1, CAST(N'2022-06-03T11:19:37.407' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30144, 30144, 10038, 1, 1, 0, 1, CAST(N'2022-06-03T11:19:37.433' AS DateTime), 1, CAST(N'2022-06-03T11:19:37.433' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30145, 30145, 10038, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:12:54.677' AS DateTime), 1, CAST(N'2022-06-03T12:12:54.677' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30146, 30146, 10040, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:12:54.697' AS DateTime), 1, CAST(N'2022-06-03T12:12:54.697' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30147, 30147, 10043, 1, 1, 0, 1, CAST(N'2022-06-03T12:14:55.820' AS DateTime), 1, CAST(N'2022-06-03T12:14:55.820' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30148, 30148, 10040, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:17:53.990' AS DateTime), 1, CAST(N'2022-06-03T12:17:53.990' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30149, 30149, 10040, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:50:38.427' AS DateTime), 1, CAST(N'2022-06-03T12:50:38.427' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30150, 30150, 10038, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:50:38.430' AS DateTime), 1, CAST(N'2022-06-03T12:50:38.430' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30151, 30151, 10043, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:50:38.433' AS DateTime), 1, CAST(N'2022-06-03T12:50:38.433' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30152, 30152, 10044, 1, 1, 0, 1, CAST(N'2022-06-03T12:50:58.857' AS DateTime), 1, CAST(N'2022-06-03T12:50:58.857' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30153, 30153, 10044, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:51:28.410' AS DateTime), 1, CAST(N'2022-06-03T12:51:28.410' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30154, 30154, 10044, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:53:25.880' AS DateTime), 1, CAST(N'2022-06-03T12:53:25.880' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30155, 30155, 10044, NULL, NULL, 0, 1, CAST(N'2022-06-03T12:55:06.117' AS DateTime), 1, CAST(N'2022-06-03T12:55:06.117' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30156, 30156, 10044, NULL, NULL, 0, 1, CAST(N'2022-06-03T13:14:00.000' AS DateTime), 1, CAST(N'2022-06-03T13:14:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30157, 30157, 10044, NULL, NULL, 0, 1, CAST(N'2022-06-03T13:14:42.930' AS DateTime), 1, CAST(N'2022-06-03T13:14:42.930' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30158, 30158, 10038, NULL, NULL, 0, 1, CAST(N'2022-06-03T13:15:27.780' AS DateTime), 1, CAST(N'2022-06-03T13:15:27.780' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30159, 30159, 10040, NULL, NULL, 0, 1, CAST(N'2022-06-03T13:15:27.783' AS DateTime), 1, CAST(N'2022-06-03T13:15:27.783' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30160, 30160, 10041, 1, 1, 0, 1, CAST(N'2022-06-03T13:17:52.897' AS DateTime), 1, CAST(N'2022-06-03T13:17:52.897' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30161, 30161, 10042, 1, 1, 0, 1, CAST(N'2022-06-03T13:17:52.903' AS DateTime), 1, CAST(N'2022-06-03T13:17:52.903' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30162, 30162, 10038, NULL, NULL, 0, 1, CAST(N'2022-06-03T13:18:32.017' AS DateTime), 1, CAST(N'2022-06-03T13:18:32.017' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30163, 30163, 10038, 1002, NULL, 0, 1, CAST(N'2022-06-03T13:20:37.113' AS DateTime), 1, CAST(N'2022-06-03T13:20:37.113' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30164, 30164, 10038, 1002, 1002, 0, 1, CAST(N'2022-06-03T13:21:20.053' AS DateTime), 1, CAST(N'2022-06-03T13:21:20.053' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30165, 30165, 10038, 1, 1002, 0, 1, CAST(N'2022-06-03T13:28:09.173' AS DateTime), 1, CAST(N'2022-06-03T13:28:09.173' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30166, 30166, 10040, 1, NULL, 0, 1, CAST(N'2022-06-03T14:25:02.330' AS DateTime), 1, CAST(N'2022-06-03T14:25:02.330' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30167, 30167, 10038, 1, 1, 0, 1, CAST(N'2022-06-03T14:26:36.023' AS DateTime), 1, CAST(N'2022-06-03T14:26:36.023' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30168, 30168, 10041, 1, 1, 0, 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30169, 30169, 10042, 1, 1, 0, 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30170, 30170, 10042, 1, 1, 0, 1, CAST(N'2022-06-03T14:27:13.060' AS DateTime), 1, CAST(N'2022-06-03T14:27:13.060' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30171, 30171, 10038, 1, 1, 0, 1, CAST(N'2022-06-03T14:29:00.927' AS DateTime), 1, CAST(N'2022-06-03T14:29:00.927' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30172, 30172, 10038, 1, 1, 0, 1, CAST(N'2022-06-03T14:29:20.153' AS DateTime), 1, CAST(N'2022-06-03T14:29:20.153' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30173, 30173, 10038, 1002, 1, 0, 1, CAST(N'2022-06-03T14:29:53.707' AS DateTime), 1, CAST(N'2022-06-03T14:29:53.707' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30174, 30174, 10038, 1002, 1002, 0, 1, CAST(N'2022-06-03T15:46:35.887' AS DateTime), 1, CAST(N'2022-06-03T15:46:35.887' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30175, 30175, 10038, 1002, 1002, 0, 1, CAST(N'2022-06-03T15:51:30.553' AS DateTime), 1, CAST(N'2022-06-03T15:51:30.553' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40133, 40133, 10042, 1, 1, 0, 1, CAST(N'2022-08-08T10:39:17.370' AS DateTime), 1, CAST(N'2022-08-08T10:39:17.370' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40134, 40134, 10045, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:38.413' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.413' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40135, 40135, 10047, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40136, 40136, 10048, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40137, 40137, 10046, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40138, 40138, 10045, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40139, 40139, 10046, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40140, 40140, 10047, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40141, 40141, 10048, 1, 1, 0, 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40142, 40142, 10051, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.897' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.897' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40143, 40143, 10049, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40144, 40144, 10053, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40145, 40145, 10054, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40146, 40146, 10050, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40147, 40147, 10052, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.903' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.903' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40148, 40148, 10055, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40149, 40149, 10056, 1, 1, 0, 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40150, 40150, 10051, 1, 1, 0, 1, CAST(N'2022-08-08T11:20:00.753' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.753' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40151, 40151, 10054, 1, 1, 0, 1, CAST(N'2022-08-08T11:20:00.770' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.770' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40152, 40152, 10053, 1, 1, 0, 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40153, 40153, 10049, 1, 1, 0, 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40154, 40154, 10052, 1, 1, 0, 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40155, 40155, 10050, 1, 1, 0, 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40156, 40156, 10051, 1, 1, 0, 1, CAST(N'2022-08-08T11:48:25.150' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.150' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40157, 40157, 10053, 1, 1, 0, 1, CAST(N'2022-08-08T11:48:25.170' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.170' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40158, 40158, 10049, 1, 1, 0, 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40159, 40159, 10054, 1, 1, 0, 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (40160, 40160, 10052, 1, 1, 0, 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50133, 50133, 10040, 1, 1, 0, 1, CAST(N'2022-08-09T17:52:44.513' AS DateTime), 1, CAST(N'2022-08-09T17:52:44.513' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50134, 50134, 10042, 1, 1, 0, 1, CAST(N'2022-08-09T17:52:44.530' AS DateTime), 1, CAST(N'2022-08-09T17:52:44.530' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50135, 50135, 10038, 1002, 1002, 0, 1, CAST(N'2022-08-10T10:12:17.733' AS DateTime), 1, CAST(N'2022-08-10T10:12:17.733' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50136, 50136, 10038, 1, 1002, 0, 1, CAST(N'2022-08-31T16:32:16.777' AS DateTime), 1, CAST(N'2022-08-31T16:32:16.777' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50137, 50137, 10041, 1, 1, 0, 1, CAST(N'2022-09-30T13:02:41.017' AS DateTime), 1, CAST(N'2022-09-30T13:02:41.017' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50138, 50138, 10040, 1007, 1, 0, 1, CAST(N'2022-09-30T14:57:58.077' AS DateTime), 1, CAST(N'2022-09-30T14:57:58.077' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50139, 50139, 10043, 1007, NULL, 0, 1, CAST(N'2022-10-12T17:45:15.037' AS DateTime), 1, CAST(N'2022-10-12T17:45:15.037' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50140, 50139, 10042, 1007, 1, 0, 1, CAST(N'2022-10-12T17:45:15.037' AS DateTime), 1, CAST(N'2022-10-12T17:45:15.037' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50141, 50140, 10057, 1007, NULL, 0, 1, CAST(N'2022-10-12T17:47:46.253' AS DateTime), 1, CAST(N'2022-10-12T17:47:46.417' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50142, 50140, 10054, 1007, 1, 0, 1, CAST(N'2022-10-12T17:47:47.923' AS DateTime), 1, CAST(N'2022-10-12T17:47:47.923' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50143, 50140, 10053, 1007, 1, 0, 1, CAST(N'2022-10-12T17:47:47.923' AS DateTime), 1, CAST(N'2022-10-12T17:47:47.923' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50144, 50141, 10057, 1007, NULL, 0, 1, CAST(N'2022-10-12T17:48:43.070' AS DateTime), 1, CAST(N'2022-10-12T17:48:43.070' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50145, 50141, 10054, 1007, 1, 0, 1, CAST(N'2022-10-12T17:48:43.073' AS DateTime), 1, CAST(N'2022-10-12T17:48:43.073' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (50146, 50141, 10053, 1007, 1, 0, 1, CAST(N'2022-10-12T17:48:43.073' AS DateTime), 1, CAST(N'2022-10-12T17:48:43.073' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60139, 60139, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T13:06:54.397' AS DateTime), 1, CAST(N'2022-11-17T13:06:54.400' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60140, 60140, 10057, 1, 1002, 0, 1, CAST(N'2022-11-17T13:07:05.407' AS DateTime), 1, CAST(N'2022-11-17T13:07:05.407' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60141, 60141, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T13:07:05.550' AS DateTime), 1, CAST(N'2022-11-17T13:07:05.550' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60142, 60142, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T13:07:18.507' AS DateTime), 1, CAST(N'2022-11-17T13:07:18.507' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60143, 60143, 10057, 1, 1002, 0, 1, CAST(N'2022-11-17T13:07:29.523' AS DateTime), 1, CAST(N'2022-11-17T13:07:29.523' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60144, 60144, 10057, 1, 1002, 0, 1, CAST(N'2022-11-17T16:13:13.900' AS DateTime), 1, CAST(N'2022-11-17T16:13:13.900' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60145, 60145, 10057, 1, 1, 0, 1, CAST(N'2022-11-17T16:18:34.710' AS DateTime), 1, CAST(N'2022-11-17T16:18:34.710' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60146, 60146, 10057, 1, 1, 0, 1, CAST(N'2022-11-17T16:22:52.180' AS DateTime), 1, CAST(N'2022-11-17T16:22:52.180' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60147, 60147, 10057, 1002, 1, 0, 1, CAST(N'2022-11-17T16:22:52.480' AS DateTime), 1, CAST(N'2022-11-17T16:22:52.480' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60148, 60148, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T16:40:39.930' AS DateTime), 1, CAST(N'2022-11-17T16:40:39.930' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60149, 60149, 10057, 1, 1002, 0, 1, CAST(N'2022-11-17T16:45:33.300' AS DateTime), 1, CAST(N'2022-11-17T16:45:33.300' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60150, 60150, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T16:45:35.533' AS DateTime), 1, CAST(N'2022-11-17T16:45:35.533' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60151, 60151, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T17:13:16.767' AS DateTime), 1, CAST(N'2022-11-17T17:13:16.770' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60152, 60152, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-17T17:13:19.837' AS DateTime), 1, CAST(N'2022-11-17T17:13:19.837' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60153, 60153, 10057, 1, 1002, 0, 1, CAST(N'2022-11-17T17:13:26.430' AS DateTime), 1, CAST(N'2022-11-17T17:13:26.430' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60154, 60154, 10057, 1, 1, 0, 1, CAST(N'2022-11-17T17:42:29.373' AS DateTime), 1, CAST(N'2022-11-17T17:42:29.373' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60155, 60155, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-17T17:42:29.733' AS DateTime), 1, CAST(N'2022-11-17T17:42:29.733' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60156, 60156, 10057, 1, 1, 0, 1, CAST(N'2022-11-17T17:42:42.157' AS DateTime), 1, CAST(N'2022-11-17T17:42:42.157' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60157, 60157, 10057, 1002, NULL, 0, 1, CAST(N'2022-11-17T17:42:54.640' AS DateTime), 1, CAST(N'2022-11-17T17:42:54.640' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60158, 60158, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T17:43:07.980' AS DateTime), 1, CAST(N'2022-11-17T17:43:07.980' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60159, 60159, 10057, 1, 1, 0, 1, CAST(N'2022-11-17T17:43:26.387' AS DateTime), 1, CAST(N'2022-11-17T17:43:26.387' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60160, 60160, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T17:43:26.850' AS DateTime), 1, CAST(N'2022-11-17T17:43:26.850' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60161, 60161, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T17:44:21.717' AS DateTime), 1, CAST(N'2022-11-17T17:44:21.717' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60162, 60162, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-17T17:44:29.717' AS DateTime), 1, CAST(N'2022-11-17T17:44:29.717' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60163, 60163, 10057, 1, 1002, 0, 1, CAST(N'2022-11-17T17:44:43.717' AS DateTime), 1, CAST(N'2022-11-17T17:44:43.717' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60164, 60164, 10057, 1002, NULL, 0, 1, CAST(N'2022-11-17T17:44:45.610' AS DateTime), 1, CAST(N'2022-11-17T17:44:45.610' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60165, 60165, 10057, 1, 1, 0, 1, CAST(N'2022-11-17T17:44:52.770' AS DateTime), 1, CAST(N'2022-11-17T17:44:52.770' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60166, 60166, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-17T17:44:58.300' AS DateTime), 1, CAST(N'2022-11-17T17:44:58.300' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60167, 60167, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:31:14.877' AS DateTime), 1, CAST(N'2022-11-18T16:31:14.877' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60168, 60168, 10057, 1, 1002, 0, 1, CAST(N'2022-11-18T16:31:21.503' AS DateTime), 1, CAST(N'2022-11-18T16:31:21.503' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60169, 60169, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:31:30.470' AS DateTime), 1, CAST(N'2022-11-18T16:31:30.470' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60170, 60170, 10057, 1, 1, 0, 1, CAST(N'2022-11-18T16:31:30.533' AS DateTime), 1, CAST(N'2022-11-18T16:31:30.533' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60171, 60171, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:31:45.130' AS DateTime), 1, CAST(N'2022-11-18T16:31:45.130' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60172, 60172, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:35:35.927' AS DateTime), 1, CAST(N'2022-11-18T16:35:35.927' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60173, 60173, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-18T16:35:42.023' AS DateTime), 1, CAST(N'2022-11-18T16:35:42.023' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60174, 60174, 10057, 1, NULL, 0, 1, CAST(N'2022-11-18T16:35:56.250' AS DateTime), 1, CAST(N'2022-11-18T16:35:56.250' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60175, 60175, 10057, 1, 1, 0, 1, CAST(N'2022-11-18T16:38:10.680' AS DateTime), 1, CAST(N'2022-11-18T16:38:10.680' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60176, 60176, 10057, 1, 1, 0, 1, CAST(N'2022-11-18T16:38:34.000' AS DateTime), 1, CAST(N'2022-11-18T16:38:34.000' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60177, 60177, 10057, 1002, 1, 0, 1, CAST(N'2022-11-18T16:38:34.537' AS DateTime), 1, CAST(N'2022-11-18T16:38:34.537' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60178, 60178, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:45:59.157' AS DateTime), 1, CAST(N'2022-11-18T16:45:59.157' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60179, 60179, 10057, 1, 1002, 0, 1, CAST(N'2022-11-18T16:46:09.310' AS DateTime), 1, CAST(N'2022-11-18T16:46:09.310' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60180, 60180, 10057, 1, 1, 0, 1, CAST(N'2022-11-18T16:47:43.593' AS DateTime), 1, CAST(N'2022-11-18T16:47:43.593' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60181, 60181, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-18T16:47:49.153' AS DateTime), 1, CAST(N'2022-11-18T16:47:49.153' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60182, 60182, 10057, 1, NULL, 0, 1, CAST(N'2022-11-18T16:50:02.023' AS DateTime), 1, CAST(N'2022-11-18T16:50:02.023' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60183, 60183, 10057, 1, 1, 0, 1, CAST(N'2022-11-18T16:50:22.500' AS DateTime), 1, CAST(N'2022-11-18T16:50:22.500' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60184, 60184, 10057, 1, 1, 0, 1, CAST(N'2022-11-18T16:50:56.723' AS DateTime), 1, CAST(N'2022-11-18T16:50:56.723' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60185, 60185, 10057, 1, 1, 0, 1, CAST(N'2022-11-18T16:51:13.647' AS DateTime), 1, CAST(N'2022-11-18T16:51:13.647' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60186, 60186, 10057, 1002, 1, 0, 1, CAST(N'2022-11-18T16:51:55.187' AS DateTime), 1, CAST(N'2022-11-18T16:51:55.187' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60187, 60187, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:57:35.323' AS DateTime), 1, CAST(N'2022-11-18T16:57:35.323' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60188, 60188, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:59:30.077' AS DateTime), 1, CAST(N'2022-11-18T16:59:30.077' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60189, 60189, 10057, 1, 1002, 0, 1, CAST(N'2022-11-18T16:59:33.967' AS DateTime), 1, CAST(N'2022-11-18T16:59:33.967' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60190, 60190, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-18T16:59:47.010' AS DateTime), 1, CAST(N'2022-11-18T16:59:47.010' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60191, 60191, 10057, 1, 1002, 0, 1, CAST(N'2022-11-21T18:11:46.510' AS DateTime), 1, CAST(N'2022-11-21T18:11:46.510' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60192, 60192, 10057, 1, 1, 0, 1, CAST(N'2022-11-21T18:13:10.377' AS DateTime), 1, CAST(N'2022-11-21T18:13:10.377' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60193, 60193, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-21T18:13:16.040' AS DateTime), 1, CAST(N'2022-11-21T18:13:16.040' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (60194, 60194, 10057, 1, 1, 0, 1, CAST(N'2022-11-21T18:13:20.230' AS DateTime), 1, CAST(N'2022-11-21T18:13:20.230' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70139, 70139, 10057, 1, 1, 0, 1, CAST(N'2022-11-24T14:17:09.643' AS DateTime), 1, CAST(N'2022-11-24T14:17:09.643' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70140, 70140, 10057, 1, 1, 0, 1, CAST(N'2022-11-24T14:17:33.087' AS DateTime), 1, CAST(N'2022-11-24T14:17:33.087' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70141, 70141, 10057, 1, 1, 0, 1, CAST(N'2022-11-24T14:20:24.233' AS DateTime), 1, CAST(N'2022-11-24T14:20:24.233' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70142, 70142, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-24T14:20:24.770' AS DateTime), 1, CAST(N'2022-11-24T14:20:24.770' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70143, 70143, 10057, 1002, NULL, 0, 1, CAST(N'2022-11-24T14:22:34.183' AS DateTime), 1, CAST(N'2022-11-24T14:22:34.183' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70144, 70144, 10057, 1, NULL, 0, 1, CAST(N'2022-11-24T14:22:38.910' AS DateTime), 1, CAST(N'2022-11-24T14:22:38.910' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70145, 70145, 10057, 1, 1, 0, 1, CAST(N'2022-11-24T14:22:48.780' AS DateTime), 1, CAST(N'2022-11-24T14:22:48.780' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70146, 70146, 10057, 1, 1, 0, 1, CAST(N'2022-11-24T14:25:07.867' AS DateTime), 1, CAST(N'2022-11-24T14:25:07.867' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70147, 70147, 10057, 1, 1, 0, 1, CAST(N'2022-11-24T14:29:28.267' AS DateTime), 1, CAST(N'2022-11-24T14:29:28.267' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70148, 70148, 10057, NULL, NULL, 0, 1, CAST(N'2022-11-24T14:29:34.300' AS DateTime), 1, CAST(N'2022-11-24T14:29:34.300' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70149, 70149, 10057, 1002, NULL, 0, 1, CAST(N'2022-11-24T14:37:55.560' AS DateTime), 1, CAST(N'2022-11-24T14:37:55.560' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (70150, 70150, 10057, 1002, 1002, 0, 1, CAST(N'2022-11-24T14:38:18.087' AS DateTime), 1, CAST(N'2022-11-24T14:38:18.087' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (80139, 80139, 10057, 1002, 1002, 0, 1, CAST(N'2022-12-05T17:54:34.150' AS DateTime), 1, CAST(N'2022-12-05T17:54:34.150' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90139, 90139, 10057, 1002, 1002, 0, 1, CAST(N'2022-12-27T17:35:07.720' AS DateTime), 1, CAST(N'2022-12-27T17:35:07.723' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90140, 90140, 10057, 1, 1002, 0, 1, CAST(N'2022-12-27T17:35:53.167' AS DateTime), 1, CAST(N'2022-12-27T17:35:53.167' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90141, 90141, 10057, 1002, 1002, 0, 1, CAST(N'2022-12-27T17:35:58.863' AS DateTime), 1, CAST(N'2022-12-27T17:35:58.863' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90142, 90142, 10057, 1002, 1002, 0, 1, CAST(N'2022-12-27T17:36:14.053' AS DateTime), 1, CAST(N'2022-12-27T17:36:14.053' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90143, 90143, 10057, NULL, NULL, 0, 1, CAST(N'2022-12-27T17:36:14.137' AS DateTime), 1, CAST(N'2022-12-27T17:36:14.137' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90144, 90144, 10057, 1002, NULL, 0, 1, CAST(N'2023-01-05T12:30:17.823' AS DateTime), 1, CAST(N'2023-01-05T12:30:17.823' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90145, 90145, 10057, 1002, 1002, 0, 1, CAST(N'2023-01-05T12:30:34.793' AS DateTime), 1, CAST(N'2023-01-05T12:30:34.793' AS DateTime))
GO
INSERT [dbo].[TransactionDetail] ([TraDetailId], [TransactionId], [AssetTagId], [LocationId], [LastLocationId], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (90146, 90146, 10057, NULL, NULL, 0, 1, CAST(N'2023-01-05T12:30:36.823' AS DateTime), 1, CAST(N'2023-01-05T12:30:36.823' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TransactionDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionHeader] ON 
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10117, 1, CAST(N'2022-05-23T16:11:00.370' AS DateTime), N'22', 1, 0, 1, CAST(N'2022-05-23T16:11:00.370' AS DateTime), 1, CAST(N'2022-05-23T16:11:00.370' AS DateTime), N'A', NULL)
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10118, 2, CAST(N'2022-05-23T16:13:27.777' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:13:27.777' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.777' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10119, 1, CAST(N'2022-05-23T16:13:27.800' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:13:27.800' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.800' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10120, 2, CAST(N'2022-05-23T16:13:27.827' AS DateTime), N'21212', 1, 0, 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime), N'R', N'asdasd')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10121, 2, CAST(N'2022-05-23T16:13:27.827' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.827' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10122, 1, CAST(N'2022-05-23T16:13:27.830' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:13:27.830' AS DateTime), 1, CAST(N'2022-05-23T16:13:27.830' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10123, 1, CAST(N'2022-05-23T16:44:11.840' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:44:11.840' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.840' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10124, 2, CAST(N'2022-05-23T16:44:11.870' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:44:11.870' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.870' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10125, 2, CAST(N'2022-05-23T16:44:11.890' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:44:11.890' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.890' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10126, 1, CAST(N'2022-05-23T16:44:11.893' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-05-23T16:44:11.893' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.893' AS DateTime), N'R', N'asd')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10127, 1, CAST(N'2022-05-23T16:44:11.897' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:44:11.897' AS DateTime), 1, CAST(N'2022-05-23T16:44:11.897' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10128, 2, CAST(N'2022-05-23T16:46:32.540' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:46:32.540' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.540' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10129, 1, CAST(N'2022-05-23T16:46:32.543' AS DateTime), N'asda', 1, 0, 1, CAST(N'2022-05-23T16:46:32.543' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.543' AS DateTime), N'A', N'asd')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10130, 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10131, 2, CAST(N'2022-05-23T16:46:32.547' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10132, 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), 1, CAST(N'2022-05-23T16:46:32.547' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10133, 2, CAST(N'2022-05-31T14:49:33.140' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-31T14:49:33.143' AS DateTime), 1, CAST(N'2022-05-31T14:49:33.143' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10134, 1, CAST(N'2022-05-31T14:49:51.340' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-31T14:49:51.340' AS DateTime), 1, CAST(N'2022-05-31T14:49:51.340' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (10135, 2, CAST(N'2022-05-31T14:50:11.453' AS DateTime), N'', 1, 0, 1, CAST(N'2022-05-31T14:50:11.453' AS DateTime), 1, CAST(N'2022-05-31T14:50:11.453' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20133, 2, CAST(N'2022-06-01T12:40:37.247' AS DateTime), N'as', 1, 0, 1, CAST(N'2022-06-01T12:40:37.247' AS DateTime), 1, CAST(N'2022-06-01T12:40:37.247' AS DateTime), N'R', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20134, 1, CAST(N'2022-06-01T12:40:37.283' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T12:40:37.283' AS DateTime), 1, CAST(N'2022-06-01T12:40:37.283' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20135, 1, CAST(N'2022-06-01T13:03:54.953' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T13:03:54.953' AS DateTime), 1, CAST(N'2022-06-01T13:03:54.953' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20136, 2, CAST(N'2022-06-01T13:03:54.980' AS DateTime), N'23', 1, 0, 1, CAST(N'2022-06-01T13:03:54.980' AS DateTime), 1, CAST(N'2022-06-01T13:03:54.980' AS DateTime), N'R', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20137, 1, CAST(N'2022-06-01T13:03:55.007' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T13:03:55.007' AS DateTime), 1, CAST(N'2022-06-01T13:03:55.007' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20138, 2, CAST(N'2022-06-01T14:13:42.863' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:13:42.863' AS DateTime), 1, CAST(N'2022-06-01T14:13:42.863' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20139, 2, CAST(N'2022-06-01T14:13:42.887' AS DateTime), N'asas', 1, 0, 1, CAST(N'2022-06-01T14:13:42.887' AS DateTime), 1, CAST(N'2022-06-01T14:13:42.887' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20140, 2, CAST(N'2022-06-01T14:13:42.910' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:13:42.910' AS DateTime), 1, CAST(N'2022-06-01T14:13:42.910' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20141, 1, CAST(N'2022-06-01T14:20:09.383' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:09.383' AS DateTime), 1, CAST(N'2022-06-01T14:20:09.383' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20142, 2, CAST(N'2022-06-01T14:20:09.403' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:09.403' AS DateTime), 1, CAST(N'2022-06-01T14:20:09.403' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20143, 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), N'df', 1, 0, 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20144, 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.107' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20145, 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20146, 2, CAST(N'2022-06-01T14:20:26.110' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime), 1, CAST(N'2022-06-01T14:20:26.110' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20147, 1, CAST(N'2022-06-01T14:20:48.237' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:48.237' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.237' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20148, 2, CAST(N'2022-06-01T14:20:48.240' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:48.240' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.240' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20149, 2, CAST(N'2022-06-01T14:20:48.243' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-06-01T14:20:48.243' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.243' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20150, 2, CAST(N'2022-06-01T14:20:48.247' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:20:48.247' AS DateTime), 1, CAST(N'2022-06-01T14:20:48.247' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20151, 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), N'wqe', 1, 0, 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20152, 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20153, 2, CAST(N'2022-06-01T14:23:09.530' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.530' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20154, 1, CAST(N'2022-06-01T14:23:09.533' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:23:09.533' AS DateTime), 1, CAST(N'2022-06-01T14:23:09.533' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20155, 2, CAST(N'2022-06-01T14:24:06.580' AS DateTime), N'1', 1, 0, 1, CAST(N'2022-06-01T14:24:06.580' AS DateTime), 1, CAST(N'2022-06-01T14:24:06.580' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20156, 1, CAST(N'2022-06-01T14:25:44.983' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:25:44.983' AS DateTime), 1, CAST(N'2022-06-01T14:25:44.983' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20157, 1, CAST(N'2022-06-01T14:27:33.610' AS DateTime), N'as', 1, 0, 1, CAST(N'2022-06-01T14:27:33.610' AS DateTime), 1, CAST(N'2022-06-01T14:27:33.610' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20158, 2, CAST(N'2022-06-01T14:27:33.610' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:27:33.610' AS DateTime), 1, CAST(N'2022-06-01T14:27:33.610' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20159, 2, CAST(N'2022-06-01T14:27:33.613' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:27:33.613' AS DateTime), 1, CAST(N'2022-06-01T14:27:33.613' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20160, 1, CAST(N'2022-06-01T14:29:11.660' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:29:11.660' AS DateTime), 1, CAST(N'2022-06-01T14:29:11.660' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20161, 2, CAST(N'2022-06-01T14:31:39.210' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:31:39.210' AS DateTime), 1, CAST(N'2022-06-01T14:31:39.210' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20162, 2, CAST(N'2022-06-01T14:33:49.117' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:33:49.117' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.117' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20163, 2, CAST(N'2022-06-01T14:33:49.117' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:33:49.117' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.117' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20164, 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20165, 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), 1, CAST(N'2022-06-01T14:33:49.120' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20166, 2, CAST(N'2022-06-01T14:35:03.737' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:35:03.737' AS DateTime), 1, CAST(N'2022-06-01T14:35:03.737' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20167, 1, CAST(N'2022-06-01T14:35:03.757' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:35:03.757' AS DateTime), 1, CAST(N'2022-06-01T14:35:03.757' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20168, 2, CAST(N'2022-06-01T14:35:32.477' AS DateTime), N'120', 1, 0, 1, CAST(N'2022-06-01T14:35:32.477' AS DateTime), 1, CAST(N'2022-06-01T14:35:32.477' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20169, 2, CAST(N'2022-06-01T14:37:09.543' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:37:09.543' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.543' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20170, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20171, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), N'a', 1, 0, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20172, 2, CAST(N'2022-06-01T14:37:09.547' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), 1, CAST(N'2022-06-01T14:37:09.547' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20173, 2, CAST(N'2022-06-01T14:42:38.727' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:42:38.730' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.730' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20174, 1, CAST(N'2022-06-01T14:42:38.750' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:42:38.750' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.750' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20175, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20176, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20177, 2, CAST(N'2022-06-01T14:42:38.773' AS DateTime), N'qw', 1, 0, 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), 1, CAST(N'2022-06-01T14:42:38.773' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20178, 2, CAST(N'2022-06-01T14:43:10.057' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:43:10.057' AS DateTime), 1, CAST(N'2022-06-01T14:43:10.057' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20179, 1, CAST(N'2022-06-01T14:43:10.060' AS DateTime), N'sd', 1, 0, 1, CAST(N'2022-06-01T14:43:10.060' AS DateTime), 1, CAST(N'2022-06-01T14:43:10.060' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20180, 2, CAST(N'2022-06-01T14:43:10.063' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:43:10.063' AS DateTime), 1, CAST(N'2022-06-01T14:43:10.063' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20181, 2, CAST(N'2022-06-01T14:43:27.977' AS DateTime), N'as', 1, 0, 1, CAST(N'2022-06-01T14:43:27.977' AS DateTime), 1, CAST(N'2022-06-01T14:43:27.977' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20182, 1, CAST(N'2022-06-01T14:43:27.977' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:43:27.977' AS DateTime), 1, CAST(N'2022-06-01T14:43:27.977' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20183, 2, CAST(N'2022-06-01T14:43:45.763' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:43:45.763' AS DateTime), 1, CAST(N'2022-06-01T14:43:45.763' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20184, 2, CAST(N'2022-06-01T14:44:05.083' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20185, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20186, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), N'a', 1, 0, 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), 1, CAST(N'2022-06-01T14:44:05.083' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20187, 2, CAST(N'2022-06-01T14:54:33.627' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20188, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20189, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.627' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20190, 1, CAST(N'2022-06-01T14:54:33.630' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:54:33.630' AS DateTime), 1, CAST(N'2022-06-01T14:54:33.630' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20191, 2, CAST(N'2022-06-01T14:55:23.197' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:55:23.197' AS DateTime), 1, CAST(N'2022-06-01T14:55:23.197' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20192, 1, CAST(N'2022-06-01T14:55:23.200' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:55:23.200' AS DateTime), 1, CAST(N'2022-06-01T14:55:23.200' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20193, 1, CAST(N'2022-06-01T14:56:45.940' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:56:45.940' AS DateTime), 1, CAST(N'2022-06-01T14:56:45.940' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20194, 2, CAST(N'2022-06-01T14:59:08.597' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:59:08.597' AS DateTime), 1, CAST(N'2022-06-01T14:59:08.597' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20195, 2, CAST(N'2022-06-01T14:59:08.617' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:59:08.617' AS DateTime), 1, CAST(N'2022-06-01T14:59:08.617' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20196, 2, CAST(N'2022-06-01T14:59:39.730' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20197, 2, CAST(N'2022-06-01T14:59:39.730' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20198, 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), 1, CAST(N'2022-06-01T14:59:39.730' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20199, 2, CAST(N'2022-06-01T15:00:10.827' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime), 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20200, 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime), 1, CAST(N'2022-06-01T15:00:10.827' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20201, 1, CAST(N'2022-06-01T15:01:12.740' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:01:12.740' AS DateTime), 1, CAST(N'2022-06-01T15:01:12.740' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20202, 2, CAST(N'2022-06-01T15:01:42.270' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:01:42.270' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.270' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20203, 1, CAST(N'2022-06-01T15:01:42.273' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:01:42.273' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.273' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20204, 2, CAST(N'2022-06-01T15:01:42.277' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:01:42.277' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.277' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20205, 2, CAST(N'2022-06-01T15:01:42.280' AS DateTime), N'asdafd', 1, 0, 1, CAST(N'2022-06-01T15:01:42.280' AS DateTime), 1, CAST(N'2022-06-01T15:01:42.280' AS DateTime), N'R', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20206, 2, CAST(N'2022-06-01T15:02:03.160' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20207, 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.160' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20208, 2, CAST(N'2022-06-01T15:02:03.163' AS DateTime), N'21', 1, 0, 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime), N'R', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20209, 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime), 1, CAST(N'2022-06-01T15:02:03.163' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20210, 1, CAST(N'2022-06-01T15:02:15.643' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:02:15.643' AS DateTime), 1, CAST(N'2022-06-01T15:02:15.643' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20211, 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime), 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20212, 2, CAST(N'2022-06-01T15:05:48.113' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime), 1, CAST(N'2022-06-01T15:05:48.113' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20213, 2, CAST(N'2022-06-01T15:06:12.230' AS DateTime), N'12', 1, 0, 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20214, 2, CAST(N'2022-06-01T15:06:12.230' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20215, 2, CAST(N'2022-06-01T15:06:12.230' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.230' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20216, 2, CAST(N'2022-06-01T15:06:12.237' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:06:12.237' AS DateTime), 1, CAST(N'2022-06-01T15:06:12.237' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20217, 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20218, 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), N'as', 1, 0, 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.600' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20219, 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20220, 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), 1, CAST(N'2022-06-01T15:06:31.603' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20221, 2, CAST(N'2022-06-01T15:07:54.240' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:07:54.240' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.240' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20222, 2, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20223, 2, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20224, 2, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'21', 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20225, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), 1, CAST(N'2022-06-01T15:07:54.243' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20226, 1, CAST(N'2022-06-01T15:08:15.853' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:08:15.853' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.853' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20227, 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20228, 2, CAST(N'2022-06-01T15:08:15.857' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.857' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20229, 1, CAST(N'2022-06-01T15:08:15.860' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-06-01T15:08:15.860' AS DateTime), 1, CAST(N'2022-06-01T15:08:15.860' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20230, 1, CAST(N'2022-06-01T15:08:32.097' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:08:32.097' AS DateTime), 1, CAST(N'2022-06-01T15:08:32.097' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20231, 2, CAST(N'2022-06-01T15:17:03.937' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20232, 2, CAST(N'2022-06-01T15:17:03.937' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (20233, 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), 1, CAST(N'2022-06-01T15:17:03.937' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30133, 1, CAST(N'2022-06-02T12:14:43.410' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-02T12:14:43.410' AS DateTime), 1, CAST(N'2022-06-02T12:14:43.410' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30134, 2, CAST(N'2022-06-02T12:14:43.430' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-02T12:14:43.430' AS DateTime), 1, CAST(N'2022-06-02T12:14:43.430' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30135, 1, CAST(N'2022-06-02T12:40:14.260' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-02T12:40:14.260' AS DateTime), 1, CAST(N'2022-06-02T12:40:14.260' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30136, 1, CAST(N'2022-06-02T12:40:43.987' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-02T12:40:43.987' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.987' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30137, 2, CAST(N'2022-06-02T12:40:43.990' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-02T12:40:43.990' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.990' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30138, 2, CAST(N'2022-06-02T12:40:43.993' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-02T12:40:43.993' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.993' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30139, 2, CAST(N'2022-06-02T12:40:43.997' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-02T12:40:43.997' AS DateTime), 1, CAST(N'2022-06-02T12:40:43.997' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30140, 1, CAST(N'2022-06-03T10:57:58.550' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T10:57:58.550' AS DateTime), 1, CAST(N'2022-06-03T10:57:58.550' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30141, 1, CAST(N'2022-06-03T10:58:36.443' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T10:58:36.443' AS DateTime), 1, CAST(N'2022-06-03T10:58:36.443' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30142, 1, CAST(N'2022-06-03T10:58:36.460' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T10:58:36.460' AS DateTime), 1, CAST(N'2022-06-03T10:58:36.460' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30143, 2, CAST(N'2022-06-03T11:19:37.387' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T11:19:37.387' AS DateTime), 1, CAST(N'2022-06-03T11:19:37.387' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30144, 2, CAST(N'2022-06-03T11:19:37.407' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T11:19:37.407' AS DateTime), 1, CAST(N'2022-06-03T11:19:37.407' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30145, 2, CAST(N'2022-06-03T12:12:54.657' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:12:54.657' AS DateTime), 1, CAST(N'2022-06-03T12:12:54.657' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30146, 2, CAST(N'2022-06-03T12:12:54.677' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:12:54.677' AS DateTime), 1, CAST(N'2022-06-03T12:12:54.677' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30147, 2, CAST(N'2022-06-03T12:14:55.797' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:14:55.797' AS DateTime), 1, CAST(N'2022-06-03T12:14:55.797' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30148, 2, CAST(N'2022-06-03T12:17:53.990' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:17:53.990' AS DateTime), 1, CAST(N'2022-06-03T12:17:53.990' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30149, 2, CAST(N'2022-06-03T12:50:38.427' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:50:38.427' AS DateTime), 1, CAST(N'2022-06-03T12:50:38.427' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30150, 2, CAST(N'2022-06-03T12:50:38.430' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:50:38.430' AS DateTime), 1, CAST(N'2022-06-03T12:50:38.430' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30151, 2, CAST(N'2022-06-03T12:50:38.433' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:50:38.433' AS DateTime), 1, CAST(N'2022-06-03T12:50:38.433' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30152, 2, CAST(N'2022-06-03T12:50:58.853' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:50:58.853' AS DateTime), 1, CAST(N'2022-06-03T12:50:58.853' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30153, 2, CAST(N'2022-06-03T12:51:28.410' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:51:28.410' AS DateTime), 1, CAST(N'2022-06-03T12:51:28.410' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30154, 2, CAST(N'2022-06-03T12:53:25.860' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:53:25.860' AS DateTime), 1, CAST(N'2022-06-03T12:53:25.860' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30155, 2, CAST(N'2022-06-03T12:55:06.097' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T12:55:06.097' AS DateTime), 1, CAST(N'2022-06-03T12:55:06.097' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30156, 2, CAST(N'2022-06-03T13:13:59.990' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T13:13:59.990' AS DateTime), 1, CAST(N'2022-06-03T13:13:59.990' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30157, 2, CAST(N'2022-06-03T13:14:42.930' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T13:14:42.930' AS DateTime), 1, CAST(N'2022-06-03T13:14:42.930' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30158, 2, CAST(N'2022-06-03T13:15:27.780' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-06-03T13:15:27.780' AS DateTime), 1, CAST(N'2022-06-03T13:15:27.780' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30159, 2, CAST(N'2022-06-03T13:15:27.783' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T13:15:27.783' AS DateTime), 1, CAST(N'2022-06-03T13:15:27.783' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30160, 2, CAST(N'2022-06-03T13:17:52.897' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T13:17:52.897' AS DateTime), 1, CAST(N'2022-06-03T13:17:52.897' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30161, 2, CAST(N'2022-06-03T13:17:52.897' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T13:17:52.900' AS DateTime), 1, CAST(N'2022-06-03T13:17:52.900' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30162, 2, CAST(N'2022-06-03T13:18:32.017' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-06-03T13:18:32.017' AS DateTime), 1, CAST(N'2022-06-03T13:18:32.017' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30163, 1, CAST(N'2022-06-03T13:20:37.093' AS DateTime), N'21', 1, 0, 1, CAST(N'2022-06-03T13:20:37.093' AS DateTime), 1, CAST(N'2022-06-03T13:20:37.093' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30164, 2, CAST(N'2022-06-03T13:21:20.053' AS DateTime), N'sda', 1, 0, 1, CAST(N'2022-06-03T13:21:20.053' AS DateTime), 1, CAST(N'2022-06-03T13:21:20.053' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30165, 1, CAST(N'2022-06-03T13:28:09.150' AS DateTime), N'asasdasd', 1, 0, 1, CAST(N'2022-06-03T13:28:09.150' AS DateTime), 1, CAST(N'2022-06-03T13:28:09.150' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30166, 1, CAST(N'2022-06-03T14:25:02.310' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T14:25:02.310' AS DateTime), 1, CAST(N'2022-06-03T14:25:02.310' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30167, 2, CAST(N'2022-06-03T14:26:36.000' AS DateTime), N'qw', 1, 0, 1, CAST(N'2022-06-03T14:26:36.000' AS DateTime), 1, CAST(N'2022-06-03T14:26:36.000' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30168, 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30169, 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), 1, CAST(N'2022-06-03T14:27:00.300' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30170, 2, CAST(N'2022-06-03T14:27:13.060' AS DateTime), N'', 1, 0, 1, CAST(N'2022-06-03T14:27:13.060' AS DateTime), 1, CAST(N'2022-06-03T14:27:13.060' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30171, 1, CAST(N'2022-06-03T14:29:00.890' AS DateTime), N'dds', 1, 0, 1, CAST(N'2022-06-03T14:29:00.890' AS DateTime), 1, CAST(N'2022-06-03T14:29:00.890' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30172, 2, CAST(N'2022-06-03T14:29:20.150' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-06-03T14:29:20.150' AS DateTime), 1, CAST(N'2022-06-03T14:29:20.150' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30173, 1, CAST(N'2022-06-03T14:29:53.707' AS DateTime), N'ds', 1, 0, 1, CAST(N'2022-06-03T14:29:53.707' AS DateTime), 1, CAST(N'2022-06-03T14:29:53.707' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30174, 2, CAST(N'2022-06-03T15:46:35.860' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-06-03T15:46:35.860' AS DateTime), 1, CAST(N'2022-06-03T15:46:35.860' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (30175, 1, CAST(N'2022-06-03T15:51:30.550' AS DateTime), N'as', 1, 0, 1, CAST(N'2022-06-03T15:51:30.550' AS DateTime), 1, CAST(N'2022-06-03T15:51:30.550' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40133, 1, CAST(N'2022-08-08T10:39:17.350' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:39:17.350' AS DateTime), 1, CAST(N'2022-08-08T10:39:17.350' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40134, 2, CAST(N'2022-08-08T10:43:38.413' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:38.413' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.413' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40135, 2, CAST(N'2022-08-08T10:43:38.417' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:38.417' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.417' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40136, 2, CAST(N'2022-08-08T10:43:38.420' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40137, 2, CAST(N'2022-08-08T10:43:38.420' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime), 1, CAST(N'2022-08-08T10:43:38.420' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40138, 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40139, 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.343' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40140, 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40141, 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), 1, CAST(N'2022-08-08T10:43:59.347' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40142, 2, CAST(N'2022-08-08T11:06:58.893' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.893' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.893' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40143, 2, CAST(N'2022-08-08T11:06:58.897' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.897' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.897' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40144, 2, CAST(N'2022-08-08T11:06:58.900' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40145, 2, CAST(N'2022-08-08T11:06:58.900' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40146, 2, CAST(N'2022-08-08T11:06:58.900' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.900' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40147, 2, CAST(N'2022-08-08T11:06:58.903' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.903' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.903' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40148, 2, CAST(N'2022-08-08T11:06:58.903' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.903' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.903' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40149, 2, CAST(N'2022-08-08T11:06:58.907' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime), 1, CAST(N'2022-08-08T11:06:58.907' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40150, 1, CAST(N'2022-08-08T11:20:00.737' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:20:00.737' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.737' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40151, 1, CAST(N'2022-08-08T11:20:00.757' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:20:00.757' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.757' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40152, 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40153, 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.773' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40154, 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40155, 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), 1, CAST(N'2022-08-08T11:20:00.777' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40156, 2, CAST(N'2022-08-08T11:48:25.130' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:48:25.130' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.130' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40157, 2, CAST(N'2022-08-08T11:48:25.150' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:48:25.150' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.150' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40158, 2, CAST(N'2022-08-08T11:48:25.170' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:48:25.170' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.170' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40159, 2, CAST(N'2022-08-08T11:48:25.173' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (40160, 2, CAST(N'2022-08-08T11:48:25.173' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime), 1, CAST(N'2022-08-08T11:48:25.173' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50133, 2, CAST(N'2022-08-09T17:52:44.493' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-09T17:52:44.493' AS DateTime), 1, CAST(N'2022-08-09T17:52:44.493' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50134, 2, CAST(N'2022-08-09T17:52:44.513' AS DateTime), N'', 1, 0, 1, CAST(N'2022-08-09T17:52:44.513' AS DateTime), 1, CAST(N'2022-08-09T17:52:44.513' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50135, 2, CAST(N'2022-08-10T10:12:17.707' AS DateTime), N'asdsa', 1, 0, 1, CAST(N'2022-08-10T10:12:17.707' AS DateTime), 1, CAST(N'2022-08-10T10:12:17.707' AS DateTime), N'A', N'asd')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50136, 1, CAST(N'2022-08-31T16:32:16.747' AS DateTime), N'123', 1, 0, 1, CAST(N'2022-08-31T16:32:16.747' AS DateTime), 1, CAST(N'2022-08-31T16:32:16.747' AS DateTime), N'A', N'121')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50137, 2, CAST(N'2022-09-30T13:02:40.990' AS DateTime), N'', 1, 0, 1, CAST(N'2022-09-30T13:02:40.990' AS DateTime), 1, CAST(N'2022-09-30T13:02:40.993' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50138, 1, CAST(N'2022-09-30T14:57:58.057' AS DateTime), N'', 1, 0, 1, CAST(N'2022-09-30T14:57:58.057' AS DateTime), 1, CAST(N'2022-09-30T14:57:58.057' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50139, 1, CAST(N'2022-10-12T17:45:15.030' AS DateTime), N'Transaction Move test 78945', 2, 0, 1, CAST(N'2022-10-12T17:45:15.030' AS DateTime), 1, CAST(N'2022-10-12T17:45:15.030' AS DateTime), N'A', NULL)
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50140, 1, CAST(N'2022-10-12T17:47:36.190' AS DateTime), N'Transaction Move test 78945', 2, 0, 1, CAST(N'2022-10-12T17:47:36.190' AS DateTime), 1, CAST(N'2022-10-12T17:47:36.190' AS DateTime), N'A', NULL)
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (50141, 1, CAST(N'2022-10-12T17:48:41.263' AS DateTime), N'Transaction Move test 78945', 2, 0, 1, CAST(N'2022-10-12T17:48:41.263' AS DateTime), 1, CAST(N'2022-10-12T17:48:41.263' AS DateTime), N'A', NULL)
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60139, 2, CAST(N'2022-11-17T13:06:54.393' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T13:06:54.397' AS DateTime), 1, CAST(N'2022-11-17T13:06:54.397' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60140, 1, CAST(N'2022-11-17T13:07:05.407' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T13:07:05.407' AS DateTime), 1, CAST(N'2022-11-17T13:07:05.407' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60141, 1, CAST(N'2022-11-17T13:07:05.550' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T13:07:05.550' AS DateTime), 1, CAST(N'2022-11-17T13:07:05.550' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60142, 2, CAST(N'2022-11-17T13:07:18.507' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T13:07:18.507' AS DateTime), 1, CAST(N'2022-11-17T13:07:18.507' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60143, 1, CAST(N'2022-11-17T13:07:29.523' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T13:07:29.523' AS DateTime), 1, CAST(N'2022-11-17T13:07:29.523' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60144, 1, CAST(N'2022-11-17T16:13:13.897' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T16:13:13.897' AS DateTime), 1, CAST(N'2022-11-17T16:13:13.897' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60145, 2, CAST(N'2022-11-17T16:18:34.707' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T16:18:34.707' AS DateTime), 1, CAST(N'2022-11-17T16:18:34.707' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60146, 1, CAST(N'2022-11-17T16:22:52.177' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T16:22:52.177' AS DateTime), 1, CAST(N'2022-11-17T16:22:52.177' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60147, 1, CAST(N'2022-11-17T16:22:52.477' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T16:22:52.477' AS DateTime), 1, CAST(N'2022-11-17T16:22:52.477' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60148, 2, CAST(N'2022-11-17T16:40:39.927' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T16:40:39.927' AS DateTime), 1, CAST(N'2022-11-17T16:40:39.927' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60149, 1, CAST(N'2022-11-17T16:45:33.297' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T16:45:33.297' AS DateTime), 1, CAST(N'2022-11-17T16:45:33.297' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60150, 1, CAST(N'2022-11-17T16:45:35.533' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T16:45:35.533' AS DateTime), 1, CAST(N'2022-11-17T16:45:35.533' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60151, 2, CAST(N'2022-11-17T17:13:16.767' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:13:16.767' AS DateTime), 1, CAST(N'2022-11-17T17:13:16.767' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60152, 2, CAST(N'2022-11-17T17:13:19.837' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:13:19.837' AS DateTime), 1, CAST(N'2022-11-17T17:13:19.837' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60153, 1, CAST(N'2022-11-17T17:13:26.430' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:13:26.430' AS DateTime), 1, CAST(N'2022-11-17T17:13:26.430' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60154, 2, CAST(N'2022-11-17T17:42:29.370' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:42:29.370' AS DateTime), 1, CAST(N'2022-11-17T17:42:29.370' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60155, 2, CAST(N'2022-11-17T17:42:29.733' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:42:29.733' AS DateTime), 1, CAST(N'2022-11-17T17:42:29.733' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60156, 1, CAST(N'2022-11-17T17:42:42.157' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:42:42.157' AS DateTime), 1, CAST(N'2022-11-17T17:42:42.157' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60157, 1, CAST(N'2022-11-17T17:42:54.640' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:42:54.640' AS DateTime), 1, CAST(N'2022-11-17T17:42:54.640' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60158, 2, CAST(N'2022-11-17T17:43:07.980' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:43:07.980' AS DateTime), 1, CAST(N'2022-11-17T17:43:07.980' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60159, 1, CAST(N'2022-11-17T17:43:26.387' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:43:26.387' AS DateTime), 1, CAST(N'2022-11-17T17:43:26.387' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60160, 1, CAST(N'2022-11-17T17:43:26.850' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:43:26.850' AS DateTime), 1, CAST(N'2022-11-17T17:43:26.850' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60161, 2, CAST(N'2022-11-17T17:44:21.710' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:44:21.710' AS DateTime), 1, CAST(N'2022-11-17T17:44:21.710' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60162, 2, CAST(N'2022-11-17T17:44:29.717' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:44:29.717' AS DateTime), 1, CAST(N'2022-11-17T17:44:29.717' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60163, 1, CAST(N'2022-11-17T17:44:43.713' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:44:43.713' AS DateTime), 1, CAST(N'2022-11-17T17:44:43.713' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60164, 1, CAST(N'2022-11-17T17:44:45.610' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:44:45.610' AS DateTime), 1, CAST(N'2022-11-17T17:44:45.610' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60165, 2, CAST(N'2022-11-17T17:44:52.770' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:44:52.770' AS DateTime), 1, CAST(N'2022-11-17T17:44:52.770' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60166, 2, CAST(N'2022-11-17T17:44:58.300' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-17T17:44:58.300' AS DateTime), 1, CAST(N'2022-11-17T17:44:58.300' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60167, 1, CAST(N'2022-11-18T16:31:14.873' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:31:14.873' AS DateTime), 1, CAST(N'2022-11-18T16:31:14.873' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60168, 1, CAST(N'2022-11-18T16:31:21.503' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:31:21.503' AS DateTime), 1, CAST(N'2022-11-18T16:31:21.503' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60169, 2, CAST(N'2022-11-18T16:31:30.470' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:31:30.470' AS DateTime), 1, CAST(N'2022-11-18T16:31:30.470' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60170, 2, CAST(N'2022-11-18T16:31:30.533' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:31:30.533' AS DateTime), 1, CAST(N'2022-11-18T16:31:30.533' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60171, 1, CAST(N'2022-11-18T16:31:45.130' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:31:45.130' AS DateTime), 1, CAST(N'2022-11-18T16:31:45.130' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60172, 2, CAST(N'2022-11-18T16:35:35.920' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:35:35.923' AS DateTime), 1, CAST(N'2022-11-18T16:35:35.923' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60173, 2, CAST(N'2022-11-18T16:35:42.023' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:35:42.023' AS DateTime), 1, CAST(N'2022-11-18T16:35:42.023' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60174, 1, CAST(N'2022-11-18T16:35:56.250' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:35:56.250' AS DateTime), 1, CAST(N'2022-11-18T16:35:56.250' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60175, 2, CAST(N'2022-11-18T16:38:10.677' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:38:10.677' AS DateTime), 1, CAST(N'2022-11-18T16:38:10.677' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60176, 1, CAST(N'2022-11-18T16:38:34.000' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:38:34.000' AS DateTime), 1, CAST(N'2022-11-18T16:38:34.000' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60177, 1, CAST(N'2022-11-18T16:38:34.537' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:38:34.537' AS DateTime), 1, CAST(N'2022-11-18T16:38:34.537' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60178, 2, CAST(N'2022-11-18T16:45:59.153' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:45:59.153' AS DateTime), 1, CAST(N'2022-11-18T16:45:59.153' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60179, 1, CAST(N'2022-11-18T16:46:09.310' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:46:09.310' AS DateTime), 1, CAST(N'2022-11-18T16:46:09.310' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60180, 2, CAST(N'2022-11-18T16:47:43.590' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:47:43.590' AS DateTime), 1, CAST(N'2022-11-18T16:47:43.590' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60181, 2, CAST(N'2022-11-18T16:47:49.153' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:47:49.153' AS DateTime), 1, CAST(N'2022-11-18T16:47:49.153' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60182, 1, CAST(N'2022-11-18T16:50:02.020' AS DateTime), N'AC', 1, 0, 1, CAST(N'2022-11-18T16:50:02.020' AS DateTime), 1, CAST(N'2022-11-18T16:50:02.020' AS DateTime), N'A', N'12')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60183, 2, CAST(N'2022-11-18T16:50:22.500' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:50:22.500' AS DateTime), 1, CAST(N'2022-11-18T16:50:22.500' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60184, 1, CAST(N'2022-11-18T16:50:56.723' AS DateTime), N'ABC', 1, 0, 1, CAST(N'2022-11-18T16:50:56.723' AS DateTime), 1, CAST(N'2022-11-18T16:50:56.723' AS DateTime), N'A', N'a')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60185, 2, CAST(N'2022-11-18T16:51:13.647' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:51:13.647' AS DateTime), 1, CAST(N'2022-11-18T16:51:13.647' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60186, 1, CAST(N'2022-11-18T16:51:55.187' AS DateTime), N'AB', 1, 0, 1, CAST(N'2022-11-18T16:51:55.187' AS DateTime), 1, CAST(N'2022-11-18T16:51:55.187' AS DateTime), N'A', N'12')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60187, 2, CAST(N'2022-11-18T16:57:35.320' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:57:35.320' AS DateTime), 1, CAST(N'2022-11-18T16:57:35.320' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60188, 1, CAST(N'2022-11-18T16:59:30.070' AS DateTime), N'ABC', 1, 0, 1, CAST(N'2022-11-18T16:59:30.073' AS DateTime), 1, CAST(N'2022-11-18T16:59:30.073' AS DateTime), N'A', N'12')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60189, 1, CAST(N'2022-11-18T16:59:33.967' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-11-18T16:59:33.967' AS DateTime), 1, CAST(N'2022-11-18T16:59:33.967' AS DateTime), N'A', N'as')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60190, 2, CAST(N'2022-11-18T16:59:47.010' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-18T16:59:47.010' AS DateTime), 1, CAST(N'2022-11-18T16:59:47.010' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60191, 1, CAST(N'2022-11-21T18:11:46.503' AS DateTime), N'asd', 1, 0, 1, CAST(N'2022-11-21T18:11:46.503' AS DateTime), 1, CAST(N'2022-11-21T18:11:46.503' AS DateTime), N'A', N'asd')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60192, 2, CAST(N'2022-11-21T18:13:10.373' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-21T18:13:10.373' AS DateTime), 1, CAST(N'2022-11-21T18:13:10.373' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60193, 2, CAST(N'2022-11-21T18:13:16.040' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-21T18:13:16.040' AS DateTime), 1, CAST(N'2022-11-21T18:13:16.040' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (60194, 1, CAST(N'2022-11-21T18:13:20.227' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-21T18:13:20.227' AS DateTime), 1, CAST(N'2022-11-21T18:13:20.227' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70139, 2, CAST(N'2022-11-24T14:17:09.640' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:17:09.640' AS DateTime), 1, CAST(N'2022-11-24T14:17:09.640' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70140, 1, CAST(N'2022-11-24T14:17:33.083' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:17:33.083' AS DateTime), 1, CAST(N'2022-11-24T14:17:33.083' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70141, 2, CAST(N'2022-11-24T14:20:24.230' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:20:24.230' AS DateTime), 1, CAST(N'2022-11-24T14:20:24.230' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70142, 2, CAST(N'2022-11-24T14:20:24.770' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:20:24.770' AS DateTime), 1, CAST(N'2022-11-24T14:20:24.770' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70143, 1, CAST(N'2022-11-24T14:22:34.183' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:22:34.183' AS DateTime), 1, CAST(N'2022-11-24T14:22:34.183' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70144, 1, CAST(N'2022-11-24T14:22:38.910' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:22:38.910' AS DateTime), 1, CAST(N'2022-11-24T14:22:38.910' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70145, 2, CAST(N'2022-11-24T14:22:48.780' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:22:48.780' AS DateTime), 1, CAST(N'2022-11-24T14:22:48.780' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70146, 1, CAST(N'2022-11-24T14:25:07.850' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:25:07.850' AS DateTime), 1, CAST(N'2022-11-24T14:25:07.850' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70147, 2, CAST(N'2022-11-24T14:29:28.260' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:29:28.260' AS DateTime), 1, CAST(N'2022-11-24T14:29:28.260' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70148, 2, CAST(N'2022-11-24T14:29:34.300' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:29:34.300' AS DateTime), 1, CAST(N'2022-11-24T14:29:34.300' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70149, 1, CAST(N'2022-11-24T14:37:55.557' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:37:55.557' AS DateTime), 1, CAST(N'2022-11-24T14:37:55.557' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (70150, 2, CAST(N'2022-11-24T14:38:18.087' AS DateTime), N'', 1, 0, 1, CAST(N'2022-11-24T14:38:18.087' AS DateTime), 1, CAST(N'2022-11-24T14:38:18.087' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (80139, 1, CAST(N'2022-12-05T17:54:34.147' AS DateTime), N'', 1, 0, 1, CAST(N'2022-12-05T17:54:34.147' AS DateTime), 1, CAST(N'2022-12-05T17:54:34.147' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90139, 2, CAST(N'2022-12-27T17:35:07.717' AS DateTime), N'', 1, 0, 1, CAST(N'2022-12-27T17:35:07.717' AS DateTime), 1, CAST(N'2022-12-27T17:35:07.717' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90140, 1, CAST(N'2022-12-27T17:35:53.163' AS DateTime), N'', 1, 0, 1, CAST(N'2022-12-27T17:35:53.163' AS DateTime), 1, CAST(N'2022-12-27T17:35:53.163' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90141, 1, CAST(N'2022-12-27T17:35:58.863' AS DateTime), N'', 1, 0, 1, CAST(N'2022-12-27T17:35:58.863' AS DateTime), 1, CAST(N'2022-12-27T17:35:58.863' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90142, 2, CAST(N'2022-12-27T17:36:14.053' AS DateTime), N'', 1, 0, 1, CAST(N'2022-12-27T17:36:14.053' AS DateTime), 1, CAST(N'2022-12-27T17:36:14.053' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90143, 2, CAST(N'2022-12-27T17:36:14.137' AS DateTime), N'', 1, 0, 1, CAST(N'2022-12-27T17:36:14.137' AS DateTime), 1, CAST(N'2022-12-27T17:36:14.137' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90144, 1, CAST(N'2023-01-05T12:30:17.817' AS DateTime), N'', 1, 0, 1, CAST(N'2023-01-05T12:30:17.817' AS DateTime), 1, CAST(N'2023-01-05T12:30:17.817' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90145, 2, CAST(N'2023-01-05T12:30:34.790' AS DateTime), N'', 1, 0, 1, CAST(N'2023-01-05T12:30:34.790' AS DateTime), 1, CAST(N'2023-01-05T12:30:34.790' AS DateTime), N'A', N'')
GO
INSERT [dbo].[TransactionHeader] ([TransactionId], [TransactionType], [TransactionDate], [Notes], [ScanType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Status], [Person]) VALUES (90146, 2, CAST(N'2023-01-05T12:30:36.823' AS DateTime), N'', 1, 0, 1, CAST(N'2023-01-05T12:30:36.823' AS DateTime), 1, CAST(N'2023-01-05T12:30:36.823' AS DateTime), N'A', N'')
GO
SET IDENTITY_INSERT [dbo].[TransactionHeader] OFF
GO
SET IDENTITY_INSERT [dbo].[UserGroupMaster] ON 
GO
INSERT [dbo].[UserGroupMaster] ([UserGroupId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'', N'Administrator', 1, 1, CAST(N'2022-04-20T12:49:44.930' AS DateTime), 5, CAST(N'2022-05-12T12:24:29.400' AS DateTime))
GO
INSERT [dbo].[UserGroupMaster] ([UserGroupId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'UG002', N'Employee', 1, 1, CAST(N'2022-04-25T16:11:42.867' AS DateTime), 5, CAST(N'2022-05-12T12:25:41.033' AS DateTime))
GO
INSERT [dbo].[UserGroupMaster] ([UserGroupId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'', N'ADMINISTRATOR', 0, 5, CAST(N'2022-05-12T12:27:08.677' AS DateTime), 1, CAST(N'2022-08-04T17:41:56.730' AS DateTime))
GO
INSERT [dbo].[UserGroupMaster] ([UserGroupId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'', N'SUPERVISOR', 0, 5, CAST(N'2022-05-12T12:27:27.060' AS DateTime), 1, CAST(N'2022-06-02T12:03:19.903' AS DateTime))
GO
INSERT [dbo].[UserGroupMaster] ([UserGroupId], [Code], [Name], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'', N'GATEKEEPER', 0, 5, CAST(N'2022-05-12T12:27:47.417' AS DateTime), 1, CAST(N'2022-05-12T15:58:57.903' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserGroupMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON 
GO
INSERT [dbo].[UserMaster] ([UserId], [UserGroupId], [Name], [UserName], [Password], [Email], [Phone], [UserType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DeviceID]) VALUES (1, 3, N'Admin', N'admin', N's2ieni2qCwI=', N'', N'', NULL, 0, 1, CAST(N'2022-04-20T12:49:44.930' AS DateTime), 1, CAST(N'2022-05-23T13:28:41.023' AS DateTime), NULL)
GO
INSERT [dbo].[UserMaster] ([UserId], [UserGroupId], [Name], [UserName], [Password], [Email], [Phone], [UserType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DeviceID]) VALUES (2, 2, N'Sanjay', N'sanjay', N'Sj3uj9kzZ/XvmP6rxBNZOw==', N'sanju@g.com', N'7897897890', NULL, 1, 1, CAST(N'2022-04-25T16:15:24.947' AS DateTime), 5, CAST(N'2022-05-12T12:24:24.663' AS DateTime), N'1')
GO
INSERT [dbo].[UserMaster] ([UserId], [UserGroupId], [Name], [UserName], [Password], [Email], [Phone], [UserType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DeviceID]) VALUES (3, 2, N'ABC', N'ABC', N's2ieni2qCwI=', N'', N'', NULL, 1, 1, CAST(N'2022-04-25T19:21:15.670' AS DateTime), 1, CAST(N'2022-05-12T11:33:57.827' AS DateTime), NULL)
GO
INSERT [dbo].[UserMaster] ([UserId], [UserGroupId], [Name], [UserName], [Password], [Email], [Phone], [UserType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DeviceID]) VALUES (4, NULL, N'Test', N'test', N's2ieni2qCwI=', N'', N'', NULL, 1, 0, CAST(N'2022-05-06T19:08:47.247' AS DateTime), 0, CAST(N'2022-05-06T19:09:55.670' AS DateTime), NULL)
GO
INSERT [dbo].[UserMaster] ([UserId], [UserGroupId], [Name], [UserName], [Password], [Email], [Phone], [UserType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DeviceID]) VALUES (5, 1, N'Nikhil Manwar', N'Nikhil', N's2ieni2qCwI=', N'nikhilmanwar@gmail.com', N'9876543210', NULL, 0, 1, CAST(N'2022-05-12T11:33:37.340' AS DateTime), 5, CAST(N'2022-05-12T11:56:08.167' AS DateTime), NULL)
GO
INSERT [dbo].[UserMaster] ([UserId], [UserGroupId], [Name], [UserName], [Password], [Email], [Phone], [UserType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DeviceID]) VALUES (6, 5, N'JAYESH CHAVDA', N'JAYESH', N's2ieni2qCwI=', N'JAYESH@GMAIL.COM', N'1234567890', NULL, 0, 5, CAST(N'2022-05-12T12:28:40.193' AS DateTime), 5, CAST(N'2022-05-12T12:28:40.193' AS DateTime), NULL)
GO
INSERT [dbo].[UserMaster] ([UserId], [UserGroupId], [Name], [UserName], [Password], [Email], [Phone], [UserType], [IsDelete], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DeviceID]) VALUES (7, 5, N'asdasdasdxZ', N'IJasdasd', N's2ieni2qCwI=', N'IJ@GMAIL.COM', N'123456789', NULL, 0, 5, CAST(N'2022-05-12T12:31:35.020' AS DateTime), 1, CAST(N'2022-05-12T16:14:29.597' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPermission] ON 
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (71, 2, 2)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (72, 2, 7)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20041, 1, 2)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20042, 1, 3)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20043, 1, 4)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20044, 1, 5)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20045, 1, 6)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20046, 1, 7)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20047, 1, 8)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20064, 5, 2)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20065, 5, 9)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20075, 4, 9)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20076, 4, 10)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (20077, 4, 11)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30066, 3, 3)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30067, 3, 4)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30068, 3, 5)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30069, 3, 6)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30070, 3, 7)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30071, 3, 8)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30072, 3, 9)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30073, 3, 13)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30074, 3, 12)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30075, 3, 10)
GO
INSERT [dbo].[UserPermission] ([UPId], [UserGroupId], [FormId]) VALUES (30076, 3, 11)
GO
SET IDENTITY_INSERT [dbo].[UserPermission] OFF
GO
ALTER TABLE [dbo].[AssetCategoryMaster] ADD  CONSTRAINT [DF_AssetCategoryMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[AssetImages] ADD  CONSTRAINT [DF_AssetImages_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[AssetMaster] ADD  CONSTRAINT [DF_AssetMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[AssetMaster] ADD  CONSTRAINT [DF_AssetMaster_IsMoveable]  DEFAULT ((1)) FOR [IsMoveable]
GO
ALTER TABLE [dbo].[AssetTagDetail] ADD  CONSTRAINT [DF_AssetTagDetail_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[AssetTypeMaster] ADD  CONSTRAINT [DF_Table_1_Active]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DeviceConfiguration] ADD  CONSTRAINT [DF_DeviceConfiguration_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[LocationMaster] ADD  CONSTRAINT [DF_LocationMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ManufacturerMaster] ADD  CONSTRAINT [DF_ManufacturerMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[PartMaster] ADD  CONSTRAINT [DF_PartMaster_IsExpire]  DEFAULT ((0)) FOR [IsExpire]
GO
ALTER TABLE [dbo].[PartMaster] ADD  CONSTRAINT [DF_PartMaster_IsSerial]  DEFAULT ((0)) FOR [IsSerial]
GO
ALTER TABLE [dbo].[PartMaster] ADD  CONSTRAINT [DF_PartMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[TransactionDetail] ADD  CONSTRAINT [DF_TransactionDetail_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[TransactionHeader] ADD  CONSTRAINT [DF_TransactionHeader_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[UserGroupMaster] ADD  CONSTRAINT [DF_UserGroupMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[AssetCategoryMaster]  WITH CHECK ADD  CONSTRAINT [FK_AssetCategoryMaster_AssetTypeMaster] FOREIGN KEY([AssetTypeId])
REFERENCES [dbo].[AssetTypeMaster] ([AssetTypeId])
GO
ALTER TABLE [dbo].[AssetCategoryMaster] CHECK CONSTRAINT [FK_AssetCategoryMaster_AssetTypeMaster]
GO
ALTER TABLE [dbo].[AssetImages]  WITH CHECK ADD  CONSTRAINT [FK_AssetImages_AssetMaster] FOREIGN KEY([AssetId])
REFERENCES [dbo].[AssetMaster] ([AssetId])
GO
ALTER TABLE [dbo].[AssetImages] CHECK CONSTRAINT [FK_AssetImages_AssetMaster]
GO
ALTER TABLE [dbo].[AssetMaster]  WITH CHECK ADD  CONSTRAINT [FK_AssetMaster_PartMaster] FOREIGN KEY([PartId])
REFERENCES [dbo].[PartMaster] ([PartId])
GO
ALTER TABLE [dbo].[AssetMaster] CHECK CONSTRAINT [FK_AssetMaster_PartMaster]
GO
ALTER TABLE [dbo].[AssetTagDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetTagDetail_AssetMaster] FOREIGN KEY([AssetId])
REFERENCES [dbo].[AssetMaster] ([AssetId])
GO
ALTER TABLE [dbo].[AssetTagDetail] CHECK CONSTRAINT [FK_AssetTagDetail_AssetMaster]
GO
ALTER TABLE [dbo].[AssetTagDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetTagDetail_LocationMaster] FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMaster] ([LocationId])
GO
ALTER TABLE [dbo].[AssetTagDetail] CHECK CONSTRAINT [FK_AssetTagDetail_LocationMaster]
GO
ALTER TABLE [dbo].[PartMaster]  WITH CHECK ADD  CONSTRAINT [FK_PartMaster_AssetCategoryMaster] FOREIGN KEY([AssetCategoryId])
REFERENCES [dbo].[AssetCategoryMaster] ([AssetCategoryId])
GO
ALTER TABLE [dbo].[PartMaster] CHECK CONSTRAINT [FK_PartMaster_AssetCategoryMaster]
GO
ALTER TABLE [dbo].[PartMaster]  WITH CHECK ADD  CONSTRAINT [FK_PartMaster_AssetTypeMaster] FOREIGN KEY([AssetTypeId])
REFERENCES [dbo].[AssetTypeMaster] ([AssetTypeId])
GO
ALTER TABLE [dbo].[PartMaster] CHECK CONSTRAINT [FK_PartMaster_AssetTypeMaster]
GO
ALTER TABLE [dbo].[PartMaster]  WITH CHECK ADD  CONSTRAINT [FK_PartMaster_ManufacturerMaster] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[ManufacturerMaster] ([ManufacturerId])
GO
ALTER TABLE [dbo].[PartMaster] CHECK CONSTRAINT [FK_PartMaster_ManufacturerMaster]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransactionDetail_AssetTagDetail] FOREIGN KEY([AssetTagId])
REFERENCES [dbo].[AssetTagDetail] ([AssetTagId])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_AssetTagDetail]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransactionDetail_LocationMaster] FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMaster] ([LocationId])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_LocationMaster]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransactionDetail_TransactionHeader] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[TransactionHeader] ([TransactionId])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_TransactionHeader]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_UserGroupMaster] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroupMaster] ([UserGroupId])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_UserGroupMaster]
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_FormMaster] FOREIGN KEY([FormId])
REFERENCES [dbo].[FormMaster] ([FormId])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_FormMaster]
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_UserGroupMaster] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroupMaster] ([UserGroupId])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_UserGroupMaster]
GO
/****** Object:  StoredProcedure [dbo].[SP_AllReports]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_AllReports]
	@Action int = 0,
	@AssetTypeId int =0,
	@AssetCategoryId int=0,
	@PartId bigint=0,
	@LocationId int=0,
	@AssetStatus int=0,
	@IdleAssetDate NVARCHAR(100)='',
	@Search nvarchar(max)='',
	@FromDate Date =null,
	@ToDate Date =null

	
AS
BEGIN

	begin tran
		begin try
			if(@Action=1)
			begin
			  --Transaction Report

				select T2.Name as PartName,T2.Description as PartDescription,
				T0.AssetName ,T0.SerialNumber,FORMAT(T0.ExpiryDate,'dd/MM/yyyy') as ExpiryDate,T0.Notes as AssetNotes,T5.Name as FromLocation,(CASE WHEN TH.TransactionType=1 THEN T6.Name ELSE '' END) as ToLocation,   
				T1.TagData as Tag,CASE WHEN TH.TransactionType=1 THEN 'In Stock' ELSE 'Checked Out' END as TransactionType,Format(TH.TransactionDate,'dd-MM-yyyy hh:mm tt') as TransactionDate,(CASE WHEN TH.Status='A' THEN 'Approve' ELSE 'Reject' END) as TransactionStatus,TH.Notes,TH.Person,T7.Name as TransactionBy 
				from TransactionHeader TH
				JOIN TransactionDetail TD on TD.TransactionId=TH.TransactionId and TD.IsDelete=0
				JOIN AssetTagDetail T1 on T1.AssetTagId=TD.AssetTagId and T1.IsDelete=0
				JOIN AssetMaster T0 on T0.AssetId=T1.AssetId
				JOIN PartMaster T2 on T2.PartId=T0.PartId 
				JOIN UserMaster T7 on T7.UserId=TH.CreatedBy
				LEFT JOIN LocationMaster T5 on T5.LocationId=TD.LastLocationId
				LEFT JOIN LocationMaster T6 on T6.LocationId=TD.LocationId

				Where T0.IsDelete=0 and 
				(Convert(date, TH.TransactionDate) between Convert(date,@FromDate) and Convert(date,@ToDate))and
				(@AssetTypeId=0 or T2.AssetTypeId=@AssetTypeId) and
				(@AssetCategoryId=0 or T2.AssetCategoryId=@AssetCategoryId) and
				(@PartId=0 or T0.PartId=@PartId) and
				(@LocationId=0 or T1.LocationId=@LocationId) and
				(@AssetStatus=0 or TH.TransactionType=@AssetStatus) and
				(isnull(@IdleAssetDate,'')='' or CONVERT(DATE, T0.ExpiryDate)=@IdleAssetDate) and
				(T2.Name like '%'+@Search+'%' or T2.Code like '%'+@Search+'%'or T0.AssetName like '%'+@Search+'%' or T0.SerialNumber like '%'+@Search+'%' or T1.TagData like '%'+@Search+'%')
				order by TH.TransactionDate

				
			end
			else if(@Action=2)
			begin
			  --Inventory Report
				

				select T3.Name as AssetType,T4.Name as AssetCategory,T2.Name as PartName,T2.Description as PartDescription,
				T0.AssetName ,T0.SerialNumber,FORMAT(T0.ExpiryDate,'dd/MM/yyyy') as ExpiryDate,T0.Notes as AssetNotes,T5.Code+' # '+T5.Name as Location,  
				T1.TagData as Tag,CASE WHEN T1.AssetStatus=1 THEN 'In Stock' ELSE 'Checked Out' END as AssetStatus,(CASE WHEN ISNULL(T0.IsMoveable,1)=1 THEN 'Yes' ELSE 'No' END) as IsAllowToMove
				from AssetMaster T0
				JOIN AssetTagDetail T1 on T1.AssetId=T0.AssetId and T1.IsDelete=0
				JOIN PartMaster T2 on T2.PartId=T0.PartId 
				JOIN AssetTypeMaster T3 on T3.AssetTypeId=T2.AssetTypeId
				JOIN AssetCategoryMaster T4 on T4.AssetCategoryId=T2.AssetCategoryId
				LEFT JOIN LocationMaster T5 on T5.LocationId=T1.LocationId
				Where T0.IsDelete=0 and (@AssetTypeId=0 or T2.AssetTypeId=@AssetTypeId) and
				(@AssetCategoryId=0 or T2.AssetCategoryId=@AssetCategoryId) and
				(@PartId=0 or T0.PartId=@PartId) and
				(@LocationId=0 or T1.LocationId=@LocationId) and
				(@AssetStatus=0 or T1.AssetStatus=@AssetStatus) and
				(isnull(@IdleAssetDate,'')='' or CONVERT(DATE, T0.ExpiryDate)=@IdleAssetDate) and
				(T2.Name like '%'+@Search+'%' or T2.Code like '%'+@Search+'%'or T0.AssetName like '%'+@Search+'%' or T0.SerialNumber like '%'+@Search+'%' or T1.TagData like '%'+@Search+'%')
				ORDER BY T2.Name,T0.AssetName,T1.TagData   --OFFSET ((@PageNumber - 1) * @RowspPage) ROWS FETCH NEXT @RowspPage ROWS ONLY; 

				
			end
			
		commit tran
	end try
	begin catch
		if(@@TRANCOUNT>0)
			rollback tran
	end catch
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAssettagdata]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetAssettagdata]
	@Action int = 0,
	@TagData  nvarchar(max)='',
	@LocationCode  nvarchar(max)=''
	
AS
BEGIN

	begin tran
		begin try
			if(@Action=1)
			begin
			    select T0.AssetTagId,T2.Name as PartNumber,T2.Description,T1.AssetName,T3.Name as FromLocation,T3.LocationId as FromLocationId,T0.TagData,(CASE WHEN T0.AssetStatus=1 THEN 'InStock' ELSE 'Checkout' END) as Status,
				T4.Name as ToLocation,t4.LocationId as ToLocationId,(CASE WHEN T0.AssetStatus=1 THEN 2 ELSE 1 END) as ToStatus,ISNULL(T1.IsMoveable,1) as IsMoveable
				from AssetTagDetail T0
				Join AssetMaster T1 on T1.AssetId=T0.AssetId and T1.IsDelete=0
				JOIN PartMaster T2  on T2.PartId=T1.PartId 
				LEFT JOIN LocationMaster T3 on T3.LocationId=T0.LocationId
				LEFT JOIN LocationMaster T4 on T4.Code=@LocationCode and T4.IsDelete=0
				where T0.IsDelete=0 and T0.TagData=@TagData

				
			end
			
		commit tran
	end try
	begin catch
		if(@@TRANCOUNT>0)
			rollback tran
	end catch
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetDashbordData]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetDashbordData]
	@Action int = 0
	
AS
BEGIN

	begin tran
		begin try
			if(@Action=1)
			begin
			
			    --Highest Checkout
			    select top 10 T2.Name as PartNumber,T2.Description,COUNT(1) as TotalCheckout
				from TransactionHeader TH
				Join TransactionDetail TD on TD.TransactionId=TH.TransactionId
				JOIN AssetTagDetail AD On AD.AssetTagId=TD.AssetTagId
				Join AssetMaster T1 on T1.AssetId=AD.AssetId and T1.IsDelete=0
				JOIN PartMaster T2  on T2.PartId=T1.PartId 
				where TH.IsDelete=0 and TH.TransactionType=2 and MONTH(Th.TransactionDate)=MONTH(GETDATE())
				GROUp BY T2.Name,T2.Description 
				Order by COUNT(1) desc

				--Location Total Part Asset
				select top 10 T3.Name as Location,COUNT(1) as TotalAsset
				from AssetTagDetail T0
				JOIN LocationMaster T3 on T3.LocationId=T0.LocationId
				where T0.IsDelete=0 
				GROUp BY T3.Name
				Order by COUNT(1) desc
				

				select 'Checked In - '+CONVERT(nvarchar(50),COUNT(1)) as Title,COUNT(1) as Total from AssetTagDetail where IsDelete=0 and AssetStatus=1
				UNION ALL
				select 'Checked Out - '+CONVERT(nvarchar(50),COUNT(1)) as Title,COUNT(1) as Total from AssetTagDetail where IsDelete=0 and AssetStatus=2
				
				
				select top 10 T2.Name as PartNumber,T1.AssetName,AD.TagData,(CASE WHEN TH.TransactionType=1 THEN 'InStock' ELSE 'Checkout' END) as TransactionType
				from TransactionHeader TH
				Join TransactionDetail TD on TD.TransactionId=TH.TransactionId
				JOIN AssetTagDetail AD On AD.AssetTagId=TD.AssetTagId
				Join AssetMaster T1 on T1.AssetId=AD.AssetId and T1.IsDelete=0
				JOIN PartMaster T2  on T2.PartId=T1.PartId 
				where TH.IsDelete=0 
				Order by TH.TransactionDate desc


			end
			
		commit tran
	end try
	begin catch
		if(@@TRANCOUNT>0)
			rollback tran
	end catch
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetManualAssettagdata]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec SP_GetManualAssettagdata 1,'Asset 001','',''
CREATE PROCEDURE [dbo].[SP_GetManualAssettagdata]
	@Action int = 0,
	@PartAsset  nvarchar(max)='',
	@Tag  nvarchar(max)='',
	@SerialNumber  nvarchar(max)='',
	@AssetStatus int=0
	
AS
BEGIN

	begin tran
		begin try
			if(@Action=1)
			begin
			    select top 25 T0.AssetTagId,T2.Name as PartNumber,T2.Description,T1.AssetName,T3.Name as FromLocation,T0.TagData,
                (CASE WHEN T0.AssetStatus=1 THEN 'InStock' ELSE 'Checkout' END) as Status
				from AssetTagDetail T0
				Join AssetMaster T1 on T1.AssetId=T0.AssetId and T1.IsDelete=0
				JOIN PartMaster T2  on T2.PartId=T1.PartId 
				LEFT JOIN LocationMaster T3 on T3.LocationId=T0.LocationId
				where T0.IsDelete=0 and T0.AssetStatus=@AssetStatus and (T1.AssetName like '%'+@PartAsset+'%' or T2.Name like '%'+@PartAsset+'%' )and( T0.TagData like '%'+@Tag+'%' ) and ( T1.SerialNumber like '%'+@SerialNumber+'%')
				
			end
			
		commit tran
	end try
	begin catch
		if(@@TRANCOUNT>0)
			rollback tran
	end catch
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InventoryReport]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InventoryReport]
	@Action int = 0,
	@AssetTypeId int =0,
	@AssetCategoryId int=0,
	@PartId bigint=0,
	@LocationId int=0,
	@AssetStatus int=0,
	@IdleAssetDate NVARCHAR(100)='',
	@Search nvarchar(max)=''
	
AS
BEGIN

	begin tran
		begin try
			if(@Action=1)
			begin
			  --Inventory Report
				--CREATE TABLE #TmpAssetTagDetail (TotalRecord int NOT NUll, AssetId bigint NOT NUll,AssetType nvarchar(100) null,AssetCategory nvarchar(100) null,PartNumber nvarchar(50) null,PartName nvarchar(150) null,PartDescription nvarchar(max) null,AssetName nvarchar(250) null,SerialNumber nvarchar(250) null,ExpiryDate nvarchar(50) null,AssetNotes nvarchar(max) null,Location nvarchar(200) null,TagData nvarchar(350) null,AssetStatus nvarchar(50) null)
				

				select T0.AssetId,T1.AssetTagId,T3.Name as AssetType,T4.Name as AssetCategory,T2.Code as PartNumber,T2.Name as PartName,T2.Description as PartDescription,
				T0.AssetName ,T0.SerialNumber,FORMAT(T0.ExpiryDate,'dd/MM/yyyy') as ExpiryDate,T0.Notes as AssetNotes,T5.Code+' # '+T5.Name as Location,  
				T1.TagData as Tag,CASE WHEN T1.AssetStatus=1 THEN 'In Stock' ELSE 'Checked Out' END as AssetStatus,CASE WHEN ISNULL(T0.IsMoveable,1)=1 THEN 'Yes' ELSE 'No' END as IsAllowToMove--,T6.AssetImage
				from AssetMaster T0
				JOIN AssetTagDetail T1 on T1.AssetId=T0.AssetId and T1.IsDelete=0
				JOIN PartMaster T2 on T2.PartId=T0.PartId 
				JOIN AssetTypeMaster T3 on T3.AssetTypeId=T2.AssetTypeId
				JOIN AssetCategoryMaster T4 on T4.AssetCategoryId=T2.AssetCategoryId
				LEFT JOIN LocationMaster T5 on T5.LocationId=T1.LocationId
				Where T0.IsDelete=0 and (@AssetTypeId=0 or T2.AssetTypeId=@AssetTypeId) and
				(@AssetCategoryId=0 or T2.AssetCategoryId=@AssetCategoryId) and
				(@PartId=0 or T0.PartId=@PartId) and
				(@LocationId=0 or T1.LocationId=@LocationId) and
				(@AssetStatus=0 or T1.AssetStatus=@AssetStatus) and
				(isnull(@IdleAssetDate,'')='' or CONVERT(DATE, T0.ExpiryDate)=@IdleAssetDate) and
				(T2.Name like '%'+@Search+'%' or T2.Code like '%'+@Search+'%'or T0.AssetName like '%'+@Search+'%' or T0.SerialNumber like '%'+@Search+'%' or T1.TagData like '%'+@Search+'%')
				ORDER BY T2.Name,T0.AssetName,T1.TagData   --OFFSET ((@PageNumber - 1) * @RowspPage) ROWS FETCH NEXT @RowspPage ROWS ONLY; 

				
			end
			
		commit tran
	end try
	begin catch
		if(@@TRANCOUNT>0)
			rollback tran
	end catch
END
GO
/****** Object:  StoredProcedure [dbo].[SPAPI_InventoryReport]    Script Date: 22-03-2023 16:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPAPI_InventoryReport]
	@Action int = 0,
	@AssetTypeId int =0,
	@AssetCategoryId int=0,
	@PartId bigint=0,
	@LocationId int=0,
	@AssetStatus int=0,
	@IdleAssetDate NVARCHAR(100)='',
	@Search nvarchar(max)='',
	@PageNumber bigint=1,
	@RowspPage  bigint=20
	
AS
BEGIN

	begin tran
		begin try
			if(@Action=1)
			begin
			  --Inventory Report
				CREATE TABLE #TmpAssetTagDetail (TotalRecord int NOT NUll, AssetId bigint NOT NUll,AssetType nvarchar(100) null,AssetCategory nvarchar(100) null,PartNumber nvarchar(50) null,PartName nvarchar(150) null,PartDescription nvarchar(max) null,AssetName nvarchar(250) null,SerialNumber nvarchar(250) null,ExpiryDate nvarchar(50) null,AssetNotes nvarchar(max) null,Location nvarchar(200) null,TagData nvarchar(350) null,AssetStatus nvarchar(50) null,IsMoveable nvarchar(50) null)
				

				INSERT INTO #TmpAssetTagDetail select count(T1.AssetTagId) over() as TotalRecord,T0.AssetId,T3.Name as AssetType,T4.Name as AssetCategory,T2.Code as PartNumber,T2.Name as PartName,T2.Description as PartDescription,
				T0.AssetName ,T0.SerialNumber,FORMAT(T0.ExpiryDate,'dd/MM/yyyy') as ExpiryDate,T0.Notes as AssetNotes,T5.Name as Location,  
				T1.TagData as Tag,CASE WHEN T1.AssetStatus=1 THEN 'In Stock' ELSE 'Checked Out' END as AssetStatus, (CASE WHEN ISNULL(T0.IsMoveable,0)=1 THEN 'Yes' ELSE 'No' END) as IsMoveable--,T6.AssetImage
				from AssetMaster T0
				JOIN AssetTagDetail T1 on T1.AssetId=T0.AssetId and T1.IsDelete=0
				JOIN PartMaster T2 on T2.PartId=T0.PartId 
				JOIN AssetTypeMaster T3 on T3.AssetTypeId=T2.AssetTypeId
				JOIN AssetCategoryMaster T4 on T4.AssetCategoryId=T2.AssetCategoryId
				LEFT JOIN LocationMaster T5 on T5.LocationId=T1.LocationId
				--LEFT JOIN AssetImages T6 on T6.AssetId=T0.AssetId
				Where T0.IsDelete=0 and (@AssetTypeId=0 or T2.AssetTypeId=@AssetTypeId) and
				(@AssetCategoryId=0 or T2.AssetCategoryId=@AssetCategoryId) and
				(@PartId=0 or T0.PartId=@PartId) and
				(@LocationId=0 or T1.LocationId=@LocationId) and
				(@AssetStatus=0 or T1.AssetStatus=@AssetStatus) and
				(isnull(@IdleAssetDate,'')='' or CONVERT(DATE, T0.ExpiryDate)=@IdleAssetDate) and
				(T2.Name like '%'+@Search+'%' or T2.Code like '%'+@Search+'%'or T0.AssetName like '%'+@Search+'%' or T0.SerialNumber like '%'+@Search+'%' or T1.TagData like '%'+@Search+'%')
				ORDER BY T2.Name,T0.AssetName,T1.TagData   OFFSET ((@PageNumber - 1) * @RowspPage) ROWS FETCH NEXT @RowspPage ROWS ONLY; 

				select T0.*,CASE WHEN ISNULL(T2.AssetImage,'')='' THEN '' ELSE '/Document/AssetImages/'+T2.AssetImage END as AssetImage from #TmpAssetTagDetail T0
				LEFT JOIN AssetImages T2 on T2.AssetId=t0.AssetId and T2.IsDelete=0


				DROP TABLE #TmpAssetTagDetail
			end
			
		commit tran
	end try
	begin catch
		if(@@TRANCOUNT>0)
			rollback tran
	end catch
END
GO
USE [master]
GO
ALTER DATABASE [NadaTech] SET  READ_WRITE 
GO
