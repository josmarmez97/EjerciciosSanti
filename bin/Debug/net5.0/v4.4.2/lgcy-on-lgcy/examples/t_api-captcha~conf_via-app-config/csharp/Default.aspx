<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CaptchaApplicationConfigSettingsExampleCSharp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BotDetect ASP.NET CAPTCHA Options: Application Config Settings Code Example</title>
    <link type="text/css" rel="Stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form runat="server" class="column" id="form1" >
        <h1>BotDetect ASP.NET CAPTCHA Options: <br /> Application Config Settings Code Example</h1>
        <fieldset>
            <legend>ASP.NET WebForm CAPTCHA Validation</legend>
            <p class="prompt"><label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsCaptcha runat="server" ID="ExampleCaptcha" UserInputID="CaptchaCodeTextBox"/>
            <div class="validationDiv">
                <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="ValidateCaptchaButton" runat="server" />
                <asp:Label ID="CaptchaCorrectLabel" runat="server" CssClass="correct"></asp:Label>
                <asp:Label ID="CaptchaIncorrectLabel" runat="server" CssClass="incorrect"></asp:Label>
            </div>
        </fieldset>
    </form>
    
    <div class="column">
        <div class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This BotDetect Captcha ASP.NET code example shows how to configure Captcha challenges by overriding Captcha control defaults in application configuration files.</p>
                <p>BotDetect allows user-defined customization of many Captcha options through a special <code>&lt;botDetect&gt;</code> section of the <code>web.config</code> file.</p> 
                <p>Captcha settings from this configuration file will apply to all Captcha challenges shown on forms in the applications, and will act as defaults with which all Captcha objects will be created. This makes configuration file settings the simplest and most convenient way of Captcha customization for most use cases.</p>
                <p>The <code>web.config</code> file used in this code example contains detailed descriptions and explanations of the many customizable Captcha options exposed by the BotDetect ASP.NET Captcha configuration API.</p>
            </div>
        </div>
        <% if (WebFormsCaptcha.IsFree) { %>
        <div class="column">
            <div class="note warning">
                <h3>Free Version Limitations</h3>
                <ul>
                    <li>The free version of BotDetect only includes a limited subset of the available CAPTCHA image styles and CAPTCHA sound styles.</li>
                    <li>The free version of BotDetect includes a randomized <code>BotDetect™</code> trademark in the background of 50% of all Captcha images generated.</li>
                    <li>It also has limited sound functionality, replacing the CAPTCHA sound with "SOUND DEMO" for randomly selected 50% of all CAPTCHA codes.</li>
                    <li>Lastly, the bottom 10 px of the CAPTCHA image are reserved for a link to the BotDetect website.</li>
                </ul>
                <p>All of these limitations are removed if you <a href="http://captcha.com/shop.html?utm_source=installation&amp;utm_medium=aspnet&amp;utm_campaign=4.4.2" rel="nofollow" title="BotDetect CAPTCHA online store, pricing information, payment options, licensing &amp; upgrading">upgrade</a> your BotDetect license.</p>
            </div>
        </div>
        <% } %>
    </div>
    
    <div id="systeminfo">
        <p><%= WebFormsCaptcha.ControlInfo %></p>
    </div>
</body>
</html>
