@Imports Microsoft.AspNet.Identity
@ModelType ManageUserViewModel
@* namespaces needed to access BotDetect members and the CaptchaHelper class *@
@Imports BotDetect.Web.Mvc
@Imports Mvc50CaptchaExampleVBNet
<p class="text-info">You're logged in as <strong>@User.Identity.GetUserName()</strong>.</p>

@Using Html.BeginForm("Manage", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

    @Html.AntiForgeryToken()

    @<text>
        <h4>Change Password Form</h4>
        <hr />
        <div class="col-md-6" id="form-container">
            @Html.ValidationSummary()
            <div class="form-group">
                @Html.LabelFor(Function(m) m.OldPassword, New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.PasswordFor(Function(m) m.OldPassword, New With {.class = "form-control"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(m) m.NewPassword, New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
                </div>
            </div>
            @* showing Captcha on the form:
                add Captcha validation controls to the protected action View,
                but only if the Captcha hasn't already been solved *@

            @Code Dim changePasswordCaptcha As MvcCaptcha = CaptchaHelper.GetChangePasswordCaptcha()
                If (Not changePasswordCaptcha.IsSolved) Then
                @<div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        @Html.Captcha(changePasswordCaptcha)
                    </div>

                    @Html.Label("Retype the code", New With {.class = "col-md-2 control-label"})

                    <div class="col-md-10">
                        @Html.TextBox("CaptchaCode", Nothing, New With {.class = "form-control captchaVal"})
                    </div>
                </div>
            End If
            End Code
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Change password" class="btn btn-default" />
                </div>
            </div>
        </div>
        <div class="col-md-6" id="notes">
            <div class="note">
                <h3>Description</h3>
                <p>This example project shows how to use the BotDetect <code>MvcCaptcha</code> control in ASP.NET MVC 5.0 web applications.</p>
                <p>Starting with the default ASP.NET MVC 5.0 Web Application project template, the example includes all code required to add CAPTCHA validation to the <code>Account</code> controller <code>Manage</code> action.</p>
                <p>The sample also shows how to complement server-side CAPTCHA validation with client-side Ajax CAPTCHA validation using ASP.NET MVC 5.0 unobtrusive validation applied to all form fields (<code>Scripts\captcha.validate.js</code>).</p>
            </div>
            @If (MvcCaptcha.IsFree) Then
                @<div class="note warning">
                    <h3>Free Version Limitations</h3>
                    <ul>
                        <li>The free version of BotDetect includes a randomized <code>BotDetect™</code> trademark in the background of 50% of all Captcha images generated.</li>
                        <li>It also has limited sound functionality, replacing the CAPTCHA sound with "SOUND DEMO" for randomly selected 50% of all CAPTCHA codes.</li>
                        <li>Lastly, the bottom 10 px of the CAPTCHA image are reserved for a link to the BotDetect website.</li>
                    </ul>
                    <p>All of these limitations are removed if you <a href="http://captcha.com/shop.html?utm_source=installation&amp;utm_medium=aspnet&amp;utm_campaign=4.4.2" rel="nofollow" title="BotDetect CAPTCHA online store, pricing information, payment options, licensing &amp; upgrading">upgrade</a> your BotDetect license.</p>
                </div>
            End If
        </div>

    </text>
End Using
