Imports BotDetect

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As _
    System.EventArgs) Handles Me.PreRender
        'Captcha2 code-behind setup

        Captcha2.CodeLength = 4
        Captcha2.CodeStyle = CodeStyle.Alpha
        Captcha2.DisallowedCodeSubstringsList = New List(Of String)(New String() {"AAA", "BBB", "CCC"})
        Captcha2.CodeTimeout = 900 ' 15 minutes

        ' only re-calcualated on form load
        Dim imageStyles As ImageStyle() =
        {
            ImageStyle.BlackOverlap,
            ImageStyle.Graffiti,
            ImageStyle.Overlap
        }
        Captcha2.ImageStyle = CaptchaRandomization.GetRandomImageStyle(imageStyles)
        Captcha2.ImageSize = New System.Drawing.Size(120, 35)
        Captcha2.ImageFormat = ImageFormat.Png
        Captcha2.CustomDarkColor = System.Drawing.Color.DarkGreen
        Captcha2.CustomLightColor = System.Drawing.ColorTranslator.FromHtml("#eeeeff")

        Captcha2.SoundEnabled = True
        Captcha2.SoundStyle = SoundStyle.Dispatch
        Captcha2.SoundFormat = SoundFormat.WavPcm8bit8kHzMono
        Captcha2.SoundRegenerationMode = SoundRegenerationMode.None

        Captcha2.Locale = "fr-CA"
        Captcha2.ImageTooltip = "Custom Canadian French Captcha image tooltip"
        Captcha2.SoundTooltip = "Custom Canadian French Captcha sound icon tooltip"
        Captcha2.ReloadTooltip = "Custom Canadian French Captcha reload icon tooltip"
        Captcha2.HelpLinkUrl = "custom-canadian-french-captcha-help-page.html"
        Captcha2.HelpLinkText = "Custom Canadian French Captcha help link text"

        Captcha2.ReloadEnabled = True
        Captcha2.UseSmallIcons = True
        Captcha2.UseHorizontalIcons = True
        Captcha2.SoundIconUrl = ""
        Captcha2.ReloadIconUrl = ""
        Captcha2.IconsDivWidth = 50
        Captcha2.HelpLinkEnabled = True
        Captcha2.HelpLinkMode = HelpLinkMode.Image
        Captcha2.TabIndex = 15
        Captcha2.AdditionalCssClasses = ""
        Captcha2.AdditionalInlineCss = ""

        Captcha2.AddScriptInclude = True
        Captcha2.AutoUppercaseInput = True
        Captcha2.AutoFocusInput = True
        Captcha2.AutoClearInput = True
        Captcha2.AutoReloadExpiredCaptchas = True
        Captcha2.AutoReloadTimeout = 3600 ' 1 hour
        Captcha2.SoundStartDelay = 1000 ' 1 second
        Captcha2.RemoteScriptEnabled = True


        ' Form validation
        If (IsPostBack) Then

            Dim isHuman1 As Boolean = Captcha1.Validate()
            If (isHuman1) Then

                Captcha1CorrectLabel.Visible = True
                Captcha1IncorrectLabel.Visible = False

            Else

                Captcha1CorrectLabel.Visible = False
                Captcha1IncorrectLabel.Visible = True
            End If

            Dim isHuman2 As Boolean = Captcha2.Validate()
            If (isHuman2) Then

                Captcha2CorrectLabel.Visible = True
                Captcha2IncorrectLabel.Visible = False

            Else

                Captcha2CorrectLabel.Visible = False
                Captcha2IncorrectLabel.Visible = True

            End If
        End If
    End Sub

End Class