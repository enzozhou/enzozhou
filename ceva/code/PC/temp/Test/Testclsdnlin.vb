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
'* Name:        clsdnlinTest
'*
'* Description: NUnit tests for clsdnlin
'*
'******************************************************************************

<TestFixture()> Public Class clsdnlinTest

    '// Business Objects we are testing
    Dim clsdnlinCollection As clsdnlins

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsdnlin
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsdnlin

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsdnlin.Newclsdnlin 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsdnlin.Newclsdnlin
        'NewObject.sku_no= ?
        'NewObject.qty= ?
        'NewObject.act_qty= ?
        'NewObject.status_code= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsdnlin)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsdnlin)

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
        clsdnlinCollection = clsdnlins.Fetch(New CXFilters(), 0)
        
        If clsdnlinCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsdnlinCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsdnlinCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsdnlinCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsdnlinCollection = clsdnlins.Fetch(FindFilters, 0)
        
        If clsdnlinCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsdnlinCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsdnlinCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsdnlinCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsdnlin = clsdnlin.Fetch(ExistingObject.dc_code,ExistingObject.dn_no,ExistingObject.row_id, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.row_id, ExistingObject.row_id, "row_id should be [" & ExistingObject.row_id.ToString() & "] after object is loaded from database. row_id is " & o.row_id.ToString())
	        Assert.AreEqual(o.sku_no, ExistingObject.sku_no, "sku_no should be [" & ExistingObject.sku_no.ToString() & "] after object is loaded from database. sku_no is " & o.sku_no.ToString())
	        Assert.AreEqual(o.qty, ExistingObject.qty, "qty should be [" & ExistingObject.qty.ToString() & "] after object is loaded from database. qty is " & o.qty.ToString())
	        Assert.AreEqual(o.act_qty, ExistingObject.act_qty, "act_qty should be [" & ExistingObject.act_qty.ToString() & "] after object is loaded from database. act_qty is " & o.act_qty.ToString())
	        Assert.AreEqual(o.status_code, ExistingObject.status_code, "status_code should be [" & ExistingObject.status_code.ToString() & "] after object is loaded from database. status_code is " & o.status_code.ToString())
	        Assert.AreEqual(o.opt_by, ExistingObject.opt_by, "opt_by should be [" & ExistingObject.opt_by.ToString() & "] after object is loaded from database. opt_by is " & o.opt_by.ToString())
	        Assert.AreEqual(o.opt_dtime, ExistingObject.opt_dtime, "opt_dtime should be [" & ExistingObject.opt_dtime.ToString() & "] after object is loaded from database. opt_dtime is " & o.opt_dtime.ToString())
	        Assert.AreEqual(o.opt_timestamp, ExistingObject.opt_timestamp, "opt_timestamp should be [" & ExistingObject.opt_timestamp.ToString() & "] after object is loaded from database. opt_timestamp is " & o.opt_timestamp.ToString())
	        Assert.AreEqual(o.dc_code, ExistingObject.dc_code, "dc_code should be [" & ExistingObject.dc_code.ToString() & "] after object is loaded from database. dc_code is " & o.dc_code.ToString())
	        Assert.AreEqual(o.dn_no, ExistingObject.dn_no, "dn_no should be [" & ExistingObject.dn_no.ToString() & "] after object is loaded from database. dn_no is " & o.dn_no.ToString())
        Else
            Assert.Fail("no existing object")			
		End If
    End Sub

#End Region


#Region "Test Standard Methods"

    <Test()> Public Sub TestClone()
        Dim o As clsdnlin = CType(ExistingObject.Clone(), clsdnlin)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.row_id, o.row_id, "Cloned object row_id should be equal To existing object.")
        Assert.AreEqual(ExistingObject.sku_no, o.sku_no, "Cloned object sku_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.qty, o.qty, "Cloned object qty should be equal To existing object.")
        Assert.AreEqual(ExistingObject.act_qty, o.act_qty, "Cloned object act_qty should be equal To existing object.")
        Assert.AreEqual(ExistingObject.status_code, o.status_code, "Cloned object status_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dc_code, o.dc_code, "Cloned object dc_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dn_no, o.dn_no, "Cloned object dn_no should be equal To existing object.")

		o = CType(NewObject.Clone(), clsdnlin)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.row_id, NewObject.row_id, "Cloned object row_id should be equal To existing object..")
        Assert.AreEqual(o.sku_no, NewObject.sku_no, "Cloned object sku_no should be equal To existing object..")
        Assert.AreEqual(o.qty, NewObject.qty, "Cloned object qty should be equal To existing object..")
        Assert.AreEqual(o.act_qty, NewObject.act_qty, "Cloned object act_qty should be equal To existing object..")
        Assert.AreEqual(o.status_code, NewObject.status_code, "Cloned object status_code should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
        Assert.AreEqual(o.dc_code, NewObject.dc_code, "Cloned object dc_code should be equal To existing object..")
        Assert.AreEqual(o.dn_no, NewObject.dn_no, "Cloned object dn_no should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsdnlin = clsdnlin.Newclsdnlin 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsdnlin = clsdnlin.Fetch(ExistingObject.dc_code,ExistingObject.dn_no,ExistingObject.row_id, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsdnlin = clsdnlin.Fetch(ExistingObject.dc_code,ExistingObject.dn_no,ExistingObject.row_id, 0)
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
        Dim o As clsdnlin = ctype(NewObject.Clone(), clsdnlin)
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