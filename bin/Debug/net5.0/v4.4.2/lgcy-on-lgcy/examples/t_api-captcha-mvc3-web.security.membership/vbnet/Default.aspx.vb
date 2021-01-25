Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not HttpRuntime.UsingIntegratedPipeline) Then
            HttpContext.Current.RewritePath(Request.ApplicationPath, False)
            Dim httpHandler As IHttpHandler = New MvcHttpHandler()
            httpHandler.ProcessRequest(HttpContext.Current)
        Else
            HttpContext.Current.Server.TransferRequest(Request.ApplicationPath, True)
        End If
    End Sub

End Class
