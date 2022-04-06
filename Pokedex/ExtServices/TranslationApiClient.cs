using Microsoft.Security.Application;
using Newtonsoft.Json;
using Pokedex.Models;

namespace Pokedex.ExtServices
{
    public class TranslationApiClient
    {
        private readonly IConfiguration _configuration;
        private HttpClient _client;

        public TranslationApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
        }

        internal async Task<string> GetAsyncYoda(string desc)
        {
            string trnDesc = string.Empty;
            var uri = _configuration["Urls:yodaApi"];
            trnDesc = await GetResponseAsync(desc, uri);
            return trnDesc;
        }

        internal async Task<string> GetAsyncShakespeare(string desc)
        {
            string trnDesc = string.Empty;
            var uri = _configuration["Urls:shakespeareApi"];
            trnDesc = await GetResponseAsync(desc, uri);
            return trnDesc;
        }

        private async Task<string> GetResponseAsync(string desc, string uri)
        {
            string trnDesc = desc;
            string contentstr = string.Empty;
            string sanitizedDesc = Sanitizer.GetSafeHtmlFragment(desc);

            using (var response = _client.GetAsync(uri + "?text=" + sanitizedDesc))
            {
                contentstr = await response.Result.Content.ReadAsStringAsync();
            }

            TranslationContent trnContent = JsonConvert.DeserializeObject<TranslationContent>(contentstr);

            if (trnContent != null && trnContent.contents != null && !string.IsNullOrEmpty(trnContent.contents.translated))
            {
                trnDesc = trnContent.contents.translated;
            }

            return trnDesc;
        }
    }
}
