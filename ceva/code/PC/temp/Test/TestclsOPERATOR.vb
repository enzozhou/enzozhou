Option Explicit On 
Option Strict On
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports NUnit.Framework
Imports COMExpress.BusinessObject.Filters
Imports YT.BusinessObject


'******************************************************************************
'*
'* Name:        clsOPERATORTest
'*
'* Description: NUnit tests for clsOPERATOR
'*
'******************************************************************************

<TestFixture()> Public Class clsOPERATORTest

    '// Business Objects we are testing
    Dim clsOPERATORCollection As clsOPERATORs

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsOPERATOR
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsOPERATOR

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsOPERATOR.NewclsOPERATOR 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsOPERATOR.NewclsOPERATOR
        'NewObject.user_name= ?
        'NewObject.password_= ?
        'NewObject.STCD= ?
        'NewObject.allowlogin= ?
        'NewObject.isadmin= ?
        'NewObject.title= ?
        'NewObject.tel= ?
        'NewObject.fax= ?
        'NewObject.mobile= ?
        'NewObject.email= ?
        'NewObject.create_date= ?
        'NewObject.update_date= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsOPERATOR)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsOPERATOR)

    End Sub
    
    Private FindRecordCount As integer = 0
    Private Function FindFilters() As CXFilters
    	Dim fs As New CXFilters
    	'TODO: add your testing filters here
    	Return fs
    End Function

#End Region
#End Region


#Region "Business Object Validation Tests"

    <Test()> Public Sub TestCollectionCountAfterLoad()
        clsOPERATORCollection = clsOPERATORs.Fetch(New CXFilters(), 0)
        
        If clsOPERATORCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsOPERATORCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsOPERATORCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsOPERATORCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsOPERATORCollection = clsOPERATORs.Fetch(FindFilters, 0)
        
        If clsOPERATORCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsOPERATORCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsOPERATORCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsOPERATORCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsOPERATOR = clsOPERATOR.Fetch(ExistingObject.user_code, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.user_code, ExistingObject.user_code, "user_code should be [" & ExistingObject.user_code.ToString() & "] after object is loaded from database. user_code is " & o.user_code.ToString())
	        Assert.AreEqual(o.user_name, ExistingObject.user_name, "user_name should be [" & ExistingObject.user_name.ToString() & "] after object is loaded from database. user_name is " & o.user_name.ToString())
	        Assert.AreEqual(o.password_, ExistingObject.password_, "password_ should be [" & ExistingObject.password_.ToString() & "] after object is loaded from database. password_ is " & o.password_.ToString())
	        Assert.AreEqual(o.STCD, ExistingObject.STCD, "STCD should be [" & ExistingObject.STCD.ToString() & "] after object is loaded from database. STCD is " & o.STCD.ToString())
	        Assert.AreEqual(o.allowlogin, ExistingObject.allowlogin, "allowlogin should be [" & ExistingObject.allowlogin.ToString() & "] after object is loaded from database. allowlogin is " & o.allowlogin.ToString())
	        Assert.AreEqual(o.isadmin, ExistingObject.isadmin, "isadmin should be [" & ExistingObject.isadmin.ToString() & "] after object is loaded from database. isadmin is " & o.isadmin.ToString())
	        Assert.AreEqual(o.title, ExistingObject.title, "title should be [" & ExistingObject.title.ToString() & "] after object is loaded from database. title is " & o.title.ToString())
	        Assert.AreEqual(o.tel, ExistingObject.tel, "tel should be [" & ExistingObject.tel.ToString() & "] after object is loaded from database. tel is " & o.tel.ToString())
	        Assert.AreEqual(o.fax, ExistingObject.fax, "fax should be [" & ExistingObject.fax.ToString() & "] after object is loaded from database. fax is " & o.fax.ToString())
	        Assert.AreEqual(o.mobile, ExistingObject.mobile, "mobile should be [" & ExistingObject.mobile.ToString() & "] after object is loaded from database. mobile is " & o.mobile.ToString())
	        Assert.AreEqual(o.email, ExistingObject.email, "email should be [" & ExistingObject.email.ToString() & "] after object is loaded from database. email is " & o.email.ToString())
	        Assert.AreEqual(o.create_date, ExistingObject.create_date, "create_date should be [" & ExistingObject.create_date.ToString() & "] after object is loaded from database. create_date is " & o.create_date.ToString())
	        Assert.AreEqual(o.update_date, ExistingObject.update_date, "update_date should be [" & ExistingObject.update_date.ToString() & "] after object is loaded from database. update_date is " & o.update_date.ToString())
	        Assert.AreEqual(o.opt_by, ExistingObject.opt_by, "opt_by should be [" & ExistingObject.opt_by.ToString() & "] after object is loaded from database. opt_by is " & o.opt_by.ToString())
	        Assert.AreEqual(o.opt_dtime, ExistingObject.opt_dtime, "opt_dtime should be [" & ExistingObject.opt_dtime.ToString() & "] after object is loaded from database. opt_dtime is " & o.opt_dtime.ToString())
	        Assert.AreEqual(o.opt_timestamp, ExistingObject.opt_timestamp, "opt_timestamp should be [" & ExistingObject.opt_timestamp.ToString() & "] after object is loaded from database. opt_timestamp is " & o.opt_timestamp.ToString())
        Else
            Assert.Fail("no existing object")			
		End If
    End Sub

