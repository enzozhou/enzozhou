USE [ceva]
GO
/****** 对象:  Table [dbo].[bin]    脚本日期: 04/27/2011 11:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bin](
	[dc_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[bin_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[description] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wh_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[bin_type] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[bin_area] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[area] [numeric](12, 3) NULL,
	[palls] [numeric](12, 3) NULL,
	[length] [numeric](12, 3) NULL,
	[width] [numeric](12, 3) NULL,
	[weight] [numeric](12, 3) NULL,
	[volume] [numeric](20, 9) NULL,
	[canpick] [bit] NULL,
	[isblocked] [bit] NULL,
	[define1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define4] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define5] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_by] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_bin] PRIMARY KEY CLUSTERED 
(
	[dc_code] ASC,
	[bin_code] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
