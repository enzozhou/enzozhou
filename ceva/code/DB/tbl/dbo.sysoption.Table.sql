SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sysoption]') AND type in (N'U'))
BEGIN
CREATE TABLE [sysoption](
	[opt_group] [nvarchar](10) NOT NULL,
	[opt_code] [nvarchar](50) NOT NULL,
	[sub_code] [nvarchar](20) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[checked] [bit] NOT NULL,
	[value] [nvarchar](100) NULL,
	[trans_type] [nchar](3) NULL,
	[remark] [ntext] NULL,
	[opt_by] [nvarchar](50) NULL,
	[opt_date] [datetime] NULL,
	[sort_idx] [int] NOT NULL,
	[opt_timestamp] [timestamp] NULL,
 CONSTRAINT [PK_sysoption] PRIMARY KEY CLUSTERED 
(
	[opt_group] ASC,
	[opt_code] ASC,
	[sub_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
