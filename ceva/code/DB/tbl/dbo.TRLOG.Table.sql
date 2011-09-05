SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TRLOG]') AND type in (N'U'))
BEGIN
CREATE TABLE [TRLOG](
	[log_id] [bigint] IDENTITY(1,1) NOT NULL,
	[trans_type] [nchar](3) NULL,
	[cmd_type] [nchar](3) NULL,
	[doc_no] [nvarchar](24) NULL,
	[LINENUM] [nchar](4) NULL,
	[STCD] [nvarchar](6) NULL,
	[ITEMNO] [nvarchar](24) NULL,
	[ITEM_DESC] [nvarchar](60) NULL,
	[BANTCH] [nvarchar](24) NULL,
	[QTY] [numeric](14, 4) NULL,
	[status] [nvarchar](50) NULL,
	[reason] [nvarchar](50) NULL,
	[reasonDesc] [varchar](255) NULL,
	[OPT_BY] [nvarchar](50) NULL,
	[OPT_ADDR] [nvarchar](50) NULL,
	[OPT_DATE] [datetime] NULL,
	[OPT_TIMESTAMP] [timestamp] NULL,
 CONSTRAINT [PK_TRLOG] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
