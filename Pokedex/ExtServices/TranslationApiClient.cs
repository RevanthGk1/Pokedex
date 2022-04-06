namespace Pokedex.ExtServices
{
    public class TranslationApiClient
    {
        private HttpClient _client;

        public TranslationApiClient()
        {
            _client = new HttpClient();
        }

        internal async Task<string> GetResponseAsync(string desc, string uri)
        {
            string contentstr = string.Empty;

            using (var response = _client.GetAsync(uri + "?text=" + desc))
            {
                contentstr = await response.Result.Content.ReadAsStringAsync();
            }

            return contentstr;
        }
    }
}
