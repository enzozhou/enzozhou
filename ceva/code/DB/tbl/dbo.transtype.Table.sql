SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transtype]') AND type in (N'U'))
BEGIN
CREATE TABLE [transtype](
	[trans_type] [nchar](3) NOT NULL,
	[trans_desc] [nvarchar](50) NOT NULL,
	[trans_desc_eng] [nvarchar](50) NULL,
	[trans_seq] [int] NOT NULL,
	[opt_date] [nvarchar](20) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NULL,
 CONSTRAINT [PK_transtype] PRIMARY KEY CLUSTERED 
(
	[trans_type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
