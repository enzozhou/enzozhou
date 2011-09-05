
-- ********
-- Database
-- ********
USE ceva
GO

EXEC sp_dropmessage 51000
GO
EXEC sp_addmessage @msgnum = 51000, 
   @severity = 16, 
   @msgtext = N'Another user has changed this record.
Please refresh your records and edit it again.'
GO
--*****************************************************************************
--* 
--* Script Name:  clsOPERATOR.SQL 
--*
--* Procedures:   stp_I_clsOPERATOR  - Insert
--*               stp_U_clsOPERATOR  - Update
--*               stp_D_clsOPERATOR  - Delete
--*               stp_S_clsOPERATOR  - Select 
--*               stp_SL_clsOPERATOR - Select List
--*
--* Description:  Stored procedure script For table clsOPERATOR.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsOPERATOR
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsOPERATOR')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsOPERATOR
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsOPERATOR(  @user_code nvarchar (20) ,
  @user_name nvarchar (50) ,
  @password_ nvarchar (20) ,
  @STCD nvarchar (6) ,
  @allowlogin bit ,
  @isadmin bit ,
  @title nvarchar (50) ,
  @tel nvarchar (20) ,
  @fax nvarchar (20) ,
  @mobile nvarchar (20) ,
  @email nvarchar (50) ,
  @create_date datetime ,
  @update_date datetime ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[OPERATOR]
(  user_code ,
  user_name ,
  password ,
  STCD ,
  allowlogin ,
  isadmin ,
  title ,
  tel ,
  fax ,
  mobile ,
  email ,
  create_date ,
  update_date ,
  opt_by ,
  opt_dtime  )
VALUES (  @user_code ,
  @user_name ,
  @password_ ,
  @STCD ,
  @allowlogin ,
  @isadmin ,
  @title ,
  @tel ,
  @fax ,
  @mobile ,
  @email ,
  @create_date ,
  @update_date ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsOPERATOR
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsOPERATOR')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsOPERATOR
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsOPERATOR(  @OLD___user_code nvarchar (20) ,
  @user_code nvarchar (20) ,
  @user_name nvarchar (50) ,
  @password_ nvarchar (20) ,
  @STCD nvarchar (6) ,
  @allowlogin bit ,
  @isadmin bit ,
  @title nvarchar (50) ,
  @tel nvarchar (20) ,
  @fax nvarchar (20) ,
  @mobile nvarchar (20) ,
  @email nvarchar (50) ,
  @create_date datetime ,
  @update_date datetime ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[OPERATOR] 
WHERE user_code =  @OLD___user_code 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[OPERATOR] Set 
    user_code = @user_code,
    user_name = @user_name,
    password = @password_,
    STCD = @STCD,
    allowlogin = @allowlogin,
    isadmin = @isadmin,
    title = @title,
    tel = @tel,
    fax = @fax,
    mobile = @mobile,
    email = @email,
    create_date = @create_date,
    update_date = @update_date,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( user_code =  @OLD___user_code )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsOPERATOR
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsOPERATOR')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsOPERATOR
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsOPERATOR
  (  @user_code nvarchar (20)  )
As DELETE [dbo].[OPERATOR] 
WHERE (user_code =  @user_code)
GO



--*****************************************************************************
-- Name:        stp_S_clsOPERATOR
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsOPERATOR')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsOPERATOR
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsOPERATOR
  (  @OLD___user_code nvarchar (20)  )
As SELECT TOP 1000 a.user_code,a.user_name,a.password,a.STCD,a.allowlogin,a.isadmin,a.title,a.tel,a.fax,a.mobile,a.email,a.create_date,a.update_date,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[OPERATOR] a
WHERE (a.user_code =  @OLD___user_code) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsOPERATOR
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsOPERATOR')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsOPERATOR
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsOPERATOR
  As SELECT TOP 1000 a.user_code,a.user_name,a.password,a.STCD,a.allowlogin,a.isadmin,a.title,a.tel,a.fax,a.mobile,a.email,a.create_date,a.update_date,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[OPERATOR] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsUserpermission.SQL 
--*
--* Procedures:   stp_I_clsUserpermission  - Insert
--*               stp_U_clsUserpermission  - Update
--*               stp_D_clsUserpermission  - Delete
--*               stp_S_clsUserpermission  - Select 
--*               stp_S_clsUserpermission_clsOPERATORRelated  - Select Related
--*               stp_SL_clsUserpermission - Select List
--*
--* Description:  Stored procedure script For table clsUserpermission.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsUserpermission
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsUserpermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsUserpermission
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsUserpermission(  @user_code nvarchar (20) ,
  @right_no nvarchar (20) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[Userpermission]
(  user_code ,
  right_no ,
  remark ,
  opt_by ,
  opt_dtime  )
VALUES (  @user_code ,
  @right_no ,
  @remark ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsUserpermission
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsUserpermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsUserpermission
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsUserpermission(  @OLD___user_code nvarchar (20) ,
  @OLD___right_no nvarchar (20) ,
  @user_code nvarchar (20) ,
  @right_no nvarchar (20) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[Userpermission] 
WHERE user_code =  @OLD___user_code AND 
right_no =  @OLD___right_no 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[Userpermission] Set 
    user_code = @user_code,
    right_no = @right_no,
    remark = @remark,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( user_code =  @OLD___user_code AND 
right_no =  @OLD___right_no )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsUserpermission
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsUserpermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsUserpermission
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsUserpermission
  (  @user_code nvarchar (20) ,
  @right_no nvarchar (20)  )
As DELETE [dbo].[Userpermission] 
WHERE (user_code =  @user_code AND 
right_no =  @right_no)
GO



--*****************************************************************************
-- Name:        stp_S_clsUserpermission
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsUserpermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsUserpermission
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsUserpermission
  (  @OLD___user_code nvarchar (20) ,
  @OLD___right_no nvarchar (20)  )
As SELECT TOP 1000 a.user_code,a.right_no,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Userpermission] a
WHERE (a.user_code =  @OLD___user_code AND 
a.right_no =  @OLD___right_no) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsUserpermission
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsUserpermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsUserpermission
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsUserpermission
  As SELECT TOP 1000 a.user_code,a.right_no,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Userpermission] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsUserpermission_clsOPERATORRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsUserpermission_clsOPERATORRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsUserpermission_clsOPERATORRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsUserpermission_clsOPERATORRelated
(  @OLD___user_code nvarchar (20)  )
  As 
SELECT TOP 1000 a.user_code,a.right_no,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Userpermission] a
WHERE 
a.user_code =  @OLD___user_code 
GO
--*****************************************************************************
--* 
--* Script Name:  clsUserrole.SQL 
--*
--* Procedures:   stp_I_clsUserrole  - Insert
--*               stp_U_clsUserrole  - Update
--*               stp_D_clsUserrole  - Delete
--*               stp_S_clsUserrole  - Select 
--*               stp_S_clsUserrole_clsOPERATORRelated  - Select Related
--*               stp_S_clsUserrole_clsRoleRelated  - Select Related
--*               stp_SL_clsUserrole - Select List
--*
--* Description:  Stored procedure script For table clsUserrole.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsUserrole
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsUserrole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsUserrole
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsUserrole(  @user_code nvarchar (20) ,
  @role_code nvarchar (10) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[Userrole]
(  user_code ,
  role_code ,
  remark ,
  opt_by ,
  opt_dtime  )
VALUES (  @user_code ,
  @role_code ,
  @remark ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsUserrole
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsUserrole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsUserrole
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsUserrole(  @OLD___user_code nvarchar (20) ,
  @OLD___role_code nvarchar (10) ,
  @user_code nvarchar (20) ,
  @role_code nvarchar (10) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[Userrole] 
WHERE user_code =  @OLD___user_code AND 
role_code =  @OLD___role_code 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[Userrole] Set 
    user_code = @user_code,
    role_code = @role_code,
    remark = @remark,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( user_code =  @OLD___user_code AND 
role_code =  @OLD___role_code )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsUserrole
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsUserrole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsUserrole
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsUserrole
  (  @user_code nvarchar (20) ,
  @role_code nvarchar (10)  )
As DELETE [dbo].[Userrole] 
WHERE (user_code =  @user_code AND 
role_code =  @role_code)
GO



--*****************************************************************************
-- Name:        stp_S_clsUserrole
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsUserrole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsUserrole
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsUserrole
  (  @OLD___user_code nvarchar (20) ,
  @OLD___role_code nvarchar (10)  )
As SELECT TOP 1000 a.user_code,a.role_code,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Userrole] a
WHERE (a.user_code =  @OLD___user_code AND 
a.role_code =  @OLD___role_code) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsUserrole
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsUserrole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsUserrole
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsUserrole
  As SELECT TOP 1000 a.user_code,a.role_code,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Userrole] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsUserrole_clsOPERATORRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsUserrole_clsOPERATORRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsUserrole_clsOPERATORRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsUserrole_clsOPERATORRelated
(  @OLD___user_code nvarchar (20)  )
  As 
SELECT TOP 1000 a.user_code,a.role_code,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Userrole] a
WHERE 
a.user_code =  @OLD___user_code 
GO

--*****************************************************************************
-- Name:        stp_S_clsUserrole_clsRoleRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsUserrole_clsRoleRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsUserrole_clsRoleRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsUserrole_clsRoleRelated
(  @OLD___role_code nvarchar (10)  )
  As 
SELECT TOP 1000 a.user_code,a.role_code,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Userrole] a
WHERE 
a.role_code =  @OLD___role_code 
GO
--*****************************************************************************
--* 
--* Script Name:  clsPermission.SQL 
--*
--* Procedures:   stp_I_clsPermission  - Insert
--*               stp_U_clsPermission  - Update
--*               stp_D_clsPermission  - Delete
--*               stp_S_clsPermission  - Select 
--*               stp_SL_clsPermission - Select List
--*
--* Description:  Stored procedure script For table clsPermission.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsPermission
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsPermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsPermission
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsPermission(  @right_no nvarchar (20) ,
  @description nvarchar (50) ,
  @trans_type nchar (3) ,
  @doc_type nchar (3) ,
  @cmd_type nchar (3) ,
  @remark ntext ,
  @opt_by nvarchar (50) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[Permission]
(  right_no ,
  description ,
  trans_type ,
  doc_type ,
  cmd_type ,
  remark ,
  opt_by ,
  opt_dtime  )
VALUES (  @right_no ,
  @description ,
  @trans_type ,
  @doc_type ,
  @cmd_type ,
  @remark ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsPermission
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsPermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsPermission
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsPermission(  @OLD___right_no nvarchar (20) ,
  @right_no nvarchar (20) ,
  @description nvarchar (50) ,
  @trans_type nchar (3) ,
  @doc_type nchar (3) ,
  @cmd_type nchar (3) ,
  @remark ntext ,
  @opt_by nvarchar (50) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[Permission] 
WHERE right_no =  @OLD___right_no 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[Permission] Set 
    right_no = @right_no,
    description = @description,
    trans_type = @trans_type,
    doc_type = @doc_type,
    cmd_type = @cmd_type,
    remark = @remark,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( right_no =  @OLD___right_no )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsPermission
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsPermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsPermission
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsPermission
  (  @right_no nvarchar (20)  )
As DELETE [dbo].[Permission] 
WHERE (right_no =  @right_no)
GO



--*****************************************************************************
-- Name:        stp_S_clsPermission
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsPermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsPermission
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsPermission
  (  @OLD___right_no nvarchar (20)  )
As SELECT TOP 1000 a.right_no,a.description,a.trans_type,a.doc_type,a.cmd_type,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Permission] a
WHERE (a.right_no =  @OLD___right_no) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsPermission
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsPermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsPermission
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsPermission
  As SELECT TOP 1000 a.right_no,a.description,a.trans_type,a.doc_type,a.cmd_type,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Permission] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsRole.SQL 
--*
--* Procedures:   stp_I_clsRole  - Insert
--*               stp_U_clsRole  - Update
--*               stp_D_clsRole  - Delete
--*               stp_S_clsRole  - Select 
--*               stp_SL_clsRole - Select List
--*
--* Description:  Stored procedure script For table clsRole.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsRole
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsRole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsRole
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsRole(  @role_code nvarchar (10) ,
  @role_name nvarchar (50) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[Role]
(  role_code ,
  role_name ,
  remark ,
  opt_by ,
  opt_dtime  )
VALUES (  @role_code ,
  @role_name ,
  @remark ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsRole
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsRole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsRole
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsRole(  @OLD___role_code nvarchar (10) ,
  @role_code nvarchar (10) ,
  @role_name nvarchar (50) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[Role] 
WHERE role_code =  @OLD___role_code 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[Role] Set 
    role_code = @role_code,
    role_name = @role_name,
    remark = @remark,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( role_code =  @OLD___role_code )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsRole
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsRole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsRole
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsRole
  (  @role_code nvarchar (10)  )
As DELETE [dbo].[Role] 
WHERE (role_code =  @role_code)
GO



--*****************************************************************************
-- Name:        stp_S_clsRole
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsRole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsRole
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsRole
  (  @OLD___role_code nvarchar (10)  )
As SELECT TOP 1000 a.role_code,a.role_name,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Role] a
WHERE (a.role_code =  @OLD___role_code) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsRole
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsRole')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsRole
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsRole
  As SELECT TOP 1000 a.role_code,a.role_name,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Role] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsRolepermission.SQL 
--*
--* Procedures:   stp_I_clsRolepermission  - Insert
--*               stp_U_clsRolepermission  - Update
--*               stp_D_clsRolepermission  - Delete
--*               stp_S_clsRolepermission  - Select 
--*               stp_S_clsRolepermission_clsRoleRelated  - Select Related
--*               stp_SL_clsRolepermission - Select List
--*
--* Description:  Stored procedure script For table clsRolepermission.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsRolepermission
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsRolepermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsRolepermission
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsRolepermission(  @role_code nvarchar (10) ,
  @right_no nvarchar (20) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[Rolepermission]
(  role_code ,
  right_no ,
  remark ,
  opt_by ,
  opt_dtime  )
VALUES (  @role_code ,
  @right_no ,
  @remark ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsRolepermission
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsRolepermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsRolepermission
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsRolepermission(  @OLD___role_code nvarchar (10) ,
  @OLD___right_no nvarchar (20) ,
  @role_code nvarchar (10) ,
  @right_no nvarchar (20) ,
  @remark ntext ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[Rolepermission] 
WHERE role_code =  @OLD___role_code AND 
right_no =  @OLD___right_no 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[Rolepermission] Set 
    role_code = @role_code,
    right_no = @right_no,
    remark = @remark,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( role_code =  @OLD___role_code AND 
right_no =  @OLD___right_no )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsRolepermission
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsRolepermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsRolepermission
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsRolepermission
  (  @role_code nvarchar (10) ,
  @right_no nvarchar (20)  )
As DELETE [dbo].[Rolepermission] 
WHERE (role_code =  @role_code AND 
right_no =  @right_no)
GO



--*****************************************************************************
-- Name:        stp_S_clsRolepermission
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsRolepermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsRolepermission
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsRolepermission
  (  @OLD___role_code nvarchar (10) ,
  @OLD___right_no nvarchar (20)  )
As SELECT TOP 1000 a.role_code,a.right_no,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Rolepermission] a
WHERE (a.role_code =  @OLD___role_code AND 
a.right_no =  @OLD___right_no) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsRolepermission
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsRolepermission')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsRolepermission
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsRolepermission
  As SELECT TOP 1000 a.role_code,a.right_no,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Rolepermission] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsRolepermission_clsRoleRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsRolepermission_clsRoleRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsRolepermission_clsRoleRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsRolepermission_clsRoleRelated
(  @OLD___role_code nvarchar (10)  )
  As 
SELECT TOP 1000 a.role_code,a.right_no,a.remark,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[Rolepermission] a
WHERE 
a.role_code =  @OLD___role_code 
GO
--*****************************************************************************
--* 
--* Script Name:  clsTRLOG.SQL 
--*
--* Procedures:   stp_I_clsTRLOG  - Insert
--*               stp_U_clsTRLOG  - Update
--*               stp_D_clsTRLOG  - Delete
--*               stp_S_clsTRLOG  - Select 
--*               stp_SL_clsTRLOG - Select List
--*
--* Description:  Stored procedure script For table clsTRLOG.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsTRLOG
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsTRLOG')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsTRLOG
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsTRLOG(@log_id bigint OUT,
  @trans_type nchar (3) ,
  @cmd_type nchar (3) ,
  @doc_no nvarchar (24) ,
  @LINENUM nchar (4) ,
  @STCD nvarchar (6) ,
  @ITEMNO nvarchar (24) ,
  @ITEM_DESC nvarchar (60) ,
  @BANTCH nvarchar (24) ,
  @QTY numeric (14,4) ,
  @status nvarchar (50) ,
  @reason nvarchar (50) ,
  @reasonDesc varchar (255) ,
  @OPT_BY nvarchar (50) ,
  @OPT_ADDR nvarchar (50) ,
  @OPT_DATE datetime ,
@OPT_TIMESTAMP timestamp OUT )
As 
	INSERT INTO [dbo].[TRLOG]
(  trans_type ,
  cmd_type ,
  doc_no ,
  LINENUM ,
  STCD ,
  ITEMNO ,
  ITEM_DESC ,
  BANTCH ,
  QTY ,
  status ,
  reason ,
  reasonDesc ,
  OPT_BY ,
  OPT_ADDR ,
  OPT_DATE  )
VALUES (  @trans_type ,
  @cmd_type ,
  @doc_no ,
  @LINENUM ,
  @STCD ,
  @ITEMNO ,
  @ITEM_DESC ,
  @BANTCH ,
  @QTY ,
  @status ,
  @reason ,
  @reasonDesc ,
  @OPT_BY ,
  @OPT_ADDR ,
  @OPT_DATE  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @log_id = @@IDENTITY
  Select @OPT_TIMESTAMP = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsTRLOG
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsTRLOG')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsTRLOG
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsTRLOG(  @OLD___log_id bigint ,
  @trans_type nchar (3) ,
  @cmd_type nchar (3) ,
  @doc_no nvarchar (24) ,
  @LINENUM nchar (4) ,
  @STCD nvarchar (6) ,
  @ITEMNO nvarchar (24) ,
  @ITEM_DESC nvarchar (60) ,
  @BANTCH nvarchar (24) ,
  @QTY numeric (14,4) ,
  @status nvarchar (50) ,
  @reason nvarchar (50) ,
  @reasonDesc varchar (255) ,
  @OPT_BY nvarchar (50) ,
  @OPT_ADDR nvarchar (50) ,
  @OPT_DATE datetime ,
  @OPT_TIMESTAMP TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, OPT_TIMESTAMP) from [dbo].[TRLOG] 
WHERE log_id =  @OLD___log_id 
If @NewStamp != CONVERT(bigint, @OPT_TIMESTAMP)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[TRLOG] Set 
    trans_type = @trans_type,
    cmd_type = @cmd_type,
    doc_no = @doc_no,
    LINENUM = @LINENUM,
    STCD = @STCD,
    ITEMNO = @ITEMNO,
    ITEM_DESC = @ITEM_DESC,
    BANTCH = @BANTCH,
    QTY = @QTY,
    status = @status,
    reason = @reason,
    reasonDesc = @reasonDesc,
    OPT_BY = @OPT_BY,
    OPT_ADDR = @OPT_ADDR,
    OPT_DATE = @OPT_DATE 
WHERE 	( log_id =  @OLD___log_id )
  Select @OPT_TIMESTAMP=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsTRLOG
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsTRLOG')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsTRLOG
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsTRLOG
  (  @log_id bigint  )
As DELETE [dbo].[TRLOG] 
WHERE (log_id =  @log_id)
GO



--*****************************************************************************
-- Name:        stp_S_clsTRLOG
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsTRLOG')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsTRLOG
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsTRLOG
  (  @OLD___log_id bigint  )
As SELECT TOP 1000 a.log_id,a.trans_type,a.cmd_type,a.doc_no,a.LINENUM,a.STCD,a.ITEMNO,a.ITEM_DESC,a.BANTCH,a.QTY,a.status,a.reason,a.reasonDesc,a.OPT_BY,a.OPT_ADDR,a.OPT_DATE,CONVERT(varchar(30), CONVERT(INT, a.OPT_TIMESTAMP),13) OPT_TIMESTAMP  FROM [dbo].[TRLOG] a
WHERE (a.log_id =  @OLD___log_id) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsTRLOG
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsTRLOG')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsTRLOG
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsTRLOG
  As SELECT TOP 1000 a.log_id,a.trans_type,a.cmd_type,a.doc_no,a.LINENUM,a.STCD,a.ITEMNO,a.ITEM_DESC,a.BANTCH,a.QTY,a.status,a.reason,a.reasonDesc,a.OPT_BY,a.OPT_ADDR,a.OPT_DATE,CONVERT(varchar(30), CONVERT(INT, a.OPT_TIMESTAMP),13) OPT_TIMESTAMP  FROM [dbo].[TRLOG] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsbchhdr.SQL 
--*
--* Procedures:   stp_I_clsbchhdr  - Insert
--*               stp_U_clsbchhdr  - Update
--*               stp_D_clsbchhdr  - Delete
--*               stp_S_clsbchhdr  - Select 
--*               stp_SL_clsbchhdr - Select List
--*
--* Description:  Stored procedure script For table clsbchhdr.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsbchhdr
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsbchhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsbchhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsbchhdr(  @dc_code nvarchar (10) ,
  @bch_no nvarchar (20) ,
  @description nvarchar (20) ,
  @status_code nchar (5) ,
  @locked int ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[bchhdr]
(  dc_code ,
  bch_no ,
  description ,
  status_code ,
  locked ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime  )
VALUES (  @dc_code ,
  @bch_no ,
  @description ,
  @status_code ,
  @locked ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsbchhdr
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsbchhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsbchhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsbchhdr(  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20) ,
  @dc_code nvarchar (10) ,
  @bch_no nvarchar (20) ,
  @description nvarchar (20) ,
  @status_code nchar (5) ,
  @locked int ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[bchhdr] 
WHERE dc_code =  @OLD___dc_code AND 
bch_no =  @OLD___bch_no 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[bchhdr] Set 
    dc_code = @dc_code,
    bch_no = @bch_no,
    description = @description,
    status_code = @status_code,
    locked = @locked,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime 
WHERE 	( dc_code =  @OLD___dc_code AND 
bch_no =  @OLD___bch_no )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsbchhdr
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsbchhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsbchhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsbchhdr
  (  @dc_code nvarchar (10) ,
  @bch_no nvarchar (20)  )
As DELETE [dbo].[bchhdr] 
WHERE (dc_code =  @dc_code AND 
bch_no =  @bch_no)
GO



--*****************************************************************************
-- Name:        stp_S_clsbchhdr
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbchhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbchhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbchhdr
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20)  )
As SELECT TOP 1000 a.dc_code,a.bch_no,a.description,a.status_code,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bchhdr] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.bch_no =  @OLD___bch_no) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsbchhdr
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsbchhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsbchhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsbchhdr
  As SELECT TOP 1000 a.dc_code,a.bch_no,a.description,a.status_code,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bchhdr] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsbchlin.SQL 
--*
--* Procedures:   stp_I_clsbchlin  - Insert
--*               stp_U_clsbchlin  - Update
--*               stp_D_clsbchlin  - Delete
--*               stp_S_clsbchlin  - Select 
--*               stp_S_clsbchlin_clsbchhdrRelated  - Select Related
--*               stp_SL_clsbchlin - Select List
--*
--* Description:  Stored procedure script For table clsbchlin.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsbchlin
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsbchlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsbchlin
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsbchlin(  @dc_code nvarchar (10) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @status_code nchar (5) ,
  @locked int ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[bchlin]
(  dc_code ,
  bch_no ,
  dn_no ,
  status_code ,
  locked ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime  )
VALUES (  @dc_code ,
  @bch_no ,
  @dn_no ,
  @status_code ,
  @locked ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsbchlin
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsbchlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsbchlin
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsbchlin(  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20) ,
  @OLD___dn_no nvarchar (20) ,
  @dc_code nvarchar (10) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @status_code nchar (5) ,
  @locked int ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[bchlin] 
WHERE dc_code =  @OLD___dc_code AND 
bch_no =  @OLD___bch_no AND 
dn_no =  @OLD___dn_no 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[bchlin] Set 
    dc_code = @dc_code,
    bch_no = @bch_no,
    dn_no = @dn_no,
    status_code = @status_code,
    locked = @locked,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime 
WHERE 	( dc_code =  @OLD___dc_code AND 
bch_no =  @OLD___bch_no AND 
dn_no =  @OLD___dn_no )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsbchlin
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsbchlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsbchlin
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsbchlin
  (  @dc_code nvarchar (10) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20)  )
As DELETE [dbo].[bchlin] 
WHERE (dc_code =  @dc_code AND 
bch_no =  @bch_no AND 
dn_no =  @dn_no)
GO



--*****************************************************************************
-- Name:        stp_S_clsbchlin
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbchlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbchlin
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbchlin
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20) ,
  @OLD___dn_no nvarchar (20)  )
As SELECT TOP 1000 a.dc_code,a.bch_no,a.dn_no,a.status_code,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bchlin] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.bch_no =  @OLD___bch_no AND 
a.dn_no =  @OLD___dn_no) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsbchlin
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsbchlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsbchlin
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsbchlin
  As SELECT TOP 1000 a.dc_code,a.bch_no,a.dn_no,a.status_code,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bchlin] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsbchlin_clsbchhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbchlin_clsbchhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbchlin_clsbchhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbchlin_clsbchhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20)  )
  As 
