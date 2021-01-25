<%@ Page Title="Register" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.vb" Inherits="WebForms451CaptchaExampleVBNet.Register" %>
<%@ Import Namespace="BotDetect.Web.UI" %>

<%@ Import Namespace="WebForms451CaptchaExampleVBNet" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />

        <div class="col-md-6" id="form-container">

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UserNameCtrl" CssClass="col-md-4 control-label">User name</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="UserNameCtrl" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserNameCtrl"
                        CssClass="text-danger" ErrorMessage="The user name field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 control-label">Password</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-4 control-label">Confirm password</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </div>
            </div>
            <!-- Add the controls for CAPTCHA validation to the registration form -->
            <div class="form-group">
                <div class="col-md-offset-4 col-md-8">
                    <BotDetect:WebFormsCaptcha ID="RegisterCaptcha" runat="server" />
                </div>
                <asp:Label runat="server" AssociatedControlID="CaptchaCode" CssClass="col-md-4 control-label">Retype code</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="CaptchaCode" CssClass="form-control captchaVal" />
                    <asp:RequiredFieldValidator ID="CaptchaRequiredValidator" runat="server" ControlToValidate="CaptchaCode"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Retyping the code from the picture is required." />
                    <asp:CustomValidator runat="server" ID="CaptchaValidator" ControlToValidate="CaptchaCode"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Incorrect code, please try again." 
                                        OnServerValidate="CaptchaValidator_ServerValidate" ClientValidationFunction="ValidateCaptcha" />
                </div>
            </div>
            <div class="form-group" id="form-submit">
                <div class="col-md-offset-4 col-md-8">
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
        <div class="col-md-6" id="notes">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to add BotDetect CAPTCHA protection to the registration form included in the default ASP.NET 4.5.1 Web Forms Application project template coming with Visual Studio 2013.</p> 
                <p>Since the Register form uses ASP.NET Identity user management, the example shows how to include BotDetect CAPTCHA validation in new user data validation (see <code>Account\Register.aspx</code> and <code>Account\Register.aspx.vb</code> source code).</p>
                <p>The example also shows how to complement server-side CAPTCHA validation with client-side Ajax CAPTCHA validation using ASP.NET 4.5.1 unobtrusive validation applied to all form fields (<code>Scripts\WebForms\WebUICaptchaValidation.js</code>).</p>
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
            <% End If %>
        </div>
        <div class="form-group">
            <div class="col-md-5" id="systeminfo">
                <p>Visual Studio 2013 / .NET 4.5.1 / VB.NET example project.</p>
                <p><%= WebFormsCaptcha.ControlInfo %></p>
            </div>
        </div>
    </div>
</asp:Content>
