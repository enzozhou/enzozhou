Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
'-----------------------------------------------------------------
'在龙腾光电程序_V1.0版本中,加/解密密钥是 ken@schm
'CEVA 退货中是  SchtKenZ
'CEVA 拣货中是  PICKKenZ
'-----------------------------------------------------------------
Public Class Encryption64
    Private Shared appKeyStr As String = "PICKKenZ"
    Private Shared key() As Byte = {}
    Private Shared IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    '-----------------------------------------------------------------------------
    ''' <summary>
    ''' 公开的方法--加密
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Encrypt(ByVal stringToDecrypt As String)
        Return Encrypt(stringToDecrypt, appKeyStr)
    End Function
    ''' <summary>
    ''' 公开的方法--解密
    ''' </summary>
    ''' <param name="stringToDecrypt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Decrypt(ByVal stringToDecrypt As String)
        Return Decrypt(stringToDecrypt, appKeyStr)
    End Function
    ''' <summary>
    ''' 解密函数,技术标准:DESCryptoServiceProvider:
    ''' 定义访问数据加密标准 (DES) 算法的加密服务提供程序 (CSP) 版本的包装对象
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
            Dim regStr As String = Convert.ToBase64String(ms.ToArray())
            Return regStr

            ''注意：这里跟PC的不一样
            'Dim tmp As String = regStr.Substring(0, 10).ToUpper()
            '' 14MYQ-VBMAE   //14MYQVBMAE  //& "-" // & tmp.Substring(5, 5)
            'Return tmp.Substring(0, 10).ToUpper()

        Catch e As Exception
            Return e.Message
        End Try
    End Function
    ''' <summary>
    ''' 加密函数
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