SELECT TOP 1000 a.dc_code,a.bch_no,a.dn_no,a.status_code,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bchlin] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.bch_no =  @OLD___bch_no 
GO
--*****************************************************************************
--* 
--* Script Name:  clsdnhdr.SQL 
--*
--* Procedures:   stp_I_clsdnhdr  - Insert
--*               stp_U_clsdnhdr  - Update
--*               stp_D_clsdnhdr  - Delete
--*               stp_S_clsdnhdr  - Select 
--*               stp_SL_clsdnhdr - Select List
--*
--* Description:  Stored procedure script For table clsdnhdr.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsdnhdr
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsdnhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsdnhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsdnhdr(  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20) ,
  @sony_bch_no nvarchar (20) ,
  @doc_type nchar (3) ,
  @imp_dtime datetime ,
  @city_to nvarchar (10) ,
  @deal_to nvarchar (10) ,
  @deal_name nvarchar (50) ,
  @deal_person nvarchar (50) ,
  @deal_tel nvarchar (30) ,
  @unloading_address nvarchar (100) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @remark ntext ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[dnhdr]
(  dc_code ,
  dn_no ,
  sony_bch_no ,
  doc_type ,
  imp_dtime ,
  city_to ,
  deal_to ,
  deal_name ,
  deal_person ,
  deal_tel ,
  unloading_address ,
  status_code ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime ,
  remark  )
