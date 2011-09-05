USE [ceva]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[barcode]') AND type in (N'U'))
BEGIN
CREATE TABLE [barcode](
	[sku_no] [nvarchar](20) NOT NULL,
	[barcode] [nvarchar](30) NOT NULL,
	[bar_type] [nchar](3) NULL,
	[opt_by] [nvarchar](20) NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_barcode] PRIMARY KEY CLUSTERED 
(
	[sku_no] ASC,
	[barcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
