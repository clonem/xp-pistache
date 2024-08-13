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




