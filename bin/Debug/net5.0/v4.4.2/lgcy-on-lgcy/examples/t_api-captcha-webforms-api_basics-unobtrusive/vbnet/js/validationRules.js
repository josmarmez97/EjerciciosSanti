$(document).ready(function() {

  $("#form1").validate({
    // the Captcha input must only be validated when the whole code string is
    // typed in, not after each individual character (onkeyup must be false)
    onkeyup: false,
    // since the example form only has one input element, it doesn't make sense
    // to validate it immediately after it loses focus
    onfocusout: false,
    // customize client-side error display elements
    errorClass: "incorrect",
    validClass: "correct",
    errorElement: "label",
    // always reload the Captcha image if remote validation failed,
    // since it will not be usable any more (a failed validation attempt
    // removes the attempted code for necessary Captcha security
    showErrors: function(errorMap, errorList) {
      this.defaultShowErrors();
      for (var i=0; i<errorList.length; i++) {
        var element = errorList[i].element;
        var message = errorList[i].message;
        // check element css class and does the error message match remote
        // validation failure
        if (element.className.match(/captchaVal/) &&
            message === this.settings.messages[element.id].remote) {
              element.Captcha.ReloadImage();
        }
      }
    }
  });

  // add validation rules by CSS class, so we don't have to know the
  // exact client id of the Captcha code textbox
  $(".captchaVal").rules('add', {
    required: true,
    remote: $(".captchaVal").get(0).Captcha.ValidationUrl,
    messages: {
      required: 'Required (client)',
      remote: 'Incorrect (client)'
    }
  });

});