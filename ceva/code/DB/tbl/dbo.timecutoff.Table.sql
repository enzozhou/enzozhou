SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[timecutoff]') AND type in (N'U'))
BEGIN
CREATE TABLE [timecutoff](
	[dc_code] [nvarchar](10) NOT NULL,
	[own_code] [nvarchar](10) NOT NULL,
	[time_cutoff] [int] NOT NULL,
	[opt_by] [nvarchar](50) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NULL,
 CONSTRAINT [PK_timecutoff] PRIMARY KEY CLUSTERED 
(
	[dc_code] ASC,
	[own_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
