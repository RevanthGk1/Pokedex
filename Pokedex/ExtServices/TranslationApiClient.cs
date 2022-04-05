using Microsoft.Security.Application;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.ExtServices
{
    public class TranslationApiClient
    {
        private readonly IConfiguration _configuration;
        private HttpClient _client = new HttpClient();

        public TranslationApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal async Task<string> GetAsyncYoda(string desc)
        {
            string trnDesc = desc;
            string contentstr = string.Empty;
            var uri = _configuration["Urls:yodaApi"];

            string sanitizedDesc = Sanitizer.GetSafeHtmlFragment(desc);

           // var request = CreateRequest(uri, desc);

            using (var response = _client.GetAsync(uri + "?text=" + sanitizedDesc))
            {
                contentstr = await response.Result.Content.ReadAsStringAsync();
            }

            contentstr = "{    \"success\": {        \"total\": 1    },    \"contents\": {        \"translated\": \"Lost a planet,  master obiwan has.\",        \"text\": \"Master Obiwan has lost a planet.\",        \"translation\": \"yoda\"}}";

            //TranslationContent trnContent = (TranslationContent)CommonService.DeserializeResponse(contentstr, typeof(TranslationContent));
            TranslationContent trnContent = (TranslationContent)JsonConvert.DeserializeObject<TranslationContent>(contentstr);

            if (trnContent != null && trnContent.contents != null && !string.IsNullOrEmpty(trnContent.contents.translated))
            {
                trnDesc = trnContent.contents.translated;
            }

            return trnDesc;
        }

        internal async Task<string> GetAsyncShakespeare(string desc)
        {
            string body = string.Empty;
            var uri = _configuration["Urls:shakespeareApi"];

            var request = CreateRequest(uri, desc);

            using (var response = _client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }

        private HttpRequestMessage CreateRequest(string uri, string desc)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers =
                    {
                        { "Accept", "application/json" },
                    },
                //Content = new StringContent("{\"text\":" +desc+""\"}")
                //    {
                //        Headers =
                //            {
                //              ContentType = new MediaTypeHeaderValue("application/json")
                //            }
                //    }
             };

            //request.Content = new StringContent("\"text\":" + desc);
            //request.Content = new StringContent("{\"text\":\"" + desc + "\"}");

            return request;
        }
    }
}
