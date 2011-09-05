USE [ceva]
GO
/****** 对象:  Table [dbo].[cityairport]    脚本日期: 04/27/2011 11:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cityairport](
	[destination] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[province] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[transit] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[type] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_impcityairport] PRIMARY KEY CLUSTERED 
(
	[destination] ASC,
	[type] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
