using Newtonsoft.Json;

namespace ReactWebAPICaptchaExampleCSharp.Backend.Models
{
    public class CaptchaBasicModel
    {
        [JsonProperty("captchaId")]
        public string CaptchaId { get; set; }

        [JsonProperty("userEnteredCaptchaCode")]
        public string UserEnteredCaptchaCode { get; set; }
    }

    public class CaptchaContactModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("captchaId")]
        public string CaptchaId { get; set; }

        [JsonProperty("userEnteredCaptchaCode")]
        public string UserEnteredCaptchaCode { get; set; }

    }
}