@* namespaces needed to access BotDetect members *@
@Imports BotDetect.Web.Mvc
@Code
    Layout = Nothing
End Code
<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>BotDetect ASP.NET CAPTCHA Validation: Basic ASP.NET MVC CAPTCHA Code Example</title>
    <link href="@BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Style/Sheet.css")" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="column">
        <h1>BotDetect ASP.NET CAPTCHA Validation: <br /> Basic ASP.NET MVC CAPTCHA Code Example</h1>
        @Using Html.BeginForm()
            @<fieldset>
                <legend>ASP.NET MVC CAPTCHA Validation</legend>
                <div>
                    @Html.Label("CaptchaCode", "Retype the code from the picture:")
                    @Code Dim exampleCaptcha As MvcCaptcha = New MvcCaptcha("ExampleCaptcha")
                    exampleCaptcha.UserInputID = "CaptchaCode"End Code
                    @Html.Captcha(exampleCaptcha)
                </div>
                <div class="actions">
                    @Html.TextBox("CaptchaCode")
                    <input type="submit" value="Validate" />
                    @Html.ValidationMessage("CaptchaCode")
                    @If ((Request.HttpMethod = "POST") And ViewData.ModelState.IsValid) Then
                        @<span class="correct">Correct!</span>
                    End If
                </div>
            </fieldset>
        End Using
    </div>

    <div class="column">
         <div class="column">
             <div class="note">
                 <h3>CAPTCHA Code Example Description</h3>
                 <p>This example project shows the most basic source code required to protect an ASP.NET MVC form with BotDetect CAPTCHA and validate the user input.</p>
                 <p>ASP.NET MVC View code displaying CAPTCHA protection can be found in <code>Views/Example/Index.vbhtml</code>, and the ASP.NET MVC Controller code checking user input is in <code>Controllers/ExampleController.vb</code>.</p>
             </div>
         </div>
        @If (MvcCaptcha.IsFree) Then
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
    </div>

    <div id="systeminfo">
        <p>@MvcCaptcha.ControlInfo</p>
    </div>
</body>

</html>
