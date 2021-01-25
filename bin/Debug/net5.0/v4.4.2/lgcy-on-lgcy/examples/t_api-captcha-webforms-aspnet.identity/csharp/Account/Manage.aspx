<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="WebForms451CaptchaExampleCSharp.Account.Manage" %>

<%@ Import Namespace="BotDetect.Web.UI" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-6" id="form-container">
            <section id="passwordForm">
                <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                    <p>
                        You do not have a local password for this site. Add a local
                        password so you can log in without an external login.
                    </p>
                    <div class="form-horizontal">
                        <h4>Set Password Form</h4>
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <hr />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                    CssClass="text-danger" ErrorMessage="The password field is required."
                                    Display="Dynamic" ValidationGroup="SetPassword" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                    CssClass="text-error" SetFocusOnError="true" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                    ValidationGroup="SetPassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                    ValidationGroup="SetPassword" />

                            </div>
                        </div>
                        <!-- Add the controls for CAPTCHA validation to the registration form -->
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <BotDetect:WebFormsCaptcha ID="SetPasswordCaptcha" runat="server" />
                            </div>
                            <asp:Label runat="server" AssociatedControlID="CaptchaCode" CssClass="col-md-2 control-label">Retype code</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="SetPasswordCaptchaCode" CssClass="form-control captchaVal" />
                                <asp:RequiredFieldValidator ID="CaptchaRequiredValidator" runat="server" ControlToValidate="SetPasswordCaptchaCode"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Retyping the code from the picture is required." />
                                <asp:CustomValidator runat="server" ID="CaptchaValidator" ControlToValidate="SetPasswordCaptchaCode"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Incorrect code, please try again."
                                    OnServerValidate="SetPasswordCaptchaValidator_ServerValidate" ClientValidationFunction="ValidateCaptcha" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Set Password" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                    <p>You're logged in as <strong><%: User.Identity.GetUserName() %></strong>.</p>
                    <div class="form-horizontal">
                        <h4>Change Password Form</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Current password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="text-danger" ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">New password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="text-danger" ErrorMessage="The new password is required."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-2 control-label">Confirm new password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <!-- Add the controls for CAPTCHA validation to the registration form -->
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <BotDetect:WebFormsCaptcha ID="ChangePasswordCaptcha" runat="server" />
                            </div>
                            <asp:Label runat="server" AssociatedControlID="ChangePasswordCaptchaCode" CssClass="col-md-2 control-label">Retype code</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ChangePasswordCaptchaCode" CssClass="form-control captchaVal" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ChangePasswordCaptchaCode"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Retyping the code from the picture is required." />
                                <asp:CustomValidator runat="server" ID="CustomValidator1" ControlToValidate="ChangePasswordCaptchaCode"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Incorrect code, please try again."
                                    OnServerValidate="ChangePasswordCaptchaValidator_ServerValidate" ClientValidationFunction="ValidateCaptcha" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Change Password" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>

            <section id="externalLoginsForm">

                <asp:ListView runat="server"
                    ItemType="Microsoft.AspNet.Identity.UserLoginInfo"
                    SelectMethod="GetLogins" DeleteMethod="RemoveLogin" DataKeyNames="LoginProvider,ProviderKey">

                    <LayoutTemplate>
                        <h4>Registered Logins</h4>
                        <table class="table">
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.LoginProvider %></td>
                            <td>
                                <asp:Button runat="server" Text="Remove" CommandName="Delete" CausesValidation="false"
                                    ToolTip='<%# "Remove this " + Item.LoginProvider + " login from your account" %>'
                                    Visible="<%# CanRemoveExternalLogins %>" CssClass="btn btn-default" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

                <uc:OpenAuthProviders runat="server" ReturnUrl="~/Account/Manage" />
            </section>

        </div>
        <div class="col-md-6" id="notes">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows how to add BotDetect CAPTCHA protection to the registration form included in the default ASP.NET 4.5.1 Web Forms Application project template coming with Visual Studio 2013.</p>
                <p>Since the Manage Account form uses ASP.NET Identity user management, the example shows how to include BotDetect CAPTCHA validation in user managing data validation (see <code>Account\Manage.aspx</code> and <code>Account\Manage.aspx.cs</code> source code).</p>
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
