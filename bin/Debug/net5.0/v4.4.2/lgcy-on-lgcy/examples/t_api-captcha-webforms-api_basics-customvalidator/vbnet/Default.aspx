<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebFormsValidatorCaptchaExampleVBNet._Default" %>

<!DOCTYPE html>
<head id="Head1" runat="server">
    <title>BotDetect CAPTCHA ASP.NET Validator Example</title>
    <link type="text/css" rel="Stylesheet" href="Content/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server" class="column">
        <h1>BotDetect ASP.NET CAPTCHA Validation:
            <br />
            BotDetect CAPTCHA ASP.NET Validator Example</h1>
        <fieldset>
            <legend>CAPTCHA Validator</legend>
            <p class="prompt">Name:</p>
            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NameValidator" runat="server"
                ControlToValidate="NameTextBox"
                ErrorMessage="Your name is required"
                EnableClientScript="true"
                SetFocusOnError="true">Missing name</asp:RequiredFieldValidator>

            <p class="prompt">
                <label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
            <BotDetect:WebFormsCaptcha ID="ExampleCaptcha" runat="server" />

            <div class="validationDiv">
                <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                <BotDetect:CaptchaValidator ID="ExampleCaptchaValidator" runat="server"
                    ControlToValidate="CaptchaCodeTextBox"
                    CaptchaControl="ExampleCaptcha"
                    ErrorMessage="Retype the characters exactly as they appear in the picture"
                    EnableClientScript="true"
                    SetFocusOnError="true">Incorrect CAPTCHA code</BotDetect:CaptchaValidator>

                <br />
                <asp:Label ID="ValidationPassedLabel" runat="server"
                    CssClass="correct"
                    Visible="False"
                    Text="Validation passed!" />

                <br />
                <asp:Button ID="SumbitButton" runat="server"
                    Text="Submit"
                    CausesValidation="true" />
            </div>
        </fieldset>
    </form>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to use the <code>CaptchaValidator</code> control to integrate BotDetect CAPTCHA validation with standard ASP.NET page validation functionality and other validator controls.</p>
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
