<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="WebFormsMembershipCaptchaExampleVBNet.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link type="text/css" rel="Stylesheet" href="Content/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server" class="column">
        <h1>BotDetect CAPTCHA ASP.NET Membership Example</h1>
        <fieldset>
            <legend>CAPTCHA Validation in a <code>Login</code> control</legend>
            <asp:Login ID="ExampleLogin" runat="server" OnAuthenticate="ExampleLogin_Authenticate">
                <LayoutTemplate>
                    <table border="0" cellpadding="1" cellspacing="0"
                        style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2">Log In</td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="185">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                ToolTip="User Name is required." ValidationGroup="ExampleLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                ControlToValidate="Password" ErrorMessage="Password is required."
                                                ToolTip="Password is required." ValidationGroup="ExampleLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <BotDetect:WebFormsCaptcha ID="LoginCaptcha" UserInputID="CaptchaCodeTextBox" ImageSize="150, 50" CodeLength="3" runat="server" />
                                        </td>
                                    </tr>
                                    <tr runat="server" id="CaptchaRow">
                                        <td align="right">
                                            <asp:Label ID="CaptchaLabel" runat="server" AssociatedControlID="CaptchaCodeTextBox">Code:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CaptchaRequiredValidator" runat="server"
                                                ControlToValidate="CaptchaCodeTextBox" ErrorMessage="CAPTCHA code is required."
                                                ToolTip="CAPTCHA code is required." ValidationGroup="ExampleLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <span>
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In"
                                                ValidationGroup="ExampleLogin" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
            <p><a href="Register.aspx">Register</a></p>
        </fieldset>
    </form>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to integrate BotDetect CAPTCHA validation with standard ASP.NET Membership functionality used in ASP.NET <code>Login</code> and <code>CreateUserWizard</code> controls.</p>
                <p>To prevent bots from trying to guess the login info by brute force submission of a large number of common values, the visitor first has to prove they are human (by solving the CAPTCHA), and only then is their username and password submission checked against the authentication data store.</p>
                <p>Also, if they enter an invalid username + password combination three times, they have to solve the CAPTCHA again. This prevents attempts in which the attacker would first solve the CAPTCHA themselves, and then let a bot brute-force the authentication info.</p>
                <p>To keep the example code simple, the example doesn't access a data store to authenticate the user, but <strong>accepts all logins with usernames and passwords at least 5 characters long as valid</strong>.</p>
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
        <p>Visual Studio 2012 / .NET 4.5 / VB.NET example project.</p>
        <p><%= WebFormsCaptcha.ControlInfo%></p>
    </div>
</body>
</html>
