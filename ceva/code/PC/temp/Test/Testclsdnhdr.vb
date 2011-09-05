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
'* Name:        clsdnhdrTest
'*
'* Description: NUnit tests for clsdnhdr
'*
'******************************************************************************

<TestFixture()> Public Class clsdnhdrTest

    '// Business Objects we are testing
    Dim clsdnhdrCollection As clsdnhdrs

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsdnhdr
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsdnhdr

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsdnhdr.Newclsdnhdr 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsdnhdr.Newclsdnhdr
        'NewObject.sony_bch_no= ?
        'NewObject.doc_type= ?
        'NewObject.imp_dtime= ?
        'NewObject.city_to= ?
        'NewObject.deal_to= ?
        'NewObject.deal_name= ?
        'NewObject.deal_person= ?
        'NewObject.deal_tel= ?
        'NewObject.unloading_address= ?
        'NewObject.status_code= ?
        'NewObject.opt_by= ?
        'NewObject.opt_dtime= ?
        'NewObject.start_dtime= ?
        'NewObject.end_dtime= ?
        'NewObject.remark= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsdnhdr)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsdnhdr)

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
        clsdnhdrCollection = clsdnhdrs.Fetch(New CXFilters(), 0)
        
        If clsdnhdrCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsdnhdrCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsdnhdrCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsdnhdrCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsdnhdrCollection = clsdnhdrs.Fetch(FindFilters, 0)
        
        If clsdnhdrCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsdnhdrCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsdnhdrCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsdnhdrCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsdnhdr = clsdnhdr.Fetch(ExistingObject.dc_code,ExistingObject.dn_no, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.dc_code, ExistingObject.dc_code, "dc_code should be [" & ExistingObject.dc_code.ToString() & "] after object is loaded from database. dc_code is " & o.dc_code.ToString())
	        Assert.AreEqual(o.dn_no, ExistingObject.dn_no, "dn_no should be [" & ExistingObject.dn_no.ToString() & "] after object is loaded from database. dn_no is " & o.dn_no.ToString())
	        Assert.AreEqual(o.sony_bch_no, ExistingObject.sony_bch_no, "sony_bch_no should be [" & ExistingObject.sony_bch_no.ToString() & "] after object is loaded from database. sony_bch_no is " & o.sony_bch_no.ToString())
	        Assert.AreEqual(o.doc_type, ExistingObject.doc_type, "doc_type should be [" & ExistingObject.doc_type.ToString() & "] after object is loaded from database. doc_type is " & o.doc_type.ToString())
	        Assert.AreEqual(o.imp_dtime, ExistingObject.imp_dtime, "imp_dtime should be [" & ExistingObject.imp_dtime.ToString() & "] after object is loaded from database. imp_dtime is " & o.imp_dtime.ToString())
	        Assert.AreEqual(o.city_to, ExistingObject.city_to, "city_to should be [" & ExistingObject.city_to.ToString() & "] after object is loaded from database. city_to is " & o.city_to.ToString())
	        Assert.AreEqual(o.deal_to, ExistingObject.deal_to, "deal_to should be [" & ExistingObject.deal_to.ToString() & "] after object is loaded from database. deal_to is " & o.deal_to.ToString())
	        Assert.AreEqual(o.deal_name, ExistingObject.deal_name, "deal_name should be [" & ExistingObject.deal_name.ToString() & "] after object is loaded from database. deal_name is " & o.deal_name.ToString())
	        Assert.AreEqual(o.deal_person, ExistingObject.deal_person, "deal_person should be [" & ExistingObject.deal_person.ToString() & "] after object is loaded from database. deal_person is " & o.deal_person.ToString())
	        Assert.AreEqual(o.deal_tel, ExistingObject.deal_tel, "deal_tel should be [" & ExistingObject.deal_tel.ToString() & "] after object is loaded from database. deal_tel is " & o.deal_tel.ToString())
	        Assert.AreEqual(o.unloading_address, ExistingObject.unloading_address, "unloading_address should be [" & ExistingObject.unloading_address.ToString() & "] after object is loaded from database. unloading_address is " & o.unloading_address.ToString())
	        Assert.AreEqual(o.status_code, ExistingObject.status_code, "status_code should be [" & ExistingObject.status_code.ToString() & "] after object is loaded from database. status_code is " & o.status_code.ToString())
	        Assert.AreEqual(o.opt_by, ExistingObject.opt_by, "opt_by should be [" & ExistingObject.opt_by.ToString() & "] after object is loaded from database. opt_by is " & o.opt_by.ToString())
	        Assert.AreEqual(o.opt_dtime, ExistingObject.opt_dtime, "opt_dtime should be [" & ExistingObject.opt_dtime.ToString() & "] after object is loaded from database. opt_dtime is " & o.opt_dtime.ToString())
	        Assert.AreEqual(o.start_dtime, ExistingObject.start_dtime, "start_dtime should be [" & ExistingObject.start_dtime.ToString() & "] after object is loaded from database. start_dtime is " & o.start_dtime.ToString())
	        Assert.AreEqual(o.end_dtime, ExistingObject.end_dtime, "end_dtime should be [" & ExistingObject.end_dtime.ToString() & "] after object is loaded from database. end_dtime is " & o.end_dtime.ToString())
	        Assert.AreEqual(o.remark, ExistingObject.remark, "remark should be [" & ExistingObject.remark.ToString() & "] after object is loaded from database. remark is " & o.remark.ToString())
	        Assert.AreEqual(o.opt_timestamp, ExistingObject.opt_timestamp, "opt_timestamp should be [" & ExistingObject.opt_timestamp.ToString() & "] after object is loaded from database. opt_timestamp is " & o.opt_timestamp.ToString())
        Else
            Assert.Fail("no existing object")			
		End If
    End Sub

