SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[skuinfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [skuinfo](
	[sku_no] [nvarchar](20) NOT NULL,
	[sku_wms] [nvarchar](20) NOT NULL,
	[sku_desc] [nvarchar](50) NULL,
	[sku_desc_eng] [nvarchar](50) NULL,
	[model_no] [nvarchar](50) NULL,
	[cost_type] [nchar](1) NULL,
	[coutable] [bit] NULL,
	[high_value] [bit] NULL,
	[sku_type] [nvarchar](10) NULL,
	[source] [nvarchar](10) NULL,
	[measured] [bit] NULL,
	[meas_date] [datetime] NULL,
	[have_sno] [bit] NULL,
	[identity] [nvarchar](10) NULL,
	[sno_len] [int] NULL,
	[six_code] [nvarchar](20) NULL,
	[vender] [nvarchar](10) NULL,
	[vender_name] [nvarchar](50) NULL,
	[unit] [nvarchar](10) NULL,
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
	[category] [nvarchar](10) NULL,
	[department] [nvarchar](10) NULL,
	[minqty_sales] [numeric](12, 3) NULL,
	[qty_pack] [numeric](12, 3) NULL,
	[qty_len] [numeric](12, 3) NULL,
	[qty_width] [numeric](12, 3) NULL,
	[qty_height] [numeric](12, 3) NULL,
	[stuff] [nvarchar](50) NULL,
	[expired_day] [datetime] NULL,
	[define1] [nvarchar](50) NULL,
	[define2] [nvarchar](50) NULL,
	[define3] [nvarchar](50) NULL,
	[define4] [nvarchar](50) NULL,
	[define5] [nvarchar](50) NULL,
	[price] [money] NULL,
	[first_opdate] [datetime] NULL,
	[last_opdate] [datetime] NULL,
	[sap_sku] [nvarchar](20) NULL,
	[opt_by] [nvarchar](20) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_skuinfo] PRIMARY KEY CLUSTERED 
(
	[sku_no] ASC,
	[sku_wms] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
