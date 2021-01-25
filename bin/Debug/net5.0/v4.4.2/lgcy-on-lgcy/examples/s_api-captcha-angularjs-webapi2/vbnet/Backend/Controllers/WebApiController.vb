Imports System.Web.Http
Imports BotDetect.Web

Public Class WebApiController
    Inherits ApiController

    ' POST api/webapi/basic
    Public Function Basic(<FromBody> data As CaptchaBasicModel) As IHttpActionResult
        Dim userEnteredCaptchaCode As String = data.UserEnteredCaptchaCode
        Dim captchaId As String = data.CaptchaId

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
        Return Ok(validationResult)
    End Function

    ' POST api/webapi/contact
    Public Function Contact(<FromBody> data As CaptchaContactModel) As IHttpActionResult
        Dim name As String = data.Name
        Dim email As String = data.Email
        Dim subject As String = data.Subject
        Dim message As String = data.Message

        Dim userEnteredCaptchaCode As String = data.UserEnteredCaptchaCode
        Dim captchaId As String = data.CaptchaId

        ' validate the form data
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
        Return Ok(validationResult)
    End Function

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
End Class
