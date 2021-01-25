<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CaptchaRequestDynamicSettingsExampleCSharp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BotDetect ASP.NET CAPTCHA Options: Request Dynamic Settings Code Example</title>
    <link type="text/css" rel="Stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form runat="server" class="column" id="form1" >
        <h1>BotDetect ASP.NET CAPTCHA Options: <br /> Request Dynamic Settings Code Example</h1>

        <fieldset>
            <legend>ASP.NET WebForm CAPTCHA Validation</legend>
            <p class="prompt"><label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsCaptcha runat="server" ID="DynamicCaptcha" UserInputID="CaptchaCodeTextBox" />
            <div class="validationDiv">
                <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="ValidateCaptchaButton" runat="server" />
                <asp:Label ID="CaptchaCorrectLabel" runat="server" CssClass="correct"></asp:Label>
                <asp:Label ID="CaptchaIncorrectLabel" runat="server" CssClass="incorrect"></asp:Label>
            </div>
        </fieldset>

        <div id="output">
            <asp:Literal runat="server" ID="StatusLiteral" />
        </div>
    </form>

    <div class="column">
        <div class="column">
             <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This BotDetect Captcha ASP.NET code example shows how to dynamically adjust Captcha configuration, potentially on each Http request made by the client.</p>
                <p>Any code setting Captcha properties in the <code>Captcha.InitializedWebCaptcha</code> event handler will be executed not only for each protected form GET or POST request (like Captcha configuration code placed in form source would be), but also for each each GET request loading a Captcha image or sound, or making an Ajax Captcha validation call.</p>
                <p>If configured values are dynamic (e.g. randomized from a range), they will be re-calculated for each Captcha challenge generated. For example, Captcha <code>ImageStyle</code> randomized in <code>Captcha.InitializedWebCaptcha</code> event handler code will change on each Captcha reload button click.</p>
                <p>This means your code can reliably keep track of visitor interaction with the Captcha challenge and dynamically adjust its settings. Also, while <code>Captcha.InitializedWebCaptcha</code> settings apply to all Captcha instances by default, you can also selectively apply them based on CaptchaId.</p>
                <p>To show an example of the possible dynamic Captcha configuration adjustments, this code example increases the difficulty of the Captcha test if the visitor associated with the current ASP.NET Session fails a certain number of Captcha validation attempts, and also sets the Captcha locale to Chinese for requests from a certain IP range.</p>
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

