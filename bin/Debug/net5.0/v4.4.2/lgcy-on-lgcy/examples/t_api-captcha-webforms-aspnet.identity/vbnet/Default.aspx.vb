Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Since we want to show the Captcha as soon as the example loads,
        ' we redirect all non-authenticated visits to the Register form.
        Response.Redirect("~/Account/Register")
    End Sub
End Class