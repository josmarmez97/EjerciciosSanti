namespace ReactWebAPIwithMVC6CaptchaExample.Models
{
    public class ContactFormModel
	{
		public string CaptchaId { get; set; }
		public string UserEnteredCaptchaCode { get; set; }

		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}
