SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[tasklin]') AND type in (N'U'))
BEGIN
CREATE TABLE [tasklin](
	[rowid] [nvarchar](10) NOT NULL,
	[dc_code] [nvarchar](10) NOT NULL,
	[wh_code] [nvarchar](10) NOT NULL,
	[task_id] [nvarchar](20) NOT NULL,
	[bch_no] [nvarchar](20) NULL,
	[dn_no] [nvarchar](20) NULL,
	[bin_area] [nvarchar](10) NOT NULL,
	[bin_code] [nvarchar](10) NULL,
	[sku_no] [nvarchar](20) NULL,
	[sno] [nvarchar](20) NULL,
	[type] [nchar](3) NULL,
	[qty] [numeric](12, 3) NULL,
	[status_code] [nchar](5) NULL,
	[close_auto] [bit] NULL,
	[print_by] [nvarchar](20) NULL,
	[print_counter] [int] NULL,
	[print_dtime] [datetime] NULL,
	[locked] [int] NULL,
	[opt_by] [nvarchar](20) NULL,
	[opt_dtime] [datetime] NULL,
	[start_dtime] [datetime] NULL,
	[end_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_tasklin] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC,
	[dc_code] ASC,
	[wh_code] ASC,
	[task_id] ASC,
	[bin_area] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
