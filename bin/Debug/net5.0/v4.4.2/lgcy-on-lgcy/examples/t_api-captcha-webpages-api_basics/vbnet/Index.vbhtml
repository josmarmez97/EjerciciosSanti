@* namespace needed to access BotDetect members *@
@Imports BotDetect.Web

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <title>BotDetect ASP.NET CAPTCHA Validation: Basic ASP.NET WebPages CAPTCHA Code Example</title>
    <link href="@CaptchaUrls.Absolute.LayoutStyleSheetUrl" rel="stylesheet" type="text/css" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form method="post" class="column">
        <h1>BotDetect ASP.NET CAPTCHA Validation: <br /> Basic ASP.NET WebPages CAPTCHA Code Example</h1>
        <fieldset>
            <legend>ASP.NET WebPage CAPTCHA Validation</legend>
            @Html.Label("Retype the code from the picture:", "CaptchaCode")
            @Code
                Dim exampleCaptcha As Captcha = New Captcha("ExampleCaptcha")
                exampleCaptcha.UserInputID = "CaptchaCode"
            End Code
            @Html.Raw(exampleCaptcha.Html)
            <div class="validationDiv">
                @Html.TextBox("CaptchaCode")
                <input type="submit" value="Validate" />
                @If ((Request.HttpMethod = "POST")) Then
                    Dim isHuman As Boolean = exampleCaptcha.Validate()
                    If (isHuman) Then
                    @<span class="correct">Correct!</span>
                    Else
                    @<span class="incorrect">Incorrect!</span>
                    End If
                End If
            </div>
        </fieldset>
    </form>

    
    <div class="column">
        <div class="column">
            <div class="note">
                <h3>CAPTCHA Code Example Description</h3>
                <p>This example project shows the most basic source code required to protect an ASP.NET MVC form with BotDetect CAPTCHA and validate the user input.</p>
                <p>ASP.NET MVC View code displaying CAPTCHA protection can be found in <code>Views/Example/Index.vbhtml</code>, and the ASP.NET MVC Controller code checking user input is in <code>Controllers/ExampleController.vb</code>.</p>
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
    </div>

    <div id="systeminfo">
        <p>@Captcha.ControlInfo</p>
    </div>
</body>

</html>
