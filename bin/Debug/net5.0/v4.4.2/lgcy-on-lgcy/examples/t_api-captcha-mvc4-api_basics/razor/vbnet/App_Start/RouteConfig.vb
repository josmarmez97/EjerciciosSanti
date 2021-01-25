Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' BotDetect requests must not be routed
        routes.IgnoreRoute("{*botdetect}", New With {.botdetect = "(.*)BotDetectCaptcha\.ashx"})

        routes.MapRoute( _
            name:="Default", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "Example", .action = "Index", .id = UrlParameter.Optional} _
        )
    End Sub
End Class