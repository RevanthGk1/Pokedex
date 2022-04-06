namespace Pokedex.ExtServices
{
    public class PokeApiClient
    {
       
        private readonly HttpClient _client;

        public PokeApiClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetPokemonByNameAsync(string name, string uri)
        {
            string content = string.Empty;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri + name),
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
