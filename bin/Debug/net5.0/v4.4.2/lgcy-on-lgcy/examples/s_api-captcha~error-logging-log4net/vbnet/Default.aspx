<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="CaptchaTroubleshootingExampleVBNet._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BotDetect ASP.NET CAPTCHA Options: Troubleshooting Helper Code Example</title>
    <link type="text/css" rel="Stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" class="column" runat="server">
        <h1>BotDetect ASP.NET CAPTCHA Options:<br /> Troubleshooting Helper Code Example</h1>
        <fieldset id="TroubleshootingDebug">
            <legend>CAPTCHA Debug Logging</legend>
            <p class="prompt"><label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsSimpleCaptcha runat="server" ID="ExampleCaptcha" />
            <div class="validationDiv">
                <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="ValidateCaptchaButton" runat="server" />
                <asp:Label ID="CaptchaCorrectLabel" runat="server" CssClass="correct"></asp:Label>
                <asp:Label ID="CaptchaIncorrectLabel" runat="server" CssClass="incorrect"></asp:Label>
            </div>
            <p class="validationTroubleshooting">A detailed trace of all CAPTCHA events will be logged to the <code>debug.txt</code> file in the example folder.</p>
            <div class="troubleshooting">
                <asp:Label ID="DebugLabel" runat="server"></asp:Label>
            </div>
        </fieldset>
        <fieldset id="TroubleshootingError">
            <legend>CAPTCHA Error Logging</legend>
            <p class="troubleshooting">Clicking <em>Simulate Error</em> will throw a fake BotDetect CAPTCHA exception and log it to the <code>error.txt</code> file in the example folder.</p>
            <asp:Button ID="CauseErrorButton" runat="server" OnClick="CauseErrorButton_Click" />
            <div class="troubleshooting">
                <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
            </div>
        </fieldset>
    </form>
    
    <div class="column">
        <div class="column">
             <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to use BotDetect built-in error logging and <code>Captcha</code> event tracing, using the BotDetect Troubleshooting utility based on log4net.</p>
                <p>The logging requires logging configuration into in <code>botdetect.xml</code> file and <code>BotDetectTroubleshootingModule</code> registration in the <code>web.config</code> file, as well as the <code>log4net.config</code> file defining log4net settings (in this case, logging to simple text files).</p>
                <p>Such logging techniques can be used as a foundation for effective diagnosis and resolution of any BotDetect issues you might encounter on your servers.</p>
            </div>
        </div>
        <% If (WebFormsSimpleCaptcha.IsFree) Then%>
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
        <% End If%>
    </div>
    
    <div id="systeminfo">
        <p><%= WebFormsSimpleCaptcha.ControlInfo %></p>
    </div>

</body>
</html>

