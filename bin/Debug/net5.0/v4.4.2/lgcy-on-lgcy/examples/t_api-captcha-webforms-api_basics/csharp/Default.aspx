<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsBasicCaptchaExampleCSharp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BotDetect ASP.NET CAPTCHA Validation: Basic ASP.NET WebForms CAPTCHA Code Example</title>
    <link type="text/css" rel="stylesheet" href="Content/StyleSheet.css" />
</head>
<body>
    <form runat="server" class="column" id="form1" >
        <h1>BotDetect ASP.NET CAPTCHA Validation: <br /> Basic ASP.NET WebForms CAPTCHA Code Example</h1>
        <fieldset>
            <legend>ASP.NET WebForm CAPTCHA Validation</legend>
            <p class="prompt"><label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsCaptcha runat="server" ID="ExampleCaptcha" UserInputID="CaptchaCodeTextBox" />
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
                <p>This example project shows the most basic source code required to protect an ASP.NET Web Form with BotDetect CAPTCHA and validate the user input.</p> 
                <p>ASP.NET form declarations displaying CAPTCHA protection can be found in <code>Default.aspx</code>, and the code-behind code checking user input is in <code>Default.aspx.cs</code>.</p>
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
