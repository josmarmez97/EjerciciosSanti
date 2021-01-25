Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub SignOutButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SignOutButton.Click
        FormsAuthentication.SignOut()
        Response.Redirect("Default.aspx?ref=signout", True)
    End Sub

End Class