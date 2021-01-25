<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsMembershipCaptchaExampleCSharp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BotDetect CAPTCHA ASP.NET Membership Example</title>
    <link type="text/css" rel="stylesheet" href="Content/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server" class="column">
        <h1>BotDetect CAPTCHA ASP.NET Membership Example</h1>
        <fieldset>
            <legend>Page protected with ASP.NET authentication</legend>
            <p>This page can only be seen after successful Captcha validation and username/password authentication.</p>
            <asp:LinkButton Text="Sign out" runat="server" ID="SignOutButton" OnClick="SignOutButton_Click"></asp:LinkButton>
        </fieldset>
    </form>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to integrate BotDetect CAPTCHA validation with standard ASP.NET Membership functionality used in ASP.NET <code>Login</code> and <code>CreateUserWizard</code> controls.</p>
            </div>
            <% if (WebFormsCaptcha.IsFree)
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
        <p>Visual Studio 2012 / .NET 4.5 / C# example project.</p>
        <p><%= WebFormsCaptcha.ControlInfo %></p>
    </div>
</body>
</html>
