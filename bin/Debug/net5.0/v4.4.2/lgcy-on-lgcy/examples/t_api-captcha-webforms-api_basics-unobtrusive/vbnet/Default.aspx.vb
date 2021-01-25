Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ' initial page setup
        If Not IsPostBack Then
            ' set control text
            ValidateCaptchaButton.Text = "Validate"
            CaptchaCorrectLabel.Text = "Successful form submission (server)"
            CaptchaIncorrectLabel.Text = "Failed form submission (server)"

            ' these messages are shown only after validation
            CaptchaCorrectLabel.Visible = False
            CaptchaIncorrectLabel.Visible = False
        End If

        ' setup client-side input processing
        ExampleCaptcha.UserInputID = CaptchaCodeTextBox.ClientID

        If IsPostBack Then
            ' validate the Captcha to check we're not dealing with a bot
            Dim code As String, isHuman As Boolean
            code = CaptchaCodeTextBox.Text.Trim()
            isHuman = ExampleCaptcha.Validate(code)
            CaptchaCodeTextBox.Text = "" ' clear previous user input

            If isHuman Then
                CaptchaCorrectLabel.Visible = True
                CaptchaIncorrectLabel.Visible = False
            Else
                CaptchaCorrectLabel.Visible = False
                CaptchaIncorrectLabel.Visible = True
            End If
        End If
    End Sub

End Class