VALUES (  @dc_code ,
  @dn_no ,
  @sony_bch_no ,
  @doc_type ,
  @imp_dtime ,
  @city_to ,
  @deal_to ,
  @deal_name ,
  @deal_person ,
  @deal_tel ,
  @unloading_address ,
  @status_code ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime ,
  @remark  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsdnhdr
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsdnhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsdnhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsdnhdr(  @OLD___dc_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20) ,
  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20) ,
  @sony_bch_no nvarchar (20) ,
  @doc_type nchar (3) ,
  @imp_dtime datetime ,
  @city_to nvarchar (10) ,
  @deal_to nvarchar (10) ,
  @deal_name nvarchar (50) ,
  @deal_person nvarchar (50) ,
  @deal_tel nvarchar (30) ,
  @unloading_address nvarchar (100) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @remark ntext ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[dnhdr] 
WHERE dc_code =  @OLD___dc_code AND 
dn_no =  @OLD___dn_no 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[dnhdr] Set 
    dc_code = @dc_code,
    dn_no = @dn_no,
    sony_bch_no = @sony_bch_no,
    doc_type = @doc_type,
    imp_dtime = @imp_dtime,
    city_to = @city_to,
    deal_to = @deal_to,
    deal_name = @deal_name,
    deal_person = @deal_person,
    deal_tel = @deal_tel,
    unloading_address = @unloading_address,
    status_code = @status_code,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime,
    remark = @remark 
