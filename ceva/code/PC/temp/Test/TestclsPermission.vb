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
'* Name:        clsPermissionTest
'*
'* Description: NUnit tests for clsPermission
'*
'******************************************************************************

<TestFixture()> Public Class clsPermissionTest

    '// Business Objects we are testing
    Dim clsPermissionCollection As clsPermissions

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsPermission
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsPermission

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsPermission.NewclsPermission 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsPermission.NewclsPermission
        'NewObject.description= ?
        'NewObject.trans_type= ?
        'NewObject.doc_type= ?
        'NewObject.remark= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsPermission)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsPermission)

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
        clsPermissionCollection = clsPermissions.Fetch(New CXFilters(), 0)
        
        If clsPermissionCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsPermissionCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsPermissionCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsPermissionCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsPermissionCollection = clsPermissions.Fetch(FindFilters, 0)
        
        If clsPermissionCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsPermissionCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsPermissionCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsPermissionCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsPermission = clsPermission.Fetch(ExistingObject.right_no, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.right_no, ExistingObject.right_no, "right_no should be [" & ExistingObject.right_no.ToString() & "] after object is loaded from database. right_no is " & o.right_no.ToString())
	        Assert.AreEqual(o.description, ExistingObject.description, "description should be [" & ExistingObject.description.ToString() & "] after object is loaded from database. description is " & o.description.ToString())
	        Assert.AreEqual(o.trans_type, ExistingObject.trans_type, "trans_type should be [" & ExistingObject.trans_type.ToString() & "] after object is loaded from database. trans_type is " & o.trans_type.ToString())
	        Assert.AreEqual(o.doc_type, ExistingObject.doc_type, "doc_type should be [" & ExistingObject.doc_type.ToString() & "] after object is loaded from database. doc_type is " & o.doc_type.ToString())
	        Assert.AreEqual(o.cmd_type, ExistingObject.cmd_type, "cmd_type should be [" & ExistingObject.cmd_type.ToString() & "] after object is loaded from database. cmd_type is " & o.cmd_type.ToString())
	        Assert.AreEqual(o.remark, ExistingObject.remark, "remark should be [" & ExistingObject.remark.ToString() & "] after object is loaded from database. remark is " & o.remark.ToString())
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
        Dim o As clsPermission = CType(ExistingObject.Clone(), clsPermission)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.right_no, o.right_no, "Cloned object right_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.description, o.description, "Cloned object description should be equal To existing object.")
        Assert.AreEqual(ExistingObject.trans_type, o.trans_type, "Cloned object trans_type should be equal To existing object.")
        Assert.AreEqual(ExistingObject.doc_type, o.doc_type, "Cloned object doc_type should be equal To existing object.")
        Assert.AreEqual(ExistingObject.cmd_type, o.cmd_type, "Cloned object cmd_type should be equal To existing object.")
        Assert.AreEqual(ExistingObject.remark, o.remark, "Cloned object remark should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")

		o = CType(NewObject.Clone(), clsPermission)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.right_no, NewObject.right_no, "Cloned object right_no should be equal To existing object..")
        Assert.AreEqual(o.description, NewObject.description, "Cloned object description should be equal To existing object..")
        Assert.AreEqual(o.trans_type, NewObject.trans_type, "Cloned object trans_type should be equal To existing object..")
        Assert.AreEqual(o.doc_type, NewObject.doc_type, "Cloned object doc_type should be equal To existing object..")
        Assert.AreEqual(o.cmd_type, NewObject.cmd_type, "Cloned object cmd_type should be equal To existing object..")
        Assert.AreEqual(o.remark, NewObject.remark, "Cloned object remark should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsPermission = clsPermission.NewclsPermission 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsPermission = clsPermission.Fetch(ExistingObject.right_no, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsPermission = clsPermission.Fetch(ExistingObject.right_no, 0)
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
        Dim o As clsPermission = ctype(NewObject.Clone(), clsPermission)
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