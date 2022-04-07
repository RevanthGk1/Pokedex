namespace Pokedex.ExtServices
{
    public class TranslationApiClient : IDisposable
    {
        private HttpClient _client;

        public TranslationApiClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetResponseAsync(string desc, string uri)
        {
            string contentstr = string.Empty;

            using (var response = _client.GetAsync(uri + "?text=" + desc))
            {
                contentstr = await response.Result.Content.ReadAsStringAsync();
            }

            return contentstr;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
