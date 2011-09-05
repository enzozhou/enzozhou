/****** Object:  StoredProcedure [dbo].[sp_hht_getavailablebatchno]    Script Date: 08/31/2011 02:20:40 ******/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--	@sErr 返回信息值: 
------------------------------------

CREATE PROCEDURE [dbo].[sp_hht_getavailablebatchno]
	@sErr	varchar(50) OUTPUT 

AS
BEGIN
	SELECT DISTINCT bch_no, task_id from tasklist where status_code < 2 order by bch_no DESC
END 

