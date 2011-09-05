SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[OPERATOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [OPERATOR](
	[user_code] [nvarchar](20) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[password] [nvarchar](20) NULL,
	[STCD] [nvarchar](6) NULL,
	[allowlogin] [bit] NULL,
	[isadmin] [bit] NULL,
	[title] [nvarchar](50) NULL,
	[tel] [nvarchar](20) NULL,
	[fax] [nvarchar](20) NULL,
	[mobile] [nvarchar](20) NULL,
	[email] [nvarchar](50) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[opt_by] [nvarchar](20) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NULL,
 CONSTRAINT [PK_OPERATOR] PRIMARY KEY CLUSTERED 
(
	[user_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
