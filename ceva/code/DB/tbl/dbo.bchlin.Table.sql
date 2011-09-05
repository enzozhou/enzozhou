SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[bchlin]') AND type in (N'U'))
BEGIN
CREATE TABLE [bchlin](
	[dc_code] [nvarchar](10) NOT NULL,
	[bch_no] [nvarchar](20) NOT NULL,
	[wh_code] [nvarchar](10) NOT NULL,
	[dn_no] [nvarchar](20) NOT NULL,
	[bch_type] [nchar](3) NULL,
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
 CONSTRAINT [PK_bchlin] PRIMARY KEY CLUSTERED 
(
	[dc_code] ASC,
	[bch_no] ASC,
	[wh_code] ASC,
	[dn_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
