<%@ WebHandler Language="VB" Class="ContactHandler" %>

Imports System
Imports System.Web
Imports Newtonsoft.Json
Imports System.IO
Imports BotDetect.Web

Public Class ContactHandler : Implements IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If HttpContext.Current.Request.HttpMethod = "POST" Then
            Dim dataJson As String = New StreamReader(context.Request.InputStream).ReadToEnd()

            Dim formDataObj As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            formDataObj = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(dataJson)

            Dim name As String = formDataObj("name")
            Dim email As String = formDataObj("email")
            Dim subject As String = formDataObj("subject")
            Dim message As String = formDataObj("message")

            Dim captchaId As String = formDataObj("captchaId")
            Dim userEnteredCaptchaCode As String = formDataObj("userEnteredCaptchaCode")

            ' captcha validation
            Dim errors As Dictionary(Of String, String) = New Dictionary(Of String, String)
            If Not IsValidName(name) Then
                errors.Add("name", "Name must be at least 3 chars long!")
            End If

            If Not IsValidEmail(email) Then
                errors.Add("email", "Email is invalid!")
            End If

            If Not IsValidSubject(subject) Then
                errors.Add("subject", "Subject must be at least 10 chars long!")
            End If

            If Not IsValidMessage(message) Then
                errors.Add("message", "Message must be at least 10 chars long!")
            End If

            ' validate the user entered captcha code
            If Not IsCaptchaCorrect(userEnteredCaptchaCode, captchaId) Then
                errors.Add("userEnteredCaptchaCode", "CAPTCHA validation failed!")
                ' TODO: consider logging the attempt                
            End If

            Dim isErrorsEmpty As Boolean = If(errors.Count > 0, False, True)

            If isErrorsEmpty Then
                ' TODO: all validations succeeded; execute the protected action
                ' (send email, write to database, etc...)
            End If

            ' create an object that stores the validation result
            Dim validationResult As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
            validationResult.Add("success", isErrorsEmpty)
            validationResult.Add("errors", errors)

            ' return the json string with the validation result to the frontend
            context.Response.ContentType = "application/json; charset=utf-8"
            context.Response.Write(JsonConvert.SerializeObject(validationResult))
        Else
            context.Response.ContentType = "text/plain"
            context.Response.Write("Only HTTP POST requests are allowed.")
        End If
    End Sub

    ' the captcha validation function
    Private Function IsCaptchaCorrect(ByVal userEnteredCaptchaCode As String, ByVal captchaId As String) As Boolean
        ' create a captcha instance to be used for the captcha validation    
        Dim captcha As SimpleCaptcha = New SimpleCaptcha()
        ' execute the captcha validation        
        Return captcha.Validate(userEnteredCaptchaCode, captchaId)
    End Function

    Private Function IsValidName(ByVal name As String) As Boolean
        If name Is Nothing Then
            Return False
        End If

        Return (name.Length >= 3)
    End Function

    Private Function IsValidEmail(ByVal email As String) As Boolean
        If email Is Nothing Then
            Return False
        End If

        Dim regex As Regex = New Regex("^[\w-_\.+]*[\w-_\.]\@([\w]+\.)+[\w]+[\w]$")
        Dim match As Match = regex.Match(email)
        Return match.Success
    End Function

    Private Function IsValidSubject(ByVal subject As String) As Boolean
        If subject Is Nothing Then
            Return False
        End If

        Return (subject.Length > 9) AndAlso (subject.Length < 255)
    End Function

    Private Function IsValidMessage(ByVal message As String) As Boolean
        If message Is Nothing Then
            Return False
        End If

        Return (message.Length > 9) AndAlso (message.Length < 255)
    End Function

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class