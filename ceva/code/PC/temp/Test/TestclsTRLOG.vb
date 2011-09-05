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
'* Name:        clsTRLOGTest
'*
'* Description: NUnit tests for clsTRLOG
'*
'******************************************************************************

<TestFixture()> Public Class clsTRLOGTest

    '// Business Objects we are testing
    Dim clsTRLOGCollection As clsTRLOGs

    '// Data that already exists in the database (before the tests run)
    Dim ExistingObject As clsTRLOG
	
    '// Data thet will be added by the tests and deleted by the tests
    Dim NewObject As clsTRLOG

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
	'// This section will not be overwritten during a round-trip code generation
	
    '// Record count used for business obkect collection test, please modify
    Dim RecordCount As Integer = 8
    
#Region "Setup, Hardcoded test Data"

    <SetUp()> Public Sub SetUp()

        'TODO: Enter test data for an existing record here
        ExistingObject = clsTRLOG.NewclsTRLOG 

        'TODO: Enter test data for a new record here. This record will be created and deleted by the tests
        '***** Please ensure that the data will not violate any unique contraints *****
        NewObject = clsTRLOG.NewclsTRLOG
        'NewObject.trans_type= ?
        'NewObject.cmd_type= ?
        'NewObject.doc_no= ?
        'NewObject.LINENUM= ?
        'NewObject.STCD= ?
        'NewObject.ITEMNO= ?
        'NewObject.ITEM_DESC= ?
        'NewObject.BANTCH= ?
        'NewObject.QTY= ?
        'NewObject.status= ?
        'NewObject.reason= ?
        'NewObject.reasonDesc= ?
        'NewObject.OPT_BY= ?
        'NewObject.OPT_ADDR= ?
        'NewObject.OPT_DATE= ?
 
    End Sub    

	'TODO: add some lines to modify the existing object so that it can be saved
    Private Sub ModifyObject(ByVal o As clsTRLOG)

    End Sub
    
    'TODO: add some lines to undo the changes to the existing object by "ModifyObject"
    Private Sub UnModifyObject(ByVal o As clsTRLOG)

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
        clsTRLOGCollection = clsTRLOGs.Fetch(New CXFilters(), 0)
        
        If clsTRLOGCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsTRLOGCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsTRLOGCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsTRLOGCollection.Count.ToString & "' records.")
    End Sub
    
    <Test()> Public Sub TestCollectionCountAfterFind()
        clsTRLOGCollection = clsTRLOGs.Fetch(FindFilters, 0)
        
        If clsTRLOGCollection.Count > 0 andalso ExistingObject.IsNew Then
        	ExistingObject = clsTRLOGCollection.Item(0)
        End If
        
        Assert.AreEqual(RecordCount, clsTRLOGCollection.Count, "Collection should contain '" & RecordCount.ToString() & "' records. It contains '" & clsTRLOGCollection.Count.ToString & "' records.")
    End Sub
#End Region


