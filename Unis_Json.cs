using Newtonsoft.Json;

namespace Task_Unis
{
    public class Unis_Json
    {
        [JsonProperty("name")]
        public string? name { get; set; }
        [JsonProperty("country")]
        public string? country { get; set; }
        [JsonProperty("web_pages")]
        public List<string>? web_pages { get; set; }
        [JsonProperty("domains")]
        public List<string>? domains { get; set; }
        [JsonProperty("alpha_two_code")]
        public string? alpha_two_code { get; set; }
        [JsonProperty("state-province")]
        public string? stateprovince { get; set; }
    }
}
