USE [master]
GO
/****** Object:  Database [dope_uat]    Script Date: 09-12-2020 10:22:09 ******/
CREATE DATABASE [dope_uat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A4A30B_EDM_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dope_uat_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 512000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A4A30B_EDM_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dope_uat_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dope_uat] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dope_uat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dope_uat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dope_uat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dope_uat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dope_uat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dope_uat] SET ARITHABORT OFF 
GO
ALTER DATABASE [dope_uat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dope_uat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dope_uat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dope_uat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dope_uat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dope_uat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dope_uat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dope_uat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dope_uat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dope_uat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dope_uat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dope_uat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dope_uat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dope_uat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dope_uat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dope_uat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dope_uat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dope_uat] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dope_uat] SET  MULTI_USER 
GO
ALTER DATABASE [dope_uat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dope_uat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dope_uat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dope_uat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dope_uat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dope_uat] SET QUERY_STORE = OFF
GO
USE [dope_uat]
GO
/****** Object:  User [dope]    Script Date: 09-12-2020 10:22:10 ******/
CREATE USER [dope] FOR LOGIN [dope] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCategoryType]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetCategoryType](
    @Type	nvarchar(100)
)
RETURNS BIGINT
AS 
BEGIN
	DECLARE @TYPEID BIGINT = 0
    IF UPPER(@Type)='TRACK'
	BEGIN
		SET @TYPEID = 1
	END
	ELSE IF UPPER(@Type) = 'BEATS'
	BEGIN
		SET @TYPEID = 2
	END
	ELSE IF UPPER(@Type) = 'BLOG'
	BEGIN
		SET @TYPEID = 3
	END
	ELSE IF UPPER(@Type) = 'SERVICE'
	BEGIN
		SET @TYPEID = 4
	END
	ELSE IF UPPER(@Type) = 'NEWS'
	BEGIN
		SET @TYPEID = 5
	END
	RETURN @TYPEID
END;
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitString]
(
	@RowData NVARCHAR(MAX)
	,@SplitOn NVARCHAR(5)
)
RETURNS @RtnValue TABLE
(
	ID BIGINT IDENTITY(1,1)
	,[Item] NVARCHAR(MAX)
)
AS
BEGIN
	DECLARE @CNT BIGINT
	SET @CNT = 1

	WHILE (CHARINDEX(@SplitOn, @RowData) > 0)
	BEGIN
		INSERT INTO @RtnValue ([Item])
		SELECT [DATA] = LTRIM(RTRIM(SUBSTRING(@RowData, 1, CHARINDEX(@SplitOn, @RowData) - 1)))

		SET @RowData = SUBSTRING(@RowData, CHARINDEX(@SplitOn, @RowData) + 1, LEN(@RowData))
		SET @CNT = @CNT + 1
	END

	IF (LTRIM(RTRIM(@RowData)) NOT LIKE '')
	BEGIN
		INSERT INTO @RtnValue ([Item])
		SELECT Data = LTRIM(RTRIM(@RowData))
	END
	RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[SplitStrings]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitStrings]
(
	@RowData NVARCHAR(MAX)
	,@SplitOn NVARCHAR(5)
)
RETURNS @RtnValue TABLE
(
	ID BIGINT IDENTITY(1,1)
	,[Data] NVARCHAR(MAX)
)
AS
BEGIN
	DECLARE @CNT BIGINT
	SET @CNT = 1

	WHILE (CHARINDEX(@SplitOn, @RowData) > 0)
	BEGIN
		INSERT INTO @RtnValue (Data)
		SELECT [DATA] = LTRIM(RTRIM(SUBSTRING(@RowData, 1, CHARINDEX(@SplitOn, @RowData) - 1)))

		SET @RowData = SUBSTRING(@RowData, CHARINDEX(@SplitOn, @RowData) + 1, LEN(@RowData))
		SET @CNT = @CNT + 1
	END

	IF (LTRIM(RTRIM(@RowData)) NOT LIKE '')
	BEGIN
		INSERT INTO @RtnValue (Data)
		SELECT Data = LTRIM(RTRIM(@RowData))
	END
	RETURN
