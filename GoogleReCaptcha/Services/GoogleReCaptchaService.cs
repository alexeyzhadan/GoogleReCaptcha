using GoogleReCaptcha.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleReCaptcha.Services
{
    public class GoogleReCaptchaService
    {
        private const string PATH_VERIFIED_API = "https://www.google.com/recaptcha/api/siteverify";

        private readonly ReCaptchaSettings _settings;

        public GoogleReCaptchaService(IOptions<ReCaptchaSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<GoogleResponse> GetResultOfVerification(string token)
        {
            GoogleResponse googleResponse;
            var data = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("secret", _settings.SecretKey),
                new KeyValuePair<string, string>("response", token)
            };


            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(PATH_VERIFIED_API, new FormUrlEncodedContent(data));
                var responseAsString = await response.Content.ReadAsStringAsync();

                googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(responseAsString);
            }

            return googleResponse;
        }

        // 2
        //private const string STRING_FORMAT_OF_PATH_VERIFIED_API = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
        //public async Task<GoogleResponse> GetResultOfVerification(string token)
        //{
        //    GoogleResponse googleResponse;

        //    using (var client = new HttpClient())
        //    {
        //        var response = await client.GetStringAsync(
        //            string.Format(STRING_FORMAT_OF_PATH_VERIFIED_API, _settings.SecretKey, token));

        //        googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(response);
        //    }

        //    return googleResponse;
        //}
    }
}