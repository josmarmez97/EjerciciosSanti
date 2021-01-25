<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Mvc20CaptchaExampleCSharp.Models.LogOnModel>" %>

<%@ Import Namespace="BotDetect.Web.Mvc" %>
<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>
<asp:Content ID="BotDetectStylesheets" ContentPlaceHolderID="includes" runat="server">
    <link href="<%= BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl %>" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Log On</h2>
    <p>
        Please enter your username and password.
        <%: Html.ActionLink("Register", "Register") %>
        if you don't have an account.
    </p>
    <% using (Html.BeginForm("Logon", "Account", FormMethod.Post, new { @class = "column", role = "form" }))
       { %>
    <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>Account Information</legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.UserName) %>
                <%: Html.ValidationMessageFor(m => m.UserName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.Password) %>
                <%: Html.ValidationMessageFor(m => m.Password) %>
            </div>
            <% // add Captcha validation controls to the protected action View
           MvcCaptcha loginCaptcha = CaptchaHelper.GetLoginCaptcha();
           if (!loginCaptcha.IsSolved)
           { %>
            <div class="editor-label">
                <%: Html.Captcha(loginCaptcha)%>
                <%: Html.LabelFor(m => m.CaptchaCode) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.CaptchaCode)%>
                <%: Html.ValidationMessageFor(m => m.CaptchaCode)%>
            </div>
            <% } %>
            <div class="editor-label">
                <%: Html.CheckBoxFor(m => m.RememberMe) %>
                <%: Html.LabelFor(m => m.RememberMe) %>
            </div>
            <p>
                <input type="submit" value="Log On" />
            </p>
        </fieldset>
    </div>
    <% } %>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>
                    CAPTCHA Code Example Description</h3>
                <p>
                    This example project shows how to use the BotDetect <code>MvcCaptcha</code> control
                    in ASP.NET MVC 2.0 web applications.</p>
                <p>
                    Starting with the default ASP.NET MVC 2.0 example project, the example includes
                    all code required to add CAPTCHA validation to the <code>Account</code> controller
                    <code>Register</code> action.</p>
                <p>
                    The example remembers when the CAPTCHA is successfully solved within a single registration,
                    and doesn't display it again if there are errors with other form values (the username,
                    for example).</p>
                <p>
                    You can get a new CAPTCHA using the <code>LogOn</code> action link in the top
                    right corner of the page, and see the explanation in the <code>Account</code> controller
                    code.</p>
            </div>
            <% if (MvcCaptcha.IsFree)
               { %>
            <div class="note warning">
                <h3>
                    Free Version Limitations</h3>
                <ul>
                    <li>The free version of BotDetect includes a randomized <code>BotDetect™</code> trademark
                        in the background of 50% of all Captcha images generated.</li>
                    <li>It also has limited sound functionality, replacing the CAPTCHA sound with "SOUND
                        DEMO" for randomly selected 50% of all CAPTCHA codes.</li>
                    <li>Lastly, the bottom 10 px of the CAPTCHA image are reserved for a link to the BotDetect
                        website.</li>
                </ul>
                <p>
                    All of these limitations are removed if you <a href="http://captcha.com/shop.html?utm_source=installation&amp;utm_medium=aspnet&amp;utm_campaign=4.4.2"
                        rel="nofollow" title="BotDetect CAPTCHA online store, pricing information, payment options, licensing &amp; upgrading">
                        upgrade</a> your BotDetect license.</p>
            </div>
            <% } %>
        </div>
    </div>
    <div id="systeminfo">
        <p>
            Visual Studio 2010 / .NET 4.0 / C# example project.</p>
        <p>
            <%= MvcCaptcha.ControlInfo%></p>
    </div>
</asp:Content>