#Region "Test Properties"

    <Test()> Public Sub TestPropertiesAfterLoad()
    	If not ExistingObject.IsNew Then
        	Dim o As clsTRLOG = clsTRLOG.Fetch(ExistingObject.log_id, 0)
        	Assert.AreEqual(ExistingObject, o, "Objects should be the same.")   
				        Assert.AreEqual(o.log_id, ExistingObject.log_id, "log_id should be [" & ExistingObject.log_id.ToString() & "] after object is loaded from database. log_id is " & o.log_id.ToString())
	        Assert.AreEqual(o.trans_type, ExistingObject.trans_type, "trans_type should be [" & ExistingObject.trans_type.ToString() & "] after object is loaded from database. trans_type is " & o.trans_type.ToString())
	        Assert.AreEqual(o.cmd_type, ExistingObject.cmd_type, "cmd_type should be [" & ExistingObject.cmd_type.ToString() & "] after object is loaded from database. cmd_type is " & o.cmd_type.ToString())
	        Assert.AreEqual(o.doc_no, ExistingObject.doc_no, "doc_no should be [" & ExistingObject.doc_no.ToString() & "] after object is loaded from database. doc_no is " & o.doc_no.ToString())
	        Assert.AreEqual(o.LINENUM, ExistingObject.LINENUM, "LINENUM should be [" & ExistingObject.LINENUM.ToString() & "] after object is loaded from database. LINENUM is " & o.LINENUM.ToString())
	        Assert.AreEqual(o.STCD, ExistingObject.STCD, "STCD should be [" & ExistingObject.STCD.ToString() & "] after object is loaded from database. STCD is " & o.STCD.ToString())
	        Assert.AreEqual(o.ITEMNO, ExistingObject.ITEMNO, "ITEMNO should be [" & ExistingObject.ITEMNO.ToString() & "] after object is loaded from database. ITEMNO is " & o.ITEMNO.ToString())
	        Assert.AreEqual(o.ITEM_DESC, ExistingObject.ITEM_DESC, "ITEM_DESC should be [" & ExistingObject.ITEM_DESC.ToString() & "] after object is loaded from database. ITEM_DESC is " & o.ITEM_DESC.ToString())
	        Assert.AreEqual(o.BANTCH, ExistingObject.BANTCH, "BANTCH should be [" & ExistingObject.BANTCH.ToString() & "] after object is loaded from database. BANTCH is " & o.BANTCH.ToString())
	        Assert.AreEqual(o.QTY, ExistingObject.QTY, "QTY should be [" & ExistingObject.QTY.ToString() & "] after object is loaded from database. QTY is " & o.QTY.ToString())
	        Assert.AreEqual(o.status, ExistingObject.status, "status should be [" & ExistingObject.status.ToString() & "] after object is loaded from database. status is " & o.status.ToString())
	        Assert.AreEqual(o.reason, ExistingObject.reason, "reason should be [" & ExistingObject.reason.ToString() & "] after object is loaded from database. reason is " & o.reason.ToString())
	        Assert.AreEqual(o.reasonDesc, ExistingObject.reasonDesc, "reasonDesc should be [" & ExistingObject.reasonDesc.ToString() & "] after object is loaded from database. reasonDesc is " & o.reasonDesc.ToString())
	        Assert.AreEqual(o.OPT_BY, ExistingObject.OPT_BY, "OPT_BY should be [" & ExistingObject.OPT_BY.ToString() & "] after object is loaded from database. OPT_BY is " & o.OPT_BY.ToString())
	        Assert.AreEqual(o.OPT_ADDR, ExistingObject.OPT_ADDR, "OPT_ADDR should be [" & ExistingObject.OPT_ADDR.ToString() & "] after object is loaded from database. OPT_ADDR is " & o.OPT_ADDR.ToString())
	        Assert.AreEqual(o.OPT_DATE, ExistingObject.OPT_DATE, "OPT_DATE should be [" & ExistingObject.OPT_DATE.ToString() & "] after object is loaded from database. OPT_DATE is " & o.OPT_DATE.ToString())
	        Assert.AreEqual(o.OPT_TIMESTAMP, ExistingObject.OPT_TIMESTAMP, "OPT_TIMESTAMP should be [" & ExistingObject.OPT_TIMESTAMP.ToString() & "] after object is loaded from database. OPT_TIMESTAMP is " & o.OPT_TIMESTAMP.ToString())
        Else
            Assert.Fail("no existing object")			
		End If
    End Sub

#End Region