WHERE 	( dc_code =  @OLD___dc_code AND 
dn_no =  @OLD___dn_no )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsdnhdr
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsdnhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsdnhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsdnhdr
  (  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20)  )
As DELETE [dbo].[dnhdr] 
WHERE (dc_code =  @dc_code AND 
dn_no =  @dn_no)
GO



--*****************************************************************************
-- Name:        stp_S_clsdnhdr
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsdnhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsdnhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsdnhdr
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20)  )
As SELECT TOP 1000 a.dc_code,a.dn_no,a.sony_bch_no,a.doc_type,a.imp_dtime,a.city_to,a.deal_to,a.deal_name,a.deal_person,a.deal_tel,a.unloading_address,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,a.remark,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[dnhdr] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.dn_no =  @OLD___dn_no) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsdnhdr
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsdnhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsdnhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsdnhdr
  As SELECT TOP 1000 a.dc_code,a.dn_no,a.sony_bch_no,a.doc_type,a.imp_dtime,a.city_to,a.deal_to,a.deal_name,a.deal_person,a.deal_tel,a.unloading_address,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,a.remark,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[dnhdr] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsdnlin.SQL 
--*
--* Procedures:   stp_I_clsdnlin  - Insert
--*               stp_U_clsdnlin  - Update
--*               stp_D_clsdnlin  - Delete
--*               stp_S_clsdnlin  - Select 
--*               stp_S_clsdnlin_clsdnhdrRelated  - Select Related
--*               stp_SL_clsdnlin - Select List
--*
--* Description:  Stored procedure script For table clsdnlin.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsdnlin
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsdnlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsdnlin
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsdnlin(  @row_id nchar (5) ,
  @sku_no nvarchar (20) ,
  @qty numeric (12,3) ,
  @act_qty numeric (12,3) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT,
  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20)  )
As 
	INSERT INTO [dbo].[dnlin]
(  row_id ,
  sku_no ,
  qty ,
  act_qty ,
  status_code ,
  opt_by ,
  opt_dtime ,
  dc_code ,
  dn_no  )
VALUES (  @row_id ,
  @sku_no ,
  @qty ,
  @act_qty ,
  @status_code ,
  @opt_by ,
  @opt_dtime ,
  @dc_code ,
  @dn_no  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsdnlin
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsdnlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsdnlin
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsdnlin(  @OLD___dc_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20) ,
  @OLD___row_id nchar (5) ,
  @row_id nchar (5) ,
  @sku_no nvarchar (20) ,
  @qty numeric (12,3) ,
  @act_qty numeric (12,3) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT ,
  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20)  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[dnlin] 
WHERE dc_code =  @OLD___dc_code AND 
dn_no =  @OLD___dn_no AND 
row_id =  @OLD___row_id 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[dnlin] Set 
    row_id = @row_id,
    sku_no = @sku_no,
    qty = @qty,
    act_qty = @act_qty,
    status_code = @status_code,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    dc_code = @dc_code,
    dn_no = @dn_no 
WHERE 	( dc_code =  @OLD___dc_code AND 
dn_no =  @OLD___dn_no AND 
row_id =  @OLD___row_id )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsdnlin
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsdnlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsdnlin
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsdnlin
  (  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20) ,
  @row_id nchar (5)  )
As DELETE [dbo].[dnlin] 
WHERE (dc_code =  @dc_code AND 
dn_no =  @dn_no AND 
row_id =  @row_id)
GO



--*****************************************************************************
-- Name:        stp_S_clsdnlin
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsdnlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsdnlin
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsdnlin
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20) ,
  @OLD___row_id nchar (5)  )
As SELECT TOP 1000 a.row_id,a.sku_no,a.qty,a.act_qty,a.status_code,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.dc_code,a.dn_no FROM [dbo].[dnlin] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.dn_no =  @OLD___dn_no AND 
a.row_id =  @OLD___row_id) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsdnlin
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsdnlin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsdnlin
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsdnlin
  As SELECT TOP 1000 a.row_id,a.sku_no,a.qty,a.act_qty,a.status_code,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.dc_code,a.dn_no FROM [dbo].[dnlin] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsdnlin_clsdnhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsdnlin_clsdnhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsdnlin_clsdnhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsdnlin_clsdnhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20)  )
  As 
SELECT TOP 1000 a.row_id,a.sku_no,a.qty,a.act_qty,a.status_code,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.dc_code,a.dn_no FROM [dbo].[dnlin] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.dn_no =  @OLD___dn_no 
GO
--*****************************************************************************
--* 
--* Script Name:  clstaskhdr.SQL 
--*
--* Procedures:   stp_I_clstaskhdr  - Insert
--*               stp_U_clstaskhdr  - Update
--*               stp_D_clstaskhdr  - Delete
--*               stp_S_clstaskhdr  - Select 
--*               stp_S_clstaskhdr_clsbchhdrRelated  - Select Related
--*               stp_SL_clstaskhdr - Select List
--*
--* Description:  Stored procedure script For table clstaskhdr.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clstaskhdr
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clstaskhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clstaskhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clstaskhdr(  @dc_code nvarchar (10) ,
  @task_id nvarchar (20) ,
  @bch_no nvarchar (20) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[taskhdr]
(  dc_code ,
  task_id ,
  bch_no ,
  status_code ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime  )
VALUES (  @dc_code ,
  @task_id ,
  @bch_no ,
  @status_code ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clstaskhdr
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clstaskhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clstaskhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clstaskhdr(  @OLD___dc_code nvarchar (10) ,
  @OLD___task_id nvarchar (20) ,
  @dc_code nvarchar (10) ,
  @task_id nvarchar (20) ,
  @bch_no nvarchar (20) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[taskhdr] 
WHERE dc_code =  @OLD___dc_code AND 
task_id =  @OLD___task_id 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[taskhdr] Set 
    dc_code = @dc_code,
    task_id = @task_id,
    bch_no = @bch_no,
    status_code = @status_code,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime 
WHERE 	( dc_code =  @OLD___dc_code AND 
task_id =  @OLD___task_id )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clstaskhdr
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clstaskhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clstaskhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clstaskhdr
  (  @dc_code nvarchar (10) ,
  @task_id nvarchar (20)  )
As DELETE [dbo].[taskhdr] 
WHERE (dc_code =  @dc_code AND 
task_id =  @task_id)
GO



--*****************************************************************************
-- Name:        stp_S_clstaskhdr
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clstaskhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clstaskhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clstaskhdr
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___task_id nvarchar (20)  )
As SELECT TOP 1000 a.dc_code,a.task_id,a.bch_no,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[taskhdr] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.task_id =  @OLD___task_id) 
GO



--*****************************************************************************
-- Name:        stp_SL_clstaskhdr
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clstaskhdr')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clstaskhdr
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clstaskhdr
  As SELECT TOP 1000 a.dc_code,a.task_id,a.bch_no,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[taskhdr] a 
GO

--*****************************************************************************
-- Name:        stp_S_clstaskhdr_clsbchhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clstaskhdr_clsbchhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clstaskhdr_clsbchhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clstaskhdr_clsbchhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20)  )
  As 
