namespace Pokedex.ExtServices
{
    public class PokeApiClient
    {
        private readonly IConfiguration _configuration;

        public PokeApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetAsync(string name)
        {
            var client = new HttpClient();
            string body = string.Empty;
            var uri = _configuration["Urls:pokiApi"];

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri + name),
            };

            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }
    }
}
