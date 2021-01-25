Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As _
    System.EventArgs) Handles Me.PreRender
        ' initial page setup
        If (Not IsPostBack) Then

            ' set control text
            ValidateCaptchaButton.Text = "Validate"
            CaptchaCorrectLabel.Text = "Correct!"
            CaptchaIncorrectLabel.Text = "Incorrect!"

            ' these messages are shown only after validation
            CaptchaCorrectLabel.Visible = False
            CaptchaIncorrectLabel.Visible = False

            CauseErrorButton.Text = "Simulate error"
            ErrorLabel.Text = "An error has been generated. Please check the 'error.txt' file."

            DebugLabel.Text = "A validation attempt has been logged. Please check the 'debug.txt' file."
            DebugLabel.Visible = False
        End If

        If (Not (Session("error") Is Nothing)) Then

            ErrorLabel.Visible = True
            CaptchaCorrectLabel.Visible = False
            CaptchaIncorrectLabel.Visible = False
            Session("error") = Nothing
            DebugLabel.Visible = False

        Else

            ErrorLabel.Visible = False
        End If

        If (IsPostBack) Then

            ' validate the Captcha to check we're not dealing with a bot
            Dim isHuman As Boolean = ExampleCaptcha.Validate()
            If (isHuman) Then

                CaptchaCorrectLabel.Visible = True
                CaptchaIncorrectLabel.Visible = False

            Else

                CaptchaCorrectLabel.Visible = False
                CaptchaIncorrectLabel.Visible = True
            End If

            DebugLabel.Visible = True
        End If
    End Sub

    Protected Sub CauseErrorButton_Click(ByVal sender As Object, ByVal e As _
    System.EventArgs) Handles CauseErrorButton.Click

        Session("error") = True
        Throw New BotDetect.WebCaptchaException("Simulated exception")
    End Sub

End Class