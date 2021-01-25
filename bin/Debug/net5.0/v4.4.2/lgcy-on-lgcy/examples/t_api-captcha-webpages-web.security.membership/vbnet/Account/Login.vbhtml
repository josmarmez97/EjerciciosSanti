@* namespace needed to access BotDetect members *@
@Imports BotDetect.Web
@* Remove this section if you are using bundling *@
@Section Scripts
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
End Section

@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Log in"

    ' Initialize general page variables
    Dim email As String = ""
    Dim password As String = ""
    Dim rememberMe As Boolean = False

    Dim returnUrl As String = Request.QueryString("ReturnUrl")
    If returnUrl.IsEmpty() Then
        ' Some external login providers always require a return URL value
        returnUrl = Href("~/")
    End If

    Dim exampleCaptcha As Captcha = New Captcha("ExampleCaptcha")
    exampleCaptcha.UserInputID = "CaptchaCode"
    exampleCaptcha.RemoteScriptEnabled = True
    ' Setup validation
    Validation.RequireField("email", "You must specify an email address.")
    Validation.RequireField("password", "You must specify a password.")
    Validation.Add("password",
        Validator.StringLength(
            maxLength:=Int32.MaxValue,
            minLength:=6,
            errorMessage:="Password must be at least 6 characters"))

    ' If this is a POST request, validate and process data
    If IsPost Then
        AntiForgery.Validate()
        ' is this an external login request?
        Dim provider As String = Request.Form("provider")
        If Not provider.IsEmpty() Then
            OAuthWebSecurity.RequestAuthentication(provider, Href("~/Account/RegisterService", New With {.ReturnUrl = returnUrl}))
            Return
        End If
        Dim isHuman As Boolean = exampleCaptcha.Validate()
        If (Not isHuman) Then
            ModelState.AddFormError("Captcha response was not correct.")
        End If
        If Validation.IsValid() Then
            email = Request.Form("email")
            password = Request.Form("password")
            rememberMe = Request.Form("rememberMe").AsBool()

            If WebSecurity.UserExists(email) AndAlso WebSecurity.GetPasswordFailuresSinceLastSuccess(email) > 4 AndAlso WebSecurity.GetLastPasswordFailureDate(email).AddSeconds(60) > DateTime.UtcNow Then
                Response.Redirect("~/Account/AccountLockedOut")
                Return
            End If

            ' Attempt to log in using provided credentials
            If WebSecurity.Login(email, password, rememberMe) Then
                Context.RedirectLocal(returnUrl)
                Return
            Else
                ModelState.AddFormError("The user name or password provided is incorrect.")
            End If
        End If
    End If


End Code

<hgroup Class="title">
    <h1>@PageData("Title").</h1>
</hgroup>

<section id="loginForm">
    <h2>Use a local account to log in.</h2>
    <form method="post">
        @AntiForgery.GetHtml()
        @* If one or more validation errors exist, show an error *@
        @Html.ValidationSummary("Log in was unsuccessful. Please correct the errors and try again.", excludeFieldErrors:=True, htmlAttributes:=Nothing)

        <fieldset>
            <legend> Log In To Your Account</legend>
            <ol>
                <li Class="email">
                    <Label for="email" @If Not ModelState.IsValidField("email") Then @<text> class="error-label" </text>  End If>Email address</Label>
                    <input type="text" id="email" name="email" value="@email" @Validation.For("email") />
                    @* Write any user name validation errors to the page *@
                    @Html.ValidationMessage("email")
                </li>
                <li Class="password">
                    <Label for="password" @If Not ModelState.IsValidField("password") Then @<text> class="error-label" </text>  End If>Password</Label>
                    <input type="password" id="password" name="password" @Validation.For("password") />
                    @* Write any password validation errors to the page *@
                    @Html.ValidationMessage("password")
                </li>
                <li>
                    @Html.Label("Retype the code from the picture:", "CaptchaCode")
                    @Html.Raw(exampleCaptcha.Html)
                    @Html.TextBox("CaptchaCode")

                </li>
                <li Class="remember-me">
                    <input type="checkbox" id="rememberMe" name="rememberMe" value="true" checked="@rememberMe" />
                    <Label Class="checkbox" for="rememberMe">Remember me?</Label>
                </li>
            </ol>
            <input type="submit" value="Log in" />
        </fieldset>
    </form>
    <p>
        <a href="~/Account/Register"> Don 't have a Account?</a>
        <a href="~/Account/ForgotPassword"> Did you forget your password?</a>
    </p>
    <div id="systeminfo">
        <p>@Captcha.ControlInfo</p>
    </div>
</section>

<section Class="social" id="socialLoginForm">
    <div class="column">
        <div class="note">
            <h3>CAPTCHA Code Example Description</h3>
            <p>This example project shows the most basic source code required to protect an ASP.NET Web Pages form using new Razor syntax with BotDetect CAPTCHA and validate the user input.</p>
        </div>
    </div>
    @If (Captcha.IsFree) Then
        @<div class="column">
            <div class="note warning">
                <h3>Free Version Limitations</h3>
                <ul>
                    <li>The free version of BotDetect only includes a limited subset of the available CAPTCHA image styles and CAPTCHA sound styles.</li>
                    <li>The free version of BotDetect includes a randomized <code>BotDetect™</code> trademark in the background of 50% of all Captcha images generated.</li>
                    <li>It also has limited sound functionality, replacing the CAPTCHA sound with "SOUND DEMO" for randomly selected 50% of all CAPTCHA codes.</li>
                    <li>Lastly, the bottom 10 px of the CAPTCHA image are reserved for a link to the BotDetect website.</li>
                </ul>
                <p>All of these limitations are removed if you <a href="http://captcha.com/shop.html?utm_source=installation&amp;utm_medium=aspnet&amp;utm_campaign=4.4.2" rel="nofollow" title="BotDetect CAPTCHA online store, pricing information, payment options, licensing &amp; upgrading">upgrade</a> your BotDetect license.</p>
            </div>
        </div>
    End If
    <h2> Use another service To log In.</h2>
    @RenderPage("~/Account/_ExternalLoginsList.vbhtml")
</section>
