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
'* Name:        clsbinStatusTest
'*
'* Description: NUnit tests for clsbinStatus
'*
'******************************************************************************

<TestFixture()> Public Class clsbinStatusTest

    '// Business Objects we are testing
    Dim clsbinStatusCollection As clsbinStatuses

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsbinStatus
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsbinStatus

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsbinStatus.NewclsbinStatus 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsbinStatus.NewclsbinStatus
        'NewObject.type_= ?
        'NewObject.status_code= ?
        'NewObject.close_auto= ?
        'NewObject.print_by= ?
        'NewObject.print_counter= ?
        'NewObject.print_dtime= ?
        'NewObject.locked= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
        'NewObject.start_dtime= ?
        'NewObject.end_dtime= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsbinStatus)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsbinStatus)

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
        clsbinStatusCollection = clsbinStatuses.Fetch(New CXFilters(), 0)
        
        If clsbinStatusCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsbinStatusCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsbinStatusCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsbinStatusCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsbinStatusCollection = clsbinStatuses.Fetch(FindFilters, 0)
        
        If clsbinStatusCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsbinStatusCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsbinStatusCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsbinStatusCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsbinStatus = clsbinStatus.Fetch(ExistingObject.dc_code,ExistingObject.id,ExistingObject.bin_area,ExistingObject.bin_code,ExistingObject.dn_no, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.dc_code, ExistingObject.dc_code, "dc_code should be [" & ExistingObject.dc_code.ToString() & "] after object is loaded from database. dc_code is " & o.dc_code.ToString())
	        Assert.AreEqual(o.id, ExistingObject.id, "id should be [" & ExistingObject.id.ToString() & "] after object is loaded from database. id is " & o.id.ToString())
	        Assert.AreEqual(o.bin_area, ExistingObject.bin_area, "bin_area should be [" & ExistingObject.bin_area.ToString() & "] after object is loaded from database. bin_area is " & o.bin_area.ToString())
	        Assert.AreEqual(o.bin_code, ExistingObject.bin_code, "bin_code should be [" & ExistingObject.bin_code.ToString() & "] after object is loaded from database. bin_code is " & o.bin_code.ToString())
	        Assert.AreEqual(o.dn_no, ExistingObject.dn_no, "dn_no should be [" & ExistingObject.dn_no.ToString() & "] after object is loaded from database. dn_no is " & o.dn_no.ToString())
	        Assert.AreEqual(o.type_, ExistingObject.type_, "type_ should be [" & ExistingObject.type_.ToString() & "] after object is loaded from database. type_ is " & o.type_.ToString())
	        Assert.AreEqual(o.status_code, ExistingObject.status_code, "status_code should be [" & ExistingObject.status_code.ToString() & "] after object is loaded from database. status_code is " & o.status_code.ToString())
	        Assert.AreEqual(o.close_auto, ExistingObject.close_auto, "close_auto should be [" & ExistingObject.close_auto.ToString() & "] after object is loaded from database. close_auto is " & o.close_auto.ToString())
	        Assert.AreEqual(o.print_by, ExistingObject.print_by, "print_by should be [" & ExistingObject.print_by.ToString() & "] after object is loaded from database. print_by is " & o.print_by.ToString())
	        Assert.AreEqual(o.print_counter, ExistingObject.print_counter, "print_counter should be [" & ExistingObject.print_counter.ToString() & "] after object is loaded from database. print_counter is " & o.print_counter.ToString())
	        Assert.AreEqual(o.print_dtime, ExistingObject.print_dtime, "print_dtime should be [" & ExistingObject.print_dtime.ToString() & "] after object is loaded from database. print_dtime is " & o.print_dtime.ToString())
	        Assert.AreEqual(o.locked, ExistingObject.locked, "locked should be [" & ExistingObject.locked.ToString() & "] after object is loaded from database. locked is " & o.locked.ToString())
	        Assert.AreEqual(o.opt_by, ExistingObject.opt_by, "opt_by should be [" & ExistingObject.opt_by.ToString() & "] after object is loaded from database. opt_by is " & o.opt_by.ToString())
	        Assert.AreEqual(o.opt_dtime, ExistingObject.opt_dtime, "opt_dtime should be [" & ExistingObject.opt_dtime.ToString() & "] after object is loaded from database. opt_dtime is " & o.opt_dtime.ToString())
	        Assert.AreEqual(o.start_dtime, ExistingObject.start_dtime, "start_dtime should be [" & ExistingObject.start_dtime.ToString() & "] after object is loaded from database. start_dtime is " & o.start_dtime.ToString())
	        Assert.AreEqual(o.end_dtime, ExistingObject.end_dtime, "end_dtime should be [" & ExistingObject.end_dtime.ToString() & "] after object is loaded from database. end_dtime is " & o.end_dtime.ToString())
	        Assert.AreEqual(o.opt_timestamp, ExistingObject.opt_timestamp, "opt_timestamp should be [" & ExistingObject.opt_timestamp.ToString() & "] after object is loaded from database. opt_timestamp is " & o.opt_timestamp.ToString())
        Else
            Assert.Fail("no existing object")			
		End If
    End Sub

