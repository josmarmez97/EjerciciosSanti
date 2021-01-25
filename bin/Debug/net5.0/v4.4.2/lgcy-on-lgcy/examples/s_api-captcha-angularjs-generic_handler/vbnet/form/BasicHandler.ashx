<%@ WebHandler Language="VB" Class="BasicHandler" %>

Imports System
Imports System.Web
Imports Newtonsoft.Json
Imports System.IO
Imports BotDetect.Web

Public Class BasicHandler : Implements IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        If HttpContext.Current.Request.HttpMethod = "POST" Then
            Dim dataJson As String = New StreamReader(context.Request.InputStream).ReadToEnd()

            Dim formDataObj As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            formDataObj = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(dataJson)

            Dim userEnteredCaptchaCode As String = formDataObj("userEnteredCaptchaCode")
            Dim captchaId As String = formDataObj("captchaId")

            ' create a captcha instance to be used for the captcha validation
            Dim captcha As SimpleCaptcha = New SimpleCaptcha()
            ' execute the captcha validation
            Dim isHuman As Boolean = captcha.Validate(userEnteredCaptchaCode, captchaId)

            ' create an object that stores the validation result
            Dim validationResult As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean)()

            If isHuman = False Then
                ' captcha validation failed
                validationResult.Add("success", False)
                ' TODO: consider logging the attempt                
            Else
                ' captcha validation succeeded
                validationResult.Add("success", True)
            End If

            ' return the json string with the validation result to the frontend
            context.Response.ContentType = "application/json; charset=utf-8"
            context.Response.Write(JsonConvert.SerializeObject(validationResult))
        Else
            context.Response.ContentType = "text/plain"
            context.Response.Write("Only HTTP POST requests are allowed.")
        End If

    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class