SELECT TOP 1000 a.dc_code,a.task_id,a.bch_no,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[taskhdr] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.bch_no =  @OLD___bch_no 
GO
--*****************************************************************************
--* 
--* Script Name:  clstasklin.SQL 
--*
--* Procedures:   stp_I_clstasklin  - Insert
--*               stp_U_clstasklin  - Update
--*               stp_D_clstasklin  - Delete
--*               stp_S_clstasklin  - Select 
--*               stp_S_clstasklin_clstaskhdrRelated  - Select Related
--*               stp_S_clstasklin_clsdnhdrRelated  - Select Related
--*               stp_SL_clstasklin - Select List
--*
--* Description:  Stored procedure script For table clstasklin.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clstasklin
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clstasklin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clstasklin
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clstasklin(  @rowid nvarchar (10) ,
  @dc_code nvarchar (10) ,
  @task_id nvarchar (20) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
@opt_timestamp timestamp OUT,
  @sku_no nvarchar (20) ,
  @sno nvarchar (20) ,
  @qty numeric (12,3)  )
As 
	INSERT INTO [dbo].[tasklin]
(  rowid ,
  dc_code ,
  task_id ,
  bch_no ,
  dn_no ,
  bin_area ,
  bin_code ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime ,
  sku_no ,
  sno ,
  qty  )
VALUES (  @rowid ,
  @dc_code ,
  @task_id ,
  @bch_no ,
  @dn_no ,
  @bin_area ,
  @bin_code ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime ,
  @sku_no ,
  @sno ,
  @qty  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clstasklin
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clstasklin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clstasklin
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clstasklin(  @OLD___rowid nvarchar (10) ,
  @rowid nvarchar (10) ,
  @dc_code nvarchar (10) ,
  @task_id nvarchar (20) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT ,
  @sku_no nvarchar (20) ,
  @sno nvarchar (20) ,
  @qty numeric (12,3)  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[tasklin] 
WHERE rowid =  @OLD___rowid 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[tasklin] Set 
    rowid = @rowid,
    dc_code = @dc_code,
    task_id = @task_id,
    bch_no = @bch_no,
    dn_no = @dn_no,
    bin_area = @bin_area,
    bin_code = @bin_code,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime,
    sku_no = @sku_no,
    sno = @sno,
    qty = @qty 
WHERE 	( rowid =  @OLD___rowid )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clstasklin
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clstasklin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clstasklin
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clstasklin
  (  @rowid nvarchar (10)  )
As DELETE [dbo].[tasklin] 
WHERE (rowid =  @rowid)
GO



--*****************************************************************************
-- Name:        stp_S_clstasklin
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clstasklin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clstasklin
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clstasklin
  (  @OLD___rowid nvarchar (10)  )
As SELECT TOP 1000 a.rowid,a.dc_code,a.task_id,a.bch_no,a.dn_no,a.bin_area,a.bin_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.sku_no,a.sno,a.qty FROM [dbo].[tasklin] a
WHERE (a.rowid =  @OLD___rowid) 
GO



--*****************************************************************************
-- Name:        stp_SL_clstasklin
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clstasklin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clstasklin
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clstasklin
  As SELECT TOP 1000 a.rowid,a.dc_code,a.task_id,a.bch_no,a.dn_no,a.bin_area,a.bin_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.sku_no,a.sno,a.qty FROM [dbo].[tasklin] a 
GO

--*****************************************************************************
-- Name:        stp_S_clstasklin_clstaskhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clstasklin_clstaskhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clstasklin_clstaskhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clstasklin_clstaskhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___task_id nvarchar (20)  )
  As 
SELECT TOP 1000 a.rowid,a.dc_code,a.task_id,a.bch_no,a.dn_no,a.bin_area,a.bin_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.sku_no,a.sno,a.qty FROM [dbo].[tasklin] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.task_id =  @OLD___task_id 
GO

--*****************************************************************************
-- Name:        stp_S_clstasklin_clsdnhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clstasklin_clsdnhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clstasklin_clsdnhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clstasklin_clsdnhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20)  )
  As 
SELECT TOP 1000 a.rowid,a.dc_code,a.task_id,a.bch_no,a.dn_no,a.bin_area,a.bin_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.sku_no,a.sno,a.qty FROM [dbo].[tasklin] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.dn_no =  @OLD___dn_no 
GO
--*****************************************************************************
--* 
--* Script Name:  clstasklist.SQL 
--*
--* Procedures:   stp_I_clstasklist  - Insert
--*               stp_U_clstasklist  - Update
--*               stp_D_clstasklist  - Delete
--*               stp_S_clstasklist  - Select 
--*               stp_S_clstasklist_clstaskhdrRelated  - Select Related
--*               stp_SL_clstasklist - Select List
--*
--* Description:  Stored procedure script For table clstasklist.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clstasklist
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clstasklist')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clstasklist
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clstasklist(  @task_id nvarchar (20) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @assigned_opt nvarchar (20) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
@opt_timestamp timestamp OUT,
  @dc_code nvarchar (10) ,
  @status_code nchar (5)  )
As 
	INSERT INTO [dbo].[tasklist]
(  task_id ,
  bch_no ,
  dn_no ,
  assigned_opt ,
  bin_area ,
  bin_code ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime ,
  dc_code ,
  status_code  )
VALUES (  @task_id ,
  @bch_no ,
  @dn_no ,
  @assigned_opt ,
  @bin_area ,
  @bin_code ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime ,
  @dc_code ,
  @status_code  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clstasklist
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clstasklist')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clstasklist
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clstasklist(  @OLD___dc_code nvarchar (10) ,
  @OLD___task_id nvarchar (20) ,
  @OLD___bch_no nvarchar (20) ,
  @OLD___dn_no nvarchar (20) ,
  @OLD___assigned_opt nvarchar (20) ,
  @task_id nvarchar (20) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @assigned_opt nvarchar (20) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT ,
  @dc_code nvarchar (10) ,
  @status_code nchar (5)  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[tasklist] 
WHERE dc_code =  @OLD___dc_code AND 
task_id =  @OLD___task_id AND 
bch_no =  @OLD___bch_no AND 
dn_no =  @OLD___dn_no AND 
assigned_opt =  @OLD___assigned_opt 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[tasklist] Set 
    task_id = @task_id,
    bch_no = @bch_no,
    dn_no = @dn_no,
    assigned_opt = @assigned_opt,
    bin_area = @bin_area,
    bin_code = @bin_code,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime,
    dc_code = @dc_code,
    status_code = @status_code 
WHERE 	( dc_code =  @OLD___dc_code AND 
task_id =  @OLD___task_id AND 
bch_no =  @OLD___bch_no AND 
dn_no =  @OLD___dn_no AND 
assigned_opt =  @OLD___assigned_opt )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clstasklist
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clstasklist')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clstasklist
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clstasklist
  (  @dc_code nvarchar (10) ,
  @task_id nvarchar (20) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @assigned_opt nvarchar (20)  )
As DELETE [dbo].[tasklist] 
WHERE (dc_code =  @dc_code AND 
task_id =  @task_id AND 
bch_no =  @bch_no AND 
dn_no =  @dn_no AND 
assigned_opt =  @assigned_opt)
GO



--*****************************************************************************
-- Name:        stp_S_clstasklist
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clstasklist')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clstasklist
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clstasklist
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___task_id nvarchar (20) ,
  @OLD___bch_no nvarchar (20) ,
  @OLD___dn_no nvarchar (20) ,
  @OLD___assigned_opt nvarchar (20)  )
As SELECT TOP 1000 a.task_id,a.bch_no,a.dn_no,a.assigned_opt,a.bin_area,a.bin_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.dc_code,a.status_code FROM [dbo].[tasklist] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.task_id =  @OLD___task_id AND 
a.bch_no =  @OLD___bch_no AND 
a.dn_no =  @OLD___dn_no AND 
a.assigned_opt =  @OLD___assigned_opt) 
GO



--*****************************************************************************
-- Name:        stp_SL_clstasklist
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clstasklist')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clstasklist
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clstasklist
  As SELECT TOP 1000 a.task_id,a.bch_no,a.dn_no,a.assigned_opt,a.bin_area,a.bin_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.dc_code,a.status_code FROM [dbo].[tasklist] a 
GO

--*****************************************************************************
-- Name:        stp_S_clstasklist_clstaskhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clstasklist_clstaskhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clstasklist_clstaskhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clstasklist_clstaskhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___task_id nvarchar (20)  )
  As 
