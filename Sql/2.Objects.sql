USE [DBTestPharmacy]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 20.07.2022 0:56:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[id] [uniqueidentifier] NOT NULL,
	[Name] [text] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*------------------------------------------------------------*/

USE [DBTestPharmacy]
GO

/****** Object:  Table [dbo].[Pharmacies]    Script Date: 20.07.2022 1:05:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pharmacies](
	[id] [uniqueidentifier] NOT NULL,
	[Name] [text] NOT NULL,
	[Address] [text] NOT NULL,
	[Phone] [text] NULL,
 CONSTRAINT [PK_Pharmacies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*------------------------------------------------------------*/

USE [DBTestPharmacy]
GO

/****** Object:  Table [dbo].[Storages]    Script Date: 20.07.2022 1:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Storages](
	[id] [uniqueidentifier] NOT NULL,
	[Pharmacy_id] [uniqueidentifier] NOT NULL,
	[Name] [text] NOT NULL,
 CONSTRAINT [PK_PharmacyStorages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Storages]  WITH CHECK ADD  CONSTRAINT [FK_PharmacyStorages_Pharmacies] FOREIGN KEY([Pharmacy_id])
REFERENCES [dbo].[Pharmacies] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Storages] CHECK CONSTRAINT [FK_PharmacyStorages_Pharmacies]
GO

/*------------------------------------------------------------*/

USE [DBTestPharmacy]
GO

/****** Object:  Table [dbo].[Batches]    Script Date: 20.07.2022 1:13:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Batches](
	[id] [uniqueidentifier] NOT NULL,
	[Product_id] [uniqueidentifier] NOT NULL,
	[Storage_id] [uniqueidentifier] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Batches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Batches]  WITH CHECK ADD  CONSTRAINT [FK_Batches_Products] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Products] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Batches] CHECK CONSTRAINT [FK_Batches_Products]
GO

ALTER TABLE [dbo].[Batches]  WITH CHECK ADD  CONSTRAINT [FK_Batches_Storages] FOREIGN KEY([Storage_id])
REFERENCES [dbo].[Storages] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Batches] CHECK CONSTRAINT [FK_Batches_Storages]
GO


