USE [ceva]
GO
/****** 对象:  Table [dbo].[impcityairport]    脚本日期: 04/27/2011 11:40:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impcityairport](
	[id] [bigint] NOT NULL,
	[destination] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[province] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[transit] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[type] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[opt_dtime] [datetime] NULL,
	[opt_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_cityairport] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[destination] ASC,
	[type] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