SELECT TOP 1000 a.task_id,a.bch_no,a.dn_no,a.assigned_opt,a.bin_area,a.bin_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.dc_code,a.status_code FROM [dbo].[tasklist] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.task_id =  @OLD___task_id 
GO
--*****************************************************************************
--* 
--* Script Name:  clsbinarea.SQL 
--*
--* Procedures:   stp_I_clsbinarea  - Insert
--*               stp_U_clsbinarea  - Update
--*               stp_D_clsbinarea  - Delete
--*               stp_S_clsbinarea  - Select 
--*               stp_SL_clsbinarea - Select List
--*
--* Description:  Stored procedure script For table clsbinarea.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsbinarea
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsbinarea')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsbinarea
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsbinarea(  @dc_code nvarchar (10) ,
  @bin_area nvarchar (10) ,
  @description nvarchar (50) ,
  @opt_by nvarchar (50) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[binarea]
(  dc_code ,
  bin_area ,
  description ,
  opt_by ,
  opt_dtime  )
VALUES (  @dc_code ,
  @bin_area ,
  @description ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsbinarea
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsbinarea')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsbinarea
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsbinarea(  @OLD___dc_code nvarchar (10) ,
  @OLD___bin_area nvarchar (10) ,
  @dc_code nvarchar (10) ,
  @bin_area nvarchar (10) ,
  @description nvarchar (50) ,
  @opt_by nvarchar (50) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[binarea] 
WHERE dc_code =  @OLD___dc_code AND 
bin_area =  @OLD___bin_area 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[binarea] Set 
    dc_code = @dc_code,
    bin_area = @bin_area,
    description = @description,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( dc_code =  @OLD___dc_code AND 
bin_area =  @OLD___bin_area )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsbinarea
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsbinarea')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsbinarea
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsbinarea
  (  @dc_code nvarchar (10) ,
  @bin_area nvarchar (10)  )
As DELETE [dbo].[binarea] 
WHERE (dc_code =  @dc_code AND 
bin_area =  @bin_area)
GO



--*****************************************************************************
-- Name:        stp_S_clsbinarea
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbinarea')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbinarea
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbinarea
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___bin_area nvarchar (10)  )
As SELECT TOP 1000 a.dc_code,a.bin_area,a.description,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[binarea] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.bin_area =  @OLD___bin_area) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsbinarea
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsbinarea')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsbinarea
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsbinarea
  As SELECT TOP 1000 a.dc_code,a.bin_area,a.description,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[binarea] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsbin.SQL 
--*
--* Procedures:   stp_I_clsbin  - Insert
--*               stp_U_clsbin  - Update
--*               stp_D_clsbin  - Delete
--*               stp_S_clsbin  - Select 
--*               stp_S_clsbin_clsbinareaRelated  - Select Related
--*               stp_SL_clsbin - Select List
--*
--* Description:  Stored procedure script For table clsbin.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsbin
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsbin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsbin
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsbin(  @dc_code nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @description nvarchar (50) ,
  @bin_area nvarchar (10) ,
  @length numeric (12,3) ,
  @width_ numeric (12,3) ,
  @weight numeric (12,3) ,
  @volume numeric (20,9) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[bin]
(  dc_code ,
  bin_code ,
  description ,
  bin_area ,
  length ,
  width ,
  weight ,
  volume ,
  opt_by ,
  opt_dtime  )
VALUES (  @dc_code ,
  @bin_code ,
  @description ,
  @bin_area ,
  @length ,
  @width_ ,
  @weight ,
  @volume ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsbin
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsbin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsbin
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsbin(  @OLD___dc_code nvarchar (10) ,
  @OLD___bin_code nvarchar (10) ,
  @dc_code nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @description nvarchar (50) ,
  @bin_area nvarchar (10) ,
  @length numeric (12,3) ,
  @width_ numeric (12,3) ,
  @weight numeric (12,3) ,
  @volume numeric (20,9) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[bin] 
WHERE dc_code =  @OLD___dc_code AND 
bin_code =  @OLD___bin_code 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[bin] Set 
    dc_code = @dc_code,
    bin_code = @bin_code,
    description = @description,
    bin_area = @bin_area,
    length = @length,
    width = @width_,
    weight = @weight,
    volume = @volume,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( dc_code =  @OLD___dc_code AND 
bin_code =  @OLD___bin_code )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsbin
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsbin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsbin
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsbin
  (  @dc_code nvarchar (10) ,
  @bin_code nvarchar (10)  )
As DELETE [dbo].[bin] 
WHERE (dc_code =  @dc_code AND 
bin_code =  @bin_code)
GO



--*****************************************************************************
-- Name:        stp_S_clsbin
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbin
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbin
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___bin_code nvarchar (10)  )
As SELECT TOP 1000 a.dc_code,a.bin_code,a.description,a.bin_area,a.length,a.width,a.weight,a.volume,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bin] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.bin_code =  @OLD___bin_code) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsbin
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsbin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsbin
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsbin
  As SELECT TOP 1000 a.dc_code,a.bin_code,a.description,a.bin_area,a.length,a.width,a.weight,a.volume,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bin] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsbin_clsbinareaRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbin_clsbinareaRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbin_clsbinareaRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbin_clsbinareaRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___bin_area nvarchar (10)  )
  As 
SELECT TOP 1000 a.dc_code,a.bin_code,a.description,a.bin_area,a.length,a.width,a.weight,a.volume,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[bin] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.bin_area =  @OLD___bin_area 
GO
--*****************************************************************************
--* 
--* Script Name:  clsbinStatus.SQL 
--*
--* Procedures:   stp_I_clsbinStatus  - Insert
--*               stp_U_clsbinStatus  - Update
--*               stp_D_clsbinStatus  - Delete
--*               stp_S_clsbinStatus  - Select 
--*               stp_S_clsbinStatus_clsbinareaRelated  - Select Related
--*               stp_SL_clsbinStatus - Select List
--*
--* Description:  Stored procedure script For table clsbinStatus.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsbinStatus
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsbinStatus')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsbinStatus
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsbinStatus(  @dc_code nvarchar (10) ,
@id int OUT,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @dn_no nvarchar (20) ,
  @type_ nchar (3) ,
  @status_code nchar (5) ,
  @close_auto bit ,
  @print_by nvarchar (20) ,
  @print_counter int ,
  @print_dtime datetime ,
  @locked int ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[binStatus]
(  dc_code ,
  bin_area ,
  bin_code ,
  dn_no ,
  type ,
  status_code ,
  close_auto ,
  print_by ,
  print_counter ,
  print_dtime ,
  locked ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime  )
VALUES (  @dc_code ,
  @bin_area ,
  @bin_code ,
  @dn_no ,
  @type_ ,
  @status_code ,
  @close_auto ,
  @print_by ,
  @print_counter ,
  @print_dtime ,
  @locked ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @id = @@IDENTITY
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsbinStatus
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsbinStatus')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsbinStatus
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsbinStatus(  @OLD___dc_code nvarchar (10) ,
  @OLD___id int ,
  @OLD___bin_area nvarchar (10) ,
  @OLD___bin_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20) ,
  @dc_code nvarchar (10) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @dn_no nvarchar (20) ,
  @type_ nchar (3) ,
  @status_code nchar (5) ,
  @close_auto bit ,
  @print_by nvarchar (20) ,
  @print_counter int ,
  @print_dtime datetime ,
  @locked int ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[binStatus] 
WHERE dc_code =  @OLD___dc_code AND 
id =  @OLD___id AND 
bin_area =  @OLD___bin_area AND 
bin_code =  @OLD___bin_code AND 
dn_no =  @OLD___dn_no 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[binStatus] Set 
    dc_code = @dc_code,
    bin_area = @bin_area,
    bin_code = @bin_code,
    dn_no = @dn_no,
    type = @type_,
    status_code = @status_code,
    close_auto = @close_auto,
    print_by = @print_by,
    print_counter = @print_counter,
    print_dtime = @print_dtime,
    locked = @locked,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime 
WHERE 	( dc_code =  @OLD___dc_code AND 
id =  @OLD___id AND 
bin_area =  @OLD___bin_area AND 
bin_code =  @OLD___bin_code AND 
dn_no =  @OLD___dn_no )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsbinStatus
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsbinStatus')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsbinStatus
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsbinStatus
  (  @dc_code nvarchar (10) ,
  @id int ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @dn_no nvarchar (20)  )
As DELETE [dbo].[binStatus] 
WHERE (dc_code =  @dc_code AND 
id =  @id AND 
bin_area =  @bin_area AND 
bin_code =  @bin_code AND 
dn_no =  @dn_no)
GO



--*****************************************************************************
-- Name:        stp_S_clsbinStatus
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbinStatus')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbinStatus
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbinStatus
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___id int ,
  @OLD___bin_area nvarchar (10) ,
  @OLD___bin_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20)  )
