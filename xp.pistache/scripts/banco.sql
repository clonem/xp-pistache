USE [pistache]
GO

/****** Object:  Table [dbo].[ClientProductTransaction]    Script Date: 8/12/2024 11:06:40 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientProductTransaction]') AND type in (N'U'))
DROP TABLE [dbo].[ClientProductTransaction]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 8/12/2024 11:07:18 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
DROP TABLE [dbo].[Client]
GO


/****** Object:  Table [dbo].[Product]    Script Date: 8/12/2024 11:07:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO



CREATE TABLE [dbo].[Client](
	[ClientID] [int] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product](
	[ProductID] [int] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [varchar](250) NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ClientProductTransaction](
	[ClientProductID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [nchar](10) NOT NULL,
	[ProductID] [nchar](10) NOT NULL,
	[ProductName] [nchar](10) NOT NULL,
	[ProductPrice] [decimal](18, 4) NOT NULL,
	[ProductQuantity] [int] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
 CONSTRAINT [PK_ClientProductTransaction] PRIMARY KEY CLUSTERED 
(
	[ClientProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





INSERT INTO [dbo].[Client] ([ClientID],[Name],[Email],[CreateAt]) VALUES (1, 'Daemon Moros', 'Daemon.Moros@email.com', GETDATE())
INSERT INTO [dbo].[Client] ([ClientID],[Name],[Email],[CreateAt]) VALUES (2, 'Cerda Obrador', 'Cerda.Obrador@email.com', GETDATE())
INSERT INTO [dbo].[Client] ([ClientID],[Name],[Email],[CreateAt]) VALUES (3, 'Sigvard Loesel', 'Sigvard.Loesel@email.com', GETDATE())
INSERT INTO [dbo].[Client] ([ClientID],[Name],[Email],[CreateAt]) VALUES (4, 'Che Chai', 'Che.Chai@email.com', GETDATE())
INSERT INTO [dbo].[Client] ([ClientID],[Name],[Email],[CreateAt]) VALUES (5, 'Verner Lacher', 'Verner.Lacher@email.com', GETDATE())
GO



INSERT INTO [dbo].[Product] ([ProductID],[Name],[Description],[Price],[Status],[DueDate],[CreateAt]) VALUES (1, 'CDB', 'DESCRIÇÃO CDB', 10.1, 'ENABLE', '2030-01-01', GETDATE())
INSERT INTO [dbo].[Product] ([ProductID],[Name],[Description],[Price],[Status],[DueDate],[CreateAt]) VALUES (2, 'TESOURO IPCA+', 'DESCRIÇÃO TESOURO DIRETO', 27.3, 'ENABLE', '2030-01-01', GETDATE())
INSERT INTO [dbo].[Product] ([ProductID],[Name],[Description],[Price],[Status],[DueDate],[CreateAt]) VALUES (3, 'TESOURO PREFIXADO', 'DESCRIÇÃO TESOURO PREFIXADO', 13.1, 'ENABLE', '2030-01-01', GETDATE())
INSERT INTO [dbo].[Product] ([ProductID],[Name],[Description],[Price],[Status],[DueDate],[CreateAt]) VALUES (4, 'TESOURO SELIC', 'DESCRIÇÃO TESOURO SELIC', 44.2, 'ENABLE', '2030-01-01', GETDATE())
INSERT INTO [dbo].[Product] ([ProductID],[Name],[Description],[Price],[Status],[DueDate],[CreateAt]) VALUES (5, 'LCI', 'DESCRIÇÃO LCI', 22.15, 'ENABLE', '2024-08-12', GETDATE())
INSERT INTO [dbo].[Product] ([ProductID],[Name],[Description],[Price],[Status],[DueDate],[CreateAt]) VALUES (6, 'POUPANÇA', 'DESCRIÇÃO POUPANÇA', 77.23, 'DISABLE', '2030-01-01', GETDATE())
GO



SELECT * FROM [dbo].[Client]
SELECT * FROM [dbo].[Product]

GO

