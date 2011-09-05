USE [ceva]
GO
/****** 对象:  Table [dbo].[impskuinfo]    脚本日期: 05/03/2011 20:40:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impskuinfo](
	[id] [bigint] NOT NULL,
	[sku_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[sku_wms] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[sku_desc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sku_desc_eng] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[model_no] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[cost_type] [nchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[coutable] [nchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[high_value] [nchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[sku_type] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[source] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[measured] [nchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[meas_date] [datetime] NULL,
	[have_sno] [nchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[identity1] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[sno_len] [int] NULL,
	[six_code] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[vender] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[vender_name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[unit] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[gross_weight] [numeric](12, 3) NULL,
	[net_weight] [numeric](12, 3) NULL,
	[volume] [numeric](20, 9) NULL,
	[length] [numeric](12, 3) NULL,
	[width] [numeric](12, 3) NULL,
	[height] [numeric](12, 3) NULL,
	[pack_len] [numeric](12, 3) NULL,
	[pack_width] [numeric](12, 3) NULL,
	[pack_height] [numeric](12, 3) NULL,
	[down_date] [datetime] NULL,
	[category] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[department] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[minqty_sales] [numeric](12, 3) NULL,
	[qty_pack] [numeric](12, 3) NULL,
	[qty_len] [numeric](12, 3) NULL,
	[qty_width] [numeric](12, 3) NULL,
	[qty_height] [numeric](12, 3) NULL,
	[stuff] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[expired_day] [datetime] NULL,
	[define1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define4] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[define5] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[price] [money] NULL,
	[first_opdate] [datetime] NULL,
	[last_opdate] [datetime] NULL,
	[sap_sku] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_by] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_dtime] [datetime] NULL,
 CONSTRAINT [PK_impskuinfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sku_no] ASC,
	[sku_wms] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
