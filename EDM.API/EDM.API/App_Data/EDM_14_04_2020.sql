USE [EDM]
GO
/****** Object:  Table [dbo].[ServiceFAQMapping]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceFAQMapping](
	[Ref_ServiceMapping_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_FAQ_ID] [bigint] NOT NULL,
	[Ref_Service_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceDetails]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceDetails](
	[Ref_Service_ID] [bigint] NOT NULL,
	[Ref_Category_ID] [bigint] NOT NULL,
	[Descripation] [nvarchar](max) NULL,
	[Price] [decimal](18, 0) NULL,
	[BigImageUrl] [nvarchar](max) NULL,
	[ThumbnailImageUrl] [nvarchar](max) NULL,
	[ServiceVideoUrl] [nvarchar](max) NULL,
	[DeliveryDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMasterMap]    Script Date: 04/14/2020 10:19:09 ******/
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
/****** Object:  Table [dbo].[GEN_UserMasterData]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMasterData](
	[Ref_UserMasterData_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_UserMaster_ID] [bigint] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_UserMaster]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserMaster](
	[Ref_UserMaster_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_Modules]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_Modules](
	[Ref_Module_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](100) NOT NULL,
	[ModuleType] [nvarchar](100) NOT NULL,
	[ModuleFor] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_ModuleAccessMapping]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_ModuleAccessMapping](
	[Ref_ModuleAccess_ID] [bigint] NOT NULL,
	[Ref_Authority_ID] [bigint] NOT NULL,
	[Ref_Module_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_FAQ]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_FAQ](
	[Ref_FAQ_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_CategoryFAQMapping]    Script Date: 04/14/2020 10:19:09 ******/
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
/****** Object:  Table [dbo].[GEN_Category]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_Category](
	[Ref_Category_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Preant_ID] [bigint] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[ThumbnailImageUrl] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GEN_ActivityDetails]    Script Date: 04/14/2020 10:19:09 ******/
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
/****** Object:  Table [dbo].[GEN_ActivityAccessMapping]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_ActivityAccessMapping](
	[Ref_ActivityAccess_ID] [bigint] NOT NULL,
	[Ref_Authority_ID] [bigint] NOT NULL,
	[Ref_Activity_ID] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorityDetails]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorityDetails](
	[Ref_Authority_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AuthorityName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLoginWithDetails]    Script Date: 04/14/2020 10:19:09 ******/
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
/****** Object:  Table [dbo].[UserDetails]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Ref_User_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[User_Code] [nvarchar](200) NULL,
	[User_FirstName] [nvarchar](500) NULL,
	[User_LastName] [nvarchar](500) NULL,
	[User_EmailID] [nvarchar](100) NULL,
	[Profile_Photo] [nvarchar](max) NULL,
	[Bio] [nvarchar](max) NULL,
	[Gender] [nvarchar](50) NULL,
	[User_Password] [nvarchar](500) NULL,
	[Pincode] [numeric](18, 0) NULL,
	[Address] [nvarchar](500) NULL,
	[Address1] [nvarchar](500) NULL,
	[Ref_Authority_ID] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccountsDetails]    Script Date: 04/14/2020 10:19:09 ******/
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
/****** Object:  Table [dbo].[TrackDetails]    Script Date: 04/14/2020 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackDetails](
	[Ref_Track_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ref_Category_ID] [bigint] NULL,
	[TrackType] [nvarchar](50) NULL,
	[Name] [nvarchar](500) NULL,
	[Bio] [nvarchar](max) NULL,
	[Duration] [int] NULL,
	[BMP] [int] NULL,
	[DAW] [nvarchar](500) NULL,
	[Price] [decimal](18, 0) NULL,
	[BigImageUrl] [nvarchar](max) NULL,
	[ThumbnailImageUrl] [nvarchar](max) NULL,
	[MasterFileUrl] [nvarchar](max) NULL,
	[UnmasteredFileUrl] [nvarchar](max) NULL,
	[MixdowFileUrl] [nvarchar](max) NULL,
	[StemsUrl] [nvarchar](max) NULL,
	[ProjectFilesUrl] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [nvarchar](100) NULL,
	[LastModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SignUp]    Script Date: 04/14/2020 10:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<BHEEM>
-- Create date: <12,04,2020>
-- Description:	<SIGNUP>
-- =============================================
CREATE PROCEDURE [dbo].[SignUp] 
    @Ref_User_ID bigint=0,
	@User_Code nvarchar(200),
	@User_FirstName nvarchar(500),
	@User_LastName nvarchar(500)=NULL,
	@User_EmailID nvarchar(100),
	@Profile_Photo nvarchar(max)=NULL,
	@Bio nvarchar(max)=NULL,
	@Gender nvarchar(50)=NULL,
	@User_Password nvarchar(500),
	@Pincode numeric(18, 0)=NULL,
	@Address nvarchar(500)=NULL,
	@Address1 nvarchar(500)=NULL,
	@AuthorityIDs nvarchar(500)='',
	@UserMasterDataIDs nvarchar(500)='',
	@IsActive bit =1,
	@CreatedBy nvarchar(100) =''
AS
BEGIN

  IF(@Ref_User_ID=0 OR @Ref_User_ID IS NULL)
  BEGIN
	  IF NOT EXISTS(SELECT 1 FROM UserDetails WITH(NOLOCK) WHERE User_Code=@User_Code)
	   BEGIN
		   INSERT INTO UserDetails(
				 User_Code
				,User_FirstName
				,User_LastName
				,User_EmailID
				,Profile_Photo
				,Bio
				,Gender
				,User_Password
				,Pincode
				,Address
				,Address1
				,Ref_Authority_ID
				,IsActive
				,CreatedBy
                ,CreatedDate)
              VALUES(@User_Code
				,@User_FirstName
				,@User_LastName
				,@User_EmailID
				,@Profile_Photo
				,@Bio
				,@Gender
				,@User_Password
				,@Pincode
				,@Address
				,@Address1
				,@AuthorityIDs
				,@IsActive
				,@CreatedBy
                ,GETUTCDATE())
		END
	   ELSE
	    BEGIN
		  SELECT 'USEREXISTS'
	    END
   END
   ELSE IF(@Ref_User_ID >0)
   BEGIN
   	IF NOT EXISTS(SELECT 1 FROM UserDetails WITH(NOLOCK) WHERE User_Code=@User_Code)
	  BEGIN
		 UPDATE UserDetails SET
		 User_Code=@User_Code
		,User_FirstName=@User_FirstName
		,User_LastName=@User_LastName
		,User_EmailID=@User_EmailID
		,Profile_Photo=@Profile_Photo
		,Bio=@Bio
		,Gender=@Gender
		,User_Password=@User_Password
		,Pincode=@Pincode
		,[Address]=@Address
		,Address1=@Address1
		,Ref_Authority_ID=@AuthorityIDs
		,IsActive=@IsActive
		,LastModifyBy=@CreatedBy
        ,LastModifyDate=GETUTCDATE()
		 WHERE Ref_User_ID=@Ref_User_ID
	   END 
	 ELSE
	   BEGIN
		 SELECT 'USEREXISTS'
	   END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SignIn]    Script Date: 04/14/2020 10:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<BHEEM>
-- Create date: <12,04,2020>
-- Description:	<SIGNIN>
-- =============================================
CREATE PROCEDURE [dbo].[SignIn]
	@User_Code nvarchar(200),
	@User_Password nvarchar(200)
AS
BEGIN

  IF EXISTS(SELECT 1 FROM UserDetails WITH(NOLOCK) WHERE User_Code=@User_Code AND User_Password=@User_Password)
   BEGIN
   SELECT Ref_User_ID
		,User_Code
		,User_FirstName
		,User_LastName
		,User_EmailID
		,Profile_Photo
		,Bio
		,Gender
		,User_Password
		,Pincode
		,Address
		,Address1
		,Ref_Authority_ID
		,IsActive
		,'USERSIGNUP'
	     FROM UserDetails WITH(NOLOCK) WHERE User_Code=@User_Code AND User_Password=@User_Password
 
   END
   ELSE
   BEGIN
   SELECT 0 Ref_User_ID
		,''User_Code
		,''User_FirstName
		,''User_LastName
		,''User_EmailID
		,''Profile_Photo
		,''Bio
		,''Gender
		,''User_Password
		,''Pincode
		,''Address
		,''Address1
		,''Ref_Authority_ID
		,''IsActive
		,'USERSIGNUPFAILED'	 
   END
END
GO
/****** Object:  Default [DF_AuthorityDetails_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[AuthorityDetails] ADD  CONSTRAINT [DF_AuthorityDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_AuthorityDetails_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[AuthorityDetails] ADD  CONSTRAINT [DF_AuthorityDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_ActivityAccessMapping_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_ActivityAccessMapping] ADD  CONSTRAINT [DF_GEN_ActivityAccessMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_ActivityAccessMapping_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_ActivityAccessMapping] ADD  CONSTRAINT [DF_GEN_ActivityAccessMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_ActivityDetails_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_ActivityDetails] ADD  CONSTRAINT [DF_GEN_ActivityDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_ActivityDetails_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_ActivityDetails] ADD  CONSTRAINT [DF_GEN_ActivityDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_Category_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_Category] ADD  CONSTRAINT [DF_GEN_Category_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_Category_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_Category] ADD  CONSTRAINT [DF_GEN_Category_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_CategoryFAQMapping_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_CategoryFAQMapping] ADD  CONSTRAINT [DF_GEN_CategoryFAQMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_CategoryFAQMapping_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_CategoryFAQMapping] ADD  CONSTRAINT [DF_GEN_CategoryFAQMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_FAQ_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_FAQ] ADD  CONSTRAINT [DF_GEN_FAQ_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_FAQ_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_FAQ] ADD  CONSTRAINT [DF_GEN_FAQ_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_ModuleAccessMapping_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_ModuleAccessMapping] ADD  CONSTRAINT [DF_GEN_ModuleAccessMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_ModuleAccessMapping_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_ModuleAccessMapping] ADD  CONSTRAINT [DF_GEN_ModuleAccessMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_Modules_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_Modules] ADD  CONSTRAINT [DF_GEN_Modules_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_Modules_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_Modules] ADD  CONSTRAINT [DF_GEN_Modules_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_UserMaster_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_UserMaster] ADD  CONSTRAINT [DF_GEN_UserMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_UserMaster_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_UserMaster] ADD  CONSTRAINT [DF_GEN_UserMaster_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_UserMasterData_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_UserMasterData] ADD  CONSTRAINT [DF_GEN_UserMasterData_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_UserMasterData_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_UserMasterData] ADD  CONSTRAINT [DF_GEN_UserMasterData_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_UserMasterMap_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_UserMasterMap] ADD  CONSTRAINT [DF_GEN_UserMasterMap_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_UserMasterMap_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[GEN_UserMasterMap] ADD  CONSTRAINT [DF_GEN_UserMasterMap_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_ServiceDetails_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[ServiceDetails] ADD  CONSTRAINT [DF_ServiceDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_ServiceDetails_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[ServiceDetails] ADD  CONSTRAINT [DF_ServiceDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_ServiceFAQMapping_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[ServiceFAQMapping] ADD  CONSTRAINT [DF_GEN_ServiceFAQMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_ServiceFAQMapping_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[ServiceFAQMapping] ADD  CONSTRAINT [DF_GEN_ServiceFAQMapping_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_TrackDetails_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[TrackDetails] ADD  CONSTRAINT [DF_TrackDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_TrackDetails_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[TrackDetails] ADD  CONSTRAINT [DF_TrackDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_User_UPI_Details_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[UserAccountsDetails] ADD  CONSTRAINT [DF_GEN_User_UPI_Details_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_User_UPI_Details_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[UserAccountsDetails] ADD  CONSTRAINT [DF_GEN_User_UPI_Details_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_UserDetails_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_GEN_UserDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_UserDetails_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_GEN_UserDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_GEN_UserLoginWithDetails_IsActive]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[UserLoginWithDetails] ADD  CONSTRAINT [DF_GEN_UserLoginWithDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GEN_UserLoginWithDetails_CreatedDate]    Script Date: 04/14/2020 10:19:09 ******/
ALTER TABLE [dbo].[UserLoginWithDetails] ADD  CONSTRAINT [DF_GEN_UserLoginWithDetails_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
