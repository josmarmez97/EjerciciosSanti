<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForms451CaptchaExampleCSharp.Account.Login" Async="true" %>

<%@ Import Namespace="BotDetect.Web.UI" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">

        <section id="loginForm">
            <div class="form-horizontal">
                <h4>Use a local account to log in.</h4>
                <hr />
                <div class="col-md-6" id="form-container">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- Add the controls for CAPTCHA validation to the registration form -->
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <BotDetect:WebFormsCaptcha ID="LoginCaptcha" runat="server" />
                        </div>
                        <asp:Label runat="server" AssociatedControlID="CaptchaCode" CssClass="col-md-2 control-label">Retype code</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="CaptchaCode" CssClass="form-control captchaVal" />
                            <asp:RequiredFieldValidator ID="CaptchaRequiredValidator" runat="server" ControlToValidate="CaptchaCode"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Retyping the code from the picture is required." />
                            <asp:CustomValidator runat="server" ID="CaptchaValidator" ControlToValidate="CaptchaCode"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Incorrect code, please try again."
                                OnServerValidate="CaptchaValidator_ServerValidate" ClientValidationFunction="ValidateCaptcha" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have a local account.
                </p>
            </div>
        </section>
        <div class="col-md-6" id="notes">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to add BotDetect CAPTCHA protection to the registration form included in the default ASP.NET 4.5.1 Web Forms Application project template coming with Visual Studio 2013.</p>
                <p>Since the Login form uses ASP.NET Identity user management, the example shows how to include BotDetect CAPTCHA validation in user logging data validation (see <code>Account\Login.aspx</code> and <code>Account\Login.aspx.cs</code> source code).</p>
                <p>The example also shows how to complement server-side CAPTCHA validation with client-side Ajax CAPTCHA validation using ASP.NET 4.5.1 unobtrusive validation applied to all form fields (<code>Scripts\WebForms\WebUICaptchaValidation.js</code>).</p>
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


</asp:Content>