As SELECT TOP 1000 a.dc_code,a.id,a.bin_area,a.bin_code,a.dn_no,a.type,a.status_code,a.close_auto,a.print_by,a.print_counter,a.print_dtime,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[binStatus] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.id =  @OLD___id AND 
a.bin_area =  @OLD___bin_area AND 
a.bin_code =  @OLD___bin_code AND 
a.dn_no =  @OLD___dn_no) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsbinStatus
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsbinStatus')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsbinStatus
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsbinStatus
  As SELECT TOP 1000 a.dc_code,a.id,a.bin_area,a.bin_code,a.dn_no,a.type,a.status_code,a.close_auto,a.print_by,a.print_counter,a.print_dtime,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[binStatus] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsbinStatus_clsbinareaRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbinStatus_clsbinareaRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbinStatus_clsbinareaRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbinStatus_clsbinareaRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___bin_area nvarchar (10)  )
  As 
SELECT TOP 1000 a.dc_code,a.id,a.bin_area,a.bin_code,a.dn_no,a.type,a.status_code,a.close_auto,a.print_by,a.print_counter,a.print_dtime,a.locked,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[binStatus] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.bin_area =  @OLD___bin_area 
GO
--*****************************************************************************
--* 
--* Script Name:  clsDnBin.SQL 
--*
--* Procedures:   stp_I_clsDnBin  - Insert
--*               stp_U_clsDnBin  - Update
--*               stp_D_clsDnBin  - Delete
--*               stp_S_clsDnBin  - Select 
--*               stp_S_clsDnBin_clsbchhdrRelated  - Select Related
--*               stp_S_clsDnBin_clsdnhdrRelated  - Select Related
--*               stp_SL_clsDnBin - Select List
--*
--* Description:  Stored procedure script For table clsDnBin.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsDnBin
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsDnBin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsDnBin
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsDnBin(  @rowid nvarchar (10) ,
  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
@opt_timestamp timestamp OUT,
  @bch_no nvarchar (20)  )
As 
	INSERT INTO [dbo].[DnBin]
(  rowid ,
  dc_code ,
  dn_no ,
  bin_area ,
  bin_code ,
  status_code ,
  opt_by ,
  opt_dtime ,
  start_dtime ,
  end_dtime ,
  bch_no  )
VALUES (  @rowid ,
  @dc_code ,
  @dn_no ,
  @bin_area ,
  @bin_code ,
  @status_code ,
  @opt_by ,
  @opt_dtime ,
  @start_dtime ,
  @end_dtime ,
  @bch_no  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsDnBin
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsDnBin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsDnBin
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsDnBin(  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20) ,
  @OLD___dn_no nvarchar (20) ,
  @OLD___bin_area nvarchar (10) ,
  @OLD___bin_code nvarchar (10) ,
  @rowid nvarchar (10) ,
  @dc_code nvarchar (10) ,
  @dn_no nvarchar (20) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10) ,
  @status_code nchar (5) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @start_dtime datetime ,
  @end_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT ,
  @bch_no nvarchar (20)  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[DnBin] 
WHERE dc_code =  @OLD___dc_code AND 
bch_no =  @OLD___bch_no AND 
dn_no =  @OLD___dn_no AND 
bin_area =  @OLD___bin_area AND 
bin_code =  @OLD___bin_code 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[DnBin] Set 
    rowid = @rowid,
    dc_code = @dc_code,
    dn_no = @dn_no,
    bin_area = @bin_area,
    bin_code = @bin_code,
    status_code = @status_code,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime,
    start_dtime = @start_dtime,
    end_dtime = @end_dtime,
    bch_no = @bch_no 
WHERE 	( dc_code =  @OLD___dc_code AND 
bch_no =  @OLD___bch_no AND 
dn_no =  @OLD___dn_no AND 
bin_area =  @OLD___bin_area AND 
bin_code =  @OLD___bin_code )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsDnBin
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsDnBin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsDnBin
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsDnBin
  (  @dc_code nvarchar (10) ,
  @bch_no nvarchar (20) ,
  @dn_no nvarchar (20) ,
  @bin_area nvarchar (10) ,
  @bin_code nvarchar (10)  )
As DELETE [dbo].[DnBin] 
WHERE (dc_code =  @dc_code AND 
bch_no =  @bch_no AND 
dn_no =  @dn_no AND 
bin_area =  @bin_area AND 
bin_code =  @bin_code)
GO



--*****************************************************************************
-- Name:        stp_S_clsDnBin
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsDnBin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsDnBin
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsDnBin
  (  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20) ,
  @OLD___dn_no nvarchar (20) ,
  @OLD___bin_area nvarchar (10) ,
  @OLD___bin_code nvarchar (10)  )
As SELECT TOP 1000 a.rowid,a.dc_code,a.dn_no,a.bin_area,a.bin_code,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.bch_no FROM [dbo].[DnBin] a
WHERE (a.dc_code =  @OLD___dc_code AND 
a.bch_no =  @OLD___bch_no AND 
a.dn_no =  @OLD___dn_no AND 
a.bin_area =  @OLD___bin_area AND 
a.bin_code =  @OLD___bin_code) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsDnBin
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsDnBin')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsDnBin
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsDnBin
  As SELECT TOP 1000 a.rowid,a.dc_code,a.dn_no,a.bin_area,a.bin_code,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.bch_no FROM [dbo].[DnBin] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsDnBin_clsbchhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsDnBin_clsbchhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsDnBin_clsbchhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsDnBin_clsbchhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___bch_no nvarchar (20)  )
  As 
SELECT TOP 1000 a.rowid,a.dc_code,a.dn_no,a.bin_area,a.bin_code,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.bch_no FROM [dbo].[DnBin] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.bch_no =  @OLD___bch_no 
GO

--*****************************************************************************
-- Name:        stp_S_clsDnBin_clsdnhdrRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsDnBin_clsdnhdrRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsDnBin_clsdnhdrRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsDnBin_clsdnhdrRelated
(  @OLD___dc_code nvarchar (10) ,
  @OLD___dn_no nvarchar (20)  )
  As 
