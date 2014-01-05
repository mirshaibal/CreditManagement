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
	