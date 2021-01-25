<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="t_api_captcha_webforms_api_basics_unobtrusive._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BotDetect ASP.NET CAPTCHA jQuery Validation Example</title>
    <link type="text/css" rel="Stylesheet" href="Content/StyleSheet.css" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.validate.min.js"></script>

</head>
<body>
    <form id="form1" runat="server" class="column">
        <h1>BotDetect ASP.NET CAPTCHA Validation:
            <br />
            BotDetect ASP.NET CAPTCHA jQuery Validation Example</h1>
        <fieldset>
            <legend>CAPTCHA Validation</legend>
            <p class="prompt">
                <label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsCaptcha ID="ExampleCaptcha" runat="server" />
            <div class="validationDiv">
                <!-- add CssClass name used to set up jQuery field validation -->
                <asp:TextBox ID="CaptchaCodeTextBox" runat="server" CssClass="captchaVal"></asp:TextBox>
                <br />
                <asp:Button ID="ValidateCaptchaButton" runat="server" />
            </div>
            <asp:Label ID="CaptchaCorrectLabel" AssociatedControlID="CaptchaCodeTextBox" runat="server" CssClass="correct"></asp:Label>
            <asp:Label ID="CaptchaIncorrectLabel" AssociatedControlID="CaptchaCodeTextBox" runat="server" CssClass="incorrect"></asp:Label>
        </fieldset>

        <script type="text/javascript" src="js/validationRules.js"></script>
    </form>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to integrate BotDetect ASP.NET CAPTCHA validation with <a target="_blank" href="http://jqueryvalidation.org/validate">jQuery Validation</a> client-side form validation.</p>
                <p>Client-side validation is not secure by itself (it can be bypassed trivially by bots that don't execute JavaScript at all), so the example shows how the protected form action must always be secured by server-side CAPTCHA validation first, and uses client-side validation only to improve the user experience.</p>
            </div>
            <% If (WebFormsCaptcha.IsFree) Then%>
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
        <p>Visual Studio 2013 / Visual Studio 2012 / .NET 4.5 / VB.NET example project.</p>
        <p><%= WebFormsCaptcha.ControlInfo%></p>
    </div>
</body>
</html>
