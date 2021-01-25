Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' BotDetect requests must not be routed
        routes.IgnoreRoute("{*botdetect}", New With {.botdetect = "(.*)BotDetectCaptcha\.ashx"})

        routes.MapRoute( _
            name:="Default", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "Example", .action = "Index", .id = UrlParameter.Optional} _
        )
    End Sub
End Module