#End Region


#Region "Test Standard Methods"

    <Test()> Public Sub TestClone()
        Dim o As clsdnhdr = CType(ExistingObject.Clone(), clsdnhdr)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dc_code, o.dc_code, "Cloned object dc_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.dn_no, o.dn_no, "Cloned object dn_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.sony_bch_no, o.sony_bch_no, "Cloned object sony_bch_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.doc_type, o.doc_type, "Cloned object doc_type should be equal To existing object.")
        Assert.AreEqual(ExistingObject.imp_dtime, o.imp_dtime, "Cloned object imp_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.city_to, o.city_to, "Cloned object city_to should be equal To existing object.")
        Assert.AreEqual(ExistingObject.deal_to, o.deal_to, "Cloned object deal_to should be equal To existing object.")
        Assert.AreEqual(ExistingObject.deal_name, o.deal_name, "Cloned object deal_name should be equal To existing object.")
        Assert.AreEqual(ExistingObject.deal_person, o.deal_person, "Cloned object deal_person should be equal To existing object.")
        Assert.AreEqual(ExistingObject.deal_tel, o.deal_tel, "Cloned object deal_tel should be equal To existing object.")
        Assert.AreEqual(ExistingObject.unloading_address, o.unloading_address, "Cloned object unloading_address should be equal To existing object.")
        Assert.AreEqual(ExistingObject.status_code, o.status_code, "Cloned object status_code should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_by, o.opt_by, "Cloned object opt_by should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_dtime, o.opt_dtime, "Cloned object opt_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.start_dtime, o.start_dtime, "Cloned object start_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.end_dtime, o.end_dtime, "Cloned object end_dtime should be equal To existing object.")
        Assert.AreEqual(ExistingObject.remark, o.remark, "Cloned object remark should be equal To existing object.")
        Assert.AreEqual(ExistingObject.opt_timestamp, o.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object.")

		o = CType(NewObject.Clone(), clsdnhdr)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.dc_code, NewObject.dc_code, "Cloned object dc_code should be equal To existing object..")
        Assert.AreEqual(o.dn_no, NewObject.dn_no, "Cloned object dn_no should be equal To existing object..")
        Assert.AreEqual(o.sony_bch_no, NewObject.sony_bch_no, "Cloned object sony_bch_no should be equal To existing object..")
        Assert.AreEqual(o.doc_type, NewObject.doc_type, "Cloned object doc_type should be equal To existing object..")
        Assert.AreEqual(o.imp_dtime, NewObject.imp_dtime, "Cloned object imp_dtime should be equal To existing object..")
        Assert.AreEqual(o.city_to, NewObject.city_to, "Cloned object city_to should be equal To existing object..")
        Assert.AreEqual(o.deal_to, NewObject.deal_to, "Cloned object deal_to should be equal To existing object..")
        Assert.AreEqual(o.deal_name, NewObject.deal_name, "Cloned object deal_name should be equal To existing object..")
        Assert.AreEqual(o.deal_person, NewObject.deal_person, "Cloned object deal_person should be equal To existing object..")
        Assert.AreEqual(o.deal_tel, NewObject.deal_tel, "Cloned object deal_tel should be equal To existing object..")
        Assert.AreEqual(o.unloading_address, NewObject.unloading_address, "Cloned object unloading_address should be equal To existing object..")
        Assert.AreEqual(o.status_code, NewObject.status_code, "Cloned object status_code should be equal To existing object..")
        Assert.AreEqual(o.opt_by, NewObject.opt_by, "Cloned object opt_by should be equal To existing object..")
        Assert.AreEqual(o.opt_dtime, NewObject.opt_dtime, "Cloned object opt_dtime should be equal To existing object..")
        Assert.AreEqual(o.start_dtime, NewObject.start_dtime, "Cloned object start_dtime should be equal To existing object..")
        Assert.AreEqual(o.end_dtime, NewObject.end_dtime, "Cloned object end_dtime should be equal To existing object..")
        Assert.AreEqual(o.remark, NewObject.remark, "Cloned object remark should be equal To existing object..")
        Assert.AreEqual(o.opt_timestamp, NewObject.opt_timestamp, "Cloned object opt_timestamp should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsdnhdr = clsdnhdr.Newclsdnhdr 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsdnhdr = clsdnhdr.Fetch(ExistingObject.dc_code,ExistingObject.dn_no, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsdnhdr = clsdnhdr.Fetch(ExistingObject.dc_code,ExistingObject.dn_no, 0)
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
        Dim o As clsdnhdr = ctype(NewObject.Clone(), clsdnhdr)
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