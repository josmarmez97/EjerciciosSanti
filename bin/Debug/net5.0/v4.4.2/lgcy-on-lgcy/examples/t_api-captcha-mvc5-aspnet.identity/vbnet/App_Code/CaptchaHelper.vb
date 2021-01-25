Imports BotDetect.Web.Mvc
Public Class CaptchaHelper

    Public Shared Function GetRegistrationCaptcha() As MvcCaptcha

        ' create the control instance
        Dim registrationCaptcha As MvcCaptcha = New MvcCaptcha("RegistrationCaptcha")

        ' set up client-side processing of the Captcha code input textbox
        registrationCaptcha.UserInputID = "CaptchaCode"

        ' Captcha settings
        registrationCaptcha.ImageSize = New System.Drawing.Size(255, 50)

        Return registrationCaptcha

    End Function

    Public Shared Function GetLoginCaptcha() As MvcCaptcha

        ' create the control instance
        Dim registrationCaptcha As MvcCaptcha = New MvcCaptcha("LoginCaptcha")

        ' set up client-side processing of the Captcha code input textbox
        registrationCaptcha.UserInputID = "CaptchaCode"

        ' Captcha settings
        registrationCaptcha.ImageSize = New System.Drawing.Size(255, 50)

        Return registrationCaptcha

    End Function

    Public Shared Function GetChangePasswordCaptcha() As MvcCaptcha

        ' create the control instance
        Dim registrationCaptcha As MvcCaptcha = New MvcCaptcha("ChangePasswordCaptcha")

        ' set up client-side processing of the Captcha code input textbox
        registrationCaptcha.UserInputID = "CaptchaCode"

        ' Captcha settings
        registrationCaptcha.ImageSize = New System.Drawing.Size(255, 50)

        Return registrationCaptcha

    End Function

End Class
