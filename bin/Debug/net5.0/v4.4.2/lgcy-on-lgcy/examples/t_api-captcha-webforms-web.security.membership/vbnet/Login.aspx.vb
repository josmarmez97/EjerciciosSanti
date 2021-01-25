Imports BotDetect.Web.UI

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub ExampleLogin_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs)
        Dim CaptchaCodeTextBox As TextBox = TryCast(ExampleLogin.FindControl("CaptchaCodeTextBox"), TextBox)
        Dim LoginCaptcha As WebFormsCaptcha = TryCast(ExampleLogin.FindControl("LoginCaptcha"), WebFormsCaptcha)

        'first, validate the Captcha to check we're not dealing with a bot
        If (Not IsHuman) Then
            Dim code As String, isHuman As Boolean
            code = CaptchaCodeTextBox.Text.Trim()
            isHuman = LoginCaptcha.Validate(code)
            CaptchaCodeTextBox.Text = "" ' clear previous user input

            If Not isHuman Then
                ExampleLogin.FailureText = "Retype the characters from the image carefully."
                e.Authenticated = False
                Return
            End If

            HideCaptcha() ' hide the CAPTCHA once it's solved

            'only when we're sure the visitor is human, we try to authenticate them
            If Not Membership.ValidateUser(ExampleLogin.UserName, ExampleLogin.Password) Then
                ExampleLogin.FailureText = "Invalid login info."
                e.Authenticated = False

                FailedAuthAttempts = FailedAuthAttempts + 1
                If (ResetFailedAuthAttempts < FailedAuthAttempts) Then
                    ' show the CAPTCHA again if the user enters invalid authentication
                    ' info three times in a row
                    ShowCaptcha()
                End If

                Return
            End If
        End If

        e.Authenticated = True
    End Sub

    Protected Sub HideCaptcha()
        Dim LoginCaptcha As WebFormsCaptcha = TryCast(ExampleLogin.FindControl("LoginCaptcha"), WebFormsCaptcha)
        Dim CaptchaRow As HtmlControl = TryCast(ExampleLogin.FindControl("CaptchaRow"), HtmlControl)

        CaptchaRow.Visible = False
        LoginCaptcha.Visible = False
    End Sub

    Protected Sub ShowCaptcha()
        Dim LoginCaptcha As WebFormsCaptcha = TryCast(ExampleLogin.FindControl("LoginCaptcha"), WebFormsCaptcha)
        Dim CaptchaRow As HtmlControl = TryCast(ExampleLogin.FindControl("CaptchaRow"), HtmlControl)

        IsHuman = False
        FailedAuthAttempts = 0
        CaptchaRow.Visible = True
        LoginCaptcha.Visible = True
    End Sub

    ' flag showing the user successfully passed the CAPTCHA test
    Protected Property IsHuman() As Boolean
        Get
            Dim result As Boolean = False
            Try
                If (Nothing <> Session("IsHuman")) Then
                    result = CBool(Session("IsHuman"))
                End If
            Catch e As InvalidCastException
            End Try

            Return result
        End Get

        Set(ByVal value As Boolean)
            Session("IsHuman") = value
        End Set
    End Property

    Protected Const ResetFailedAuthAttempts As Integer = 3

    ' failed authentication attempt counter
    Protected Property FailedAuthAttempts() As Integer
        Get
            Dim count As Integer = 0
            Try
                If (Nothing <> Session("FailedAuthAttempts")) Then
                    count = CInt(Session("FailedAuthAttempts"))
                End If
            Catch e As InvalidCastException
            End Try

            Return count
        End Get

        Set(ByVal value As Integer)
            Session("FailedAuthAttempts") = value
        End Set
    End Property

End Class