#Region "Test Standard Methods"

    <Test()> Public Sub TestClone()
        Dim o As clsTRLOG = CType(ExistingObject.Clone(), clsTRLOG)
        
        'Assert.AreEqual(ExistingObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(ExistingObject.log_id, o.log_id, "Cloned object log_id should be equal To existing object.")
        Assert.AreEqual(ExistingObject.trans_type, o.trans_type, "Cloned object trans_type should be equal To existing object.")
        Assert.AreEqual(ExistingObject.cmd_type, o.cmd_type, "Cloned object cmd_type should be equal To existing object.")
        Assert.AreEqual(ExistingObject.doc_no, o.doc_no, "Cloned object doc_no should be equal To existing object.")
        Assert.AreEqual(ExistingObject.LINENUM, o.LINENUM, "Cloned object LINENUM should be equal To existing object.")
        Assert.AreEqual(ExistingObject.STCD, o.STCD, "Cloned object STCD should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ITEMNO, o.ITEMNO, "Cloned object ITEMNO should be equal To existing object.")
        Assert.AreEqual(ExistingObject.ITEM_DESC, o.ITEM_DESC, "Cloned object ITEM_DESC should be equal To existing object.")
        Assert.AreEqual(ExistingObject.BANTCH, o.BANTCH, "Cloned object BANTCH should be equal To existing object.")
        Assert.AreEqual(ExistingObject.QTY, o.QTY, "Cloned object QTY should be equal To existing object.")
        Assert.AreEqual(ExistingObject.status, o.status, "Cloned object status should be equal To existing object.")
        Assert.AreEqual(ExistingObject.reason, o.reason, "Cloned object reason should be equal To existing object.")
        Assert.AreEqual(ExistingObject.reasonDesc, o.reasonDesc, "Cloned object reasonDesc should be equal To existing object.")
        Assert.AreEqual(ExistingObject.OPT_BY, o.OPT_BY, "Cloned object OPT_BY should be equal To existing object.")
        Assert.AreEqual(ExistingObject.OPT_ADDR, o.OPT_ADDR, "Cloned object OPT_ADDR should be equal To existing object.")
        Assert.AreEqual(ExistingObject.OPT_DATE, o.OPT_DATE, "Cloned object OPT_DATE should be equal To existing object.")
        Assert.AreEqual(ExistingObject.OPT_TIMESTAMP, o.OPT_TIMESTAMP, "Cloned object OPT_TIMESTAMP should be equal To existing object.")

		o = CType(NewObject.Clone(), clsTRLOG)
        
        'Assert.AreEqual(NewObject, o, "Cloned object should be equal To existing object.")
        Assert.AreEqual(NewObject.IsNew, o.IsNew, "Cloned object IsNew Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDirty, o.IsDirty, "Cloned object IsDirty Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsValid, o.IsValid, "Cloned object IsValid Property should be equal To existing object.")
        Assert.AreEqual(NewObject.IsDeleted, o.IsDeleted, "Cloned object IsDeleted Property should be equal To existing object.")
        Assert.AreEqual(NewObject.ToString(), o.ToString(), "Cloned object ToString should be equal To existing object.")
        Assert.AreEqual(o.log_id, NewObject.log_id, "Cloned object log_id should be equal To existing object..")
        Assert.AreEqual(o.trans_type, NewObject.trans_type, "Cloned object trans_type should be equal To existing object..")
        Assert.AreEqual(o.cmd_type, NewObject.cmd_type, "Cloned object cmd_type should be equal To existing object..")
        Assert.AreEqual(o.doc_no, NewObject.doc_no, "Cloned object doc_no should be equal To existing object..")
        Assert.AreEqual(o.LINENUM, NewObject.LINENUM, "Cloned object LINENUM should be equal To existing object..")
        Assert.AreEqual(o.STCD, NewObject.STCD, "Cloned object STCD should be equal To existing object..")
        Assert.AreEqual(o.ITEMNO, NewObject.ITEMNO, "Cloned object ITEMNO should be equal To existing object..")
        Assert.AreEqual(o.ITEM_DESC, NewObject.ITEM_DESC, "Cloned object ITEM_DESC should be equal To existing object..")
        Assert.AreEqual(o.BANTCH, NewObject.BANTCH, "Cloned object BANTCH should be equal To existing object..")
        Assert.AreEqual(o.QTY, NewObject.QTY, "Cloned object QTY should be equal To existing object..")
        Assert.AreEqual(o.status, NewObject.status, "Cloned object status should be equal To existing object..")
        Assert.AreEqual(o.reason, NewObject.reason, "Cloned object reason should be equal To existing object..")
        Assert.AreEqual(o.reasonDesc, NewObject.reasonDesc, "Cloned object reasonDesc should be equal To existing object..")
        Assert.AreEqual(o.OPT_BY, NewObject.OPT_BY, "Cloned object OPT_BY should be equal To existing object..")
        Assert.AreEqual(o.OPT_ADDR, NewObject.OPT_ADDR, "Cloned object OPT_ADDR should be equal To existing object..")
        Assert.AreEqual(o.OPT_DATE, NewObject.OPT_DATE, "Cloned object OPT_DATE should be equal To existing object..")
        Assert.AreEqual(o.OPT_TIMESTAMP, NewObject.OPT_TIMESTAMP, "Cloned object OPT_TIMESTAMP should be equal To existing object..")
    End Sub

#End Region


#Region "Tests For IsNew, IsDirty, IsDeleted Flag"

    <Test()> Public Sub TestFlagAfterConstructor()
        Dim o As clsTRLOG = clsTRLOG.NewclsTRLOG 
        Assert.AreEqual(True, o.IsNew, "IsNew Flag should be 'TRUE' after constructor is called.")
        Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
    End Sub

    <Test()> Public Sub TestFlagAfterLoad()
    	If Not ExistingObject.IsNew Then
        	Dim o As clsTRLOG = clsTRLOG.Fetch(ExistingObject.log_id, 0)
        	Assert.AreEqual(False, o.IsNew, "IsNew Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDirty, "IsDirty Flag should be 'FALSE' after constructor is called.")
        	Assert.AreEqual(False, o.IsDeleted, "IsDeleted Flag should be 'FALSE' after constructor is called.")
        Else
            Assert.Fail("no existing object")
        End If
    End Sub

    <Test()> Public Sub TestFlagAfterUpdateSave()
        If Not ExistingObject.IsNew Then
        	Dim o As clsTRLOG = clsTRLOG.Fetch(ExistingObject.log_id, 0)
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
        Dim o As clsTRLOG = ctype(NewObject.Clone(), clsTRLOG)
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