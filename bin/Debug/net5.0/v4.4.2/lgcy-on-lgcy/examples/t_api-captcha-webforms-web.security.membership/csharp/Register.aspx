<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsMembershipCaptchaExampleCSharp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link type="text/css" rel="Stylesheet" href="Content/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server" class="column">
        <h1>BotDetect CAPTCHA ASP.NET Membership Example</h1>
        <fieldset>
            <legend>CAPTCHA Validation in a <code>CreateUserWizard</code> control</legend>
            <asp:CreateUserWizard ID="RegisterUser" runat="server"
                OnNextButtonClick="RegisterUser_NextButtonClick" ActiveStepIndex="0">
                <WizardSteps>
                    <asp:CreateUserWizardStep runat="server">
                        <ContentTemplate>
                            <table border="0">
                                <tr>
                                    <td align="center" colspan="2">Sign Up for Your New Account</td>
                                </tr>
                                <tr>
                                    <td align="right" width="185">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                            ControlToValidate="UserName" ErrorMessage="User Name is required."
                                            ToolTip="User Name is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
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
                                            ToolTip="Password is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server"
                                            AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server"
                                            ControlToValidate="ConfirmPassword"
                                            ErrorMessage="Confirm Password is required."
                                            ToolTip="Confirm Password is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server"
                                            ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                            Display="Dynamic"
                                            ErrorMessage="The Password and Confirmation Password must match."
                                            ValidationGroup="RegisterUser"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server"
                                            ControlToValidate="Email" ErrorMessage="E-mail is required."
                                            ToolTip="E-mail is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <BotDetect:WebFormsCaptcha ID="RegisterCaptcha" UserInputID="CaptchaCodeTextBox" ImageSize="150, 50" CodeLength="3" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="CaptchaLabel" runat="server" AssociatedControlID="CaptchaCodeTextBox">Code:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="CaptchaRequiredValidator" runat="server"
                                            ControlToValidate="CaptchaCodeTextBox" ErrorMessage="CAPTCHA code is required."
                                            ToolTip="CAPTCHA code is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <span>
                                            <asp:Literal ID="InvalidCaptchaInput" runat="server" EnableViewState="False" Visible="False" Text="Retype the characters from the image carefully."></asp:Literal></span>
                                    </td>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <span>
                                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal></span>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep runat="server">
                        <ContentTemplate>
                            <table border="0">
                                <tr>
                                    <td align="center" colspan="2">Complete</td>
                                </tr>
                                <tr>
                                    <td>Your account has been successfully created.</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <p><a href="Default.aspx">Continue</a></p>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
            <p><a href="Login.aspx">Login</a></p>
        </fieldset>
    </form>
    <div class="column">
        <div id="notes" class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to integrate BotDetect CAPTCHA validation with standard ASP.NET Membership functionality used in ASP.NET <code>Login</code> and <code>CreateUserWizard</code> controls.</p>
                <p>To prevent bots from registering user accounts, the Captcha has to be solved before user details are recorded.</p>
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
