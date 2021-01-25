﻿@ModelType Mvc30CaptchaExampleVBNet.RegisterModel

@Imports BotDetect.Web.Mvc
@Imports Mvc30CaptchaExampleVBNet

@Code
    ViewData("Title") = "Register"
End Code

@* add BotDetect header includes *@
@Section BotDetectStyles 
    <link href="@BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl" rel="stylesheet" type="text/css" />
End Section

<h2>Create a New Account</h2>
<p>
    Use the form below to create a new account. 
</p>
<p>
    Passwords are required to be a minimum of @Membership.MinRequiredPasswordLength characters in length.
</p>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "column", .role = "form"})
    @Html.ValidationSummary(True, "Account creation was unsuccessful. Please correct the errors and try again.")
    @<div>
        <fieldset>
            <legend>Account Information</legend>

            <div class="editor-label">
                @Html.LabelFor(Function(m) m.UserName)
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </div>

            <div class="editor-label">
                @Html.LabelFor(Function(m) m.Email)
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(Function(m) m.Email)
                @Html.ValidationMessageFor(Function(m) m.Email)
            </div>

            <div class="editor-label">
                @Html.LabelFor(Function(m) m.Password)
            </div>
            <div class="editor-field">
                @Html.PasswordFor(Function(m) m.Password)
                @Html.ValidationMessageFor(Function(m) m.Password)
            </div>

            <div class="editor-label">
                @Html.LabelFor(Function(m) m.ConfirmPassword)
            </div>
            <div class="editor-field">
                @Html.PasswordFor(Function(m) m.ConfirmPassword)
                @Html.ValidationMessageFor(Function(m) m.ConfirmPassword)
            </div>

            @* add Captcha validation controls to the protected action View *@
            @Code Dim registrationCaptcha As MvcCaptcha
            registrationCaptcha = CaptchaHelper.GetRegistrationCaptcha() End Code
            @If (Not registrationCaptcha.IsSolved) Then
            @:<div class="editor-label">
                @Html.LabelFor(Function(m) m.CaptchaCode)
                @Html.Captcha(registrationCaptcha)
            @:</div>
            @:<div class="editor-field">
                @Html.TextBoxFor(Function(m) m.CaptchaCode)
                @Html.ValidationMessageFor(Function(m) m.CaptchaCode)
            @:</div>
            End If 

            <p style="width: 210px; text-align: right;">
                <input type="submit" value="Register" />
            </p>
        </fieldset>
    </div>
End Using
<div class="column">
    <div id="notes" class="column">
        <div class="note">
            <h3>CAPTCHA Code Example Description</h3>
            <p>This example project shows how to use the BotDetect <code>MvcCaptcha</code> control in ASP.NET MVC 3.0 web applications.</p>
            <p>Starting with the default ASP.NET MVC 3.0 example project, the example includes all code required to add CAPTCHA validation to the <code>Account</code> controller <code>Register</code> action.</p>
            <p>The example remembers when the CAPTCHA is successfully solved within a single registration, and doesn't display it again if there are errors with other form values (the username, for example).</p>
            <p>You can get a new CAPTCHA using the <code>Register</code> action link in the top right corner of the page, and see the explanation in the <code>Account</code> controller code.</p>
        </div>
        @If (MvcCaptcha.IsFree) Then
        @:<div class="note warning">
            @:<h3>Free Version Limitations</h3>
            @:<ul>
                @:<li>The free version of BotDetect includes a randomized <code>BotDetect™</code> trademark in the background of 50% of all Captcha images generated.</li>
                @:<li>It also has limited sound functionality, replacing the CAPTCHA sound with "SOUND DEMO" for randomly selected 50% of all CAPTCHA codes.</li>
                @:<li>Lastly, the bottom 10 px of the CAPTCHA image are reserved for a link to the BotDetect website.</li>
            @:</ul>
            @:<p>If you want to remove these limitations, you can <a href="http://captcha.com/shop.html?utm_source=installation&amp;utm_medium=aspnet&amp;utm_campaign=4.4.2" rel="nofollow" title="BotDetect CAPTCHA online store, pricing information, payment options, licensing &amp; upgrading">upgrade</a> your BotDetect license.</p>
        @:</div>
        End If 
    </div>
</div>
<div id="systeminfo">
    <p>Visual Studio 2010 / .NET 4.0 / C# example project.</p>
    <p>@MvcCaptcha.ControlInfo</p>
</div>