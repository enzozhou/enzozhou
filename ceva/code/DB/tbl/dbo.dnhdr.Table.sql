USE [ceva]
GO
/****** 对象:  Table [dbo].[dnhdr]    脚本日期: 04/27/2011 09:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dnhdr](
	[dc_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[dn_no] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[description] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[own_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[wh_code] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[due_date] [datetime] NULL,
	[bch_no] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
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
	[exp_status] [int] NULL,
	[close_auto] [bit] NULL,
	[archived] [bit] NULL,
	[print_by] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[print_counter] [int] NULL,
	[print_dtime] [datetime] NULL,
	[opt_by] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[opt_dtime] [datetime] NULL,
	[start_dtime] [datetime] NULL,
	[end_dtime] [datetime] NULL,
	[remark] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_dnhdr] PRIMARY KEY CLUSTERED 
(
	[dc_code] ASC,
	[dn_no] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
