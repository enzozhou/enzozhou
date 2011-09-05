USE [ceva]
GO
/****** 对象:  Table [dbo].[ImpDn]    脚本日期: 05/16/2011 10:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpDn](
	[sn] [int] IDENTITY(1,1) NOT NULL,
	[id] [bigint] NOT NULL,
	[dc_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[dn_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[description] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[own_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[wh_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[due_date] [datetime] NULL,
	[sony_bch_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[doc_type] [nchar](3) COLLATE Chinese_PRC_CI_AS NULL,
	[source] [nchar](3) COLLATE Chinese_PRC_CI_AS NULL,
	[stat_type] [nchar](3) COLLATE Chinese_PRC_CI_AS NULL,
	[have_tag] [nchar](1) COLLATE Chinese_PRC_CI_AS NULL,
	[ref_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[status_code] [nchar](5) COLLATE Chinese_PRC_CI_AS NULL,
	[status_trk] [nchar](5) COLLATE Chinese_PRC_CI_AS NULL,
	[imp_dtime] [datetime] NULL,
	[plant] [nchar](4) COLLATE Chinese_PRC_CI_AS NULL,
	[city_from] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[deal_from] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[city_to] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[bill_to] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[bill_name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[bill_person] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[bill_addr] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[bill_tel] [nvarchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[deal_to] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[deal_name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[deal_person] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[deal_tel] [nvarchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[carr_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[method] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[unloading_address] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[instruction] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[route] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[point] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[condition] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sku_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[sku_status] [nchar](4) COLLATE Chinese_PRC_CI_AS NULL,
	[lot_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[serialed] [bit] NULL,
	[qty] [numeric](12, 3) NULL,
	[sku_ref] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[tag_no] [nvarchar](30) COLLATE Chinese_PRC_CI_AS NULL,
	[tag_qty] [int] NULL,
	[opt_by] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_ImpDn_1] PRIMARY KEY CLUSTERED 
(
	[sn] ASC,
	[id] ASC,
	[dc_code] ASC,
	[dn_no] ASC,
	[sku_no] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
