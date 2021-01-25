Imports BotDetect.Web.UI

Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub RegisterUser_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs)

        If e.CurrentStepIndex = 0 Then 'CreateUserStep

            ' get control references
            Dim RegisterCaptcha As WebFormsCaptcha = TryCast(RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("RegisterCaptcha"), WebFormsCaptcha)
            Dim CaptchaCodeTextBox As TextBox = TryCast(RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CaptchaCodeTextBox"), TextBox)
            Dim CaptchaIncorrect As Literal = TryCast(RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("InvalidCaptchaInput"), Literal)

            ' validate the Captcha to check we're not dealing with a bot
            Dim code As String, isHuman As Boolean
            code = CaptchaCodeTextBox.Text.Trim()
            isHuman = RegisterCaptcha.Validate(code)
            CaptchaCodeTextBox.Text = "" ' clear previous user input

            If Not isHuman Then
                CaptchaIncorrect.Visible = True
                e.Cancel = True
            Else
                CaptchaIncorrect.Visible = False
            End If
        End If

    End Sub
End Class
