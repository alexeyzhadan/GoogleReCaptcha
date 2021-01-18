using Newtonsoft.Json;

namespace GoogleReCaptcha.Models
{
    // Model for sending to https://www.google.com/recaptcha/api/siteverify
    public class ReCaptchaData
    {
        [JsonProperty(PropertyName = "secret")]
        public string SecretKey { get; set; }

        [JsonProperty(PropertyName = "response")]
        public string Token { get; set; }
    }
}