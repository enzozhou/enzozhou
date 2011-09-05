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
'* Name:        clsskuinfoTest
'*
'* Description: NUnit tests for clsskuinfo
'*
'******************************************************************************

<TestFixture()> Public Class clsskuinfoTest

    '// Business Objects we are testing
    Dim clsskuinfoCollection As clsskuinfoes

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsskuinfo
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsskuinfo

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsskuinfo.Newclsskuinfo 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsskuinfo.Newclsskuinfo
        'NewObject.sku_desc= ?
        'NewObject.sku_desc_eng= ?
        'NewObject.model_no= ?
        'NewObject.volume= ?
        'NewObject.length= ?
        'NewObject.width_= ?
        'NewObject.height= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsskuinfo)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsskuinfo)

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
        clsskuinfoCollection = clsskuinfoes.Fetch(New CXFilters(), 0)
        
        If clsskuinfoCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsskuinfoCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsskuinfoCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsskuinfoCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsskuinfoCollection = clsskuinfoes.Fetch(FindFilters, 0)
        
        If clsskuinfoCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsskuinfoCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsskuinfoCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsskuinfoCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsskuinfo = clsskuinfo.Fetch(ExistingObject.sku_no,ExistingObject.sku_wms, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.sku_no, ExistingObject.sku_no, "sku_no should be [" & ExistingObject.sku_no.ToString() & "] after object is loaded from database. sku_no is " & o.sku_no.ToString())
	        Assert.AreEqual(o.sku_wms, ExistingObject.sku_wms, "sku_wms should be [" & ExistingObject.sku_wms.ToString() & "] after object is loaded from database. sku_wms is " & o.sku_wms.ToString())
	        Assert.AreEqual(o.sku_desc, ExistingObject.sku_desc, "sku_desc should be [" & ExistingObject.sku_desc.ToString() & "] after object is loaded from database. sku_desc is " & o.sku_desc.ToString())
	        Assert.AreEqual(o.sku_desc_eng, ExistingObject.sku_desc_eng, "sku_desc_eng should be [" & ExistingObject.sku_desc_eng.ToString() & "] after object is loaded from database. sku_desc_eng is " & o.sku_desc_eng.ToString())
	        Assert.AreEqual(o.model_no, ExistingObject.model_no, "model_no should be [" & ExistingObject.model_no.ToString() & "] after object is loaded from database. model_no is " & o.model_no.ToString())
	        Assert.AreEqual(o.volume, ExistingObject.volume, "volume should be [" & ExistingObject.volume.ToString() & "] after object is loaded from database. volume is " & o.volume.ToString())
	        Assert.AreEqual(o.length, ExistingObject.length, "length should be [" & ExistingObject.length.ToString() & "] after object is loaded from database. length is " & o.length.ToString())
	        Assert.AreEqual(o.width_, ExistingObject.width_, "width_ should be [" & ExistingObject.width_.ToString() & "] after object is loaded from database. width_ is " & o.width_.ToString())
	        Assert.AreEqual(o.height, ExistingObject.height, "height should be [" & ExistingObject.height.ToString() & "] after object is loaded from database. height is " & o.height.ToString())
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
        Dim o As clsskuinfo = CType(ExistingObject.Clone(), clsskuinfo)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.sku_no, o.sku_no, "Cloned object sku_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.sku_wms, o.sku_wms, "Cloned object sku_wms should be equal To existing object.")
        Assert.AreEqual(ExistingObject.sku_desc, o.sku_desc, "Cloned object sku_desc should be equal To existing object.")
        Assert.AreEqual(ExistingObject.sku_desc_eng, o.sku_desc_eng, "Cloned object sku_desc_eng should be equal To existing object.")
        Assert.AreEqual(ExistingObject.model_no, o.model_no, "Cloned object model_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.volume, o.volume, "Cloned object volume should be equal To existing object.")
        Assert.AreEqual(ExistingObject.length, o.length, "Cloned object length should be equal To existing object.")
        Assert.AreEqual(ExistingObject.width_, o.width_, "Cloned object width_ should be equal To existing object.")
        Assert.AreEqual(ExistingObject.height, o.height, "Cloned object height should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")

		o = CType(NewObject.Clone(), clsskuinfo)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.sku_no, NewObject.sku_no, "Cloned object sku_no should be equal To existing object..")
        Assert.AreEqual(o.sku_wms, NewObject.sku_wms, "Cloned object sku_wms should be equal To existing object..")
        Assert.AreEqual(o.sku_desc, NewObject.sku_desc, "Cloned object sku_desc should be equal To existing object..")
        Assert.AreEqual(o.sku_desc_eng, NewObject.sku_desc_eng, "Cloned object sku_desc_eng should be equal To existing object..")
        Assert.AreEqual(o.model_no, NewObject.model_no, "Cloned object model_no should be equal To existing object..")
        Assert.AreEqual(o.volume, NewObject.volume, "Cloned object volume should be equal To existing object..")
        Assert.AreEqual(o.length, NewObject.length, "Cloned object length should be equal To existing object..")
        Assert.AreEqual(o.width_, NewObject.width_, "Cloned object width_ should be equal To existing object..")
        Assert.AreEqual(o.height, NewObject.height, "Cloned object height should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsskuinfo = clsskuinfo.Newclsskuinfo 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsskuinfo = clsskuinfo.Fetch(ExistingObject.sku_no,ExistingObject.sku_wms, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsskuinfo = clsskuinfo.Fetch(ExistingObject.sku_no,ExistingObject.sku_wms, 0)
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
        Dim o As clsskuinfo = ctype(NewObject.Clone(), clsskuinfo)
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