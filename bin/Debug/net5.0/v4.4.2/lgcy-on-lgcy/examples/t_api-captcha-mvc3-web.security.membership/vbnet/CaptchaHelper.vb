Imports BotDetect
Imports BotDetect.Web
Imports BotDetect.Web.UI
Imports BotDetect.Web.Mvc

Public Class CaptchaHelper

    Public Shared Function GetRegistrationCaptcha() As MvcCaptcha

        ' all Captcha properties are set in this event handler
        AddHandler WebFormsCaptcha.InitializedWebCaptcha, _
            AddressOf RegistrationCaptcha_InitializedWebCaptcha
        
        ' create the control instance
        Dim registrationCaptcha As BotDetect.Web.Mvc.MvcCaptcha = _
            New BotDetect.Web.Mvc.MvcCaptcha("RegistrationCaptcha")

        registrationCaptcha.UserInputID = "CaptchaCode"

        Return registrationCaptcha

    End Function

    ' event handler used for Captcha control property randomization
    Public Shared Sub RegistrationCaptcha_InitializedWebCaptcha( _
        ByVal sender As Object, _
        ByVal e As BotDetect.InitializedWebCaptchaEventArgs)

        If (e.CaptchaId <> "RegistrationCaptcha") Then
            Return
        End If

        Dim registrationCaptcha As Captcha = TryCast(sender, Captcha)

        ' fixed Captcha settings 
        registrationCaptcha.ImageSize = New System.Drawing.Size(200, 50)
        registrationCaptcha.CodeLength = 4

        ' randomized Captcha settings
        registrationCaptcha.ImageStyle = CaptchaRandomization.GetRandomImageStyle()
        registrationCaptcha.SoundStyle = CaptchaRandomization.GetRandomSoundStyle()
    End Sub

    Public Shared Function GetLoginCaptcha() As MvcCaptcha

        ' all Captcha properties are set in this event handler
        AddHandler WebFormsCaptcha.InitializedWebCaptcha, _
            AddressOf LoginCaptcha_InitializedWebCaptcha

        ' create the control instance
        Dim loginCaptcha As BotDetect.Web.Mvc.MvcCaptcha = _
            New BotDetect.Web.Mvc.MvcCaptcha("LoginCaptcha")

        loginCaptcha.UserInputID = "CaptchaCode"

        Return loginCaptcha

    End Function

    ' event handler used for Captcha control property randomization
    Public Shared Sub LoginCaptcha_InitializedWebCaptcha( _
        ByVal sender As Object, _
        ByVal e As BotDetect.InitializedWebCaptchaEventArgs)

        If (e.CaptchaId <> "LoginCaptcha") Then
            Return
        End If

        Dim loginCaptcha As Captcha = TryCast(sender, Captcha)

        ' fixed Captcha settings 
        loginCaptcha.ImageSize = New System.Drawing.Size(200, 50)
        loginCaptcha.CodeLength = 4

        ' randomized Captcha settings
        loginCaptcha.ImageStyle = CaptchaRandomization.GetRandomImageStyle()
        loginCaptcha.SoundStyle = CaptchaRandomization.GetRandomSoundStyle()
    End Sub

End Class
