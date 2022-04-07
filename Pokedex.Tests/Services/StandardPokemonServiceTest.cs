using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Cache;
using Pokedex.Models;
using Pokedex.Services;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Tests
{
    [TestClass()]
    public class StandardPokemonServiceTest
    {
        private StandardPokemonService _stdPokemonSvc;

        [TestInitialize()]
        public void SetUp()
        {

            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);                       

            IConfigurationRoot configuration = builder.Build();
            StandardCacheManager svc = new StandardCacheManager(configuration);

            _stdPokemonSvc = new StandardPokemonService(configuration, svc);
        }

        [TestMethod()]
        public async Task GetAsyncTest_ValidName_ReturnsValidPokemonAsync()
        {
            //Arrange
            string nameOnix = "onix";
            string namePikachu = "pikachu";

            //Expected
            Pokemon expPokemonOnix = GetPokemon(nameOnix);
            Pokemon expPokemonPikachu = GetPokemon(namePikachu);

            // Act
            Pokemon resPokemonOnix = await _stdPokemonSvc.GetAsync(nameOnix);
            Pokemon resPokemonPikachu = await _stdPokemonSvc.GetAsync(namePikachu);

            // Assert
            Assert.IsNotNull(resPokemonOnix);
            Assert.IsNotNull(resPokemonPikachu);
            Assert.AreEqual(expPokemonOnix.Id, resPokemonOnix.Id);
            Assert.AreEqual(expPokemonOnix.Description, resPokemonOnix.Description);
            Assert.AreEqual(expPokemonPikachu.Description, resPokemonPikachu.Description);

        }

        [TestMethod()]
        public async Task GetAsyncTest_NonExistantName_ReturnsException()
        {
            string name = "NonExistantPokemonName";
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _stdPokemonSvc.GetAsync(name));   
        }

        [TestMethod()]
        public async Task GetAsyncTest_SuspiciousText_ReturnsException()
        {
            string name = "<script>";

            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _stdPokemonSvc.GetAsync(name));
        }


        private Pokemon GetPokemon(string name)
        {
            Pokemon pokemonOnix = new Pokemon()
            {
                Name = "onix",
                Id = 95,
                Description = "Opening its large mouth, it ingests\nmassive amounts of soil and creates\nlong tunnels.",
                Habitat = "cave",
                IsLegendary = false
            };

            Pokemon pokemonPikachu = new Pokemon()
            {
                Name = "pikachu",
                Id = 25,
                Description = "When several of\nthese POKéMON\ngather, their\felectricity could\nbuild and cause\nlightning storms.",
                Habitat = "forest",
                IsLegendary = false
            };

            if(name == "onix")
            {
                return pokemonOnix;
            }

            return pokemonPikachu;
        }
    }
}