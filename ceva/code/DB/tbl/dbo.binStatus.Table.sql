SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[binStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [binStatus](
	[dc_code] [nvarchar](10) NOT NULL,
	[wh_code] [nvarchar](10) NOT NULL,
	[id] [int] NOT NULL,
	[bin_area] [nvarchar](10) NOT NULL,
	[bin_code] [nvarchar](10) NOT NULL,
	[dn_no] [nvarchar](20) NOT NULL,
	[type] [nchar](3) NULL,
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
 CONSTRAINT [PK_binStatus] PRIMARY KEY CLUSTERED 
(
	[dc_code] ASC,
	[wh_code] ASC,
	[id] ASC,
	[bin_area] ASC,
	[bin_code] ASC,
	[dn_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
