using Newtonsoft.Json;

namespace Pokedex.Models
{
    /// <summary>
    /// Content structured returned by the Ext Translation Api.
    /// </summary>
    public class TranslationContent
    {
        public Contents contents { get; set; }
    }

    public class Contents
    {
        /// <summary>
        /// Translated text from the response.
        /// </summary>
        [JsonProperty("translated")]
        public string translated { get; set; }

        /// <summary>
        /// Input text sent in the request.
        /// </summary>
        [JsonProperty("text")]
        public string text { get; set; }

        /// <summary>
        /// Translation type ex. yoda,shakespeare, etc.
        /// </summary>
        [JsonProperty("translation")]
        public string translation { get; set; }
    }

}