#End Region


#Region "Test Standard Methods"

    <Test()> Public Sub TestClone()
        Dim o As clsbinStatus = CType(ExistingObject.Clone(), clsbinStatus)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dc_code, o.dc_code, "Cloned object dc_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.id, o.id, "Cloned object id should be equal To existing object.")
        Assert.AreEqual(ExistingObject.bin_area, o.bin_area, "Cloned object bin_area should be equal To existing object.")
        Assert.AreEqual(ExistingObject.bin_code, o.bin_code, "Cloned object bin_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dn_no, o.dn_no, "Cloned object dn_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.type_, o.type_, "Cloned object type_ should be equal To existing object.")
        Assert.AreEqual(ExistingObject.status_code, o.status_code, "Cloned object status_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.close_auto, o.close_auto, "Cloned object close_auto should be equal To existing object.")
        Assert.AreEqual(ExistingObject.print_by, o.print_by, "Cloned object print_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.print_counter, o.print_counter, "Cloned object print_counter should be equal To existing object.")
        Assert.AreEqual(ExistingObject.print_dtime, o.print_dtime, "Cloned object print_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.locked, o.locked, "Cloned object locked should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.start_dtime, o.start_dtime, "Cloned object start_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.end_dtime, o.end_dtime, "Cloned object end_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")

		o = CType(NewObject.Clone(), clsbinStatus)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.dc_code, NewObject.dc_code, "Cloned object dc_code should be equal To existing object..")
        Assert.AreEqual(o.id, NewObject.id, "Cloned object id should be equal To existing object..")
        Assert.AreEqual(o.bin_area, NewObject.bin_area, "Cloned object bin_area should be equal To existing object..")
        Assert.AreEqual(o.bin_code, NewObject.bin_code, "Cloned object bin_code should be equal To existing object..")
        Assert.AreEqual(o.dn_no, NewObject.dn_no, "Cloned object dn_no should be equal To existing object..")
        Assert.AreEqual(o.type_, NewObject.type_, "Cloned object type_ should be equal To existing object..")
        Assert.AreEqual(o.status_code, NewObject.status_code, "Cloned object status_code should be equal To existing object..")
        Assert.AreEqual(o.close_auto, NewObject.close_auto, "Cloned object close_auto should be equal To existing object..")
        Assert.AreEqual(o.print_by, NewObject.print_by, "Cloned object print_by should be equal To existing object..")
        Assert.AreEqual(o.print_counter, NewObject.print_counter, "Cloned object print_counter should be equal To existing object..")
        Assert.AreEqual(o.print_dtime, NewObject.print_dtime, "Cloned object print_dtime should be equal To existing object..")
        Assert.AreEqual(o.locked, NewObject.locked, "Cloned object locked should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.start_dtime, NewObject.start_dtime, "Cloned object start_dtime should be equal To existing object..")
        Assert.AreEqual(o.end_dtime, NewObject.end_dtime, "Cloned object end_dtime should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsbinStatus = clsbinStatus.NewclsbinStatus 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsbinStatus = clsbinStatus.Fetch(ExistingObject.dc_code,ExistingObject.id,ExistingObject.bin_area,ExistingObject.bin_code,ExistingObject.dn_no, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsbinStatus = clsbinStatus.Fetch(ExistingObject.dc_code,ExistingObject.id,ExistingObject.bin_area,ExistingObject.bin_code,ExistingObject.dn_no, 0)
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
        Dim o As clsbinStatus = ctype(NewObject.Clone(), clsbinStatus)
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