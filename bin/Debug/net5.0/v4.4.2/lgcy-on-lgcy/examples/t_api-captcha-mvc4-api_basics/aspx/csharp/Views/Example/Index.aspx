<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%-- namespaces needed to access BotDetect members --%>
<%@ Import Namespace="BotDetect.Web.Mvc" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>BotDetect CAPTCHA Basic ASP.NET MVC 4.0 Example</title>
    <link href="<%: Url.Content("~/Style/Sheet.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: Url.Content("~/" + BotDetect.Web.CaptchaUrls.LayoutStyleSheetUrl) %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>BotDetect CAPTCHA Basic ASP.NET MVC 4.0 Example</h1>

    <% using (Html.BeginForm("Index", "Example", FormMethod.Post, new { @class = "column", role = "form" }))
       { %>
    <fieldset>
        <legend>CAPTCHA Protection Shown on an ASP.NET MVC View</legend>
        <div>
            <%: Html.Label("CaptchaCode", "Retype the code from the picture:") %>
            <% MvcCaptcha exampleCaptcha = new MvcCaptcha("ExampleCaptcha");
               exampleCaptcha.UserInputID = "CaptchaCode"; %>
            <%: Html.Captcha(exampleCaptcha) %>
        </div>
        <div class="actions">
            <%: Html.TextBox("CaptchaCode") %>
            <input type="submit" value="Validate" />
            <%: Html.ValidationMessage("CaptchaCode") %>
        </div>
    </fieldset>
    <% } %>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows the most basic source code required to protect an ASP.NET MVC form with BotDetect CAPTCHA and validate the user input.</p>
                <p>ASP.NET MVC View code displaying CAPTCHA protection can be found in <code>Views/Example/Index.aspx</code>, and the ASP.NET MVC Controller code checking user input is in <code>Controllers/ExampleController.cs</code>.</p>
            </div>
            <% if (MvcCaptcha.IsFree)
               { %>
            <div class="note warning">
                <h3>Free Version Limitations</h3>
                <ul>
                    <li>The free version of BotDetect includes a randomized <code>BotDetect™</code> trademark in the background of 50% of all Captcha images generated.</li>
                    <li>It also has limited sound functionality, replacing the CAPTCHA sound with "SOUND DEMO" for randomly selected 50% of all CAPTCHA codes.</li>
                    <li>Lastly, the bottom 10 px of the CAPTCHA image are reserved for a link to the BotDetect website.</li>
                </ul>
                <p>All of these limitations are removed if you <a href="http://captcha.com/shop.html?utm_source=installation&amp;utm_medium=aspnet&amp;utm_campaign=4.4.2" rel="nofollow" title="BotDetect CAPTCHA online store, pricing information, payment options, licensing &amp; upgrading">upgrade</a> your BotDetect license.</p>
            </div>
            <% } %>
        </div>
    </div>
    <div id="systeminfo">
        <p>Visual Studio 2012 / .NET 4.5 / ASPX / C# example project.</p>
        <p><%: MvcCaptcha.ControlInfo %></p>
    </div>
</body>
</html>
