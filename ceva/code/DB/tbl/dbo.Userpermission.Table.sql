SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Userpermission]') AND type in (N'U'))
BEGIN
CREATE TABLE [Userpermission](
	[user_code] [nvarchar](20) NOT NULL,
	[right_no] [nvarchar](20) NOT NULL,
	[remark] [ntext] NULL,
	[opt_by] [nvarchar](20) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NULL,
 CONSTRAINT [PK_Userpermission] PRIMARY KEY CLUSTERED 
(
	[user_code] ASC,
	[right_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
