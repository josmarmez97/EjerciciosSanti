Imports BotDetect.Web.Mvc
Public Class CaptchaHelper

    Public Shared Function GetExampleCaptcha(captchaId As String) As MvcCaptcha

        ' create the control instance
        Dim exampleCaptcha As MvcCaptcha = New MvcCaptcha(captchaId)

        ' set up client-side processing of the Captcha code input textbox
        exampleCaptcha.UserInputID = "CaptchaCode"

        ' Captcha settings
        exampleCaptcha.ImageSize = New System.Drawing.Size(255, 50)

        Return exampleCaptcha

    End Function
End Class
