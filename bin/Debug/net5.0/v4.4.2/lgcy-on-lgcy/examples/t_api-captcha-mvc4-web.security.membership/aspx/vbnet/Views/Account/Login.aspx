﻿<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Mvc40CaptchaExampleAspxVBNet.LoginModel)" %>

<%-- namespaces needed to access BotDetect members and the CaptchaHelper class --%>
<%@ Import Namespace="BotDetect.Web.Mvc" %>
<%@ Import Namespace="Mvc40CaptchaExampleAspxVBNet" %>
<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log in
</asp:Content>
<asp:Content ID="BotDetectStylesheets" ContentPlaceHolderID="HeadIncludes" runat="server">
    <%: Styles.Render(BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl) %>
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Log in.</h1>
    </hgroup>

    <section id="loginForm">
        <h2>Use a local account to log in.</h2>
        <% Using Html.BeginForm("Login", "Account", FormMethod.Post, New With {.ReturnUrl = ViewData("ReturnUrl"), .class = "column", .role = "form"})%>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Log in Form</legend>
            <ol>
                <li>
                    <%: Html.LabelFor(Function(m) m.UserName) %>
                    <%: Html.TextBoxFor(Function(m) m.UserName) %>
                    <%: Html.ValidationMessageFor(Function(m) m.UserName) %>
                </li>
                <li>
                    <%: Html.LabelFor(Function(m) m.Password) %>
                    <%: Html.PasswordFor(Function(m) m.Password) %>
                    <%: Html.ValidationMessageFor(Function(m) m.Password) %>
                </li>
                <%  ' showing Captcha on the form:
                    ' add Captcha validation controls to the protected action View, 
                    ' but only if the Captcha hasn't already been solved
                    Dim loginCaptcha As MvcCaptcha
                    loginCaptcha = CaptchaHelper.GetLoginCaptcha()
                    If (Not loginCaptcha.IsSolved) Then%>
                <li>
                    <%: Html.Label("CaptchaCode", "Retype the code from the picture") %>
                    <%: Html.Captcha(loginCaptcha) %>
                    <%: Html.TextBox("CaptchaCode", "", New With { .class = "captchaVal" }) %>
                </li>
                <% End If%>
                <li>
                    <%: Html.CheckBoxFor(Function(m) m.RememberMe) %>
                    <%: Html.LabelFor(Function(m) m.RememberMe, New With { .Class = "checkbox" }) %>
                </li>
            </ol>
            <input type="submit" value="Log in" />
        </fieldset>
        <p>
            <%: Html.ActionLink("Register", "Register") %> if you don't have an account.
        </p>
        <% End Using%>
        <div class="column">
            <div id="notes" class="column">
                <div class="note">
                    <h3>CAPTCHA Code Example Description</h3>
                    <p>This example project shows how to use the BotDetect <code>MvcCaptcha</code> control in ASP.NET MVC 4.0 web applications.</p>
                    <p>Starting with the default ASP.NET MVC 4.0 Internet Application project template, the example includes all code required to add CAPTCHA validation to the <code>Account</code> controller <code>Login</code> action.</p>
                    <p>The example also shows how to complement server-side CAPTCHA validation with client-side Ajax CAPTCHA validation using ASP.NET MVC 4.0 unobtrusive validation applied to all form fields (<code>Scripts\captcha.validate.js</code>).</p>
                </div>
                <% If (MvcCaptcha.IsFree) Then%>
                <div class="note warning">
                    <h3>Free Version Limitations</h3>
                    <ul>
                        <li>The free version of BotDetect includes a randomized <code>BotDetect™</code> trademark in the background of 50% of all Captcha images generated.</li>
                        <li>It also has limited sound functionality, replacing the CAPTCHA sound with "SOUND DEMO" for randomly selected 50% of all CAPTCHA codes.</li>
                        <li>Lastly, the bottom 10 px of the CAPTCHA image are reserved for a link to the BotDetect website.</li>
                    </ul>
                    <p>All of these limitations are removed if you <a href="http://captcha.com/shop.html?utm_source=installation&amp;utm_medium=aspnet&amp;utm_campaign=4.4.2" rel="nofollow" title="BotDetect CAPTCHA online store, pricing information, payment options, licensing &amp; upgrading">upgrade</a> your BotDetect license.</p>
                </div>
                <% End If%>
            </div>
        </div>
        <div id="systeminfo">
            <p>Visual Studio 2012 / .NET 4.5 / ASPX / VB.NET example project.</p>
            <p><%= MvcCaptcha.ControlInfo %></p>
        </div>
    </section>

    <section class="social" id="socialLoginForm">
        <h2>Use another service to log in.</h2>
        <%: Html.Action("ExternalLoginsList", New With { .ReturnUrl = ViewData("ReturnUrl") }) %>
    </section>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
    <%-- client-side Captcha validation script inlcude --%>
    <%: Scripts.Render("~/Scripts/captcha.validate.js") %>
</asp:Content>
