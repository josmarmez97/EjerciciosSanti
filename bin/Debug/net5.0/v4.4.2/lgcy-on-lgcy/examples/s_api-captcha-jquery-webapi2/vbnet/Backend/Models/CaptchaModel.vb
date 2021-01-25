Imports Newtonsoft.Json

Public Class CaptchaBasicModel

    <JsonProperty("captchaId")>
    Public Property CaptchaId As String

    <JsonProperty("userEnteredCaptchaCode")>
    Public Property UserEnteredCaptchaCode As String
End Class

Public Class CaptchaContactModel

    <JsonProperty("name")>
    Public Property Name As String

    <JsonProperty("email")>
    Public Property Email As String

    <JsonProperty("subject")>
    Public Property Subject As String

    <JsonProperty("message")>
    Public Property Message As String

    <JsonProperty("captchaId")>
    Public Property CaptchaId As String

    <JsonProperty("userEnteredCaptchaCode")>
    Public Property UserEnteredCaptchaCode As String
End Class
