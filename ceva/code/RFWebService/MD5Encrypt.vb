Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' DES加密/解密类。
''' </summary>
Public Class MD5Encrypt
    Public Sub New()
    End Sub
#Region "========加密========"
    ''' <summary>
    ''' 加密
    ''' </summary>
    ''' <param name="Text"></param>
    ''' <returns></returns>
    Public Shared Function Encrypt(ByVal Text As String) As String
        Return Encrypt(Text, "Zhang121")
    End Function
    ''' <summary> 
    ''' 加密数据 
    ''' </summary> 
    ''' <param name="Text"></param> 
    ''' <param name="sKey"></param> 
    ''' <returns></returns> 
    Public Shared Function Encrypt(ByVal Text As String, ByVal sKey As String) As String
        Dim des As New DESCryptoServiceProvider()
        Dim inputByteArray As Byte()
        inputByteArray = Encoding.[Default].GetBytes(Text)
        des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
        des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
        Dim ms As New System.IO.MemoryStream()
        Dim cs As New CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write)
        cs.Write(inputByteArray, 0, inputByteArray.Length)
        cs.FlushFinalBlock()
        Dim ret As New StringBuilder()
        For Each b As Byte In ms.ToArray()
            ret.AppendFormat("{0:X2}", b)
        Next
        Return ret.ToString()
    End Function
#End Region

#Region "========解密========"

    ''' <summary>
    ''' 解密
    ''' </summary>
    ''' <param name="Text"></param>
    ''' <returns></returns>
    Public Shared Function Decrypt(ByVal Text As String, ByRef sErr As String) As String
        Return Decrypt(Text, "Zhang121", sErr)
    End Function
    ''' <summary> 
    ''' 解密数据 
    ''' </summary> 
    ''' <param name="Text"></param> 
    ''' <param name="sKey"></param> 
    ''' <returns></returns> 
    Public Shared Function Decrypt(ByVal Text As String, ByVal sKey As String, ByRef sErr As String) As String
        Try
            Dim des As New DESCryptoServiceProvider()
            Dim len As Integer
            len = Text.Length \ 2
            Dim inputByteArray As Byte() = New Byte(len - 1) {}
            Dim x As Integer, i As Integer
            For x = 0 To len - 1
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16)
                inputByteArray(x) = CByte(i)
            Next
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
            Dim ms As New System.IO.MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            sErr = ""
            Return Encoding.[Default].GetString(ms.ToArray())
        Catch
            sErr = "加密串错误，无法解密！"
            Return ""
        End Try
    End Function

#End Region

End Class
