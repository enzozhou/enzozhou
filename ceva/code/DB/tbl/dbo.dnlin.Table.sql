USE [ceva]
GO
/****** 对象:  Table [dbo].[dnlin]    脚本日期: 04/19/2011 13:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dnlin](
	[dc_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[dn_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[row_id] [nchar](5) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[own_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[wh_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[bin_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[sku_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[sku_status] [nchar](4) COLLATE Chinese_PRC_CI_AS NULL,
	[lot_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[serialed] [bit] NULL,
	[qty] [numeric](12, 3) NULL,
	[act_qty] [numeric](12, 3) NULL,
	[status_code] [nchar](5) COLLATE Chinese_PRC_CI_AS NULL,
	[sku_ref] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[tag_no] [nvarchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[tag_qty] [int] NULL,
	[req_id] [bigint] NULL,
	[to_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[to_row] [nchar](5) COLLATE Chinese_PRC_CI_AS NULL,
	[exp_status] [int] NULL,
	[opt_by] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_dnlin] PRIMARY KEY CLUSTERED 
(
	[dc_code] ASC,
	[dn_no] ASC,
	[row_id] ASC,
	[sku_no] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
