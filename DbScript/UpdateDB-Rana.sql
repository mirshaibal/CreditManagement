USE [CreditManagementDB]
GO

ALTER TABLE dbo.Branch
ADD [Deposit] [money] NULL,
	[NLCostDeposit] [money] NULL,
	[Advance] [money] NULL,
	[ClassifiedAmount] [money] NULL,
	[WOL] [money] NULL,
	[Profit] [money] NULL,
	[Manpower] [int] NULL
GO
	
ALTER TABLE dbo.Client
ADD [Address] [nvarchar](1000) NULL,
	[CorporateAddress] [nvarchar](1000) NULL,
	[FactoryAddress] [nvarchar](1000) NULL,
	[AuthorizedCapital] [nvarchar](100) NULL,
	[PaidupCapital] [nvarchar](100) NULL,
	[Products] [nvarchar](1000) NULL,
	[IncorporationDate] [date] NULL,
	[BusinessNature] [nvarchar](1000) NULL,
	[ConstitutionNature] [nvarchar](1000) NULL
GO
CREATE TABLE [dbo].[ClientAdministration](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[FatherName] [nvarchar](200) NULL,
	[MotherName] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[Age] [nvarchar](50) NULL,
	[Education] [nvarchar](200) NULL,
	[BackgroundDetails] [nvarchar](1000) NULL,
	[BusinessExperience] [nvarchar](200) NULL,
	[Position] [nvarchar](200) NULL,
	[ActionTime] [datetime] NULL,
 CONSTRAINT [PK_ClientAdministration] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ClientAdministration]  WITH CHECK ADD  CONSTRAINT [FK_ClientAdministration_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO

ALTER TABLE [dbo].[ClientAdministration] CHECK CONSTRAINT [FK_ClientAdministration_Client]
GO

CREATE TABLE [dbo].[ClientSisterConcern](
	[SisterConcernId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](1000) NULL,
	[NationalId] [nvarchar](100) NULL,
	[HoldingShares] [nvarchar](50) NULL,
	[Percentage] [nvarchar](50) NULL,
	[PNW] [nvarchar](50) NULL,
	[ClientId] [int] NOT NULL,
	[ActionTime] [datetime] NULL,
 CONSTRAINT [PK_ClientSisterConcern] PRIMARY KEY CLUSTERED 
(
	[SisterConcernId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ClientSisterConcern]  WITH CHECK ADD  CONSTRAINT [FK_ClientSisterConcern_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO

ALTER TABLE [dbo].[ClientSisterConcern] CHECK CONSTRAINT [FK_ClientSisterConcern_Client]
GO