#End Region


#Region "Test Standard Methods"

    <Test()> Public Sub TestClone()
        Dim o As clsOPERATOR = CType(ExistingObject.Clone(), clsOPERATOR)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.user_code, o.user_code, "Cloned object user_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.user_name, o.user_name, "Cloned object user_name should be equal To existing object.")
        Assert.AreEqual(ExistingObject.password_, o.password_, "Cloned object password_ should be equal To existing object.")
        Assert.AreEqual(ExistingObject.STCD, o.STCD, "Cloned object STCD should be equal To existing object.")
        Assert.AreEqual(ExistingObject.allowlogin, o.allowlogin, "Cloned object allowlogin should be equal To existing object.")
        Assert.AreEqual(ExistingObject.isadmin, o.isadmin, "Cloned object isadmin should be equal To existing object.")
        Assert.AreEqual(ExistingObject.title, o.title, "Cloned object title should be equal To existing object.")
        Assert.AreEqual(ExistingObject.tel, o.tel, "Cloned object tel should be equal To existing object.")
        Assert.AreEqual(ExistingObject.fax, o.fax, "Cloned object fax should be equal To existing object.")
        Assert.AreEqual(ExistingObject.mobile, o.mobile, "Cloned object mobile should be equal To existing object.")
        Assert.AreEqual(ExistingObject.email, o.email, "Cloned object email should be equal To existing object.")
        Assert.AreEqual(ExistingObject.create_date, o.create_date, "Cloned object create_date should be equal To existing object.")
        Assert.AreEqual(ExistingObject.update_date, o.update_date, "Cloned object update_date should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")

		o = CType(NewObject.Clone(), clsOPERATOR)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.user_code, NewObject.user_code, "Cloned object user_code should be equal To existing object..")
        Assert.AreEqual(o.user_name, NewObject.user_name, "Cloned object user_name should be equal To existing object..")
        Assert.AreEqual(o.password_, NewObject.password_, "Cloned object password_ should be equal To existing object..")
        Assert.AreEqual(o.STCD, NewObject.STCD, "Cloned object STCD should be equal To existing object..")
        Assert.AreEqual(o.allowlogin, NewObject.allowlogin, "Cloned object allowlogin should be equal To existing object..")
        Assert.AreEqual(o.isadmin, NewObject.isadmin, "Cloned object isadmin should be equal To existing object..")
        Assert.AreEqual(o.title, NewObject.title, "Cloned object title should be equal To existing object..")
        Assert.AreEqual(o.tel, NewObject.tel, "Cloned object tel should be equal To existing object..")
        Assert.AreEqual(o.fax, NewObject.fax, "Cloned object fax should be equal To existing object..")
        Assert.AreEqual(o.mobile, NewObject.mobile, "Cloned object mobile should be equal To existing object..")
        Assert.AreEqual(o.email, NewObject.email, "Cloned object email should be equal To existing object..")
        Assert.AreEqual(o.create_date, NewObject.create_date, "Cloned object create_date should be equal To existing object..")
        Assert.AreEqual(o.update_date, NewObject.update_date, "Cloned object update_date should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsOPERATOR = clsOPERATOR.NewclsOPERATOR 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsOPERATOR = clsOPERATOR.Fetch(ExistingObject.user_code, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsOPERATOR = clsOPERATOR.Fetch(ExistingObject.user_code, 0)
        	ModifyObject(o)
        	o.Save()
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterInsertSave()
        Dim o As clsOPERATOR = ctype(NewObject.Clone(), clsOPERATOR)
        If o.IsSavable Then
	        o.Save()
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
	        o.Delete()
	        o.Save()	    
        Else
            Assert.Fail("Validation rules broken:" & o.BrokenRulesString())
        End If
    End Sub

#End Region
End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region