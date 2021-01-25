<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="BotDetect.Web.Mvc" %>
<%@ Import Namespace="Mvc10CaptchaExampleVBNet" %>
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
        <%= Html.ActionLink("Register", "Register")%>
        if you don't have an account.
    </p>
    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>
    <% Using Html.BeginForm("Logon", "Account", FormMethod.Post, New With {.class = "column", .role = "form"})%>
    <div>
        <fieldset>
            <legend>Account Information</legend>
            <p>
                <label for="username">
                    Username:</label>
                <%= Html.TextBox("username") %>
                <%= Html.ValidationMessage("username") %>
            </p>
            <p>
                <label for="password">
                    Password:</label>
                <%= Html.Password("password") %>
                <%= Html.ValidationMessage("password") %>
            </p>
            <%  Dim loginCaptcha As MvcCaptcha = _
                        CaptchaHelper.GetLoginCaptcha()
                    
                If (Not loginCaptcha.IsSolved) Then%>
            <%=Html.Captcha(loginCaptcha)%>
            <p>
                <label for="captchaCode">
                    Please retype the characters from the picture:</label>
                <%= Html.TextBox("captchaCode")%>
                <%= Html.ValidationMessage("captchaCode")%>
            </p>
            <% End If%>
            <p>
                <%= Html.CheckBox("rememberMe") %>
                <label class="inline" for="rememberMe">
                    Remember me?</label>
            </p>
            <p>
                <input type="submit" value="Log On" />
            </p>
        </fieldset>
    </div>
    <% End Using%>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>
                    CAPTCHA Code Example Description</h3>
                <p>
                    This example project shows how to use the BotDetect <code>MvcCaptcha</code> control
                    in ASP.NET MVC web applications.</p>
                <p>
                    Starting with the default ASP.NET MVC example project, the example includes all
                    code required to add CAPTCHA validation to the <code>Account</code> controller <code>
                        Register</code> action.</p>
                <p>
                    The example remembers when the CAPTCHA is successfully solved within a single registration,
                    and doesn't display it again if there are errors with other form values (the username,
                    for example).</p>
                <p>
                    You can get a new CAPTCHA using the <code>Logon</code> action link in the top right
                    corner of the page, and see the explanation in the <code>Account</code> controller
                    code.</p>
            </div>
            <% If MvcCaptcha.IsFree Then%>
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
            <% End If%>
        </div>
    </div>
    <div id="systeminfo">
        <p>
            Visual Studio 2008 / .NET 3.5 / VB.NET example project.</p>
        <p>
            <%= MvcCaptcha.ControlInfo%></p>
    </div>
</asp:Content>
