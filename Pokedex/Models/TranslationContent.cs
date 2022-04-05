using Newtonsoft.Json;

namespace Pokedex.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TranslationContent
    {
    //    public Success success { get; set; }
        public Contents contents { get; set; }
    }
    public class Contents
    {
        [JsonProperty("translated")]
        public string translated { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("translation")]
        public string translation { get; set; }
    }

}
