Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        ' setup client-side input processing
        ExampleCaptcha.UserInputID = CaptchaCodeTextBox.ClientID

        If IsPostBack Then
            ' clear previous user input
            CaptchaCodeTextBox.Text = Nothing

            If Page.IsValid Then
                ValidationPassedLabel.Visible = True
            Else
                ValidationPassedLabel.Visible = False
            End If
        End If

    End Sub

End Class