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
'* Name:        clsUserroleTest
'*
'* Description: NUnit tests for clsUserrole
'*
'******************************************************************************

<TestFixture()> Public Class clsUserroleTest

    '// Business Objects we are testing
    Dim clsUserroleCollection As clsUserroles

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsUserrole
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsUserrole

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsUserrole.NewclsUserrole 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsUserrole.NewclsUserrole
        'NewObject.remark= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsUserrole)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsUserrole)

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
        clsUserroleCollection = clsUserroles.Fetch(New CXFilters(), 0)
        
        If clsUserroleCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsUserroleCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsUserroleCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsUserroleCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsUserroleCollection = clsUserroles.Fetch(FindFilters, 0)
        
        If clsUserroleCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsUserroleCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsUserroleCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsUserroleCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsUserrole = clsUserrole.Fetch(ExistingObject.user_code,ExistingObject.role_code, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.user_code, ExistingObject.user_code, "user_code should be [" & ExistingObject.user_code.ToString() & "] after object is loaded from database. user_code is " & o.user_code.ToString())
	        Assert.AreEqual(o.role_code, ExistingObject.role_code, "role_code should be [" & ExistingObject.role_code.ToString() & "] after object is loaded from database. role_code is " & o.role_code.ToString())
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
        Dim o As clsUserrole = CType(ExistingObject.Clone(), clsUserrole)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.user_code, o.user_code, "Cloned object user_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.role_code, o.role_code, "Cloned object role_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.remark, o.remark, "Cloned object remark should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")

		o = CType(NewObject.Clone(), clsUserrole)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.user_code, NewObject.user_code, "Cloned object user_code should be equal To existing object..")
        Assert.AreEqual(o.role_code, NewObject.role_code, "Cloned object role_code should be equal To existing object..")
        Assert.AreEqual(o.remark, NewObject.remark, "Cloned object remark should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsUserrole = clsUserrole.NewclsUserrole 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsUserrole = clsUserrole.Fetch(ExistingObject.user_code,ExistingObject.role_code, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsUserrole = clsUserrole.Fetch(ExistingObject.user_code,ExistingObject.role_code, 0)
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
        Dim o As clsUserrole = ctype(NewObject.Clone(), clsUserrole)
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