SELECT TOP 1000 a.rowid,a.dc_code,a.dn_no,a.bin_area,a.bin_code,a.status_code,a.opt_by,a.opt_dtime,a.start_dtime,a.end_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp ,a.bch_no FROM [dbo].[DnBin] a
WHERE 
a.dc_code =  @OLD___dc_code AND 
a.dn_no =  @OLD___dn_no 
GO
--*****************************************************************************
--* 
--* Script Name:  clsskuinfo.SQL 
--*
--* Procedures:   stp_I_clsskuinfo  - Insert
--*               stp_U_clsskuinfo  - Update
--*               stp_D_clsskuinfo  - Delete
--*               stp_S_clsskuinfo  - Select 
--*               stp_SL_clsskuinfo - Select List
--*
--* Description:  Stored procedure script For table clsskuinfo.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsskuinfo
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsskuinfo')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsskuinfo
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsskuinfo(  @sku_no nvarchar (20) ,
  @sku_wms nvarchar (20) ,
  @sku_desc nvarchar (50) ,
  @sku_desc_eng nvarchar (50) ,
  @model_no nvarchar (50) ,
  @volume numeric (20,9) ,
  @length numeric (12,3) ,
  @width_ numeric (12,3) ,
  @height numeric (12,3) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[skuinfo]
(  sku_no ,
  sku_wms ,
  sku_desc ,
  sku_desc_eng ,
  model_no ,
  volume ,
  length ,
  width ,
  height ,
  opt_by ,
  opt_dtime  )
VALUES (  @sku_no ,
  @sku_wms ,
  @sku_desc ,
  @sku_desc_eng ,
  @model_no ,
  @volume ,
  @length ,
  @width_ ,
  @height ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsskuinfo
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsskuinfo')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsskuinfo
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsskuinfo(  @OLD___sku_no nvarchar (20) ,
  @OLD___sku_wms nvarchar (20) ,
  @sku_no nvarchar (20) ,
  @sku_wms nvarchar (20) ,
  @sku_desc nvarchar (50) ,
  @sku_desc_eng nvarchar (50) ,
  @model_no nvarchar (50) ,
  @volume numeric (20,9) ,
  @length numeric (12,3) ,
  @width_ numeric (12,3) ,
  @height numeric (12,3) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[skuinfo] 
WHERE sku_no =  @OLD___sku_no AND 
sku_wms =  @OLD___sku_wms 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[skuinfo] Set 
    sku_no = @sku_no,
    sku_wms = @sku_wms,
    sku_desc = @sku_desc,
    sku_desc_eng = @sku_desc_eng,
    model_no = @model_no,
    volume = @volume,
    length = @length,
    width = @width_,
    height = @height,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( sku_no =  @OLD___sku_no AND 
sku_wms =  @OLD___sku_wms )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsskuinfo
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsskuinfo')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsskuinfo
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsskuinfo
  (  @sku_no nvarchar (20) ,
  @sku_wms nvarchar (20)  )
As DELETE [dbo].[skuinfo] 
WHERE (sku_no =  @sku_no AND 
sku_wms =  @sku_wms)
GO



--*****************************************************************************
-- Name:        stp_S_clsskuinfo
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsskuinfo')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsskuinfo
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsskuinfo
  (  @OLD___sku_no nvarchar (20) ,
  @OLD___sku_wms nvarchar (20)  )
As SELECT TOP 1000 a.sku_no,a.sku_wms,a.sku_desc,a.sku_desc_eng,a.model_no,a.volume,a.length,a.width,a.height,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[skuinfo] a
WHERE (a.sku_no =  @OLD___sku_no AND 
a.sku_wms =  @OLD___sku_wms) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsskuinfo
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsskuinfo')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsskuinfo
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsskuinfo
  As SELECT TOP 1000 a.sku_no,a.sku_wms,a.sku_desc,a.sku_desc_eng,a.model_no,a.volume,a.length,a.width,a.height,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[skuinfo] a 
GO
--*****************************************************************************
--* 
--* Script Name:  clsbarcode.SQL 
--*
--* Procedures:   stp_I_clsbarcode  - Insert
--*               stp_U_clsbarcode  - Update
--*               stp_D_clsbarcode  - Delete
--*               stp_S_clsbarcode  - Select 
--*               stp_S_clsbarcode_clsskuinfoRelated  - Select Related
--*               stp_SL_clsbarcode - Select List
--*
--* Description:  Stored procedure script For table clsbarcode.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clsbarcode
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clsbarcode')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clsbarcode
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clsbarcode(  @sku_no nvarchar (20) ,
  @barcode nvarchar (30) ,
  @bar_type nchar (3) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[barcode]
(  sku_no ,
  barcode ,
  bar_type ,
  opt_by ,
  opt_dtime  )
VALUES (  @sku_no ,
  @barcode ,
  @bar_type ,
  @opt_by ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clsbarcode
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clsbarcode')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clsbarcode
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clsbarcode(  @OLD___sku_no nvarchar (20) ,
  @OLD___barcode nvarchar (30) ,
  @sku_no nvarchar (20) ,
  @barcode nvarchar (30) ,
  @bar_type nchar (3) ,
  @opt_by nvarchar (20) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[barcode] 
WHERE sku_no =  @OLD___sku_no AND 
barcode =  @OLD___barcode 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[barcode] Set 
    sku_no = @sku_no,
    barcode = @barcode,
    bar_type = @bar_type,
    opt_by = @opt_by,
    opt_dtime = @opt_dtime 
WHERE 	( sku_no =  @OLD___sku_no AND 
barcode =  @OLD___barcode )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clsbarcode
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clsbarcode')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clsbarcode
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clsbarcode
  (  @sku_no nvarchar (20) ,
  @barcode nvarchar (30)  )
As DELETE [dbo].[barcode] 
WHERE (sku_no =  @sku_no AND 
barcode =  @barcode)
GO



--*****************************************************************************
-- Name:        stp_S_clsbarcode
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbarcode')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbarcode
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbarcode
  (  @OLD___sku_no nvarchar (20) ,
  @OLD___barcode nvarchar (30)  )
As SELECT TOP 1000 a.sku_no,a.barcode,a.bar_type,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[barcode] a
WHERE (a.sku_no =  @OLD___sku_no AND 
a.barcode =  @OLD___barcode) 
GO



--*****************************************************************************
-- Name:        stp_SL_clsbarcode
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clsbarcode')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clsbarcode
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clsbarcode
  As SELECT TOP 1000 a.sku_no,a.barcode,a.bar_type,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[barcode] a 
GO

--*****************************************************************************
-- Name:        stp_S_clsbarcode_clsskuinfoRelated
-- 
-- Purpose:     Select related records from the table - no where clause
--
-- Description: Returns a recordset To calling program. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clsbarcode_clsskuinfoRelated')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clsbarcode_clsskuinfoRelated
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clsbarcode_clsskuinfoRelated
(  @OLD___sku_no nvarchar (20)  )
  As 
SELECT TOP 1000 a.sku_no,a.barcode,a.bar_type,a.opt_by,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[barcode] a
WHERE 
a.sku_no =  @OLD___sku_no 
GO
--*****************************************************************************
--* 
--* Script Name:  clscityairport.SQL 
--*
--* Procedures:   stp_I_clscityairport  - Insert
--*               stp_U_clscityairport  - Update
--*               stp_D_clscityairport  - Delete
--*               stp_S_clscityairport  - Select 
--*               stp_SL_clscityairport - Select List
--*
--* Description:  Stored procedure script For table clscityairport.
--*****************************************************************************


-- ****************************************************************************
-- Name:        stp_I_clscityairport
-- 
-- Purpose:     Insert a New record into table.     
-- ****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_I_clscityairport')
              AND (Type = 'P')))
  DROP PROCEDURE stp_I_clscityairport
GO

-- Procedure definition
CREATE PROCEDURE stp_I_clscityairport(  @destination nvarchar (10) ,
  @province nvarchar (10) ,
  @transit nvarchar (10) ,
  @type_ nvarchar (10) ,
  @opt_dtime datetime ,
@opt_timestamp timestamp OUT )
As 
	INSERT INTO [dbo].[cityairport]
(  destination ,
  province ,
  transit ,
  type ,
  opt_dtime  )
VALUES (  @destination ,
  @province ,
  @transit ,
  @type_ ,
  @opt_dtime  )
-- Auto Identifer table - Return the id, guid, or computed value of the record created
  Select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
GO


--*****************************************************************************
-- Name:        stp_U_clscityairport
-- 
-- Purpose:     Update record identified by key
--
-- Notes:       Store procedure requires that all table fields be passed In.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_U_clscityairport')
              AND (Type = 'P')))
  DROP PROCEDURE stp_U_clscityairport
GO

-- Procedure definition
CREATE PROCEDURE stp_U_clscityairport(  @OLD___destination nvarchar (10) ,
  @OLD___type_ nvarchar (10) ,
  @destination nvarchar (10) ,
  @province nvarchar (10) ,
  @transit nvarchar (10) ,
  @type_ nvarchar (10) ,
  @opt_dtime datetime ,
  @opt_timestamp TIMESTAMP OUT  )
As 
Declare @NewStamp bigint
Select @NewStamp=CONVERT(bigint, opt_timestamp) from [dbo].[cityairport] 
WHERE destination =  @OLD___destination AND 
type =  @OLD___type_ 
If @NewStamp != CONVERT(bigint, @opt_timestamp)
  Begin
    RAISERROR(51000, 16, 1)
    ROLLBACK TRANSACTION
  End
Else
UPDATE [dbo].[cityairport] Set 
    destination = @destination,
    province = @province,
    transit = @transit,
    type = @type_,
    opt_dtime = @opt_dtime 
WHERE 	( destination =  @OLD___destination AND 
type =  @OLD___type_ )
  Select @opt_timestamp=CONVERT(TIMESTAMP, @@DBTS)	
GO

--*****************************************************************************
-- Name:    stp_D_clscityairport
--
-- Purpose: Delete record identified by key
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_D_clscityairport')
              AND (Type = 'P')))
  DROP PROCEDURE stp_D_clscityairport
GO

-- Procedure definition
CREATE PROCEDURE stp_D_clscityairport
  (  @destination nvarchar (10) ,
  @type_ nvarchar (10)  )
As DELETE [dbo].[cityairport] 
WHERE (destination =  @destination AND 
type =  @type_)
GO



--*****************************************************************************
-- Name:        stp_S_clscityairport
-- 
-- Purpose:     Select record identified by key
--
-- Description: Returns a recordset To calling program. The recordset should
--              contain only one record. 
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_S_clscityairport')
              AND (Type = 'P')))
  DROP PROCEDURE stp_S_clscityairport
GO

-- Procedure definition
CREATE PROCEDURE stp_S_clscityairport
  (  @OLD___destination nvarchar (10) ,
  @OLD___type_ nvarchar (10)  )
As SELECT TOP 1000 a.destination,a.province,a.transit,a.type,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[cityairport] a
WHERE (a.destination =  @OLD___destination AND 
a.type =  @OLD___type_) 
GO



--*****************************************************************************
-- Name:        stp_SL_clscityairport
-- 
-- Purpose:     Select all the records from the table - no where clause
--
-- Description: Returns a recordset To calling program. The recordset will
--              contain all the records from the table.
--*****************************************************************************

-- Drop before creating
If (EXISTS (Select *
            FROM dbo.sysobjects
            WHERE (name = 'stp_SL_clscityairport')
              AND (Type = 'P')))
  DROP PROCEDURE stp_SL_clscityairport
GO

-- Procedure definition
CREATE PROCEDURE stp_SL_clscityairport
  As SELECT TOP 1000 a.destination,a.province,a.transit,a.type,a.opt_dtime,CONVERT(varchar(30), CONVERT(INT, a.opt_timestamp),13) opt_timestamp  FROM [dbo].[cityairport] a 
GO
