Imports BotDetect.Web.Mvc
Imports System.Web.Mvc

Namespace Mvc50BasicCaptchaExampleVBNet
    Public Class ExampleController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Example

        Function Index() As ActionResult
            Return View()
        End Function


        '
        ' POST: /Example/

        <HttpPost()> _
        <CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Incorrect!")> _
        Public Function Index(ByVal model As ExampleModel) As ActionResult
            MvcCaptcha.ResetCaptcha("ExampleCaptcha")
            Return View(model)
        End Function

    End Class
End Namespace