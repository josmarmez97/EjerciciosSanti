@Imports Microsoft.AspNet.Identity
@Code
    ViewBag.Title = "Manage Account"
End Code
@* include BotDetect layout stylesheet in page <head> *@
@Section HeadIncludes
    <link href="@BotDetect.Web.CaptchaUrls.Absolute.LayoutStyleSheetUrl" rel="stylesheet" type="text/css" />
End Section
<h2>@ViewBag.Title.</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
<div class="row">
    <div class="col-md-12">
        @If ViewBag.HasLocalPassword Then
            @Html.Partial("_ChangePasswordPartial")
        Else
            @Html.Partial("_SetPasswordPartial")
        End If

        <section id="externalLogins">
            @Html.Action("RemoveAccountList")
            @Html.Partial("_ExternalLoginsListPartial", New With {.Action = "LinkLogin", .ReturnUrl = ViewBag.ReturnUrl})
        </section>
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/Scripts/captcha.validate.js")
End Section
