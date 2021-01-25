Imports Microsoft.AspNet.Identity
Imports System
Imports System.Web.UI

Partial Public Class Register
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' setup client-side input processing
        RegisterCaptcha.UserInputID = CaptchaCode.ClientID
    End Sub

    Protected Sub CreateUser_Click(sender As Object, e As EventArgs)
        If Me.IsValid Then
            Dim userName As String = UserNameCtrl.Text
            Dim manager = New UserManager()
            Dim user = New ApplicationUser() With {.UserName = userName}
            Dim result = manager.Create(user, Password.Text)
            If result.Succeeded Then
                IdentityHelper.SignIn(manager, user, isPersistent:=False)
                IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
            Else
                ErrorMessage.Text = result.Errors.FirstOrDefault()
            End If
            'Response.Redirect("~/About")
        End If
        
    End Sub

    Protected Sub CaptchaValidator_ServerValidate(source As Object, args As ServerValidateEventArgs)
        ' validate the Captcha to check we're not dealing with a bot
        args.IsValid = RegisterCaptcha.Validate(args.Value.Trim())

        CaptchaCode.Text = Nothing ' clear previous user input
    End Sub
End Class

