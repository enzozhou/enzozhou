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
'* Name:        clstasklistTest
'*
'* Description: NUnit tests for clstasklist
'*
'******************************************************************************

<TestFixture()> Public Class clstasklistTest

    '// Business Objects we are testing
    Dim clstasklistCollection As clstasklists

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clstasklist
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clstasklist

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clstasklist.Newclstasklist 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clstasklist.Newclstasklist
        'NewObject.bin_area= ?
        'NewObject.bin_code= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
        'NewObject.start_dtime= ?
        'NewObject.end_dtime= ?
        'NewObject.status_code= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clstasklist)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clstasklist)

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
        clstasklistCollection = clstasklists.Fetch(New CXFilters(), 0)
        
        If clstasklistCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clstasklistCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clstasklistCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clstasklistCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clstasklistCollection = clstasklists.Fetch(FindFilters, 0)
        
        If clstasklistCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clstasklistCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clstasklistCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clstasklistCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clstasklist = clstasklist.Fetch(ExistingObject.dc_code,ExistingObject.task_id,ExistingObject.bch_no,ExistingObject.dn_no,ExistingObject.assigned_opt, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.task_id, ExistingObject.task_id, "task_id should be [" & ExistingObject.task_id.ToString() & "] after object is loaded from database. task_id is " & o.task_id.ToString())
	        Assert.AreEqual(o.bch_no, ExistingObject.bch_no, "bch_no should be [" & ExistingObject.bch_no.ToString() & "] after object is loaded from database. bch_no is " & o.bch_no.ToString())
	        Assert.AreEqual(o.dn_no, ExistingObject.dn_no, "dn_no should be [" & ExistingObject.dn_no.ToString() & "] after object is loaded from database. dn_no is " & o.dn_no.ToString())
	        Assert.AreEqual(o.assigned_opt, ExistingObject.assigned_opt, "assigned_opt should be [" & ExistingObject.assigned_opt.ToString() & "] after object is loaded from database. assigned_opt is " & o.assigned_opt.ToString())
	        Assert.AreEqual(o.bin_area, ExistingObject.bin_area, "bin_area should be [" & ExistingObject.bin_area.ToString() & "] after object is loaded from database. bin_area is " & o.bin_area.ToString())
	        Assert.AreEqual(o.bin_code, ExistingObject.bin_code, "bin_code should be [" & ExistingObject.bin_code.ToString() & "] after object is loaded from database. bin_code is " & o.bin_code.ToString())
	        Assert.AreEqual(o.opt_by, ExistingObject.opt_by, "opt_by should be [" & ExistingObject.opt_by.ToString() & "] after object is loaded from database. opt_by is " & o.opt_by.ToString())
	        Assert.AreEqual(o.opt_dtime, ExistingObject.opt_dtime, "opt_dtime should be [" & ExistingObject.opt_dtime.ToString() & "] after object is loaded from database. opt_dtime is " & o.opt_dtime.ToString())
	        Assert.AreEqual(o.start_dtime, ExistingObject.start_dtime, "start_dtime should be [" & ExistingObject.start_dtime.ToString() & "] after object is loaded from database. start_dtime is " & o.start_dtime.ToString())
	        Assert.AreEqual(o.end_dtime, ExistingObject.end_dtime, "end_dtime should be [" & ExistingObject.end_dtime.ToString() & "] after object is loaded from database. end_dtime is " & o.end_dtime.ToString())
	        Assert.AreEqual(o.opt_timestamp, ExistingObject.opt_timestamp, "opt_timestamp should be [" & ExistingObject.opt_timestamp.ToString() & "] after object is loaded from database. opt_timestamp is " & o.opt_timestamp.ToString())
	        Assert.AreEqual(o.dc_code, ExistingObject.dc_code, "dc_code should be [" & ExistingObject.dc_code.ToString() & "] after object is loaded from database. dc_code is " & o.dc_code.ToString())
	        Assert.AreEqual(o.status_code, ExistingObject.status_code, "status_code should be [" & ExistingObject.status_code.ToString() & "] after object is loaded from database. status_code is " & o.status_code.ToString())
        Else
            Assert.Fail("no existing object")			
		End If
    End Sub

#End Region


#Region "Test Standard Methods"

    <Test()> Public Sub TestClone()
        Dim o As clstasklist = CType(ExistingObject.Clone(), clstasklist)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.task_id, o.task_id, "Cloned object task_id should be equal To existing object.")
        Assert.AreEqual(ExistingObject.bch_no, o.bch_no, "Cloned object bch_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dn_no, o.dn_no, "Cloned object dn_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.assigned_opt, o.assigned_opt, "Cloned object assigned_opt should be equal To existing object.")
        Assert.AreEqual(ExistingObject.bin_area, o.bin_area, "Cloned object bin_area should be equal To existing object.")
        Assert.AreEqual(ExistingObject.bin_code, o.bin_code, "Cloned object bin_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.start_dtime, o.start_dtime, "Cloned object start_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.end_dtime, o.end_dtime, "Cloned object end_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dc_code, o.dc_code, "Cloned object dc_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.status_code, o.status_code, "Cloned object status_code should be equal To existing object.")

		o = CType(NewObject.Clone(), clstasklist)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.task_id, NewObject.task_id, "Cloned object task_id should be equal To existing object..")
        Assert.AreEqual(o.bch_no, NewObject.bch_no, "Cloned object bch_no should be equal To existing object..")
        Assert.AreEqual(o.dn_no, NewObject.dn_no, "Cloned object dn_no should be equal To existing object..")
        Assert.AreEqual(o.assigned_opt, NewObject.assigned_opt, "Cloned object assigned_opt should be equal To existing object..")
        Assert.AreEqual(o.bin_area, NewObject.bin_area, "Cloned object bin_area should be equal To existing object..")
        Assert.AreEqual(o.bin_code, NewObject.bin_code, "Cloned object bin_code should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.start_dtime, NewObject.start_dtime, "Cloned object start_dtime should be equal To existing object..")
        Assert.AreEqual(o.end_dtime, NewObject.end_dtime, "Cloned object end_dtime should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
        Assert.AreEqual(o.dc_code, NewObject.dc_code, "Cloned object dc_code should be equal To existing object..")
        Assert.AreEqual(o.status_code, NewObject.status_code, "Cloned object status_code should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clstasklist = clstasklist.Newclstasklist 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clstasklist = clstasklist.Fetch(ExistingObject.dc_code,ExistingObject.task_id,ExistingObject.bch_no,ExistingObject.dn_no,ExistingObject.assigned_opt, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clstasklist = clstasklist.Fetch(ExistingObject.dc_code,ExistingObject.task_id,ExistingObject.bch_no,ExistingObject.dn_no,ExistingObject.assigned_opt, 0)
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
        Dim o As clstasklist = ctype(NewObject.Clone(), clstasklist)
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