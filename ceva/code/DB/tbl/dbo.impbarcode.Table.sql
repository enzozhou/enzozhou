USE [ceva]
GO
/****** 对象:  Table [dbo].[impbarcode]    脚本日期: 05/16/2011 17:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impbarcode](
	[id] [bigint] NOT NULL,
	[sku_no] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[barcode] [nvarchar](30) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[bar_type] [nchar](3) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_by] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_impbarcode] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sku_no] ASC,
	[barcode] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
