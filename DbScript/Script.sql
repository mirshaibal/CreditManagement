
USE [CreditManagementDB]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/29/2013 09:27:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 12/29/2013 09:27:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[ActionTime] [datetime] NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/29/2013 09:27:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[IsActive] [bit] NULL,
	[ActionTime] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 12/29/2013 09:27:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[ActionTime] [datetime] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditInfo]    Script Date: 12/29/2013 09:27:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditInfo](
	[CreditInfoId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[BranchId] [int] NULL,
	[CreatedUserId] [int] NULL,
	[AssignUserId] [int] NULL,
	[Info] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[Subject] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
	[BorrowerName] [nvarchar](200) NULL,
	[ApplicationDate] [datetime] NULL,
	[ProposedFacility] [nvarchar](200) NULL,
	[BranchProposalRef] [nvarchar](200) NULL,
	[BranchProposalDate] [nvarchar](200) NULL,
	[HOReceivedDate] [nvarchar](200) NULL,
	[DateOfAccountOpening] [nvarchar](200) NULL,
	[ClientName] [nvarchar](50) NULL,
	[RegisterAddress] [nvarchar](200) NULL,
	[CorporateAddress] [nvarchar](200) NULL,
	[FactoryAddress] [nvarchar](200) NULL,
	[NatureOfBusiness] [nvarchar](200) NULL,
	[Products] [nvarchar](200) NULL,
	[CapitalStructure] [nvarchar](50) NULL,
 CONSTRAINT [PK_CreditInfo] PRIMARY KEY CLUSTERED 
(
	[CreditInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditFlow]    Script Date: 12/29/2013 09:27:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditFlow](
	[CreditFlowId] [int] IDENTITY(1,1) NOT NULL,
	[AssignFromUserId] [int] NULL,
	[AssignToUserId] [int] NULL,
	[CreditInfoId] [int] NULL,
	[Note] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[ActionTime] [datetime] NULL,
 CONSTRAINT [PK_CreditFlow] PRIMARY KEY CLUSTERED 
(
	[CreditFlowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditFile]    Script Date: 12/29/2013 09:27:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditFile](
	[CreditFileId] [int] IDENTITY(1,1) NOT NULL,
	[CreditInfoId] [int] NULL,
	[Title] [nvarchar](200) NULL,
	[FilePath] [nvarchar](200) NULL,
	[ActionTime] [datetime] NULL,
 CONSTRAINT [PK_CreditFile] PRIMARY KEY CLUSTERED 
(
	[CreditFileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Branch_ActionTime]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [DF_Branch_ActionTime]  DEFAULT (getdate()) FOR [ActionTime]
GO
/****** Object:  Default [DF_Client_ActionTime]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [DF_Client_ActionTime]  DEFAULT (getdate()) FOR [ActionTime]
GO
/****** Object:  Default [DF_CreditFile_ActionTime]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditFile] ADD  CONSTRAINT [DF_CreditFile_ActionTime]  DEFAULT (getdate()) FOR [ActionTime]
GO
/****** Object:  Default [DF_CreditFlow_ActionTime]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditFlow] ADD  CONSTRAINT [DF_CreditFlow_ActionTime]  DEFAULT (getdate()) FOR [ActionTime]
GO
/****** Object:  Default [DF_CreditInfo_CreateTime]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditInfo] ADD  CONSTRAINT [DF_CreditInfo_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_CreditInfo_ApplicationDate]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditInfo] ADD  CONSTRAINT [DF_CreditInfo_ApplicationDate]  DEFAULT (getdate()) FOR [ApplicationDate]
GO
/****** Object:  Default [DF_Users_ActionTime]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_ActionTime]  DEFAULT (getdate()) FOR [ActionTime]
GO
/****** Object:  ForeignKey [FK_Client_Branch]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Branch] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([BranchId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Branch]
GO
/****** Object:  ForeignKey [FK_CreditFile_CreditInfo]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditFile]  WITH CHECK ADD  CONSTRAINT [FK_CreditFile_CreditInfo] FOREIGN KEY([CreditInfoId])
REFERENCES [dbo].[CreditInfo] ([CreditInfoId])
GO
ALTER TABLE [dbo].[CreditFile] CHECK CONSTRAINT [FK_CreditFile_CreditInfo]
GO
/****** Object:  ForeignKey [FK_CreditFlow_AssignFromUser]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditFlow]  WITH CHECK ADD  CONSTRAINT [FK_CreditFlow_AssignFromUser] FOREIGN KEY([AssignFromUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CreditFlow] CHECK CONSTRAINT [FK_CreditFlow_AssignFromUser]
GO
/****** Object:  ForeignKey [FK_CreditFlow_AssignToUser]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditFlow]  WITH CHECK ADD  CONSTRAINT [FK_CreditFlow_AssignToUser] FOREIGN KEY([AssignToUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CreditFlow] CHECK CONSTRAINT [FK_CreditFlow_AssignToUser]
GO
/****** Object:  ForeignKey [FK_CreditFlow_CreditInfo]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditFlow]  WITH CHECK ADD  CONSTRAINT [FK_CreditFlow_CreditInfo] FOREIGN KEY([CreditInfoId])
REFERENCES [dbo].[CreditInfo] ([CreditInfoId])
GO
ALTER TABLE [dbo].[CreditFlow] CHECK CONSTRAINT [FK_CreditFlow_CreditInfo]
GO
/****** Object:  ForeignKey [FK_CreditInfo_AssignUser]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditInfo]  WITH CHECK ADD  CONSTRAINT [FK_CreditInfo_AssignUser] FOREIGN KEY([AssignUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CreditInfo] CHECK CONSTRAINT [FK_CreditInfo_AssignUser]
GO
/****** Object:  ForeignKey [FK_CreditInfo_Branch]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditInfo]  WITH CHECK ADD  CONSTRAINT [FK_CreditInfo_Branch] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([BranchId])
GO
ALTER TABLE [dbo].[CreditInfo] CHECK CONSTRAINT [FK_CreditInfo_Branch]
GO
/****** Object:  ForeignKey [FK_CreditInfo_Client]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditInfo]  WITH CHECK ADD  CONSTRAINT [FK_CreditInfo_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[CreditInfo] CHECK CONSTRAINT [FK_CreditInfo_Client]
GO
/****** Object:  ForeignKey [FK_CreditInfo_CreatedUser]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[CreditInfo]  WITH CHECK ADD  CONSTRAINT [FK_CreditInfo_CreatedUser] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CreditInfo] CHECK CONSTRAINT [FK_CreditInfo_CreatedUser]
GO
/****** Object:  ForeignKey [FK_Users_Role]    Script Date: 12/29/2013 09:27:07 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
