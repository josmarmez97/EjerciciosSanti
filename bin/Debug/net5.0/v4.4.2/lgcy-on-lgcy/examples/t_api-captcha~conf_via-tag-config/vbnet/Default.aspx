<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="CaptchaFormObjectSettingsExampleVBNet._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BotDetect ASP.NET CAPTCHA Options: Form Object Settings Code Example</title>
    <link type="text/css" rel="Stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form runat="server" class="column" id="form1" >
        <h1>BotDetect ASP.NET CAPTCHA Options: <br /> Form Object Settings Code Example</h1>
        <fieldset>
            <legend>ASP.NET WebForm CAPTCHA Validation</legend>
            <p class="prompt"><label for="Captcha1CodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsCaptcha runat="server" ID="Captcha1" UserInputID="Captcha1CodeTextBox"
                CodeLength="6" 
                CodeStyle="Numeric"
                DisallowedCodeSubstringsCsv="1,2,3,4,5,00,777,9999" 
                CodeTimeout="300" 
                ImageStyle="SunAndWarmAir" 
                ImageSize="250,60"
                ImageFormat="Png"
                CustomDarkColor="Black"
                CustomLightColor="White"
                SoundEnabled="true" 
                SoundStyle="Synth" 
                SoundFormat="WavPcm8bit8kHzMono" 
                SoundRegenerationMode="Limited"
                Locale="es-MX" 
                ImageTooltip="Custom Mexican Spanish Captcha image tooltip" 
                SoundTooltip="Custom Mexican Spanish Captcha sound icon tooltip" 
                ReloadTooltip="Custom Mexican Spanish Captcha reload icon tooltip" 
                HelpLinkText="Custom Mexican Spanish Captcha help link text"
                HelpLinkUrl="custom-mexican-spanish-captcha-help-page.html"
                ReloadEnabled="true"
                UseSmallIcons="false"
                UseHorizontalIcons="false"
                SoundIconUrl=""
                ReloadIconUrl=""
                IconsDivWidth="27"
                HelpLinkEnabled="true" 
                HelpLinkMode="Text"
                TabIndex="-1"
                AdditionalCssClasses="class1 class2 class3" 
                AdditionalInlineCss="border: 4px solid #fff; background-color: #f8f8f8;" 
                AddScriptInclude="true"
                AutoUppercaseInput="true"
                AutoFocusInput="true"
                AutoClearInput="true"
                AutoReloadExpiredCaptchas="true"
                AutoReloadTimeout="7200"
                SoundStartDelay="100"
                RemoteScriptEnabled="true"
            />
            <div class="validationDiv">
                <asp:TextBox ID="Captcha1CodeTextBox" runat="server"></asp:TextBox>
                <asp:Label ID="Captcha1CorrectLabel" runat="server" CssClass="correct" Text="Correct!" Visible="false"></asp:Label>
                <asp:Label ID="Captcha1IncorrectLabel" runat="server" CssClass="incorrect" Text="Incorrect!" Visible="false"></asp:Label>
            </div>
        </fieldset>

        <fieldset>
            <legend>ASP.NET WebForm CAPTCHA Validation</legend>
            <p class="prompt"><label for="Captcha2CodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsCaptcha runat="server" ID="Captcha2" UserInputID="Captcha2CodeTextBox" />
            <div class="validationDiv">
                <asp:TextBox ID="Captcha2CodeTextBox" runat="server"></asp:TextBox>
                <asp:Label ID="Captcha2CorrectLabel" runat="server" CssClass="correct" Text="Correct!" Visible="false"></asp:Label>
                <asp:Label ID="Captcha2IncorrectLabel" runat="server" CssClass="incorrect" Text="Incorrect!" Visible="false"></asp:Label>
            </div>
        </fieldset>

        <asp:Button ID="SubmitFormButton" runat="server" Text="Submit Form" />
    </form>

    
    <div class="column">
        <div class="column">
             <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This BotDetect Captcha ASP.NET code example shows how to configure Captcha challenges by setting Captcha control properties in ASP.NET form source.</p>
                <p>Multiple ASP.NET forms within the same ASP.NET website can be protected by BotDetect Captcha challenges: e.g. you could add Captcha controls in both your Contact form and Registration form source.</p> 
                <p>To function properly, separate Captcha challenges placed on each form should have different names (<code>CaptchaId</code> values, <code>Captcha1</code> and <code>Captcha2</code> in this example), and can use completely different Captcha settings.</p>
                <p>Even multiple Captcha instances placed on the same form won't interfere with each other's validation and functionality. And if a user opens the same page in multiple browser tabs, each tab will independently validate the shown Captcha code.</p>
                <p>Shared Captcha settings should always be placed in the <code>web.config</code> application configuration file, and only diverging settings set through Captcha object instance properties in form code, to avoid code duplication.</p> 
                <p>Settings that affect only Captcha container markup generation take effect immediately (changing <code>Captcha.Html</code> output), but settings that affect Captcha challenge (image or sound) generation in separate Http requests need to be saved in ASP.NET Session state when set through <code>Captcha</code> object instance properties in form source, consuming server resources and reverting to defaults when the ASP.NET Session expires.</p>
            </div>
        </div>
        <% If (WebFormsCaptcha.IsFree) Then%>
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
        <p><%= WebFormsCaptcha.ControlInfo %></p>
    </div>
</body>
</html>

