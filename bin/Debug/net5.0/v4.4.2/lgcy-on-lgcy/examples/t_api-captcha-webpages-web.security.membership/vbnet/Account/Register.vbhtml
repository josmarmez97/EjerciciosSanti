﻿@* namespace needed to access BotDetect members *@
@Imports BotDetect.Web
@* Remove this section if you are using bundling *@
@Section Scripts
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
End Section

@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Register"

    ' Initialize general page variables
    Dim email As String = ""
    Dim password As String = ""
    Dim confirmPassword As String = ""

    ' Setup validation
    Validation.RequireField("email", "The email address field is required.")
    Validation.RequireField("password", "Password cannot be blank.")
    Validation.Add("confirmPassword",
        Validator.EqualsTo("password", "Password and confirmation password do not match."))
    Validation.Add("password",
        Validator.StringLength(
            maxLength:=Int32.MaxValue,
            minLength:=6,
            errorMessage:="Password must be at least 6 characters"))

    Dim exampleCaptcha As Captcha = New Captcha("ExampleCaptcha")
    exampleCaptcha.UserInputID = "CaptchaCode"
    exampleCaptcha.RemoteScriptEnabled = True

    ' If this is a POST request, validate and process data
    If IsPost Then
        AntiForgery.Validate()
        email = Request.Form("email")
        password = Request.Form("password")
        confirmPassword = Request.Form("confirmPassword")

        Dim isHuman As Boolean = exampleCaptcha.Validate()
        If (Not isHuman) Then
            ModelState.AddFormError("Captcha response was not correct.")
        End If

        ' If all information is valid, create a new account
        If Validation.IsValid() Then
            ' Insert a new user into the database
            Dim db As Database = Database.Open("StarterSite")

            ' Check if user already exists
            Dim user As Object = db.QuerySingle("SELECT Email FROM UserProfile WHERE LOWER(Email) = LOWER(@0)", email)
            If user Is Nothing Then
                ' Insert email into the profile table
                db.Execute("INSERT INTO UserProfile (Email) VALUES (@0)", email)

                ' Create and associate a new entry in the membership database.
                ' If successful, continue processing the request
                Try
                    Dim requireEmailConfirmation As Boolean = Not WebMail.SmtpServer.IsEmpty()
                    Dim token As String = WebSecurity.CreateAccount(email, password, requireEmailConfirmation)
                    If requireEmailConfirmation Then
                        Dim hostUrl As String = Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped)
                        Dim confirmationUrl As String = hostUrl + VirtualPathUtility.ToAbsolute("~/Account/Confirm?confirmationCode=" + HttpUtility.UrlEncode(token))

                        WebMail.Send(
                            to:=email,
                            subject:="Please confirm your account",
                            body:="Your confirmation code is: " + token + ". Visit <a href=""" + confirmationUrl + """>" + confirmationUrl + "</a> to activate your account."
                        )
                    End If

                    If requireEmailConfirmation Then
                        ' Thank the user for registering and let them know an email is on its way
                        Response.Redirect("~/Account/Thanks")
                    Else
                        ' Navigate back to the homepage and exit
                        WebSecurity.Login(email, password)

                        Response.Redirect("~/")
                    End If
                Catch e As System.Web.Security.MembershipCreateUserException
                    ModelState.AddFormError(e.Message)
                End Try
            Else
                ' User already exists
                ModelState.AddFormError("Email address is already in use.")
            End If
        End If
    End If
End Code

<hgroup class="title">
    <h1>@PageData("Title").</h1>
    <h2>Create a new account.</h2>
</hgroup>

<form method="post">
    @AntiForgery.GetHtml()
    @* If at least one validation error exists, notify the user *@
    @Html.ValidationSummary("Account creation was unsuccessful. Please correct the errors and try again.", excludeFieldErrors:=True, htmlAttributes:=Nothing)

    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li class="email">
                <label for="email" @If Not ModelState.IsValidField("email") Then @<text> class="error-label" </text>  End If>Email address</label>
                <input type="text" id="email" name="email" value="@email" @Validation.For("email") />
                @* Write any email validation errors to the page *@
                @Html.ValidationMessage("email")
            </li>
            <li class="password">
                <label for="password" @If Not ModelState.IsValidField("password") Then @<text> class="error-label" </text>  End If>Password</label>
                <input type="password" id="password" name="password" @Validation.For("password") />
                @* Write any password validation errors to the page *@
                @Html.ValidationMessage("password")
            </li>
            <li class="confirm-password">
                <label for="confirmPassword" @If Not ModelState.IsValidField("confirmPassword") Then @<text> class="error-label" </text>  End If>Confirm password</label>
                <input type="password" id="confirmPassword" name="confirmPassword" @Validation.For("confirmPassword") />
                @* Write any password validation errors to the page *@
                @Html.ValidationMessage("confirmPassword")
            </li>
            <li>
                @Html.Label("Retype the code from the picture:", "CaptchaCode")
                @Html.Raw(exampleCaptcha.Html)
                @Html.TextBox("CaptchaCode")

            </li>

            <li class="column">
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
            </li>
        </ol>
        <input type="submit" value="Register" />
    </fieldset>
</form>

<div id="systeminfo">
    <p>@Captcha.ControlInfo</p>
</div>