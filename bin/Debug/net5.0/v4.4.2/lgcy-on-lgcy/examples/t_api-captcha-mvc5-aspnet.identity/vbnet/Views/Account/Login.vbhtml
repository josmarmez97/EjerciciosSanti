@ModelType LoginViewModel
@* namespaces needed to access BotDetect members and the CaptchaHelper class *@
@Imports BotDetect.Web.Mvc
@Imports Mvc50CaptchaExampleVBNet
@Code
    ViewBag.Title = "Log in"
End Code

@* include BotDetect layout stylesheet in page <head> *@
@Section HeadIncludes
    <link href="@BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl" rel="stylesheet" type="text/css" />
End Section


<h2>@ViewBag.Title.</h2>
<div class="row">
    <section id="loginForm">
        @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
            @Html.AntiForgeryToken()
            @<text>
                <h4>Use a local account to log in.</h4>
                <hr />
                <div class="col-md-6" id="form-container">
                    @Html.ValidationSummary()
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.UserName, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-10">
                            @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.UserName)
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.Password)
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                @Html.CheckBoxFor(Function(m) m.RememberMe)
                                @Html.LabelFor(Function(m) m.RememberMe)
                            </div>
                        </div>
                    </div>
                    @* showing Captcha on the form:
                        add Captcha validation controls to the protected action View,
                        but only if the Captcha hasn't already been solved *@

                    @Code Dim loginCaptcha As MvcCaptcha = CaptchaHelper.GetLoginCaptcha()
                        If (Not loginCaptcha.IsSolved) Then
                        @<div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                @Html.Captcha(loginCaptcha)
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
                            <input type="submit" value="Log in" class="btn btn-default" />
                        </div>
                    </div>
                    <p>
                        @Html.ActionLink("Register", "Register") if you don't have a local account.
                    </p>
                </div>
            </text>
        End Using
    </section>
    <div class="col-md-6" id="notes">
        <section id="socialLoginForm">
            @Html.Partial("_ExternalLoginsListPartial", New With {.Action = "ExternalLogin", .ReturnUrl = ViewBag.ReturnUrl})
        </section>
        <div class="note">
            <h3>CAPTCHA Code Example Description</h3>
            <p>This example project shows how to use the BotDetect <code>MvcCaptcha</code> control in ASP.NET MVC 5.0 web applications.</p>
            <p>Starting with the default ASP.NET MVC 5.0 Web Application project template, the example includes all code required to add CAPTCHA validation to the <code>Account</code> controller <code>Login</code> action.</p>
            <p>The example also shows how to complement server-side CAPTCHA validation with client-side Ajax CAPTCHA validation using ASP.NET MVC 5.0 unobtrusive validation applied to all form fields (<code>Scripts\captcha.validate.js</code>).</p>
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
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/Scripts/captcha.validate.js")
End Section
