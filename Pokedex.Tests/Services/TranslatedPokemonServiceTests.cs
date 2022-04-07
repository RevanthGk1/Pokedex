using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Cache;
using Pokedex.Models;
using Pokedex.Services;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokedexTests.Tests
{
    [TestClass()]
    public class TranslatedPokemonServiceTests
    {
        internal TranslatedPokemonService _trnPokemonSvc;

        [TestInitialize()]
        public void SetUp()
        {

            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            TranslatedCacheManager svc = new TranslatedCacheManager(configuration);

            _trnPokemonSvc = new TranslatedPokemonService(configuration, svc);
        }

        [TestMethod()]
        public async Task GetAsyncTest_ValidName_ReturnsValidPokemonAsync()
        {
            //Arrange
            string nameOnix = "onix";
            string namePikachu = "pikachu";

            //Expected
            Pokemon expPokemonOnix = GetExpectedPokemon(nameOnix);
            Pokemon expPokemonPikachu = GetExpectedPokemon(namePikachu);

            // Act
            Pokemon resPokemonOnix = await _trnPokemonSvc.GetAsync(nameOnix);
            Pokemon resPokemonPikachu = await _trnPokemonSvc.GetAsync(namePikachu);

            // Assert
            Assert.IsNotNull(resPokemonOnix);
            Assert.IsNotNull(resPokemonPikachu);
            Assert.AreEqual(expPokemonOnix.Id, resPokemonOnix.Id);
            Assert.AreEqual(expPokemonPikachu.Id, resPokemonPikachu.Id);
            Assert.AreEqual(expPokemonOnix.Description, resPokemonOnix.Description);
            Assert.AreEqual(expPokemonPikachu.Description, resPokemonPikachu.Description);

        }

        [TestMethod()]
        public async Task GetAsyncTest_NonExistantName_ReturnsException()
        {
            string name = "NonExistantPokemonName";
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _trnPokemonSvc.GetAsync(name));
        }

        [TestMethod()]
        public async Task GetAsyncTest_SuspiciousText_ReturnsException()
        {
            string name = "<script>";

            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _trnPokemonSvc.GetAsync(name));
        }

        public Pokemon GetExpectedPokemon(string name)
        {
            Pokemon pokemonOnix = new Pokemon()
            {
                Name = "onix",
                Id = 95,
                Description = "Opening its large mouth,Long tunnels,  it ingests massive amounts of soil and creates.",
                Habitat = "cave",
                IsLegendary = false
            };

            Pokemon pokemonPikachu = new Pokemon()
            {
                Name = "pikachu",
                Id = 25,
                Description = "At which hour several of these pokémon gather,  their electricity couldst buildeth and cause lightning storms.",
                Habitat = "forest",
                IsLegendary = false
            };

            if (name == "onix")
            {
                return pokemonOnix;
            }

            return pokemonPikachu;
        }
    }
}