namespace GoogleReCaptcha.Models
{
    // Settings of reCaptcha from the application.json
    public class ReCaptchaSettings
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
    }
}