Imports BotDetect
Imports BotDetect.Web

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        AddHandler Captcha.InitializedWebCaptcha, AddressOf DynamicCaptcha_InitializedWebCaptcha

    End Sub

    Private Sub DynamicCaptcha_InitializedWebCaptcha(ByVal sender As Object, ByVal e As InitializedWebCaptchaEventArgs) Handles DynamicCaptcha.InitializedWebCaptcha

        Dim captchaInstance As Captcha
        captchaInstance = DirectCast(sender, Captcha)

        ' Captcha.InitializedWebCaptcha event handlers are global and apply to all Captcha instances 
        ' in the application if some settings need to be apply only to a particular Captcha 
        ' instance, this is how settings can be conditionally applied based on CaptchaId
        If (e.CaptchaId = DynamicCaptcha.CaptchaId) Then

            captchaInstance.SoundEnabled = False
        End If

        ' re-calculated on each image request
        Dim imageStyles As ImageStyle() = {ImageStyle.Graffiti, ImageStyle.SunAndWarmAir, ImageStyle.Overlap}
        captchaInstance.ImageStyle = CaptchaRandomization.GetRandomImageStyle(imageStyles)

        ' dynamic Captcha settings depending on failed validation attempts: increase Captcha 
        ' difficulty according to number of previously failed validations
        Dim count As Integer = ValidationCounter.GetFailedValidationsCount()
        If (count < 3) Then

            captchaInstance.CodeLength = CaptchaRandomization.GetRandomCodeLength(3, 4)
            captchaInstance.CodeStyle = CodeStyle.Numeric
            captchaInstance.CodeTimeout = 600 ' 10 minutes

        ElseIf (count < 10) Then

            captchaInstance.CodeLength = CaptchaRandomization.GetRandomCodeLength(4, 6)
            captchaInstance.CodeStyle = CodeStyle.Alpha
            captchaInstance.CodeTimeout = 180 ' 3 minutes

        Else

            captchaInstance.CodeLength = CaptchaRandomization.GetRandomCodeLength(6, 9)
            captchaInstance.CodeStyle = CodeStyle.Alphanumeric
            captchaInstance.CodeTimeout = 60 ' 1 minute
        End If

        ' set Captcha locale to Chinese for requests from a certain IP range
        Dim ipRange As String = "223.254."
        Dim requestFromRangeDetected As Boolean = False

        ' have to use HttpContext.Current.Request and not Page.Request because Page
        ' properties won't be set for Captcha image and sound requests serverd directly
        ' by the BotDetect Captcha HttpHandler
        If (Not (HttpContext.Current.Request Is Nothing) And
                Not String.IsNullOrEmpty(HttpContext.Current.Request.UserHostAddress) And
                HttpContext.Current.Request.UserHostAddress.StartsWith(ipRange)) Then

            requestFromRangeDetected = True
        End If

        If (requestFromRangeDetected) Then

            captchaInstance.CodeStyle = CodeStyle.Alpha
            captchaInstance.Locale = "cmn"
        End If
    End Sub

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
        End If

        If (IsPostBack) Then

            ' validate the Captcha to check we're not dealing with a bot
            Dim isHuman As Boolean = DynamicCaptcha.Validate()
            If (isHuman) Then

                CaptchaCorrectLabel.Visible = True
                CaptchaIncorrectLabel.Visible = False
                ValidationCounter.ResetFailedValidationsCount()

            Else

                CaptchaCorrectLabel.Visible = False
                CaptchaIncorrectLabel.Visible = True
                ValidationCounter.IncrementFailedValidationsCount()
            End If
        End If

        ' update status display
        Dim count As Integer = ValidationCounter.GetFailedValidationsCount()
        StatusLiteral.Text = String.Format("<p>Failed Captcha validations: {0}</p>", count)
        If (count < 3) Then

            StatusLiteral.Text += "<p>Dynamic Captcha difficulty: Easy</p>"

        ElseIf (count < 10) Then

            StatusLiteral.Text += "<p>Dynamic Captcha difficulty: Moderate</p>"

        Else

            StatusLiteral.Text += "<p>Dynamic Captcha difficulty: Hard</p>"
        End If
    End Sub

End Class