END
GO
/****** Object:  Table [dbo].[AuthorityDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorityDetails](
	[Ref_Authority_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AuthorityName] [nvarchar](100) NOT NULL,
	[AuthorityType] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BannerDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BannerDetails](
	[Ref_Banner_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BannerTitle] [nvarchar](500) NULL,
	[BannerPageName] [nvarchar](500) NULL,
	[Descripation] [nvarchar](max) NULL,
	[ViewOnHome] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogDetails](
	[Ref_Blog_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](500) NULL,
	[Blog] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_ActivityDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_ActivityDetails](
	[Ref_Activity_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ActivityName] [nvarchar](100) NOT NULL,
	[ActivityType] [nvarchar](100) NOT NULL,
	[ActivityFor] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_Category]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_Category](
	[Ref_Category_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Parent_ID] [bigint] NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
	[AliasName] [nvarchar](500) NULL,
	[CategoryUseBy] [bigint] NULL,
	[Description] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](max) NULL,
	[MetaKeywords] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_GEN_Category] PRIMARY KEY CLUSTERED 
(
	[Ref_Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_CategoryFAQMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_CategoryFAQMapping](
	[Ref_CategoryMapping_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_FAQ_ID] [bigint] NOT NULL,
	[Ref_Category_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_CouponDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_CouponDetails](
	[Ref_Coupon_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CouponCode] [nvarchar](50) NULL,
	[CouponUseBy] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[DiscountInPercentage] [decimal](18, 0) NULL,
	[DiscountInMax] [decimal](18, 0) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[OneTimeUse] [bit] NULL,
	[AudienceCount] [int] NULL,
	[OnlyForNewUsers] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_CouponObjectMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_CouponObjectMapping](
	[Ref_ObjectMapping_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Coupon_ID] [bigint] NOT NULL,
	[Ref_Object_ID] [bigint] NOT NULL,
	[ObjectType] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_DAW]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_DAW](
	[Ref_DAW_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DAW] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL,
 CONSTRAINT [PK_GEN_DAW] PRIMARY KEY CLUSTERED 
(
	[Ref_DAW_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_FAQ]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_FAQ](
	[Ref_FAQ_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedName] [nvarchar](255) NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedName] [nvarchar](255) NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_GEN_FAQ] PRIMARY KEY CLUSTERED 
(
	[Ref_FAQ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_FileManager]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_FileManager](
	[Ref_FileManager_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ModuleID] [bigint] NULL,
	[ModuleType] [nvarchar](100) NULL,
	[FileIdentifier] [nvarchar](100) NULL,
	[FileName] [nvarchar](500) NULL,
	[FilePath] [nvarchar](max) NULL,
	[FileExtension] [nvarchar](100) NULL,
	[FileType] [nvarchar](100) NULL,
	[FileSize] [bigint] NULL,
	[Sequence] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_GuestUserDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_GuestUserDetails](
	[Ref_GuestUser_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_GuestUser_GUID] [uniqueidentifier] NULL,
	[Ref_Device_GUID] [uniqueidentifier] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_GEN_GuestUserDetails] PRIMARY KEY CLUSTERED 
(
	[Ref_GuestUser_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_ModuleAccessMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_ModuleAccessMapping](
	[Ref_ModuleAccess_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Authority_ID] [bigint] NOT NULL,
	[Ref_Module_ID] [bigint] NOT NULL,
	[ViewAccess] [bit] NULL,
	[EditAccess] [bit] NULL,
	[DeleteAccess] [bit] NULL,
	[ApprovalAccess] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_Modules]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_Modules](
	[Ref_Module_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](100) NOT NULL,
	[ModuleIdentifier] [nvarchar](100) NULL,
	[ModuleType] [nvarchar](100) NULL,
	[ModuleFor] [nvarchar](100) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[ModuleUrl] [nvarchar](max) NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_OrderObjectMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_OrderObjectMapping](
	[Ref_OOM_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Order_ID] [bigint] NOT NULL,
	[Ref_Object_ID] [bigint] NOT NULL,
	[ObjectType] [nvarchar](100) NULL,
	[IncludeProjectFile] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_RequestOTP]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_RequestOTP](
	[Ref_OTP_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_User_ID] [bigint] NULL,
	[OTP] [nvarchar](500) NULL,
	[Flag] [nvarchar](100) NULL,
	[IsValidate] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_GEN_RequestOTP] PRIMARY KEY CLUSTERED 
(
	[Ref_OTP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_TicketDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_TicketDetails](
	[Ref_Ticket_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_TicketType_ID] [bigint] NOT NULL,
	[Ref_User_ID] [bigint] NULL,
	[Subject] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_TicketType]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_TicketType](
	[Ref_TicketType_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TicketType] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_GEN_TicketTypeMaster] PRIMARY KEY CLUSTERED 
(
	[Ref_TicketType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserCouponMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserCouponMapping](
	[Ref_UserMapping_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_User_ID] [bigint] NOT NULL,
	[Ref_Order_ID] [bigint] NULL,
	[Ref_Coupon_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMaster]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMaster](
	[Ref_UserMaster_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MasterName] [nvarchar](500) NULL,
	[ControlName] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[IsMandatory] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[Ref_UserMaster_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMasterAccessMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMasterAccessMapping](
	[Ref_MasterAccess_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Authority_ID] [bigint] NOT NULL,
	[Ref_UserMaster_ID] [bigint] NOT NULL,
	[Ref_UserMasterData_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMasterData]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMasterData](
	[Ref_UserMasterData_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_UserMaster_ID] [bigint] NOT NULL,
	[MasterDataName] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMasterDataParentChildRelationship]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMasterDataParentChildRelationship](
	[Ref_ParentChildRelationMasterData_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_UserMaster_ID] [bigint] NULL,
	[Ref_UserMasterData_ID] [bigint] NULL,
	[ParentID] [bigint] NULL,
	[IsMandatory] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_GEN_UserMasterDataParentChildRelationship] PRIMARY KEY CLUSTERED 
(
	[Ref_ParentChildRelationMasterData_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMasterMap]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMasterMap](
	[Ref_UserMasterMap_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_UserMasterData_ID] [bigint] NOT NULL,
	[Ref_UserMaster_ID] [bigint] NOT NULL,
	[Ref_User_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMasterParentChildRelationship]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMasterParentChildRelationship](
	[Ref_ParentChildRelationship_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_UserMaster_ID] [bigint] NOT NULL,
	[ParentID] [bigint] NULL,
	[IsMandatory] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_ParentChildRelationship] PRIMARY KEY CLUSTERED 
(
	[Ref_ParentChildRelationship_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserObjectActionMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserObjectActionMapping](
	[Ref_UOAM_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_User_ID] [bigint] NOT NULL,
	[Ref_Object_ID] [bigint] NOT NULL,
	[ObjectType] [nvarchar](100) NULL,
	[Action] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserOrderStatus]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserOrderStatus](
	[Ref_Order_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_User_ID] [bigint] NOT NULL,
	[OrderCode] [nvarchar](50) NULL,
	[OrderStatus] [nvarchar](100) NULL,
	[OrderDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProducerObjectMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProducerObjectMapping](
	[Ref_ObjectMapping_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_User_ID] [bigint] NOT NULL,
	[Ref_Object_ID] [bigint] NOT NULL,
	[ObjectType] [nvarchar](100) NULL,
	[ObjectValue] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceDetails](
	[Ref_Service_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Category_ID] [bigint] NOT NULL,
	[ServiceTitle] [nvarchar](500) NULL,
	[AliasName] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 0) NULL,
	[PriceWithProjectFiles] [decimal](18, 0) NULL,
	[DeliveryDate] [datetime] NULL,
	[Revision] [int] NULL,
	[MetaTitle] [nvarchar](max) NULL,
	[MetaKeywords] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceFAQMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceFAQMapping](
	[Ref_ServiceMapping_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_FAQ_ID] [bigint] NOT NULL,
	[Ref_Service_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedName] [nvarchar](255) NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedName] [nvarchar](255) NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_ServiceFAQMapping] PRIMARY KEY CLUSTERED 
(
	[Ref_ServiceMapping_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrackDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackDetails](
	[Ref_Track_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Category_ID] [bigint] NULL,
	[TrackType] [nvarchar](50) NULL,
	[TrackName] [nvarchar](500) NULL,
	[Bio] [nvarchar](max) NULL,
	[Mood] [nvarchar](max) NULL,
	[TrackKey] [nvarchar](max) NULL,
	[Tag] [nvarchar](max) NULL,
	[Duration] [nvarchar](100) NULL,
	[BMP] [int] NULL,
	[DAW] [nvarchar](500) NULL,
	[Price] [decimal](18, 0) NULL,
	[PriceWithProjectFiles] [decimal](18, 0) NULL,
	[IsVocals] [bit] NULL,
	[IsTrack] [bit] NULL,
	[IsActive] [bit] NULL,
	[TrackStatus] [nvarchar](100) NULL,
	[ReasonOfReject] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccountsDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccountsDetails](
	[Ref_UserUPI_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_User_ID] [bigint] NOT NULL,
	[UPI_ID] [nvarchar](500) NOT NULL,
	[BankName] [nvarchar](500) NULL,
	[AccountNo] [nvarchar](500) NULL,
	[IDFC_Code] [nvarchar](50) NULL,
	[EmailID] [nvarchar](100) NULL,
	[ExtraInfo] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Ref_User_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserCode] [nvarchar](200) NULL,
	[FullName] [nvarchar](255) NULL,
	[EmailID] [nvarchar](255) NULL,
	[MobileNumber] [nvarchar](20) NULL,
	[Bio] [nvarchar](150) NULL,
	[Gender] [nvarchar](30) NULL,
	[Password] [nvarchar](500) NULL,
	[AuthorityIDs] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[Ref_User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLoginWithDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLoginWithDetails](
	[Ref_LoginWith_ID] [bigint] NOT NULL,
	[LoginWith] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthorityDetails] ADD  CONSTRAINT [DF_AuthorityDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[AuthorityDetails] ADD  CONSTRAINT [DF_AuthorityDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[BannerDetails] ADD  CONSTRAINT [DF_BannerDetails_ViewOnHome]  DEFAULT ((0)) FOR [ViewOnHome]
GO
ALTER TABLE [dbo].[BannerDetails] ADD  CONSTRAINT [DF_BannerDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BannerDetails] ADD  CONSTRAINT [DF_BannerDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[BlogDetails] ADD  CONSTRAINT [DF_BlogDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BlogDetails] ADD  CONSTRAINT [DF_BlogDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_ActivityDetails] ADD  CONSTRAINT [DF_GEN_ActivityDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_ActivityDetails] ADD  CONSTRAINT [DF_GEN_ActivityDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_CategoryFAQMapping] ADD  CONSTRAINT [DF_GEN_CategoryFAQMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_CategoryFAQMapping] ADD  CONSTRAINT [DF_GEN_CategoryFAQMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_CouponDetails] ADD  CONSTRAINT [DF_GEN_CouponDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_CouponDetails] ADD  CONSTRAINT [DF_GEN_CouponDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_CouponObjectMapping] ADD  CONSTRAINT [DF_GEN_CouponObjectMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_CouponObjectMapping] ADD  CONSTRAINT [DF_GEN_CouponObjectMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_DAW] ADD  CONSTRAINT [DF_GEN_DAW_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_DAW] ADD  CONSTRAINT [DF_GEN_DAW_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_FileManager] ADD  CONSTRAINT [DF_Table_1_IsActive1]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_FileManager] ADD  CONSTRAINT [DF_Table_1_IsActive]  DEFAULT ((1)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[GEN_FileManager] ADD  CONSTRAINT [DF_GEN_FileManager_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_ModuleAccessMapping] ADD  CONSTRAINT [DF_GEN_ModuleAccessMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_ModuleAccessMapping] ADD  CONSTRAINT [DF_GEN_ModuleAccessMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_Modules] ADD  CONSTRAINT [DF_GEN_Modules_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_Modules] ADD  CONSTRAINT [DF_GEN_Modules_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_OrderObjectMapping] ADD  CONSTRAINT [DF_GEN_OrderObjectMapping_IncludeProjectFile]  DEFAULT ((0)) FOR [IncludeProjectFile]
GO
ALTER TABLE [dbo].[GEN_OrderObjectMapping] ADD  CONSTRAINT [DF_GEN_OrderObjectMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_OrderObjectMapping] ADD  CONSTRAINT [DF_GEN_OrderObjectMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_RequestOTP] ADD  CONSTRAINT [DF_GEN_RequestOTP_CreatedDateTime]  DEFAULT (getutcdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[GEN_RequestOTP] ADD  CONSTRAINT [DF_GEN_RequestOTP_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_RequestOTP] ADD  CONSTRAINT [DF_GEN_RequestOTP_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[GEN_UserCouponMapping] ADD  CONSTRAINT [DF_GEN_UserCouponMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserCouponMapping] ADD  CONSTRAINT [DF_GEN_UserCouponMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_UserMasterAccessMapping] ADD  CONSTRAINT [DF_GEN_UserMasterAccessMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserMasterAccessMapping] ADD  CONSTRAINT [DF_GEN_UserMasterAccessMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_UserMasterData] ADD  CONSTRAINT [DF_GEN_UserMasterData_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserMasterData] ADD  CONSTRAINT [DF_GEN_UserMasterData_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[GEN_UserMasterDataParentChildRelationship] ADD  CONSTRAINT [DF_GEN_UserMasterDataParentChildRelationship_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserMasterDataParentChildRelationship] ADD  CONSTRAINT [DF_GEN_UserMasterDataParentChildRelationship_CreatedDateTime]  DEFAULT (getutcdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[GEN_UserMasterMap] ADD  CONSTRAINT [DF_GEN_UserMasterMap_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserMasterMap] ADD  CONSTRAINT [DF_GEN_UserMasterMap_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_UserObjectActionMapping] ADD  CONSTRAINT [DF_GEN_UserObjectActionMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserObjectActionMapping] ADD  CONSTRAINT [DF_GEN_UserObjectActionMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[GEN_UserOrderStatus] ADD  CONSTRAINT [DF_GEN_UserOrderStatus_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserOrderStatus] ADD  CONSTRAINT [DF_GEN_UserOrderStatus_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[TrackDetails] ADD  CONSTRAINT [DF_TrackDetails_IsActive1]  DEFAULT ((1)) FOR [IsVocals]
GO
ALTER TABLE [dbo].[TrackDetails] ADD  CONSTRAINT [DF_TrackDetails_IsTrack]  DEFAULT ((1)) FOR [IsTrack]
GO
ALTER TABLE [dbo].[TrackDetails] ADD  CONSTRAINT [DF_TrackDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TrackDetails] ADD  CONSTRAINT [DF_TrackDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserAccountsDetails] ADD  CONSTRAINT [DF_GEN_User_UPI_Details_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserAccountsDetails] ADD  CONSTRAINT [DF_GEN_User_UPI_Details_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserLoginWithDetails] ADD  CONSTRAINT [DF_GEN_UserLoginWithDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserLoginWithDetails] ADD  CONSTRAINT [DF_GEN_UserLoginWithDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[AddModifyAuthority]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 25-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyAuthority] @Ref_Authority_ID BIGINT = 0
	,@AuthorityName NVARCHAR(200)
	,@AuthorityType NVARCHAR(200)=''
	,@Description NVARCHAR(MAX)=''
	,@MasterDataIDs NVARCHAR(MAX) = ''
	,@IsActive BIT = 1
	,@CreatedBy NVARCHAR(100) = ''
AS
BEGIN
	IF (
			@Ref_Authority_ID = 0
			OR @Ref_Authority_ID IS NULL
			)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM AuthorityDetails WITH (NOLOCK)
				WHERE AuthorityName = @AuthorityName
				)
		BEGIN
			INSERT INTO AuthorityDetails (
				AuthorityName
				,AuthorityType
				,[Description]
				,IsActive
				,CreatedBy
				,CreatedDate
				)
			VALUES (
				@AuthorityName
				,@AuthorityType
				,@Description
				,@IsActive
				,@CreatedBy
				,GETUTCDATE()
				)

			SET @Ref_Authority_ID = (
					SELECT SCOPE_IDENTITY()
					)

			INSERT INTO GEN_UserMasterAccessMapping (
				Ref_Authority_ID
				,Ref_UserMaster_ID
				,Ref_UserMasterData_ID
				,IsActive
				,CreatedBy
				,CreatedDate
				)
			SELECT @Ref_Authority_ID
				,Ref_UserMaster_ID
				,[Data]
				,1
				,@CreatedBy
				,GETUTCDATE()
			FROM dbo.SplitStrings(@MasterDataIDs, ',') SS
			INNER JOIN GEN_UserMasterData UMD WITH (NOLOCK) ON UMD.Ref_UserMasterData_ID = SS.[Data]

			SELECT @Ref_Authority_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END
	ELSE IF (@Ref_Authority_ID > 0)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM AuthorityDetails WITH (NOLOCK)
				WHERE AuthorityName = @AuthorityName
				)
		BEGIN
			UPDATE AuthorityDetails
			SET AuthorityName = @AuthorityName
			    ,AuthorityType=@AuthorityType
				,[Description] = @Description
				,IsActive = @IsActive
				,LastModifyBy = @CreatedBy
				,LastModifyDate = GETUTCDATE()
			WHERE Ref_Authority_ID = @Ref_Authority_ID

			DELETE GEN_ModuleAccessMapping
			WHERE Ref_Authority_ID = @Ref_Authority_ID

			DELETE GEN_UserMasterAccessMapping
			WHERE Ref_Authority_ID = @Ref_Authority_ID

			INSERT INTO GEN_UserMasterAccessMapping (
				Ref_Authority_ID
				,Ref_UserMaster_ID
				,Ref_UserMasterData_ID
				,IsActive
				,CreatedBy
				,CreatedDate
				)
			SELECT @Ref_Authority_ID
				,Ref_UserMaster_ID
				,[DATA]
				,1
				,@CreatedBy
				,GETUTCDATE()
			FROM dbo.SplitStrings(@MasterDataIDs, ',') SS
			INNER JOIN GEN_UserMasterData UMD WITH (NOLOCK) ON UMD.Ref_UserMasterData_ID = SS.[Data]

			SELECT @Ref_Authority_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyAuthorityModuleAccess]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 25-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyAuthorityModuleAccess] @Ref_Authority_ID BIGINT = 0
	,@Ref_Module_ID BIGINT
	,@View BIT = 1
	,@Edit BIT = 1
	,@Delete BIT = 1
	,@Approval BIT = 1
	,@CreatedBy NVARCHAR(100) = ''
AS
BEGIN
	INSERT INTO GEN_ModuleAccessMapping (
		Ref_Authority_ID
		,Ref_Module_ID
		,ViewAccess
		,EditAccess
		,DeleteAccess
		,ApprovalAccess
		,IsActive
		,CreatedBy
		,CreatedDate
		)
	VALUES (
		@Ref_Authority_ID
		,@Ref_Module_ID
		,@View
		,@Edit
		,@Delete
		,@Approval
		,1
		,@CreatedBy
		,GETUTCDATE()
		)
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyBannerDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 01-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyBannerDetails] @Ref_Banner_ID BIGINT = 0
	,@BannerTitle NVARCHAR(500)
	,@BannerPageName NVARCHAR(MAX) = ''
	,@Descripation NVARCHAR(MAX) = ''
	,@IsActive BIT = 0
	,@ViewOnHome BIT = 1
	,@CreatedBy NVARCHAR(100) = ''
AS
BEGIN
	IF (
			@Ref_Banner_ID = 0
			OR @Ref_Banner_ID IS NULL
			)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM BannerDetails WITH (NOLOCK)
				WHERE BannerTitle = @BannerTitle
				)
		BEGIN
			INSERT INTO BannerDetails (
				BannerTitle
				,BannerPageName
				,Descripation
				,IsActive
				,ViewOnHome
				,CreatedBy
				,CreatedDate
				)
			VALUES (
				@BannerTitle
				,@BannerPageName
				,@Descripation
				,@IsActive
				,@ViewOnHome
				,@CreatedBy
				,GETUTCDATE()
				)

			SET @Ref_Banner_ID=(
			           SELECT SCOPE_IDENTITY()
			          )

			SELECT @Ref_Banner_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END
	ELSE IF (@Ref_Banner_ID > 0)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM BannerDetails WITH (NOLOCK)
				WHERE BannerTitle = @BannerTitle
					AND Ref_Banner_ID <> @Ref_Banner_ID
				)
		BEGIN
			UPDATE BannerDetails
			SET BannerTitle = @BannerTitle
				,BannerPageName = @BannerPageName
				,Descripation = @Descripation
				,IsActive = @IsActive
				,ViewOnHome = @ViewOnHome
				,LastModifyBy = @CreatedBy
				,LastModifyDate = GETUTCDATE()
			WHERE Ref_Banner_ID = @Ref_Banner_ID

			SELECT @Ref_Banner_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyBlogDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 28-09-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyBlogDetails] @Ref_Blog_ID BIGINT = 0
	,@BlogTitle NVARCHAR(500)
	,@Blog NVARCHAR(MAX) = ''
	,@IsActive BIT = 0
	,@ViewOnHome BIT = 1
	,@CreatedBy NVARCHAR(100) = ''
AS
BEGIN
	IF (
			@Ref_Blog_ID = 0
			OR @Ref_Blog_ID IS NULL
			)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM BlogDetails WITH (NOLOCK)
				WHERE BlogTitle = @BlogTitle
				)
		BEGIN
			INSERT INTO BlogDetails (
				BlogTitle
				,Blog
				,IsActive
				,CreatedBy
				,CreatedDate
				)
			VALUES (
				@BlogTitle
				,@Blog
				,@IsActive
				,@CreatedBy
				,GETUTCDATE()
				)

			SET @Ref_Blog_ID=(
			           SELECT SCOPE_IDENTITY()
			          )

			SELECT @Ref_Blog_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END
	ELSE IF (@Ref_Blog_ID > 0)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM BlogDetails WITH (NOLOCK)
				WHERE BlogTitle = @BlogTitle
					AND Ref_Blog_ID <> @Ref_Blog_ID
				)
		BEGIN
			UPDATE BlogDetails
			SET BlogTitle = @BlogTitle
				,Blog = @Blog
				,IsActive = @IsActive
				,LastModifyBy = @CreatedBy
				,LastModifyDate = GETUTCDATE()
			WHERE Ref_Blog_ID = @Ref_Blog_ID

			SELECT @Ref_Blog_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyCategory]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 27-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyCategory] @Ref_Category_ID BIGINT = 0
	,@Ref_Parent_ID BIGINT = 0
	,@CategoryName NVARCHAR(500) = ''
	,@AliasName NVARCHAR(500) = ''
	,@Description NVARCHAR(MAX) = ''
	,@CategoryUseBy BIGINT = 0
	,@MetaTitle NVARCHAR(MAX) = ''
	,@MetaKeywords NVARCHAR(MAX) = ''
	,@MetaDescription NVARCHAR(MAX) = ''
	,@Ref_User_ID BIGINT = 0
AS
BEGIN
	IF @Ref_Category_ID = 0
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_Category WITH (NOLOCK)
				WHERE CategoryName = @CategoryName
					AND IsActive = 1
					AND IsDeleted = 0
				)
		BEGIN
			INSERT INTO GEN_Category (
				Ref_Parent_ID
				,CategoryName
				,AliasName
				,[Description]
				,CategoryUseBy
				,MetaTitle
				,MetaKeywords
				,MetaDescription
				,IsActive
				,IsDeleted
				,CreatedBy
				,CreatedDateTime
				)
			VALUES (
				@Ref_Parent_ID
				,@CategoryName
				,@AliasName
				,@Description
				,@CategoryUseBy
				,@MetaTitle
				,@MetaKeywords
				,@MetaDescription
				,1
				,0
				,@Ref_User_ID
				,GETUTCDATE()
				)

			SET @Ref_Category_ID = (
					SELECT SCOPE_IDENTITY()
					)

			SELECT @Ref_Category_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END
	ELSE IF @Ref_Category_ID > 0
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_Category WITH (NOLOCK)
				WHERE CategoryName = @CategoryName
					AND Ref_Category_ID <> @Ref_Category_ID
				)
		BEGIN
			UPDATE GEN_Category
			SET Ref_Parent_ID = @Ref_Parent_ID
				,CategoryName = @CategoryName
				,AliasName = @AliasName
				,[Description] = @Description
				,CategoryUseBy = @CategoryUseBy
				,MetaTitle = @MetaTitle
				,MetaKeywords = @MetaKeywords
				,MetaDescription = @MetaDescription
				,UpdatedBy = @Ref_User_ID
				,UpdatedDateTime = GETUTCDATE()
			WHERE Ref_Category_ID = @Ref_Category_ID

			SELECT @Ref_Category_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyCouponCode]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 25-06-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyCouponCode] @Ref_Coupon_ID BIGINT = 0
	,@CouponCode NVARCHAR(50) = ''
	,@CouponUseBy NVARCHAR(100) = ''
	,@Description NVARCHAR(MAX) = ''
	,@DiscountInPercentage FLOAT
	,@DiscountInMax FLOAT
	,@StartDate DATETIME
	,@EndDate DATETIME
	,@OneTimeUse BIT = 0
	,@AudienceCount INT = 0
	,@OnlyForNewUsers BIT = 0
	,@IsActive BIT = 1
	,@CreatedBy NVARCHAR(100) = ''
AS
BEGIN
	IF (@Ref_Coupon_ID = 0)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_CouponDetails WITH (NOLOCK)
				WHERE CouponCode = @CouponCode
				)
		BEGIN
			INSERT INTO GEN_CouponDetails (
				CouponCode
				,CouponUseBy
				,[Description]
				,DiscountInPercentage
				,DiscountInMax
				,StartDate
				,EndDate
				,OneTimeUse
				,AudienceCount
				,OnlyForNewUsers
				,IsActive
				,CreatedBy
				,CreatedDate
				)
			VALUES (
				@CouponCode
				,@CouponUseBy
				,@Description
				,@DiscountInPercentage
				,@DiscountInMax
				,@StartDate
				,@EndDate
				,@OneTimeUse
				,@AudienceCount
				,@OnlyForNewUsers
				,@IsActive
				,@CreatedBy
				,GETUTCDATE()
				)

			SELECT SCOPE_IDENTITY()
		END
	END
	ELSE
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_CouponDetails WITH (NOLOCK)
				WHERE CouponCode = @CouponCode
					AND Ref_Coupon_ID <> @Ref_Coupon_ID
				)
		BEGIN
			UPDATE GEN_CouponDetails
			SET CouponCode = @CouponCode
				,CouponUseBy = @CouponUseBy
				,[Description] = @Description
				,DiscountInPercentage = @DiscountInPercentage
				,DiscountInMax = @DiscountInMax
				,StartDate = @StartDate
				,EndDate = @EndDate
				,OneTimeUse = @OneTimeUse
				,AudienceCount = @AudienceCount
				,OnlyForNewUsers = @OnlyForNewUsers
				,IsActive = @IsActive
				,LastModifyBy = @CreatedBy
				,LastModifyDate = GETUTCDATE()
			WHERE Ref_Coupon_ID = @Ref_Coupon_ID
		END

		SELECT @Ref_Coupon_ID
	END

	DELETE FROM GEN_CouponObjectMapping  WHERE Ref_Coupon_ID=@Ref_Coupon_ID
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyCouponObjectMapping]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 25-06-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyCouponObjectMapping] 
     @Ref_CouponCode_ID BIGINT=0
	,@ObjectType nvarchar(MAX) =''
	,@Ref_Object_ID BIGINT=0
	,@CreatedBy nvarchar(100) =''
AS
BEGIN

	INSERT INTO GEN_CouponObjectMapping(Ref_Coupon_ID,ObjectType,Ref_Object_ID,IsActive,CreatedBy,CreatedDate)
	VALUES(@Ref_CouponCode_ID,@ObjectType,@Ref_Object_ID,1,@CreatedBy,GETUTCDATE())

END

GO
/****** Object:  StoredProcedure [dbo].[AddModifyServiceDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 26-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyServiceDetails] @Ref_Service_ID BIGINT = 0
	,@Ref_Category_ID BIGINT = 0
	,@ServiceTitle NVARCHAR(500) = ''
	,@AliasName NVARCHAR(MAX) = ''
	,@Description NVARCHAR(MAX) = ''
	,@Price DECIMAL(18, 0) = 0
	,@PriceWithProjectFiles DECIMAL(18, 0) = 0
	,@DeliveryDate NVARCHAR(MAX) = ''
	,@Revision BIT = 0
	,@MetaTitle NVARCHAR(MAX) = ''
	,@MetaKeywords NVARCHAR(MAX) = ''
	,@MetaDescription NVARCHAR(MAX) = ''
	,@Ref_User_ID BIGINT = 0
AS
BEGIN
	IF @Ref_Service_ID = 0
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM ServiceDetails WITH (NOLOCK)
				WHERE ServiceTitle = @ServiceTitle
					AND IsActive = 1
					AND IsDeleted = 0
				)
		BEGIN
			INSERT INTO ServiceDetails (
				Ref_Category_ID
				,ServiceTitle
				,AliasName
				,[Description]
				,Price
				,PriceWithProjectFiles
				,DeliveryDate
				,Revision
				,MetaTitle
				,MetaKeywords
				,MetaDescription
				,IsActive
				,IsDeleted
				,CreatedBy
				,CreatedDateTime
				)
			VALUES (
				@Ref_Category_ID
				,@ServiceTitle
				,@AliasName
				,@Description
				,@Price
				,@PriceWithProjectFiles
				,CASE 
					WHEN @DeliveryDate = ''
						OR @DeliveryDate IS NULL
						THEN NULL
					ELSE CONVERT(DATE, @DeliveryDate)
					END
				,@Revision
				,@MetaTitle
				,@MetaKeywords
				,@MetaDescription
				,1
				,0
				,@Ref_User_ID
				,GETUTCDATE()
				)

			SET @Ref_Service_ID = (
					SELECT SCOPE_IDENTITY()
					)

			SELECT @Ref_Service_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END
	ELSE IF @Ref_Service_ID > 0
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM ServiceDetails WITH (NOLOCK)
				WHERE ServiceTitle = @ServiceTitle
					AND Ref_Service_ID <> @Ref_Service_ID
				)
		BEGIN
			UPDATE ServiceDetails
			SET Ref_Category_ID = @Ref_Category_ID
				,ServiceTitle = @ServiceTitle
				,AliasName = @AliasName
				,[Description] = @Description
				,Price = @Price
				,PriceWithProjectFiles = @PriceWithProjectFiles
				,DeliveryDate = CASE 
					WHEN @DeliveryDate = ''
						OR @DeliveryDate IS NULL
						THEN NULL
					ELSE CONVERT(DATE, @DeliveryDate)
					END
				,Revision = @Revision
				,MetaTitle = @MetaTitle
				,MetaKeywords = @MetaKeywords
				,MetaDescription = @MetaDescription
				,IsActive = 1
				,UpdatedBy = @Ref_User_ID
				,UpdatedDateTime = GETUTCDATE()
			WHERE Ref_Service_ID = @Ref_Service_ID

			SELECT @Ref_Service_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END

	DELETE ServiceFAQMapping
	WHERE Ref_Service_ID = @Ref_Service_ID

	DELETE ProducerObjectMapping
	WHERE Ref_Object_ID = @Ref_Service_ID
		AND ObjectType = 'SERVICE'

	IF (@Ref_Service_ID > 0)
	BEGIN
		INSERT INTO ProducerObjectMapping (
			Ref_User_ID
			,Ref_Object_ID
			,ObjectType
			,IsActive
			,CreatedBy
			,CreatedDateTime
			)
		VALUES (
			@Ref_User_ID
			,@Ref_Service_ID
			,'SERVICE'
			,1
			,@Ref_User_ID
			,GETUTCDATE()
			)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyServiceFAQ]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 23-06-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyServiceFAQ] 
     @Ref_Service_ID BIGINT=0
	,@Question nvarchar(MAX) =''
	,@Answer nvarchar(MAX) =''
	,@Ref_User_ID BIGINT = 0
	,@CreatedName NVARCHAR(255)= 0
AS
BEGIN

	INSERT INTO GEN_FAQ(Question,Answer,IsActive,IsDeleted,CreatedBy,CreatedName,CreatedDateTime)
	VALUES(@Question,@Answer,1,0,@Ref_User_ID,@CreatedName,GETUTCDATE())

	DECLARE @FAQID BIGINT=(SELECT SCOPE_IDENTITY())

	INSERT INTO ServiceFAQMapping(Ref_Service_ID,Ref_FAQ_ID,IsActive,IsDeleted,CreatedBy,CreatedName,CreatedDateTime)
	VALUES(@Ref_Service_ID,@FAQID,1,0,@Ref_User_ID,@CreatedName,GETUTCDATE())

END

GO
/****** Object:  StoredProcedure [dbo].[AddModifyTrackDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 26-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyTrackDetails] @Ref_Track_ID BIGINT = 0
	,@Ref_Category_ID BIGINT = 0
	,@TrackType NVARCHAR(200)
	,@TrackName NVARCHAR(200)
	,@Bio NVARCHAR(MAX) = ''
	,@Mood NVARCHAR(MAX) = ''
	,@Key NVARCHAR(MAX) = ''
	,@Tag NVARCHAR(MAX) = ''
	,@Duration NVARCHAR(100) = 0
	,@BMP INT = 0
	,@DAW NVARCHAR(500) = 0
	,@Price DECIMAL(18, 0) = NULL
	,@PriceWithProjectFiles DECIMAL(18, 0) = NULL
	,@IsTrack BIT = 1
	,@IsVocals BIT = 0
	,@IsActive BIT = 1
	,@TrackStatus NVARCHAR(50) = 'Pending'
	,@CreatedBy NVARCHAR(100) = ''
AS
BEGIN
	IF (
			@Ref_Track_ID = 0
			OR @Ref_Track_ID IS NULL
			)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM TrackDetails WITH (NOLOCK)
				WHERE TrackName = @TrackName
				)
		BEGIN
			INSERT INTO TrackDetails (
				Ref_Category_ID
				,TrackType
				,TrackName
				,Bio
				,Mood
				,TrackKey
				,Tag
				,Duration
				,BMP
				,DAW
				,Price
				,PriceWithProjectFiles
				,IsTrack
				,IsVocals
				,IsActive
				,CreatedBy
				,CreatedDate
				)
			VALUES (
				@Ref_Category_ID
				,@TrackType
				,@TrackName
				,@Bio
				,@Mood
				,@Key
				,@Tag
				,@Duration
				,@BMP
				,@DAW
				,@Price
				,@PriceWithProjectFiles
				,@IsTrack
				,@IsVocals
				,@IsActive
				,@CreatedBy
				,GETUTCDATE()
				)

			SET @Ref_Track_ID = (
					SELECT SCOPE_IDENTITY()
					)

			SELECT @Ref_Track_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END
	ELSE IF (@Ref_Track_ID > 0)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM TrackDetails WITH (NOLOCK)
				WHERE TrackName = @TrackName
					AND Ref_Track_ID <> @Ref_Track_ID
				)
		BEGIN
			UPDATE TrackDetails
			SET TrackName = @TrackName
				,Ref_Category_ID = @Ref_Category_ID
				,TrackType = @TrackType
				,Bio = @Bio
				,Mood = @Mood
				,TrackKey = @Key
				,Tag = @Tag
				,Duration = @Duration
				,BMP = @BMP
				,DAW = @DAW
				,Price = @Price
				,PriceWithProjectFiles = @PriceWithProjectFiles
				,IsTrack = @IsTrack
				,IsVocals = @IsVocals
				,IsActive = @IsActive
				,LastModifyBy = @CreatedBy
				,LastModifyDate = GETUTCDATE()
			WHERE Ref_Track_ID = @Ref_Track_ID

			SELECT @Ref_Track_ID
		END
		ELSE
		BEGIN
			SELECT -1
		END
	END

	DELETE
	FROM ProducerObjectMapping
	WHERE Ref_Object_ID = @Ref_Track_ID
		AND ObjectType = 'TRACKANDBEAT'

	IF (@Ref_Track_ID > 0)
	BEGIN
		INSERT INTO ProducerObjectMapping (
			Ref_User_ID
			,Ref_Object_ID
			,ObjectType
			,IsActive
			,CreatedBy
			,CreatedDateTime
			)
		VALUES (
			CONVERT(BIGINT, @CreatedBy)
			,@Ref_Track_ID
			,'TRACKANDBEAT'
			,1
			,@CreatedBy
			,GETUTCDATE()
			)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyUserAction]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 10-08-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyUserAction] @ObjectID BIGINT = 0
	,@ObjectType NVARCHAR(100) = ''
	,@Action NVARCHAR(100) = ''
	,@UserID BIGINT = 0
AS
BEGIN
	IF NOT EXISTS (
			SELECT 1
			FROM GEN_UserObjectActionMapping WITH (NOLOCK)
			WHERE ObjectType = @ObjectType
				AND Ref_Object_ID = @ObjectID
				AND Ref_User_ID = @UserID
				AND [Action] = @Action
			)
	BEGIN
		INSERT INTO GEN_UserObjectActionMapping (
			Ref_User_ID
			,Ref_Object_ID
			,ObjectType
			,[Action]
			,IsActive
			,CreatedBy
			,CreatedDate
			)
		VALUES (
			@UserID
			,@ObjectID
			,@ObjectType
			,@Action
			,1
			,@UserID
			,GETUTCDATE()
			)

			SELECT @Action
	END
	ELSE
	BEGIN
	DELETE FROM GEN_UserObjectActionMapping 
	WHERE ObjectType = @ObjectType
		AND Ref_Object_ID = @ObjectID
		AND Ref_User_ID = @UserID
		AND [Action] = [Action]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyUserMaster]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyUserMaster] @Ref_UserMaster_ID BIGINT
	,@ControlName NVARCHAR(500)
	,@MasterName NVARCHAR(500)
	,@Description NVARCHAR(MAX) = ''
	,@MandatoryMasterIDs NVARCHAR(MAX) = ''
	,@NonMandatoryMasterIDs NVARCHAR(MAX) = ''
	,@IsMandatory BIT = 0
	,@IsActive BIT = 1
	,@AddedBy NVARCHAR(500) = 'SYSTEM'
AS
BEGIN
	IF (
			@Ref_UserMaster_ID = 0
			OR @Ref_UserMaster_ID IS NULL
			)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_UserMaster WITH (NOLOCK)
				WHERE MasterName = @MasterName
				)
		BEGIN
			INSERT INTO [dbo].[GEN_UserMaster] (
				ControlName
				,MasterName
				,[Description]
				,IsMandatory
				,IsActive
				,CreatedBy
				,CreatedDateTime
				)
			VALUES (
				@ControlName
				,@MasterName
				,@Description
				,@IsMandatory
				,@IsActive
				,@AddedBy
				,GETUTCDATE()
				)

			SET @Ref_UserMaster_ID = (
					SELECT SCOPE_IDENTITY()
					)

			SELECT 'USERMASTERADDED'
		END
		ELSE
		BEGIN
			SELECT 'USERMASTEREXISTS'
		END
	END
	ELSE
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_UserMaster WITH (NOLOCK)
				WHERE MasterName = @MasterName
					AND Ref_UserMaster_ID <> @Ref_UserMaster_ID
				)
		BEGIN
			UPDATE [dbo].[GEN_UserMaster]
			SET ControlName = @ControlName
				,MasterName = @MasterName
				,[Description]=@Description
				,IsMandatory = @IsMandatory
				,IsActive = @IsActive
				,UpdatedBy = @AddedBy
				,UpdatedDateTime = GETUTCDATE()
			WHERE Ref_UserMaster_ID = @Ref_UserMaster_ID

			SELECT 'USERMASTERUPDATED'
		END
		ELSE
		BEGIN
			SELECT 'USERMASTEREXISTS'
		END
	END

	DELETE
	FROM GEN_UserMasterParentChildRelationship
	WHERE Ref_UserMaster_ID = @Ref_UserMaster_ID

	IF (
			@MandatoryMasterIDs <> ''
			AND @MandatoryMasterIDs IS NOT NULL
			)
	BEGIN
		INSERT INTO GEN_UserMasterParentChildRelationship (
			Ref_UserMaster_ID
			,ParentID
			,IsMandatory
			,CreatedBy
			,CreatedDateTime
			,IsActive
			)
		SELECT @Ref_UserMaster_ID
			,ITEM
			,1
			,@AddedBy
			,GETUTCDATE()
			,1
		FROM DBO.SPLITSTRING(@MandatoryMasterIDs, ',')
	END

	IF (
			@NonMandatoryMasterIDs <> ''
			AND @NonMandatoryMasterIDs IS NOT NULL
			)
	BEGIN
		INSERT INTO GEN_UserMasterParentChildRelationship (
			Ref_UserMaster_ID
			,ParentID
			,IsMandatory
			,CreatedBy
			,CreatedDateTime
			,IsActive
			)
		SELECT @Ref_UserMaster_ID
			,ITEM
			,0
			,@AddedBy
			,GETUTCDATE()
			,1
		FROM DBO.SPLITSTRING(@NonMandatoryMasterIDs, ',')
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyUserMasterData]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyUserMasterData] @Ref_UserMasterData_ID BIGINT=0,
 @Ref_UserMaster_ID BIGINT=0
,@MasterDataName NVARCHAR(500)=''
,@Description NVARCHAR(MAX) = ''
,@MandatoryMasterIDs NVARCHAR(MAX) = ''
,@NonMandatoryMasterIDs NVARCHAR(MAX) = ''
,@IsActive BIT = 1
,@AddedBy NVARCHAR(500) = '1'
AS
BEGIN
	IF (
			@Ref_UserMasterData_ID = 0
			OR @Ref_UserMasterData_ID IS NULL
			)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_UserMasterData WITH (NOLOCK)
				WHERE MasterDataName = @MasterDataName
				)
		BEGIN
			INSERT INTO [dbo].[GEN_UserMasterData] (
			     Ref_UserMaster_ID
				,MasterDataName
				,[Description]
				,IsActive
				,CreatedBy
				,CreatedDateTime
				)
			VALUES (
			     @Ref_UserMaster_ID
				,@MasterDataName
				,@Description
				,@IsActive
				,@AddedBy
				,GETUTCDATE()
				)

			SET @Ref_UserMasterData_ID = (
					SELECT SCOPE_IDENTITY()
					)

			SELECT 'USERMASTERDATAADDED'
		END
		ELSE
		BEGIN
			SELECT 'USERMASTERDATAEXISTS'
		END
	END
	ELSE
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_UserMasterData WITH (NOLOCK)
				WHERE MasterDataName = @MasterDataName
					AND Ref_UserMasterData_ID <> @Ref_UserMasterData_ID
				)
		BEGIN
			UPDATE [dbo].[GEN_UserMasterData]
			SET  Ref_UserMaster_ID=@Ref_UserMaster_ID
			    ,MasterDataName = @MasterDataName
				,[Description] = @Description
				,IsActive = @IsActive
				,UpdatedBy = @AddedBy
				,UpdatedDateTime = GETUTCDATE()
			WHERE Ref_UserMasterData_ID = @Ref_UserMasterData_ID

			SELECT 'USERMASTERDATAUPDATED'
		END
		ELSE
		BEGIN
			SELECT 'USERMASTERDATAEXISTS'
		END
	END

	DELETE
	FROM GEN_UserMasterDataParentChildRelationship
	WHERE Ref_UserMasterData_ID = @Ref_UserMasterData_ID

	IF (
			@MandatoryMasterIDs <> ''
			AND @MandatoryMasterIDs IS NOT NULL
			)
	BEGIN
		INSERT INTO GEN_UserMasterDataParentChildRelationship (
			Ref_UserMasterData_ID
			,Ref_UserMaster_ID
			,ParentID
			,IsMandatory
			,CreatedBy
			,CreatedDateTime
			,IsActive
			)
		SELECT @Ref_UserMasterData_ID
		    ,@Ref_UserMaster_ID
			,ITEM
			,1
			,@AddedBy
			,GETUTCDATE()
			,1
		FROM DBO.SPLITSTRING(@MandatoryMasterIDs, ',')
	END

	IF (
			@NonMandatoryMasterIDs <> ''
			AND @NonMandatoryMasterIDs IS NOT NULL
			)
	BEGIN
		INSERT INTO GEN_UserMasterDataParentChildRelationship (
			Ref_UserMasterData_ID
			,Ref_UserMaster_ID
			,ParentID
			,IsMandatory
			,CreatedBy
			,CreatedDateTime
			,IsActive
			)
		SELECT @Ref_UserMasterData_ID
		    ,@Ref_UserMaster_ID
			,ITEM
			,0
			,@AddedBy
			,GETUTCDATE()
			,1
		FROM DBO.SPLITSTRING(@NonMandatoryMasterIDs, ',')
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyUserOrder]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 10-08-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyUserOrder] @OrderID BIGINT = 0
	,@OrderCode NVARCHAR(100) = ''
	,@ObjectID BIGINT = 0
	,@ObjectType NVARCHAR(100) = ''
	,@IncludeProjectFile BIT = 0
	,@OrderStatus NVARCHAR(100) = ''
	,@UserID BIGINT = 0
AS
BEGIN
	IF (@OrderID = 0)
	BEGIN
		INSERT INTO GEN_UserOrderStatus (
			Ref_User_ID
			,OrderCode
			,OrderStatus
			,IsActive
			,CreatedBy
			,CreatedDate
			)
		VALUES (
			@UserID
			,@OrderCode
			,@OrderStatus
			,1
			,@UserID
			,GETUTCDATE()
			)

		SET @OrderID = (
				SELECT SCOPE_IDENTITY()
				)
	END
	ELSE
	BEGIN
		UPDATE GEN_UserOrderStatus
		SET OrderStatus = @OrderStatus
		WHERE Ref_Order_ID = @OrderID
	END

	IF NOT EXISTS (
			SELECT 1
			FROM GEN_OrderObjectMapping WITH (NOLOCK)
			WHERE ObjectType = @ObjectType
				AND Ref_Object_ID = @ObjectID
				AND Ref_Order_ID = @OrderID
			)
	BEGIN
		INSERT INTO GEN_OrderObjectMapping (
			Ref_Order_ID
			,Ref_Object_ID
			,ObjectType
			,IncludeProjectFile
			,IsActive
			,CreatedBy
			,CreatedDate
			)
		VALUES (
			@OrderID
			,@ObjectID
			,@ObjectType
			,@IncludeProjectFile
			,1
			,@UserID
			,GETUTCDATE()
			)
	END
	ELSE
	BEGIN
		IF (@OrderStatus = 'REMOVE')
		BEGIN
			DELETE
			FROM GEN_OrderObjectMapping
			WHERE ObjectType = @ObjectType
				AND Ref_Object_ID = @ObjectID
				AND Ref_Order_ID = @OrderID
		END
	END

	SELECT @OrderStatus
END
GO
/****** Object:  StoredProcedure [dbo].[AddModifyUserTicket]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 18-11-2020
-- =============================================
CREATE PROCEDURE [dbo].[AddModifyUserTicket] @Ref_Ticket_ID BIGINT = 0
	,@Ref_TicketType_ID BIGINT = 0
	,@Ref_User_ID BIGINT = 0
	,@Subject NVARCHAR(500) = ''
	,@Description NVARCHAR(MAX) = ''
AS
BEGIN
	IF @Ref_Ticket_ID = 0
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_TicketDetails WITH (NOLOCK)
				WHERE [Subject] = @Subject
					AND Ref_TicketType_ID = @Ref_TicketType_ID
				)
		BEGIN
			INSERT INTO GEN_TicketDetails (
				Ref_TicketType_ID
				,Ref_User_ID
				,[Subject]
				,[Description]
				,CreatedBy
				,CreatedDateTime
				)
			VALUES (
				@Ref_TicketType_ID
				,@Ref_User_ID
				,@Subject
				,@Description
				,@Ref_User_ID
				,GETUTCDATE()
				)

			SET @Ref_Ticket_ID = (
					SELECT SCOPE_IDENTITY()
					)

			SELECT @Ref_Ticket_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END
	ELSE IF @Ref_Ticket_ID > 0
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM GEN_TicketDetails WITH (NOLOCK)
				WHERE [Subject] = @Subject
					AND Ref_TicketType_ID = @Ref_TicketType_ID
					AND @Ref_Ticket_ID <> @Ref_Ticket_ID
				)
		BEGIN
			UPDATE GEN_TicketDetails
			SET  Ref_TicketType_ID = @Ref_TicketType_ID
				,[Subject] = @Subject
				,[Description] = @Description
				,UpdatedBy = @Ref_User_ID
				,UpdatedDateTime = GETUTCDATE()
			WHERE @Ref_Ticket_ID = @Ref_Ticket_ID

			SELECT @Ref_Ticket_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ApplyCouponCode]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 07-11-2020
-- =============================================
CREATE PROCEDURE [dbo].[ApplyCouponCode] @OrderID BIGINT = 0
	,@UserID BIGINT = 0
	,@CouponCode NVARCHAR(100) = ''
AS
BEGIN
	DECLARE @ObjectIDs NVARCHAR(MAX) = ''
		,@CouponStatus NVARCHAR(MAX) = ''

	IF EXISTS (
			SELECT 1
			FROM GEN_CouponDetails WITH (NOLOCK)
			WHERE CouponCode = @CouponCode
				AND StartDate > GETUTCDATE()
			)
	BEGIN
		SELECT DISTINCT @CouponStatus = 'Coupon will be applicable from ' + CONVERT(NVARCHAR(20), StartDate) + ' to ' + CONVERT(NVARCHAR(20), EndDate)
		FROM GEN_CouponDetails WITH (NOLOCK)
		WHERE CouponCode = @CouponCode
	END
	ELSE IF EXISTS (
			SELECT 1
			FROM GEN_CouponDetails WITH (NOLOCK)
			WHERE CouponCode = @CouponCode
				AND EndDate < GETUTCDATE()
			)
	BEGIN
		SET @CouponStatus = 'EXPIRED'
	END
	ELSE IF NOT EXISTS (
			SELECT 1
			FROM GEN_CouponDetails WITH (NOLOCK)
			WHERE CouponCode = @CouponCode
			)
	BEGIN
		SET @CouponStatus = 'INVALIDCOUPONCODE'
	END
	ELSE
	BEGIN
		SELECT @ObjectIDs = COALESCE(@ObjectIDs, '') + CONVERT(NVARCHAR(100), Ref_Object_ID) + ','
		FROM GEN_CouponObjectMapping COM WITH (NOLOCK)
		INNER JOIN GEN_CouponDetails CD WITH (NOLOCK) ON CD.Ref_Coupon_ID = COM.Ref_Coupon_ID
		WHERE CouponCode = @CouponCode

		INSERT INTO GEN_UserCouponMapping (
			Ref_User_ID
			,Ref_Order_ID
			,Ref_Coupon_ID
			,IsActive
			,CreatedBy
			,CreatedDate
			)
		SELECT @UserID
			,@OrderID
			,Ref_Coupon_ID
			,1
			,@UserID
			,GETUTCDATE()
		FROM GEN_CouponDetails WITH (NOLOCK)
		WHERE CouponCode = @CouponCode

		SET @CouponStatus = 'APPLIED'
	END

	IF (@CouponStatus = 'INVALIDCOUPONCODE')
	BEGIN
		SELECT '' ObjectIDs
			,CONVERT(DECIMAL, 0) DiscountInPercentage
			,CONVERT(DECIMAL, 0) DiscountInMax
			,'INVALIDCOUPONCODE' AS CouponStatus
	END
	ELSE
	BEGIN
		SELECT @ObjectIDs AS ObjectIDs
			,DiscountInPercentage
			,DiscountInMax
			,@CouponStatus AS CouponStatus
		FROM GEN_CouponDetails WITH (NOLOCK)
		WHERE CouponCode = @CouponCode
				AND @CouponStatus <> ''
				
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorityDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 27-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetAuthorityDetails] @AuthorityID BIGINT=2
AS
BEGIN
	DECLARE @MasterDataIDs NVARCHAR(MAX) = ''

	SELECT  @MasterDataIDs=COALESCE(@MasterDataIDs,'') + CONVERT(NVARCHAR(100), Ref_UserMasterData_ID)+','
	FROM GEN_UserMasterAccessMapping WITH (NOLOCK)
	WHERE Ref_Authority_ID = @AuthorityID

	SELECT Ref_Authority_ID
		,AuthorityName
		,AuthorityType
		,[Description]
		,IsActive
		,@MasterDataIDs AS MasterDataIDs
	FROM AuthorityDetails WITH (NOLOCK)
	WHERE Ref_Authority_ID = @AuthorityID

	SELECT Ref_Authority_ID
		,Ref_Module_ID 
		,ViewAccess
		,EditAccess
		,DeleteAccess
		,ApprovalAccess
	FROM GEN_ModuleAccessMapping WITH (NOLOCK)
	WHERE Ref_Authority_ID = @AuthorityID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorityList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 27-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetAuthorityList] 
AS
BEGIN

   SELECT Ref_Authority_ID,AuthorityName,AuthorityType,IsActive
   FROM AuthorityDetails WITH(NOLOCK)

 END
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableProducersForServices]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 20,09,2020
-- =============================================
CREATE PROCEDURE [dbo].[GetAvailableProducersForServices] @UserID BIGINT = 0
	,@ServiceID BIGINT = 1
	,@StartCount INT = 0
	,@EndCount INT = 5
AS
BEGIN
	DECLARE @Ref_Category_ID BIGINT = (
			SELECT Ref_Category_ID
			FROM ServiceDetails WITH (NOLOCK)
			WHERE Ref_Service_ID = @ServiceID
			)

	SELECT UD.Ref_User_ID
		,UserCode
		,FullName
		,EmailID
		,MobileNumber
		,Bio
		,CNTR.ProducerFrom
		,CASE 
			WHEN Ref_UOAM_ID IS NOT NULL
				THEN 'Followed'
			ELSE '-'
			END Followed
		,FM.FilePath AS ProfilePhoto
	FROM UserDetails UD WITH (NOLOCK)
	INNER JOIN ProducerObjectMapping POM WITH (NOLOCK) ON UD.Ref_User_ID = POM.Ref_User_ID
		AND ObjectType = 'SERVICE'
	INNER JOIN ServiceDetails SD WITH (NOLOCK) ON POM.Ref_Object_ID = SD.Ref_Service_ID
		AND SD.Ref_Category_ID = @Ref_Category_ID
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = UD.Ref_User_ID
			AND ObjectType = 'PRODUCER'
			AND [Action] = 'FOLLOW'
		) UOAM
	OUTER APPLY (
		SELECT TOP 1 MasterDataName ProducerFrom
		FROM GEN_UserMaster UM WITH (NOLOCK)
		INNER JOIN GEN_UserMasterData UMD WITH (NOLOCK) ON UM.Ref_UserMaster_ID = UMD.Ref_UserMaster_ID
			AND UM.MasterName = 'COUNTRY'
		INNER JOIN GEN_UserMasterMap UMM WITH (NOLOCK) ON UMD.Ref_UserMasterData_ID = UMM.Ref_UserMasterData_ID
			AND UMM.Ref_User_ID = UD.Ref_User_ID
		) CNTR
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = UD.Ref_User_ID
			AND ModuleType = 'USER'
			AND FileIdentifier = 'UserProfile'
			AND IsActive = 1
			AND IsDeleted = 0
		) FM
	WHERE UD.IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetBannersList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 02-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetBannersList] @Ref_Banner_ID BIGINT = 0
AS
BEGIN
	SELECT Ref_Banner_ID
		,BannerTitle
		,BannerPageName
		,Descripation
		,ViewOnHome
		,IsActive
		,CreatedBy
		,CreatedDate
	FROM BannerDetails BD WITH (NOLOCK)
	WHERE (
			(
				@Ref_Banner_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Banner_ID > 0
				AND BD.Ref_Banner_ID = @Ref_Banner_ID
				)
			)

    SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager
	WHERE ModuleType = 'BANNER'
		AND (
			(
				@Ref_Banner_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Banner_ID > 0
				AND ModuleID = @Ref_Banner_ID
				)
			)
END
GO
/****** Object:  StoredProcedure [dbo].[GetBlogList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 28-09-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetBlogList] @Ref_Blog_ID BIGINT = 0
AS
BEGIN
	SELECT Ref_Blog_ID
		,BlogTitle
		,Blog
		,IsActive
		,CreatedBy
		,CreatedDate
	FROM BlogDetails WITH (NOLOCK)
	WHERE (
			(
				@Ref_Blog_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Blog_ID > 0
				AND Ref_Blog_ID = @Ref_Blog_ID
				)
			)

    SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager
	WHERE ModuleType = 'BLOG'
		AND (
			(
				@Ref_Blog_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Blog_ID > 0
				AND ModuleID = @Ref_Blog_ID
				)
			)
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 27-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetCategoryList] @Flag NVARCHAR(100) = 'ALL'
	,@Ref_Category_ID BIGINT = 0
	,@AliasName NVARCHAR(MAX) = 'null'
AS
BEGIN
	SELECT Ref_Category_ID
		,Ref_Parent_ID
		,CategoryName
		,AliasName
		,CategoryUseBy
		,[Description]
		,MetaTitle
		,MetaKeywords
		,MetaDescription
		,IsActive
	FROM GEN_Category WITH (NOLOCK)
	WHERE IsActive = 1
		AND IsDeleted = 0
		AND (
			(
				@AliasName = 'null'
				AND 1 = 1
				)
			OR (
				AliasName <> 'null'
				AND AliasName = @AliasName
				)
			)
		AND (
			(
				@Ref_Category_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Category_ID > 0
				AND Ref_Category_ID = @Ref_Category_ID
				)
			)
		AND (
			(
				@Flag = 'ALL'
				AND 1 = 1
				)
			OR (
				@Flag <> 'ALL'
				AND CategoryUseBy = [dbo].[GetCategoryType](@Flag)
				)
			)

	SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager
	WHERE ModuleType = 'Category'
		AND IsActive = 1
		AND IsDeleted = 0
		AND (
			(
				@Ref_Category_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Category_ID > 0
				AND ModuleID = @Ref_Category_ID
				)
			)
END
GO
/****** Object:  StoredProcedure [dbo].[GetCouponCodeList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 25-06-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetCouponCodeList] 
AS
BEGIN
	SELECT Ref_Coupon_ID
	      ,CouponCode
		  ,CouponUseBy
		  ,[Description]
		  ,DiscountInPercentage
		  ,DiscountInMax
		  ,StartDate
		  ,EndDate
		  ,OneTimeUse
		  ,AudienceCount
		  ,OnlyForNewUsers
		  ,IsActive
	FROM GEN_CouponDetails WITH (NOLOCK)

	SELECT Ref_Coupon_ID,
	      Ref_Object_ID,
	      ObjectType
	FROM GEN_CouponObjectMapping

END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomServiceDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 16-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomServiceDetails] @ServiceID BIGINT
AS
BEGIN
	SELECT Ref_Service_ID
		,CategoryName
		,ServiceTitle
		,SD.[Description]
		,Revision
		,Price
		,PriceWithProjectFiles
	FROM ServiceDetails SD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = SD.Ref_Category_ID
		AND Ref_Service_ID = @ServiceID

	SELECT DISTINCT Ref_Service_ID
		,GF.Ref_FAQ_ID
		,Question
		,Answer
	FROM ServiceFAQMapping SFM WITH (NOLOCK)
	INNER JOIN GEN_FAQ GF WITH (NOLOCK) ON SFM.Ref_FAQ_ID = GF.Ref_FAQ_ID
		AND Ref_Service_ID = @ServiceID

	SELECT DISTINCT Ref_FileManager_ID
	    ,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize,0)FileSize
		,ISNULL([Sequence],0)[Sequence]
	FROM GEN_FileManager
	WHERE ModuleID = @ServiceID
		AND ModuleType = 'SERVICE'
		AND IsActive = 1
		AND IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetDAWList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-06-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetDAWList]
AS
BEGIN
	SELECT Ref_DAW_ID,DAW
	FROM GEN_DAW WITH (NOLOCK) WHERE IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[GetFeaturedTrackList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 15-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetFeaturedTrackList] @UserID BIGINT = 0
	,@StartCount INT = 0
	,@EndCount INT = 5
AS
BEGIN
	SELECT Ref_Track_ID
		,CategoryName
		,TrackName
		,Bio
		,Duration
		,BMP
		,Price
		,CASE 
			WHEN IsTrack = 1
				THEN 'Track'
			ELSE 'Beat'
			END IsTrack
		,CASE 
			WHEN Ref_UOAM_ID IS NOT NULL
				THEN 'Favourite'
			ELSE '-'
			END Favourite
		,FMT.FilePath AS Thumbnail
		,MFU.FilePath As PlayUrl
	FROM TrackDetails TD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = TD.Ref_Category_ID
	    AND TrackStatus<>'Rejected'
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = TD.Ref_Track_ID
			AND ObjectType = 'TRACK'
			AND [Action] = 'FAVOURITE'
		) UOAM
	OUTER APPLY (
	SELECT TOP 1 FilePath
	FROM GEN_FileManager FM WITH (NOLOCK)
	WHERE ModuleID = TD.Ref_Track_ID
		AND ModuleType IN('TRACK','BEAT')
		AND FileIdentifier = 'Thumbnail'
		AND IsActive = 1
		AND IsDeleted = 0
	) FMT
	OUTER APPLY (
	SELECT TOP 1 FilePath
	FROM GEN_FileManager FM WITH (NOLOCK)
	WHERE ModuleID = TD.Ref_Track_ID
		AND ModuleType IN('TRACK','BEAT')
		AND FileIdentifier = 'MasterFile'
		AND IsActive = 1
		AND IsDeleted = 0
	) MFU
END

GO
/****** Object:  StoredProcedure [dbo].[GetModuleList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 27-04-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetModuleList] 
AS
BEGIN

   SELECT Ref_Module_ID
  ,ModuleName
  ,ModuleIdentifier
  ,ModuleType
  ,ModuleFor
  ,ImageUrl
  ,ModuleUrl
  ,ISNULL(DisplayOrder, 0) DisplayOrder
   FROM GEN_Modules WITH(NOLOCK)

 END
GO
/****** Object:  StoredProcedure [dbo].[GetParentCategoryList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 23-09-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetParentCategoryList]
AS
BEGIN

	SELECT Ref_Category_ID
		,CategoryName
		,AliasName
		,'' CategoryUseBy
		,[Description]
		,MetaTitle
		,MetaKeywords
		,MetaDescription
		,FilePath As Thumbnail
	FROM GEN_Category GC WITH (NOLOCK)
	OUTER APPLY (
	SELECT TOP 1 FilePath
	FROM GEN_FileManager FM WITH (NOLOCK)
	WHERE ModuleID = GC.Ref_Category_ID
		AND ModuleType = 'CATEGORY'
		AND FileIdentifier = 'Thumbnail'
		AND IsActive = 1
		AND IsDeleted = 0
	) FM
	WHERE IsActive = 1
		AND IsDeleted = 0
		AND Ref_Parent_ID = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetParentUserMasterList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetParentUserMasterList] @Ref_UserMaster_ID BIGINT = 5
AS
BEGIN

	SELECT UM.Ref_UserMaster_ID,
	ControlName,
	MasterName,
	MPR.IsMandatory
	FROM GEN_UserMaster UM WITH (NOLOCK)
	INNER JOIN GEN_UserMasterParentChildRelationship MPR WITH (NOLOCK) ON UM.Ref_UserMaster_ID=MPR.ParentID 
	WHERE MPR.Ref_UserMaster_ID = @Ref_UserMaster_ID AND UM.IsActive=1

	SELECT UMD.Ref_UserMasterData_ID,
	UMD.Ref_UserMaster_ID,
	MasterDataName
	FROM GEN_UserMasterData UMD
	INNER JOIN GEN_UserMasterParentChildRelationship MPR WITH (NOLOCK) ON UMD.Ref_UserMaster_ID=MPR.ParentID 
	WHERE MPR.Ref_UserMaster_ID = @Ref_UserMaster_ID AND UMD.IsActive=1

END
GO
/****** Object:  StoredProcedure [dbo].[GetProducersCustomServicesList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 15-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetProducersCustomServicesList] @ProducersID BIGINT
AS
BEGIN
	SELECT Ref_Service_ID
		,CategoryName
		,ServiceTitle
		,SD.[Description]
		,Price
		,FM.FilePath AS Thumbnail
		,CONVERT(VARCHAR(10), DeliveryDate) DeliveryDate
	FROM ServiceDetails SD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = SD.Ref_Category_ID
	INNER JOIN ProducerObjectMapping POM WITH (NOLOCK) ON POM.Ref_Object_ID = SD.Ref_Service_ID
		AND ObjectType = 'SERVICE'
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = SD.Ref_Service_ID
			AND ModuleType = 'SERVICE'
			AND FileIdentifier = 'Thumbnail'
			AND [Sequence] = 1
			AND IsDeleted = 0
		) FM
	WHERE Ref_User_ID = @ProducersID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducersList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 18,07,2020
-- =============================================
CREATE PROCEDURE [dbo].[GetProducersList] @UserID BIGINT = 0
	,@StartCount INT = 0
	,@EndCount INT = 5
AS
BEGIN
	SELECT Ref_User_ID
		,UserCode
		,FullName
		,EmailID
		,MobileNumber
		,Bio
		,CASE 
			WHEN Ref_UOAM_ID IS NOT NULL
				THEN 'Followed'
			ELSE '-'
			END Followed
		,FM.FilePath AS ProfilePhoto
	FROM UserDetails UD WITH (NOLOCK)
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = UD.Ref_User_ID
			AND ObjectType = 'PRODUCER'
			AND [Action] = 'FOLLOW'
		) UOAM
	OUTER APPLY (
	SELECT TOP 1 FilePath
	FROM GEN_FileManager FM WITH (NOLOCK)
	WHERE ModuleID = UD.Ref_User_ID
		AND ModuleType = 'USER'
		AND FileIdentifier = 'USERPROFILE'
		AND IsActive = 1
		AND IsDeleted = 0
	) FM
	WHERE IsActive = 1
END

GO
/****** Object:  StoredProcedure [dbo].[GetProducerTrackAndBeatList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 15-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetProducerTrackAndBeatList] @ProducersID BIGINT = 1
	,@UserID BIGINT = 5
AS
BEGIN
	DECLARE @ProducerFrom NVARCHAR(100)

	SELECT @ProducerFrom = MasterDataName
	FROM GEN_UserMaster UM WITH (NOLOCK)
	INNER JOIN GEN_UserMasterData UMD WITH (NOLOCK) ON UM.Ref_UserMaster_ID = UMD.Ref_UserMaster_ID
		AND UM.MasterName = 'COUNTRY'
	INNER JOIN GEN_UserMasterMap UMM WITH (NOLOCK) ON UMD.Ref_UserMasterData_ID = UMM.Ref_UserMasterData_ID
		AND UMM.Ref_User_ID = @ProducersID

	SELECT Ref_User_ID
		,FullName AS ProducerName
		,FM.FilePath AS ProfilePhoto
		,@ProducerFrom AS ProducerFrom
		,Bio AS ProducerBio
		,CASE 
			WHEN UOAM.Ref_UOAM_ID IS NOT NULL
				THEN 'Followed'
			ELSE '-'
			END Followed
		,CONVERT(BIGINT, FLW.Followers) Followers
		,CONVERT(BIGINT, FLWI.[Following]) [Following]
		,CONVERT(BIGINT, UP.Plays) Plays
	FROM UserDetails UD WITH (NOLOCK)
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = UD.Ref_User_ID
			AND ModuleType = 'USER'
			AND FileIdentifier = 'USERPROFILE'
			AND IsActive = 1
			AND IsDeleted = 0
		) FM
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = UD.Ref_User_ID
			AND ObjectType = 'PRODUCER'
			AND [Action] = 'FOLLOW'
		) UOAM
	OUTER APPLY (
		SELECT COUNT(Ref_UOAM_ID) Followers
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_Object_ID = UD.Ref_User_ID
			AND ObjectType = 'PRODUCER'
			AND [Action] = 'FOLLOW'
		) FLW
	OUTER APPLY (
		SELECT COUNT(Ref_UOAM_ID) [Following]
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = UD.Ref_User_ID
			AND ObjectType = 'PRODUCER'
			AND [Action] = 'FOLLOW'
		) FLWI
	OUTER APPLY (
		SELECT COUNT(Ref_UOAM_ID) Plays
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @ProducersID
			AND ObjectType = 'TRACKANDBEAT'
			AND [Action] = 'TRACKANDBEATPLAY'
		) UP
	WHERE UD.Ref_User_ID = @ProducersID

	SELECT Ref_Track_ID
		,CategoryName
		,TrackType
		,TrackName
		,Bio
		,Duration
		,BMP
		,Price
		,FilePath AS Thumbnail
		,ISNULL(TrackStatus, '-') TrackStatus
		,CASE 
			WHEN IsTrack = 1
				THEN 'Track'
			ELSE 'Beat'
			END IsTrack
		,CASE 
			WHEN OrderStatus = 'SUCCESS'
				THEN 'SOLD_OUT'
			WHEN OrderStatus IS NOT NULL
				AND OrderStatus <> 'SUCCESS'
				THEN 'IN_CART'
			ELSE 'ADD_TO_CART'
			END SoldOut
		,CASE 
			WHEN Ref_UOAM_ID IS NOT NULL
				THEN 'Favourite'
			ELSE '-'
			END Favourite
		,CONVERT(BIGINT, UP.Plays) Plays
	FROM TrackDetails TD WITH (NOLOCK)
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = TD.Ref_Track_ID
			AND ModuleType = 'TRACK'
			AND FileIdentifier = 'Thumbnail'
			AND IsActive = 1
			AND IsDeleted = 0
		) FM
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = TD.Ref_Track_ID
			AND ObjectType = 'TRACK'
			AND [Action] = 'FAVOURITE'
		) UOAM
	OUTER APPLY (
		SELECT COUNT(Ref_UOAM_ID) Plays
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_Track_ID = TD.Ref_Track_ID
			AND ObjectType = 'TRACKANDBEAT'
			AND [Action] = 'TRACKANDBEATPLAY'
		) UP
	OUTER APPLY (
		SELECT TOP 1 OrderStatus
		FROM GEN_UserOrderStatus UOS WITH (NOLOCK)
		INNER JOIN GEN_OrderObjectMapping OOM WITH (NOLOCK) ON UOS.Ref_Order_ID = OOM.Ref_Order_ID
			AND Ref_User_ID = @UserID
			AND Ref_Object_ID = TD.Ref_Track_ID
			AND ObjectType = 'TRACKANDBEAT'
		) UOS
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = TD.Ref_Category_ID
	INNER JOIN ProducerObjectMapping POM WITH (NOLOCK) ON POM.Ref_Object_ID = TD.Ref_Track_ID
		AND ObjectType = 'TRACKANDBEAT'
	WHERE Ref_User_ID = @ProducersID
END
GO
/****** Object:  StoredProcedure [dbo].[GetServiceDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-05-2020
-- EXEC [dbo].[GetServiceDetails] 0,'custom-track'
-- =============================================
CREATE PROCEDURE [dbo].[GetServiceDetails] @Ref_Service_ID BIGINT = 0
	,@AliasName NVARCHAR(MAX) = ''
AS
BEGIN
	IF @Ref_Service_ID = 0
		AND (
			@AliasName IS NOT NULL
			OR @AliasName <> ''
			)
	BEGIN
		SELECT @Ref_Service_ID = Ref_Service_ID
		FROM ServiceDetails
		WHERE IsDeleted = 0
			AND AliasName = @AliasName
	END

	SELECT Ref_Service_ID
		,Ref_Category_ID
		,ServiceTitle
		,AliasName
		,[Description]
		,Price
		,PriceWithProjectFiles
		,Revision
		,MetaTitle
		,MetaKeywords
		,MetaDescription
		,IsActive
		,IsDeleted
		,CreatedBy
		,CB.CreatedName
		,CreatedDateTime
		,CONVERT(VARCHAR(16), DeliveryDate) DeliveryDate
	FROM ServiceDetails WITH (NOLOCK)
	OUTER APPLY (
		SELECT TOP 1 FullName AS CreatedName
		FROM UserDetails UD WITH (NOLOCK)
		WHERE Ref_User_ID = CreatedBy
		) CB
	WHERE IsDeleted = 0
		AND (
			(
				@Ref_Service_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Service_ID > 0
				AND Ref_Service_ID = @Ref_Service_ID
				)
			)

	SELECT GF.Ref_FAQ_ID
		,Ref_Service_ID
		,Question
		,Answer
		,SFM.IsActive
		,SFM.IsDeleted
	FROM ServiceFAQMapping SFM
	INNER JOIN GEN_FAQ GF WITH (NOLOCK) ON SFM.Ref_FAQ_ID = GF.Ref_FAQ_ID
	WHERE (
			(
				@Ref_Service_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Service_ID > 0
				AND Ref_Service_ID = @Ref_Service_ID
				)
			)
		AND GF.IsActive = 1
		AND SFM.IsActive = 1
		AND GF.IsDeleted = 0
		AND SFM.IsDeleted = 0

	SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager
	WHERE ModuleType = 'SERVICE'
		AND (
			(
				@Ref_Service_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_Service_ID > 0
				AND ModuleID = @Ref_Service_ID
				)
			)
	ORDER BY FileType 
END
GO
/****** Object:  StoredProcedure [dbo].[GetServiceList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 20,09,2020
-- =============================================
CREATE PROCEDURE [dbo].[GetServiceList] 
 	 @StartCount INT = 0
	,@EndCount INT = 5
AS
BEGIN

	SELECT Ref_Service_ID
		,CategoryName
		,ServiceTitle
		,SD.[Description]
		,Price
		,FilePath AS Thumbnail
	FROM ServiceDetails SD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = SD.Ref_Category_ID
	OUTER APPLY (
	SELECT TOP 1 FilePath
	FROM GEN_FileManager FM WITH (NOLOCK)
	WHERE ModuleID = SD.Ref_Service_ID
		AND ModuleType = 'SERVICE'
		AND FileIdentifier = 'Thumbnail'
		AND IsActive = 1
		AND IsDeleted = 0
	) FM
	WHERE SD.IsActive = 1 AND SD.IsDeleted = 0

END

GO
/****** Object:  StoredProcedure [dbo].[GetServiceListByCategory]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 15-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetServiceListByCategory] @StartCount INT = 0
	,@EndCount INT = 10
	,@AliasName NVARCHAR(200) = 'artist-branding'
AS
BEGIN
	DECLARE @CategoryID BIGINT = 0

	SELECT @CategoryID = Ref_Category_ID
	FROM GEN_Category WITH (NOLOCK)
	WHERE AliasName = @AliasName
	AND IsActive = 1 AND IsDeleted = 0

	SELECT Ref_Service_ID
		,CategoryName
		,ServiceTitle
		,SD.[Description]
		,Price
		,FilePath AS Thumbnail
	FROM ServiceDetails SD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = SD.Ref_Category_ID
	OUTER APPLY (
	SELECT TOP 1 FilePath
	FROM GEN_FileManager FM WITH (NOLOCK)
	WHERE ModuleID = SD.Ref_Service_ID
		AND ModuleType = 'SERVICE'
		AND FileIdentifier = 'Thumbnail'
		AND IsActive = 1
		AND IsDeleted = 0
	) FM
	WHERE GC.Ref_Parent_ID = @CategoryID
	AND SD.IsActive = 1 AND SD.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetTicketTypeList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 18-11-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetTicketTypeList]
AS
BEGIN
	SELECT Ref_TicketType_ID
		,TicketType
	FROM GEN_TicketType WITH(NOLOCK)
	WHERE IsActive = 1
		AND IsDeleted = 0
	ORDER BY TicketType DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetTrackAndBeatDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 15-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackAndBeatDetails] @UserID BIGINT = 0
	,@TrackID BIGINT
AS
BEGIN
	SELECT Ref_Track_ID
		,CategoryName
		,TrackType
		,TrackName
		,Bio
		,Duration
		,BMP
		,DAW
		,Price
		,Mood
		,TrackKey
		,Tag
		,PriceWithProjectFiles
		,CASE 
			WHEN IsTrack = 1
				THEN 'Track'
			ELSE 'Beat'
			END IsTrack
		,CASE 
			WHEN IsVocals = 1
				THEN 'Yes'
			ELSE 'No'
			END IsVocals
		,CASE 
			WHEN Ref_UOAM_ID IS NOT NULL
				THEN 'Favourite'
			ELSE '-'
			END Favourite
	FROM TrackDetails TD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = TD.Ref_Category_ID
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = TD.Ref_Track_ID
			AND ObjectType = 'TRACK'
			AND [Action] = 'FAVOURITE'
		) UOAM
	WHERE Ref_Track_ID = @TrackID

	SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager
	WHERE ModuleType IN (
			'TRACK'
			,'BEAT'
			)
		AND ModuleID = @TrackID

	SELECT Ref_Track_ID
		,CategoryName
		,TrackName
		,Bio
		,Price
		,CASE 
			WHEN IsTrack = 1
				THEN 'Track'
			ELSE 'Beat'
			END IsTrack
		,CASE 
			WHEN Ref_UOAM_ID IS NOT NULL
				THEN 'Favourite'
			ELSE '-'
			END Favourite
		,ISNULL(FMT.FilePath, '-') Thumbnail
		,ISNULL(MFU.FilePath, '-') PlayUrl
	FROM TrackDetails TD WITH (NOLOCK)
	CROSS APPLY (
		SELECT Ref_Category_ID
		FROM TrackDetails WITH (NOLOCK)
		WHERE Ref_Track_ID = @TrackID
		) Related
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = TD.Ref_Category_ID
		AND TD.Ref_Category_ID = Related.Ref_Category_ID
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = TD.Ref_Track_ID
			AND ObjectType = 'TRACK'
			AND [Action] = 'FAVOURITE'
		) UOAM
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = TD.Ref_Track_ID
			AND ModuleType IN (
				'TRACK'
				,'BEAT'
				)
			AND FileIdentifier = 'Thumbnail'
			AND IsActive = 1
			AND IsDeleted = 0
		) FMT
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = TD.Ref_Track_ID
			AND ModuleType IN (
				'TRACK'
				,'BEAT'
				)
			AND FileIdentifier = 'MasterFile'
			AND IsActive = 1
			AND IsDeleted = 0
		) MFU
	WHERE Ref_Track_ID <> @TrackID
END
GO
/****** Object:  StoredProcedure [dbo].[GetTrackAndBeatList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 15-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackAndBeatList]  @UserID BIGINT = 0,
 @StartCount INT=0,
 @EndCount INT=10
AS
BEGIN


SELECT Ref_Track_ID
	   ,CategoryName
	   ,TrackType
	   ,TrackName
	   ,Bio
	   ,Duration
	   ,BMP
	   ,DAW
	   ,Price
	   ,Mood
	   ,TrackKey
	   ,Tag
	   ,CASE WHEN IsTrack = 1 THEN 'Track' ELSE 'Beat' END IsTrack
	   ,CASE WHEN IsVocals = 1 THEN 'Yes' ELSE 'No' END IsVocals
	   ,CASE 
			WHEN Ref_UOAM_ID IS NOT NULL
				THEN 'Favourite'
			ELSE '-'
			END Favourite
		,FMT.FilePath As Thumbnail
		,ISNULL(FMM.FilePath ,'-')PlayUrl
	   FROM TrackDetails TD WITH(NOLOCK)
	   INNER JOIN GEN_Category GC WITH(NOLOCK) ON GC.Ref_Category_ID=TD.Ref_Category_ID
	       AND TrackStatus<>'Rejected'
	   OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = TD.Ref_Track_ID
			AND ModuleType = 'TRACK'
			AND FileIdentifier = 'MASTERFILE'
			AND IsActive = 1
			AND IsDeleted = 0
		) FMM
	   	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = TD.Ref_Track_ID
			AND ModuleType = 'TRACK'
			AND FileIdentifier = 'THUMBNAIL'
			AND IsActive = 1
			AND IsDeleted = 0
		) FMT
	   OUTER APPLY (SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = TD.Ref_Track_ID
			AND ObjectType = 'TRACK'
			AND [Action] = 'FAVOURITE'
		) UOAM

END
GO
/****** Object:  StoredProcedure [dbo].[GetTrackDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackDetails] @TrackID BIGINT=0
AS
BEGIN
	SELECT DISTINCT Ref_Track_ID
		,Ref_Category_ID
		,TrackType
		,TrackName
		,Bio
		,Duration
		,BMP
		,DAW
		,Price
		,Mood
		,TrackKey
		,Tag
		,PriceWithProjectFiles
		,ISNULL(TrackStatus, '-') TrackStatus
		,ISNULL(ReasonOfReject, '-') Reason
		,IsTrack
		,IsVocals
		,IsActive
		,CB.CreatedBy
	FROM TrackDetails TD WITH (NOLOCK)
	OUTER APPLY (
		SELECT FullName AS CreatedBy
		FROM UserDetails WITH (NOLOCK)
		WHERE CONVERT(NVARCHAR(100),Ref_User_ID) = TD.CreatedBy
		) CB
	WHERE (
			(
				@TrackID = 0
				AND 1 = 1
				)
			OR (
				@TrackID > 0
				AND Ref_Track_ID = @TrackID
				)
			)

	SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager
	WHERE ModuleType IN (
			'TRACK'
			,'BEAT'
			)
		AND (
			(
				@TrackID = 0
				AND 1 = 1
				)
			OR (
				@TrackID > 0
				AND ModuleID = @TrackID
				)
			)
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserActionDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 10-08-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetUserActionDetails] @Action NVARCHAR(100) = ''
	,@UserID BIGINT = 0
AS
BEGIN
	SELECT Ref_User_ID
		,Ref_Object_ID
		,ObjectType
		,[Action]
		,CASE 
			WHEN Fav.Ref_UOAM_ID IS NOT NULL
				THEN 'Favourite'
			ELSE '-'
			END Favourite
		,CASE 
			WHEN ObjectType IN (
					'TRACK'
					,'BEAT'
					)
				THEN TrackName
			WHEN ObjectType = 'SERVICE'
				THEN ServiceTitle
			WHEN ObjectType = 'PRODUCER'
				THEN FullName
			END ObjectName
		,CASE 
			WHEN ObjectType IN (
					'TRACK'
					,'BEAT'
					)
				THEN TD.Price
			WHEN ObjectType = 'SERVICE'
				THEN SD.Price
			ELSE CONVERT(DECIMAL, 0)
			END Price
		,CASE 
			WHEN ObjectType IN (
					'TRACK'
					,'BEAT'
					)
				THEN TD.CategoryName
			WHEN ObjectType = 'SERVICE'
				THEN SD.CategoryName
			ELSE '-'
			END ObjectCategory
		,ISNULL(FMM.FilePath, '-') PlayUrl
		,FM.FilePath AS Thumbnail
	FROM GEN_UserObjectActionMapping UOAM WITH (NOLOCK)
	OUTER APPLY (
		SELECT TOP 1 TD.TrackName
			,TD.Price
			,CategoryName
		FROM TrackDetails TD WITH (NOLOCK)
		INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = TD.Ref_Category_ID
		WHERE TD.Ref_Track_ID = UOAM.Ref_Object_ID
		) TD
	OUTER APPLY (
		SELECT TOP 1 SD.ServiceTitle
			,SD.Price
			,CategoryName
		FROM ServiceDetails SD WITH (NOLOCK)
		INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = SD.Ref_Category_ID
		WHERE SD.Ref_Service_ID = UOAM.Ref_Object_ID
		) SD
	OUTER APPLY (
		SELECT TOP 1 FullName
		FROM UserDetails WITH (NOLOCK)
		WHERE Ref_User_ID = UOAM.Ref_Object_ID
		) UD
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = UOAM.Ref_Object_ID
			AND ModuleType IN (
				'TRACK'
				,'BEAT'
				)
			AND FileIdentifier = 'MASTERFILE'
			AND IsActive = 1
			AND IsDeleted = 0
		) FMM
	OUTER APPLY (
		SELECT TOP 1 Ref_UOAM_ID
		FROM GEN_UserObjectActionMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @UserID
			AND Ref_Object_ID = UOAM.Ref_Object_ID
			AND ObjectType = ObjectType
			AND [Action] = 'FAVOURITE'
		) Fav
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = UOAM.Ref_Object_ID
			AND ModuleType = ObjectType
			AND FileIdentifier = 'Thumbnail'
			AND IsActive = 1
			AND IsDeleted = 0
		) FM
	WHERE Ref_User_ID = @UserID
		AND [Action] = @Action
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserMasterDataList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetUserMasterDataList] @Ref_UserMasterData_ID BIGINT = 0
 ,@UserMasterID BIGINT = 0
AS
BEGIN
	DECLARE @MandatoryMaster NVARCHAR(100) = ''
	DECLARE @NonMandatoryMaster NVARCHAR(100) = ''

	IF (@Ref_UserMasterData_ID > 0)
	BEGIN
		SELECT @MandatoryMaster=COALESCE(@MandatoryMaster,'') + CONVERT(NVARCHAR(100), ParentID)+','
		FROM GEN_UserMasterDataParentChildRelationship WITH (NOLOCK)
		WHERE Ref_UserMasterData_ID = @Ref_UserMasterData_ID
			AND IsMandatory = 1

		SELECT @NonMandatoryMaster=COALESCE(@NonMandatoryMaster,'') + CONVERT(NVARCHAR(100), ParentID)+','
		FROM GEN_UserMasterDataParentChildRelationship WITH (NOLOCK)
		WHERE Ref_UserMasterData_ID = @Ref_UserMasterData_ID
			AND IsMandatory = 0
	END

	SELECT Ref_UserMasterData_ID
	    ,UMD.Ref_UserMaster_ID
		,MasterName
		,MasterDataName
		,UMD.[Description]
		,@MandatoryMaster AS MandatoryMasterIDs
		,@NonMandatoryMaster AS NonMandatoryMasterIDs
		,UMD.IsActive
	FROM GEN_UserMasterData UMD WITH (NOLOCK)
	INNER JOIN GEN_UserMaster UM WITH (NOLOCK) ON UMD.Ref_UserMaster_ID=UM.Ref_UserMaster_ID
	WHERE (
			(
				@UserMasterID = 0
				AND 1 = 1
				)
			OR (
				@UserMasterID > 0
				AND UM.Ref_UserMaster_ID = @UserMasterID
				)
			)
		AND	(
			(
				@Ref_UserMasterData_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_UserMasterData_ID > 0
				AND UMD.Ref_UserMasterData_ID = @Ref_UserMasterData_ID
				)
			)
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserMasterList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 24-05-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetUserMasterList] @Ref_UserMaster_ID BIGINT = 5
AS
BEGIN
	DECLARE @MandatoryMaster NVARCHAR(100) = ''
	DECLARE @NonMandatoryMaster NVARCHAR(100) = ''

	IF (@Ref_UserMaster_ID > 0)
	BEGIN
		SELECT @MandatoryMaster=COALESCE(@MandatoryMaster,'') + CONVERT(NVARCHAR(100), ParentID)+','
		FROM GEN_UserMasterParentChildRelationship WITH (NOLOCK)
		WHERE Ref_UserMaster_ID = @Ref_UserMaster_ID
			AND IsMandatory = 1

		SELECT @NonMandatoryMaster=COALESCE(@NonMandatoryMaster,'') + CONVERT(NVARCHAR(100), ParentID)+','
		FROM GEN_UserMasterParentChildRelationship WITH (NOLOCK)
		WHERE Ref_UserMaster_ID = @Ref_UserMaster_ID
			AND IsMandatory = 0
	END

	SELECT Ref_UserMaster_ID
		,ControlName
		,MasterName
		,[Description]
		,IsMandatory
		,@MandatoryMaster AS MandatoryMasterIDs
		,@NonMandatoryMaster AS NonMandatoryMasterIDs
		,IsActive
	FROM GEN_UserMaster WITH (NOLOCK)
	WHERE (
			(
				@Ref_UserMaster_ID = 0
				AND 1 = 1
				)
			OR (
				@Ref_UserMaster_ID > 0
				AND Ref_UserMaster_ID = @Ref_UserMaster_ID
				)
			)
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserModuleAccess]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 21-10-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetUserModuleAccess] 
   @UserID BIGINT =0
  ,@ModuleID BIGINT = 0
AS
BEGIN

   SELECT Ref_Module_ID
  ,ModuleName
  ,ModuleIdentifier
  ,ModuleType
  ,ModuleFor
  ,ImageUrl
  ,ModuleUrl
  ,ISNULL(DisplayOrder, 0) DisplayOrder
   FROM GEN_Modules WITH(NOLOCK)
   WHERE ((@ModuleID =0 AND  (1=1)) OR (@ModuleID > 0 AND(Ref_Module_ID = @ModuleID)))

   	SELECT Ref_Module_ID 
		,ViewAccess
		,EditAccess
		,DeleteAccess
		,ApprovalAccess
	FROM GEN_ModuleAccessMapping MAM WITH (NOLOCK)
	CROSS APPLY(SELECT AUD.Item AUTHID FROM UserDetails WITH (NOLOCK) 
	CROSS APPLY(SELECT Item FROM SplitString(AuthorityIDs, ',')) AUD)AUD
	WHERE Ref_Authority_ID = AUD.AUTHID
	AND ((@ModuleID =0 AND  (1=1)) OR (@ModuleID > 0 AND(Ref_Module_ID = @ModuleID)))

 END
GO
/****** Object:  StoredProcedure [dbo].[GetUserOrderDetails]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 10-08-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetUserOrderDetails] @UserID BIGINT = 0
 ,@OrderStatus NVARCHAR(100)=''
AS
BEGIN
   
    IF @OrderStatus = '' SET @OrderStatus = NULL

	SELECT Ref_User_ID
	    ,UOS.Ref_Order_ID
	    ,OrderCode
		,OrderStatus
		,CONVERT(VARCHAR(10),OrderDate)OrderDate
		,Ref_Object_ID
		,ObjectType
		,ISNULL(IncludeProjectFile, 0) IncludeProjectFile
		,CASE 
			WHEN ObjectType IN('TRACK','BEAT')
				THEN TrackName
			WHEN ObjectType = 'SERVICE'
				THEN ServiceTitle
			END ObjectName
		,CONVERT(NVARCHAR(100),CASE 
			WHEN ObjectType IN('TRACK','BEAT')
				THEN TD.Price
			WHEN ObjectType = 'SERVICE'
				THEN SD.Price
			END) Price
		,CASE 
			WHEN ObjectType IN('TRACK','BEAT')
				THEN TD.CategoryName
			WHEN ObjectType = 'SERVICE'
				THEN SD.CategoryName
			END ObjectCategory
		,FM.FilePath Thumbnail
	FROM GEN_UserOrderStatus UOS WITH (NOLOCK)
	INNER JOIN GEN_OrderObjectMapping OOM WITH (NOLOCK) ON UOS.Ref_Order_ID = OOM.Ref_Order_ID
	OUTER APPLY (
		SELECT TOP 1 TrackName,CategoryName,CASE WHEN OOM.IncludeProjectFile = 1 THEN PriceWithProjectFiles ELSE Price END Price
		FROM TrackDetails TD WITH (NOLOCK)
		INNER JOIN GEN_Category GC WITH (NOLOCK) ON TD.Ref_Category_ID = GC.Ref_Category_ID
		WHERE Ref_Track_ID = OOM.Ref_Object_ID
		AND ObjectType IN('TRACK','BEAT')
		) TD
	OUTER APPLY (
		SELECT TOP 1 ServiceTitle,CategoryName,CASE WHEN OOM.IncludeProjectFile = 1 THEN PriceWithProjectFiles ELSE Price END Price
		FROM ServiceDetails SD WITH (NOLOCK)
		INNER JOIN GEN_Category GC WITH (NOLOCK) ON SD.Ref_Category_ID = GC.Ref_Category_ID
		WHERE Ref_Service_ID = OOM.Ref_Object_ID
		AND ObjectType ='SERVICE'
		) SD
	OUTER APPLY (
	SELECT TOP 1 FilePath
	FROM GEN_FileManager FM WITH (NOLOCK)
	WHERE ModuleID = OOM.Ref_Object_ID
		AND ModuleType = ObjectType
		AND FileIdentifier = 'Thumbnail'
		AND IsActive = 1
		AND IsDeleted = 0
	) FM
	WHERE Ref_User_ID = @UserID
	AND ((@OrderStatus IS NULL AND (1=1)) OR (@OrderStatus IS NOT NULL AND (OrderStatus = @OrderStatus)))

END
GO
/****** Object:  StoredProcedure [dbo].[GetUserTicketList]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 18-11-2020
-- =============================================
CREATE PROCEDURE [dbo].[GetUserTicketList]
  @UserID BIGINT = 0
 ,@StartCount INT = 0
 ,@EndCount INT = 10
AS
BEGIN
	SELECT Ref_Ticket_ID
		  ,Ref_TicketType_ID
		  ,Ref_User_ID
		  ,[Subject]
		  ,[Description]
	FROM GEN_TicketDetails WITH(NOLOCK)
	WHERE Ref_User_ID = @UserID
	ORDER BY Ref_Ticket_ID DESC


		SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager FM  WITH (NOLOCK)
	INNER JOIN GEN_TicketDetails TD WITH (NOLOCK) ON TD.Ref_Ticket_ID =  FM.ModuleID
	WHERE ModuleType = 'TICKET'
	    AND Ref_User_ID = @UserID
		AND IsActive = 1
		AND IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GlobalSearch]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 15-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[GlobalSearch] @SearchKeyWord NVARCHAR(500)
AS
BEGIN
	SELECT Ref_Track_ID AS Ref_Object_ID
		,'TRACK' ObjectType
		,TrackName AS Title
		,Bio
		,Price
		,FM.FilePath AS Thumbnail
	FROM TrackDetails TD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = TD.Ref_Category_ID
		AND IsTrack = 1
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = TD.Ref_Track_ID
			AND ModuleType = 'TRACK'
			AND FileIdentifier = 'Thumbnail'
			AND IsActive = 1
			AND IsDeleted = 0
		) FM
	WHERE (
			CategoryName LIKE '%' + @SearchKeyWord + '%'
			OR TrackName LIKE '%' + @SearchKeyWord + '%'
			OR Bio LIKE '%' + @SearchKeyWord + '%'
			)
	
	UNION ALL
	
	SELECT Ref_Track_ID AS Ref_Object_ID
		,'BEAT' ObjectType
		,TrackName AS Title
		,Bio
		,Price
		,FM.FilePath AS Thumbnail
	FROM TrackDetails TD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = TD.Ref_Category_ID
		AND IsTrack = 0
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = TD.Ref_Track_ID
			AND ModuleType = 'BEAT'
			AND FileIdentifier = 'Thumbnail'
			AND IsActive = 1
			AND IsDeleted = 0
		) FM
	WHERE (
			CategoryName LIKE '%' + @SearchKeyWord + '%'
			OR TrackName LIKE '%' + @SearchKeyWord + '%'
			OR Bio LIKE '%' + @SearchKeyWord + '%'
			)
	
	UNION ALL
	
	SELECT Ref_Service_ID AS Ref_Object_ID
		,'SERVICE' ObjectType
		,ServiceTitle AS Title
		,SD.[Description] AS Bio
		,Price
		,FM.FilePath AS Thumbnail
	FROM ServiceDetails SD WITH (NOLOCK)
	INNER JOIN GEN_Category GC WITH (NOLOCK) ON GC.Ref_Category_ID = SD.Ref_Category_ID
	OUTER APPLY (
		SELECT TOP 1 FilePath
		FROM GEN_FileManager FM WITH (NOLOCK)
		WHERE ModuleID = SD.Ref_Service_ID
			AND ModuleType = 'SERVICE'
			AND FileIdentifier = 'Thumbnail'
			AND IsActive = 1
			AND IsDeleted = 0
		) FM
	WHERE (
			CategoryName LIKE '%' + @SearchKeyWord + '%'
			OR ServiceTitle LIKE '%' + @SearchKeyWord + '%'
			OR SD.[Description] LIKE '%' + @SearchKeyWord + '%'
			)
END
GO
/****** Object:  StoredProcedure [dbo].[ManageBanner]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 08-08-2020
-- =============================================
CREATE PROCEDURE [dbo].[ManageBanner] @BannerIDs NVARCHAR(MAX) = ''
	,@Action NVARCHAR(100) = ''
AS
BEGIN
	
	IF(UPPER(@Action)='ACTIVE')
	BEGIN

	  UPDATE BannerDetails SET IsActive = 1 WHERE Ref_Banner_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@BannerIDs,','))

	  SELECT 'BANNERACTIVE'

	END
	ELSE IF(UPPER(@Action)='DEACTIVE')
	BEGIN

	  UPDATE BannerDetails SET IsActive = 0 WHERE Ref_Banner_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@BannerIDs,','))

	  SELECT 'BANNERDEACTIVE'

	END
	ELSE IF(UPPER(@Action)='DELETE')
	BEGIN

	  DELETE FROM BannerDetails WHERE Ref_Banner_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@BannerIDs,','))

	  SELECT 'BANNERDELETE'

	END
END
GO
/****** Object:  StoredProcedure [dbo].[ManageBlog]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 28-09-2020
-- =============================================
CREATE PROCEDURE [dbo].[ManageBlog] @BlogIDs NVARCHAR(MAX) = ''
	,@Action NVARCHAR(100) = ''
AS
BEGIN
	
	IF(UPPER(@Action)='ACTIVE')
	BEGIN

	  UPDATE BlogDetails SET IsActive = 1 WHERE Ref_Blog_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@BlogIDs,','))

	  SELECT 'BLOGACTIVE'

	END
	ELSE IF(UPPER(@Action)='DEACTIVE')
	BEGIN

	  UPDATE BlogDetails SET IsActive = 0 WHERE Ref_Blog_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@BlogIDs,','))

	  SELECT 'BLOGDEACTIVE'

	END
	ELSE IF(UPPER(@Action)='DELETE')
	BEGIN

	  DELETE FROM BlogDetails WHERE Ref_Blog_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@BlogIDs,','))

	  SELECT 'BLOGDELETE'

	END
END
GO
/****** Object:  StoredProcedure [dbo].[ManageCouponCode]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 02-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[ManageCouponCode] @CouponIDs NVARCHAR(MAX) = ''
	,@Action NVARCHAR(100) = ''
AS
BEGIN
	
	IF(UPPER(@Action)='ACTIVE')
	BEGIN

	  UPDATE GEN_CouponDetails SET IsActive = 1 WHERE Ref_Coupon_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@CouponIDs,','))

	  SELECT 'COUPONACTIVE'

	END
	ELSE IF(UPPER(@Action)='DEACTIVE')
	BEGIN

	  UPDATE GEN_CouponDetails SET IsActive = 0 WHERE Ref_Coupon_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@CouponIDs,','))

	  SELECT 'COUPONDEACTIVE'

	END
	ELSE IF(UPPER(@Action)='DELETE')
	BEGIN

	  DELETE FROM GEN_CouponObjectMapping WHERE Ref_Coupon_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@CouponIDs,','))
	  DELETE FROM GEN_CouponDetails WHERE Ref_Coupon_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@CouponIDs,','))

	  SELECT 'COUPONDELETE'

	END
END
GO
/****** Object:  StoredProcedure [dbo].[ManageService]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 02-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[ManageService] @ServiceIDs NVARCHAR(MAX) = ''
	,@Action NVARCHAR(100) = ''
AS
BEGIN
	
	IF(UPPER(@Action)='ACTIVE')
	BEGIN

	  UPDATE ServiceDetails SET IsActive = 1 WHERE Ref_Service_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@ServiceIDs,','))

	  SELECT 'SERVICEACTIVE'

	END
	ELSE IF(UPPER(@Action)='DEACTIVE')
	BEGIN

	  UPDATE ServiceDetails SET IsActive = 0 WHERE Ref_Service_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@ServiceIDs,','))

	  SELECT 'SERVICEDEACTIVE'

	END
	ELSE IF(UPPER(@Action)='DELETE')
	BEGIN

	  DELETE FROM ServiceDetails WHERE Ref_Service_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@ServiceIDs,','))

	  SELECT 'SERVICEDELETE'

	END
END
GO
/****** Object:  StoredProcedure [dbo].[ManageTrack]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 02-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[ManageTrack] @TrackIDs NVARCHAR(MAX) = ''
	,@Action NVARCHAR(100) = ''
AS
BEGIN
	
	IF(UPPER(@Action)='ACTIVE')
	BEGIN

	  UPDATE TrackDetails SET IsActive = 1 WHERE Ref_Track_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@TrackIDs,','))

	  SELECT 'TRACKACTIVE'

	END
	ELSE IF(UPPER(@Action)='DEACTIVE')
	BEGIN

	  UPDATE TrackDetails SET IsActive = 0 WHERE Ref_Track_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@TrackIDs,','))

	  SELECT 'TRACKDEACTIVE'

	END
	ELSE IF(UPPER(@Action)='DELETE')
	BEGIN

	  DELETE FROM TrackDetails WHERE Ref_Track_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@TrackIDs,','))

	  SELECT 'TRACKDELETE'

	END
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveFile]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	PRAGNESH MAKWANA
-- CREATE DATE: 13-12-2019
-- =============================================
CREATE PROC [dbo].[RemoveFile] @Ref_File_ID BIGINT = 0
AS
BEGIN
	IF @Ref_File_ID <> 0
	BEGIN
		UPDATE GEN_FileManager SET IsActive = 0, IsDeleted = 1 WHERE Ref_FileManager_ID=@Ref_File_ID
		SELECT 'SUCCESS'
	END
	ELSE
	BEGIN
		SELECT 'NOFILE'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUserOrderObject]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 07-11-2020
-- =============================================
CREATE PROCEDURE [dbo].[RemoveUserOrderObject] @OrderID BIGINT = 0
	,@ObjectID BIGINT = 0
	,@ObjectType NVARCHAR(100) = ''
	,@UserID BIGINT = 0
AS
BEGIN
	DELETE
	FROM GEN_OrderObjectMapping
	WHERE Ref_Order_ID = @OrderID
		AND Ref_Object_ID = @ObjectID
		AND ObjectType = @ObjectType

    SELECT 'REMOVED'

END
GO
/****** Object:  StoredProcedure [dbo].[RequestOTP]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	PRAGNESH MAKWANA
-- CREATE DATE: 18-12-2019
-- =============================================
CREATE PROCEDURE [dbo].[RequestOTP] @Ref_User_ID BIGINT = 0
	,@OTP NVARCHAR(10) = ''
	,@Flag NVARCHAR(100) = ''
	,@Type NVARCHAR(100) = ''
	,@IsValidate BIT = 0
AS
BEGIN
	IF (@Type = 'REQUEST')
	BEGIN
		UPDATE [dbo].[GEN_RequestOTP]
		SET IsActive = 0
			,IsDeleted = 1
			,IsValidate = 0
		WHERE Ref_User_ID = @Ref_User_ID

		INSERT INTO [dbo].[GEN_RequestOTP] (
			Ref_User_ID
			,OTP
			,Flag
			,IsValidate
			,CreatedBy
			,CreatedDateTime
			,IsActive
			,IsDeleted
			)
		VALUES (
			@Ref_User_ID
			,CAST(@OTP AS NVARCHAR(10))
			,@Flag
			,@IsValidate
			,@Ref_User_ID
			,GETUTCDATE()
			,1
			,0
			)

		SELECT 'OTPGENERATEDSUCCESS~' + CAST(@OTP AS NVARCHAR(50)) AS RESPONSE
	END
	ELSE IF (@Type = 'VALIDATE')
	BEGIN
		DECLARE @OTPVALUE NVARCHAR(10)

		SET @OTPVALUE = (SELECT TOP 1 OTP
				FROM [dbo].[GEN_RequestOTP]
				WHERE Ref_User_ID = @Ref_User_ID
					AND IsActive = 1
					AND IsDeleted = 0
					AND IsValidate = 0
					AND OTP = CAST(@OTP AS NVARCHAR(10))
				ORDER BY CreatedDateTime DESC)
		IF @OTPVALUE IS NOT NULL OR @OTPVALUE <>''
		BEGIN
			UPDATE [dbo].[GEN_RequestOTP]
			SET IsActive = 0
				,IsDeleted = 1
				,IsValidate = 1
			WHERE Ref_User_ID = @Ref_User_ID
				AND OTP = CAST(@OTP AS NVARCHAR(10))
				AND IsActive = 1
				AND IsDeleted = 0
				AND IsValidate = 0

			SELECT 'VALIDATEOTP' AS RESPONSE
		END
		ELSE
		BEGIN
			SELECT 'INVALIDOTP' AS RESPONSE
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SaveModuleFile]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 22-09-2020
-- =============================================
CREATE PROCEDURE [dbo].[SaveModuleFile] @FileManagerID BIGINT = 0
	,@ModuleID BIGINT=0
	,@ModuleType NVARCHAR(100) = ''
	,@FileIdentifier NVARCHAR(100) = ''
	,@FileName NVARCHAR(MAX) = ''
	,@FilePath NVARCHAR(MAX) = ''
	,@FileExtension NVARCHAR(100) = ''
	,@FileType NVARCHAR(100) = ''
	,@FileSize BIGINT = 0
	,@FileSequence INT = 0
AS
BEGIN
	IF @FileManagerID > 0
	BEGIN
		UPDATE GEN_FileManager
		SET ModuleID = @ModuleID
		    ,FileIdentifier = @FileIdentifier
			,[FileName] = @FileName
			,FilePath = @FilePath
			,FileExtension = @FileExtension
			,FileType = @FileType
			,FileSize = @FileSize
			,[Sequence] = @FileSequence
		WHERE Ref_FileManager_ID = @FileManagerID
			
	END
	ELSE
	BEGIN
		INSERT INTO GEN_FileManager (
			ModuleID
			,ModuleType
			,FileIdentifier
			,[FileName]
			,FilePath
			,FileExtension
			,FileType
			,FileSize
			,[Sequence]
			,IsActive
			,IsDeleted
			,CreatedBy
			,CreatedDate
			)
		VALUES (@ModuleID
		    ,@ModuleType
			,@FileIdentifier
			,@FileName
			,@FilePath
			,@FileExtension
			,@FileType
			,@FileSize
			,@FileSequence
			,1
			,0
			,''
			,GETUTCDATE()
			)

		SET @FileManagerID=(SELECT SCOPE_IDENTITY())
	END

	SELECT @FileManagerID
END
GO
/****** Object:  StoredProcedure [dbo].[SetUserOrderStatus]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 07-11-2020
-- =============================================
CREATE PROCEDURE [dbo].[SetUserOrderStatus] @OrderID BIGINT = 0
	,@UserID BIGINT = 0
	,@OrderStatus NVARCHAR(100)
AS
BEGIN
	UPDATE GEN_UserOrderStatus
	  SET OrderStatus =@OrderStatus
		  ,LastModifyBy = @UserID
	      ,LastModifyDate = GETUTCDATE()
	WHERE Ref_Order_ID = @OrderID

END
GO
/****** Object:  StoredProcedure [dbo].[SignIn]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 12/04/2020
-- =============================================
CREATE PROCEDURE [dbo].[SignIn] @UserCode NVARCHAR(255) = ''
	,@Password NVARCHAR(200) = ''
	,@IsSocialLogin BIT = 0
AS
BEGIN
	DECLARE @Ref_User_ID BIGINT = 0
	DECLARE @StudioGears NVARCHAR(MAX) = ''
	DECLARE @PayPalEmailID NVARCHAR(MAX) = ''
	DECLARE @SocialProfileUrl NVARCHAR(MAX) = ''

	SELECT @Ref_User_ID = Ref_User_ID
	FROM UserDetails WITH (NOLOCK)
	WHERE (
			UserCode = @UserCode
			OR EmailID = @UserCode
			)
		AND [Password] = @Password
		AND IsActive = 1
		AND IsDeleted = 0

	IF (@Ref_User_ID > 0)
	BEGIN
		SELECT @StudioGears = COALESCE(@StudioGears, '') + CONVERT(NVARCHAR(MAX), ObjectValue) + '|'
		FROM ProducerObjectMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @Ref_User_ID
			AND ObjectType = 'STUDIOGEARS'
			AND IsActive = 1
			AND IsDeleted = 0

		SELECT @PayPalEmailID = COALESCE(@PayPalEmailID, '') + CONVERT(NVARCHAR(MAX), ObjectValue) + '|'
		FROM ProducerObjectMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @Ref_User_ID
			AND ObjectType = 'PAYPALEMAILID'
			AND IsActive = 1
			AND IsDeleted = 0

		SELECT @SocialProfileUrl = COALESCE(@SocialProfileUrl, '') + CONVERT(NVARCHAR(MAX), ObjectValue) + '|'
		FROM ProducerObjectMapping WITH (NOLOCK)
		WHERE Ref_User_ID = @Ref_User_ID
			AND ObjectType = 'SOCIALPROFILEURL'
			AND IsActive = 1
			AND IsDeleted = 0
	END

	IF @IsSocialLogin = 1
	BEGIN
		SELECT Ref_User_ID
			,UserCode
			,FullName
			,EmailID
			,MobileNumber
			,Bio
			,Gender
			,@StudioGears AS StudioGears
			,@PayPalEmailID AS PayPalEmailID
			,@SocialProfileUrl AS SocialProfileUrl
			,'USERSIGNINSUCCESS' AS Response
		FROM UserDetails WITH (NOLOCK)
		WHERE UserCode = @UserCode
			AND IsActive = 1
			AND IsDeleted = 0
	END
	ELSE IF (@Ref_User_ID > 0)
	BEGIN
		SELECT Ref_User_ID
			,UserCode
			,FullName
			,EmailID
			,MobileNumber
			,Bio
			,Gender
			,@StudioGears AS StudioGears
			,@PayPalEmailID AS PayPalEmailID
			,@SocialProfileUrl AS SocialProfileUrl
			,'USERSIGNINSUCCESS' AS Response
		FROM UserDetails WITH (NOLOCK)
		WHERE Ref_User_ID = @Ref_User_ID
	END
	ELSE
	BEGIN
		SELECT CONVERT(BIGINT, 0) Ref_User_ID
			,'' UserCode
			,'' FullName
			,'' EmailID
			,'' MobileNumber
			,'' Bio
			,'' Gender
			,'' StudioGears
			,'' PayPalEmailID
			,'' SocialProfileUrl
			,'USERSIGNINFAILED' AS Response
	END

	SELECT Ref_FileManager_ID
		,ModuleID
		,ModuleType
		,FileIdentifier
		,[FileName]
		,FilePath
		,FileExtension
		,FileType
		,ISNULL(FileSize, 0) FileSize
		,ISNULL([Sequence], 0) [Sequence]
	FROM GEN_FileManager
	WHERE ModuleType = 'USER'
		AND ModuleID = @Ref_User_ID

	SELECT DISTINCT MasterName
		,MasterDataName
	FROM GEN_UserMaster UM WITH (NOLOCK)
	INNER JOIN GEN_UserMasterData UMD WITH (NOLOCK) ON UM.Ref_UserMaster_ID = UMD.Ref_UserMaster_ID
	INNER JOIN GEN_UserMasterMap UMM WITH (NOLOCK) ON UMD.Ref_UserMasterData_ID = UMM.Ref_UserMasterData_ID
		AND UMM.Ref_User_ID = @Ref_User_ID
END
GO
/****** Object:  StoredProcedure [dbo].[SignUp]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 12/04/2020
-- =============================================
CREATE PROCEDURE [dbo].[SignUp] @Ref_User_ID BIGINT = 0
	,@UserCode NVARCHAR(50) = ''
	,@FullName NVARCHAR(200)
	,@EmailID NVARCHAR(100)
	,@MobileNumber NVARCHAR(20) = NULL
	,@Bio NVARCHAR(MAX) = ''
	,@Password NVARCHAR(50) = ''
	,@Gender NVARCHAR(50) = ''
	,@PayPalEmailID NVARCHAR(MAX) = ''
	,@StudioGears NVARCHAR(MAX) = NULL
	,@SocialProfileUrl NVARCHAR(MAX) = NULL
	,@AuthorityIDs NVARCHAR(500) = NULL
	,@UserMasterDataIDs NVARCHAR(MAX) = NULL
	,@CreatedBy NVARCHAR(100) = ''
AS
BEGIN
	IF (@Ref_User_ID = 0)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM UserDetails WITH (NOLOCK)
				WHERE (
						EMAILID = @EmailID
						OR UserCode = @UserCode
						)
					AND IsActive = 1
					AND IsDeleted = 0
				)
		BEGIN
			INSERT INTO UserDetails (
				UserCode
				,FullName
				,EmailID
				,MobileNumber
				,[Password]
				,Bio
				,Gender
				,AuthorityIDs
				,IsActive
				,IsDeleted
				,CreatedBy
				,CreatedDateTime
				)
			VALUES (
				@UserCode
				,@FullName
				,@EmailID
				,@MobileNumber
				,@Password
				,@Bio
				,@Gender
				,@AuthorityIDs
				,1
				,0
				,0
				,GETUTCDATE()
				)

			SET @Ref_User_ID = (
					SELECT SCOPE_IDENTITY()
					)

			SELECT @Ref_User_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END
	ELSE IF (@Ref_User_ID > 0)
	BEGIN
		IF NOT EXISTS (
				SELECT 1
				FROM UserDetails WITH (NOLOCK)
				WHERE (
						EMAILID = @EmailID
						OR UserCode = @UserCode
						)
					AND IsActive = 1
					AND IsDeleted = 0
					AND Ref_User_ID <> @Ref_User_ID
				)
		BEGIN
			UPDATE UserDetails
			SET UserCode = @UserCode
				,FullName = @FullName
				,MobileNumber = @MobileNumber
				,[Password] = CASE 
					WHEN @Password = ''
						OR @Password IS NULL
						THEN [Password]
					ELSE @Password
					END
				,Bio = @Bio
				,Gender = @Gender
				,AuthorityIDs = @AuthorityIDs
				,UpdatedBy = @Ref_User_ID
				,UpdatedDateTime = GETUTCDATE()
			WHERE Ref_User_ID = @Ref_User_ID

			SELECT @Ref_User_ID
		END
		ELSE
		BEGIN
			SELECT - 1
		END
	END

	DELETE
	FROM ProducerObjectMapping
	WHERE Ref_User_ID = @Ref_User_ID
		AND ObjectType IN (
			'SOCIALPROFILEURL'
			,'STUDIOGEARS'
			,'PAYPALEMAILID'
			)

	IF @SocialProfileUrl <> ''
	BEGIN
		INSERT INTO ProducerObjectMapping (
			Ref_User_ID
			,Ref_Object_ID
			,ObjectType
			,ObjectValue
			,IsActive
			,IsDeleted
			,CreatedBy
			,CreatedDateTime
			)
		SELECT @Ref_User_ID
			,0
			,'SOCIALPROFILEURL'
			,LTRIM(RTRIM(Data))
			,1
			,0
			,@Ref_User_ID
			,GETUTCDATE()
		FROM dbo.SplitStrings(@SocialProfileUrl, '|')
	END

	IF @StudioGears <> ''
	BEGIN
		INSERT INTO ProducerObjectMapping (
			Ref_User_ID
			,Ref_Object_ID
			,ObjectType
			,ObjectValue
			,IsActive
			,IsDeleted
			,CreatedBy
			,CreatedDateTime
			)
		SELECT @Ref_User_ID
			,0
			,'STUDIOGEARS'
			,LTRIM(RTRIM(Data))
			,1
			,0
			,@Ref_User_ID
			,GETUTCDATE()
		FROM dbo.SplitStrings(@StudioGears, '|')
	END

	IF @PayPalEmailID <> ''
	BEGIN
		INSERT INTO ProducerObjectMapping (
			Ref_User_ID
			,Ref_Object_ID
			,ObjectType
			,ObjectValue
			,IsActive
			,IsDeleted
			,CreatedBy
			,CreatedDateTime
			)
		SELECT @Ref_User_ID
			,0
			,'PAYPALEMAILID'
			,LTRIM(RTRIM(Data))
			,1
			,0
			,@Ref_User_ID
			,GETUTCDATE()
		FROM dbo.SplitStrings(@PayPalEmailID, '|')
	END

	DELETE
	FROM GEN_UserMasterMap
	WHERE Ref_User_ID = @Ref_User_ID

	IF @UserMasterDataIDs <> ''
	BEGIN
		INSERT INTO GEN_UserMasterMap (
			Ref_User_ID
			,Ref_UserMasterData_ID
			,Ref_UserMaster_ID
			,IsActive
			,CreatedBy
			,CreatedDate
			)
		SELECT @Ref_User_ID
			,Ref_UserMasterData_ID
			,Ref_UserMaster_ID
			,1
			,@Ref_User_ID
			,GETUTCDATE()
		FROM dbo.SplitStrings(@UserMasterDataIDs, ',') SS
		INNER JOIN GEN_UserMasterData UMD WITH (NOLOCK) ON UMD.Ref_UserMasterData_ID = SS.Data
	END
END
GO
/****** Object:  StoredProcedure [dbo].[TrackApproveAndRejact]    Script Date: 09-12-2020 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- AUTHOR:	BHEEM
-- CREATE DATE: 02-07-2020
-- =============================================
CREATE PROCEDURE [dbo].[TrackApproveAndRejact] @TrackIDs NVARCHAR(MAX) = ''
	,@Action NVARCHAR(100) = ''
	,@Reason NVARCHAR(MAX) = ''
	,@ActionBy NVARCHAR(100) = ''
AS
BEGIN
	
	  UPDATE TrackDetails SET TrackStatus = @Action,ReasonOfReject=@Reason,LastModifyBy=@ActionBy,LastModifyDate =GETUTCDATE()
	  WHERE Ref_Track_ID IN (SELECT ITEM FROM DBO.SPLITSTRING(@TrackIDs,','))

	  SELECT @Action
END
GO
USE [master]
GO
ALTER DATABASE [dope_uat] SET  READ_WRITE 
GO
