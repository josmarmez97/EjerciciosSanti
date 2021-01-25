Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ' initial page setup
        If Not IsPostBack Then
            ' set control text
            ValidateCaptchaButton.Text = "Validate"
            CaptchaIncorrectLabel.Text = "Incorrect!"

            CaptchaIncorrectLabel.Visible = False
        End If

        ' setup client-side input processing
        ExampleCaptcha.UserInputID = CaptchaCodeTextBox.ClientID
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = False
        Panel2.Visible = True

        CaptchaIncorrectLabel.Visible = False

        ' ensure the BotDetect client scripts are added to the page
        IncludeBotDetectScripts()
    End Sub

    Protected Sub IncludeBotDetectScripts()
        ScriptManager.RegisterClientScriptInclude(
            Me.Page,
            Me.GetType(),
            "BotDetect_Include",
            ExampleCaptcha.WebCaptcha.UrlGenerator.ScriptIncludeUrl(ExampleCaptcha.CaptchaId, ExampleCaptcha.WebCaptcha.CurrentInstanceId))
    End Sub


    Protected Sub ValidateCaptchaButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValidateCaptchaButton.Click
        ' validate the Captcha to check we're not dealing with a bot
        Dim code As String, isHuman As Boolean
        code = CaptchaCodeTextBox.Text.Trim()
        isHuman = ExampleCaptcha.Validate(code)
        CaptchaCodeTextBox.Text = "" ' clear previous user input

        If isHuman Then
            CaptchaIncorrectLabel.Visible = False

            Panel1.Visible = True
            Panel2.Visible = False
        Else
            CaptchaIncorrectLabel.Visible = True
        End If
    End Sub

End Class