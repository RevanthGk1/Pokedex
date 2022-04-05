namespace Pokedex.ExtServices
{
    public class PokeApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly string _uri;
        private readonly HttpClient _client;

        public PokeApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _uri = _configuration["Urls:pokiApi"];
            _client = new HttpClient();
        }

        public async Task<string> GetPokemonByNameAsync(string name)
        {
            string content = string.Empty;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_uri + name),
            };

            using (var response = _client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                content = await response.Content.ReadAsStringAsync();
            }

            return content;
        }
    }
}
