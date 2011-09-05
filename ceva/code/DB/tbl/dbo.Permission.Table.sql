SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Permission]') AND type in (N'U'))
BEGIN
CREATE TABLE [Permission](
	[right_no] [nvarchar](20) NOT NULL,
	[description] [nvarchar](50) NULL,
	[trans_type] [nchar](3) NULL,
	[doc_type] [nchar](3) NULL,
	[cmd_type] [nchar](3) NOT NULL,
	[remark] [ntext] NULL,
	[opt_by] [nvarchar](50) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NULL,
 CONSTRAINT [PK_permission] PRIMARY KEY CLUSTERED 
(
	[right_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
