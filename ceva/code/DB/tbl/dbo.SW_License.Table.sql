SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SW_License]') AND type in (N'U'))
BEGIN
CREATE TABLE [SW_License](
	[AutoID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[DeviceSN] [nvarchar](255) NULL,
	[DeviceName] [nvarchar](100) NULL,
	[LicenseKey] [nvarchar](50) NULL,
	[Organization] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
