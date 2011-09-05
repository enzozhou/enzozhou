Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
'-----------------------------------------------------------------
'-----------------------------------------------------------------
Public Class Encryption64
    Private Shared appKeyStr As String = "ken@schm"
    Private Shared key() As Byte = {}
    Private Shared IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    '-----------------------------------------------------------------------------
    ''' <summary>
    ''' �����ķ���--����
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Encrypt(ByVal stringToDecrypt As String)
        Return Encrypt(stringToDecrypt, appKeyStr)
    End Function
    ''' <summary>
    ''' �����ķ���--����
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Decrypt(ByVal stringToDecrypt As String)
        Return Decrypt(stringToDecrypt, appKeyStr)
    End Function
    ''' <summary>
    ''' ���ܺ���,������׼:DESCryptoServiceProvider:
    ''' ����������ݼ��ܱ�׼ (DES) �㷨�ļ��ܷ����ṩ���� (CSP) �汾�İ�װ����
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <param name="sEncryptionKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Decrypt(ByVal stringToDecrypt As String, ByVal sEncryptionKey As String) As String
        Try
            Dim inputByteArray(stringToDecrypt.Length) As Byte
            key = System.Text.Encoding.UTF8.GetBytes(Left(sEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
    ''' <summary>
    ''' ���ܺ���
    ''' </summary>
    ''' <param name="stringToEncrypt"></param>
    ''' <param name="SEncryptionKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Encrypt(ByVal stringToEncrypt As String, ByVal SEncryptionKey As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(SEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(stringToEncrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function

End Class