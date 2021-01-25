﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Mvc40CaptchaExampleAspxCSharp.Models.RegisterModel>" %>

<%-- namespaces needed to access BotDetect members and the CaptchaHelper class --%>
<%@ Import Namespace="BotDetect.Web.Mvc" %>
<%@ Import Namespace="Mvc40CaptchaExampleAspxCSharp.App_Code" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<%-- include BotDetect layout stylesheet in page <head> --%>
<asp:Content ID="BotDetectStylesheets" ContentPlaceHolderID="HeadIncludes" runat="server">
    <%: Styles.Render(BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl) %>
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Register.</h1>
        <h2>Create a new account.</h2>
    </hgroup>

    <% using (Html.BeginForm("Register", "Account", FormMethod.Post, new { @class = "column", role = "form" }))
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary() %>

    <fieldset class="register">
        <legend>Registration Form</legend>
        <ol>
            <li>
                <%: Html.LabelFor(m => m.UserName) %>
                <%: Html.TextBoxFor(m => m.UserName) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.Password) %>
                <%: Html.PasswordFor(m => m.Password) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.ConfirmPassword) %>
                <%: Html.PasswordFor(m => m.ConfirmPassword) %>
            </li>
            <% // showing Captcha on the form:
           // add Captcha validation controls to the protected action  
           // View, but only if the Captcha hasn't already been solved
           MvcCaptcha registrationCaptcha = CaptchaHelper.GetRegistrationCaptcha();
           if (!registrationCaptcha.IsSolved)
           { %>
            <li>
                <%: Html.Label("CaptchaCode", "Retype the code from the picture") %>
                <%: Html.Captcha(registrationCaptcha) %>
                <%: Html.TextBox("CaptchaCode", "", new { @class = "captchaVal" }) %>
            </li>
            <% } %>
        </ol>
        <input type="submit" value="Register" />
    </fieldset>
    <% } %>
    <div class="column"></div>
    <div id="notes" class="column">
        <div class="note">
            <h3>CAPTCHA Code Example Description</h3>
            <p>This example project shows how to use the BotDetect <code>MvcCaptcha</code> control in ASP.NET MVC 4.0 web applications.</p>
            <p>Starting with the default ASP.NET MVC 4.0 Internet Application project template, the example includes all code required to add CAPTCHA validation to the <code>Account</code> controller <code>Register</code> action.</p>
            <p>The example also shows how to complement server-side CAPTCHA validation with client-side Ajax CAPTCHA validation using ASP.NET MVC 4.0 unobtrusive validation applied to all form fields (<code>Scripts\captcha.validate.js</code>).</p>
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
    <div id="systeminfo">
        <p>Visual Studio 2012 / .NET 4.5 / ASPX / C# example project.</p>
        <p><%= MvcCaptcha.ControlInfo%></p>
    </div>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
    <%-- client-side Captcha validation script inlcude --%>
    <%: Scripts.Render("~/Scripts/captcha.validate.js") %>
</asp:Content>
