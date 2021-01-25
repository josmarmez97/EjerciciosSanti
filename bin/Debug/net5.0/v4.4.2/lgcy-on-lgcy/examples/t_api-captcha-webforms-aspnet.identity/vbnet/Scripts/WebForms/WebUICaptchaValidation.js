// CAPTCHA client-side validation function
function ValidateCaptcha(source, arguments) {
    var captcha = $(".captchaVal").get(0).Captcha;
    var validationUrl = captcha.ValidationUrl + "&i=" + arguments.Value;
    $.getJSON(validationUrl, function (data) {
        // WebUIValidation.js status update
        source.isvalid = data;
        ValidatorUpdateDisplay(source);
        ValidatorUpdateIsValid();

        // reload the Captcha image if validation failed
        if (!data) { captcha.ReloadImage(); }
    });
}