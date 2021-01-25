<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Mvc20CaptchaExampleCSharp.Models.RegisterModel>" %>

<%@ Import Namespace="BotDetect.Web.Mvc" %>
<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>
<asp:Content ID="BotDetectStylesheets" ContentPlaceHolderID="includes" runat="server">
    <link href="<%= BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl %>" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create a New Account</h2>
    <p>
        Use the form below to create a new account.
    </p>
    <p>
        Passwords are required to be a minimum of
        <%: ViewData["PasswordLength"] %>
        characters in length.
    </p>
    <% using (Html.BeginForm("Register", "Account", FormMethod.Post, new { @class = "column", role = "form" }))
       { %>
    <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset id="RegisterFields">
            <legend>Account Information</legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.UserName) %>
                <%: Html.ValidationMessageFor(m => m.UserName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Email) %>
                <%: Html.ValidationMessageFor(m => m.Email) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.Password) %>
                <%: Html.ValidationMessageFor(m => m.Password) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
            </div>
            <% // add Captcha validation controls to the protected action View
           MvcCaptcha registrationCaptcha = CaptchaHelper.GetRegistrationCaptcha();
           if (!registrationCaptcha.IsSolved)
           { %>
            <div class="editor-label">
                <%: Html.Captcha(registrationCaptcha) %>
                <%: Html.LabelFor(m => m.CaptchaCode) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.CaptchaCode)%>
                <%: Html.ValidationMessageFor(m => m.CaptchaCode)%>
            </div>
            <% } %>
            <p style="width: 195px; text-align: right;">
                <input type="submit" value="Register" />
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
                    You can get a new CAPTCHA using the <code>Register</code> action link in the top
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
