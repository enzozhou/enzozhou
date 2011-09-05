SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[binarea]') AND type in (N'U'))
BEGIN
CREATE TABLE [binarea](
	[dc_code] [nvarchar](10) NOT NULL,
	[bin_area] [nvarchar](10) NOT NULL,
	[description] [nvarchar](50) NULL,
	[wh_code] [nvarchar](10) NULL,
	[seq] [nchar](3) NULL,
	[address] [nvarchar](50) NULL,
	[person] [nvarchar](50) NULL,
	[tel] [nvarchar](20) NULL,
	[fax] [nvarchar](20) NULL,
	[zip] [nchar](6) NULL,
	[dif_sku] [bit] NULL,
	[dif_status] [bit] NULL,
	[dif_owner] [bit] NULL,
	[define1] [nvarchar](50) NULL,
	[define2] [nvarchar](50) NULL,
	[define3] [nvarchar](50) NULL,
	[define4] [nvarchar](50) NULL,
	[define5] [nvarchar](50) NULL,
	[opt_by] [nvarchar](50) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_binarea] PRIMARY KEY CLUSTERED 
(
	[dc_code] ASC,
	[bin_area] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
