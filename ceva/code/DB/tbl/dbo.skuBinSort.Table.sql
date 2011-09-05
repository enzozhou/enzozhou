USE [ceva1]
GO
/****** 对象:  Table [dbo].[skuBinSort]    脚本日期: 08/16/2011 18:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[skuBinSort](
	[userID] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[sku_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[bin_code] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[dn_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[bch_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[task_id] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[opt_time] [datetime] NULL CONSTRAINT [DF_skuBinSort_opt_time]  DEFAULT (getdate()),
 CONSTRAINT [PK_skuBinSort] PRIMARY KEY CLUSTERED 
(
	[userID] ASC,
	[sku_no] ASC,
	[bin_code] ASC,
	[dn_no] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
