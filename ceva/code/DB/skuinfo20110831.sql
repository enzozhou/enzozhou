/*
   2011年9月1日18:47:00
   用户: 
   服务器: .
   数据库: ceva
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.skuinfo
	DROP CONSTRAINT DF__skuinfo__cost_ty__5812160E
GO
ALTER TABLE dbo.skuinfo
	DROP CONSTRAINT DF__skuinfo__coutabl__59063A47
GO
CREATE TABLE dbo.Tmp_skuinfo
	(
	sku_no nvarchar(20) NOT NULL,
	sku_wms nvarchar(20) NOT NULL,
	sku_desc nvarchar(50) NULL,
	sku_desc_eng nvarchar(50) NULL,
	model_no nvarchar(50) NULL,
	cost_type nchar(1) NULL,
	coutable bit NULL,
	high_value bit NULL,
	sku_type nvarchar(10) NULL,
	source nvarchar(10) NULL,
	measured bit NULL,
	meas_date datetime NULL,
	have_sno bit NULL,
	[identity] nvarchar(10) NULL,
	sno_len int NULL,
	six_code nvarchar(20) NULL,
	vender nvarchar(10) NULL,
	vender_name nvarchar(200) NULL,
	unit nvarchar(10) NULL,
	gross_weight numeric(12, 3) NULL,
	net_weight numeric(12, 3) NULL,
	volume numeric(20, 9) NULL,
	length numeric(12, 3) NULL,
	width numeric(12, 3) NULL,
	height numeric(12, 3) NULL,
	pack_len numeric(12, 3) NULL,
	pack_width numeric(12, 3) NULL,
	pack_height numeric(12, 3) NULL,
	down_date datetime NULL,
	category nvarchar(10) NULL,
	department nvarchar(10) NULL,
	minqty_sales numeric(12, 3) NULL,
	qty_pack numeric(12, 3) NULL,
	qty_len numeric(12, 3) NULL,
	qty_width numeric(12, 3) NULL,
	qty_height numeric(12, 3) NULL,
	stuff nvarchar(50) NULL,
	expired_day datetime NULL,
	define1 nvarchar(50) NULL,
	define2 nvarchar(50) NULL,
	define3 nvarchar(50) NULL,
	define4 nvarchar(50) NULL,
	define5 nvarchar(50) NULL,
	price money NULL,
	first_opdate datetime NULL,
	last_opdate datetime NULL,
	sap_sku nvarchar(20) NULL,
	opt_by nvarchar(20) NULL,
	opt_dtime datetime NULL,
	opt_timestamp timestamp NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_skuinfo ADD CONSTRAINT
	DF__skuinfo__cost_ty__5812160E DEFAULT (getdate()) FOR cost_type
GO
ALTER TABLE dbo.Tmp_skuinfo ADD CONSTRAINT
	DF__skuinfo__coutabl__59063A47 DEFAULT (((2001)/(1))/(1)) FOR coutable
GO
IF EXISTS(SELECT * FROM dbo.skuinfo)
	 EXEC('INSERT INTO dbo.Tmp_skuinfo (sku_no, sku_wms, sku_desc, sku_desc_eng, model_no, cost_type, coutable, high_value, sku_type, source, measured, meas_date, have_sno, [identity], sno_len, six_code, vender, vender_name, unit, gross_weight, net_weight, volume, length, width, height, pack_len, pack_width, pack_height, down_date, category, department, minqty_sales, qty_pack, qty_len, qty_width, qty_height, stuff, expired_day, define1, define2, define3, define4, define5, price, first_opdate, last_opdate, sap_sku, opt_by, opt_dtime)
		SELECT sku_no, sku_wms, sku_desc, sku_desc_eng, model_no, cost_type, coutable, high_value, sku_type, source, measured, meas_date, have_sno, [identity], sno_len, six_code, vender, vender_name, unit, gross_weight, net_weight, volume, length, width, height, pack_len, pack_width, pack_height, down_date, category, department, minqty_sales, qty_pack, qty_len, qty_width, qty_height, stuff, expired_day, define1, define2, define3, define4, define5, price, first_opdate, last_opdate, sap_sku, opt_by, opt_dtime FROM dbo.skuinfo WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.skuinfo
GO
EXECUTE sp_rename N'dbo.Tmp_skuinfo', N'skuinfo', 'OBJECT' 
GO
ALTER TABLE dbo.skuinfo ADD CONSTRAINT
	PK_skuinfo PRIMARY KEY CLUSTERED 
	(
	sku_no,
	sku_wms
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
