<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="t_api_captcha_webforms_api_basics_msajax._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BotDetect CAPTCHA ASP.NET Ajax Example</title>
    <link type="text/css" rel="Stylesheet" href="Content/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server" class="column">
        <h1>BotDetect ASP.NET CAPTCHA Validation: <br /> BotDetect CAPTCHA ASP.NET Ajax Example</h1>
        <fieldset>
            <legend>CAPTCHA Validation</legend>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="CaptchaUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                        <h3>Step 1</h3>
                        <p class="prompt">The first screen doesn't contain BotDetect yet. After you click "Next", Captcha protection will be shown using an ASP.NET Ajax partial postback.</p>
                        <asp:Button ID="Button1" runat="server" Text="Next" />
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <h3>Step 2</h3>
                        <p class="prompt">
                            <label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
                        <BotDetect:WebFormsCaptcha ID="ExampleCaptcha" runat="server" />
                        <div class="validationDiv">
                            <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                            <asp:Button ID="ValidateCaptchaButton" runat="server" />
                            <asp:Label ID="CaptchaIncorrectLabel" runat="server" CssClass="incorrect"></asp:Label>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </fieldset>

    </form>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to use BotDetect within an ASP.NET Ajax <code>UpdatePanel</code>. The basic code used to add Captcha protection to the page is the same as in regular ASP.NET forms.</p>
                <p>However, some additional work is required if BotDetect is not visible on the first page load, but gets added to the page dynamically.</p>
                <p>Since BotDetect can't automatically add required stylesheet and client-side script includes to the page if it's not visible on the first page load, they can be added manually.</p>
                <p>In this example, the BotDetect stylesheet include is added to the <code>Default.aspx</code> page header, while the script include and the BotDetect initialization script are registered in the code-behind.</p>
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
        <p>Visual Studio 2015 / Visual Studio 2013 / Visual Studio 2012 / .NET 4.5 / .NET 4.6 / VB.NET example project.</p>
        <p><%= WebFormsCaptcha.ControlInfo%></p>
    </div>
</body>
</html>
