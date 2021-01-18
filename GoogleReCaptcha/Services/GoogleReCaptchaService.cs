using GoogleReCaptcha.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleReCaptcha.Services
{
    public class GoogleReCaptchaService
    {
        private const string STRING_FORMAT_OF_PATH_VERIFIED_API = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";

        private readonly ReCaptchaSettings _settings;

        public GoogleReCaptchaService(IOptions<ReCaptchaSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<GoogleResponse> GetResultOfVerification(string token)
        {
            GoogleResponse googleResponse;

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(
                    string.Format(STRING_FORMAT_OF_PATH_VERIFIED_API, _settings.SecretKey, token));

                googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(response);
            }

            return googleResponse;
        }
    }
}