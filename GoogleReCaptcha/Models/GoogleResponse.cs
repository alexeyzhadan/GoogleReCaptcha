using Newtonsoft.Json;
using System;

namespace GoogleReCaptcha.Models
{
    public class GoogleResponse
    {
        public bool Success { get; set; }

        public double Score { get; set; }

        public string Action { get; set; }

        [JsonProperty(PropertyName = "challenge_ts")]
        public DateTime ChallengeTimeSpan { get; set; }

        public string Hostname { get; set; }
    }
}