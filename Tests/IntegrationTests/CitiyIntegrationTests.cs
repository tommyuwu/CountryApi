using Domain.Entities;
using Newtonsoft.Json;
using System.Text;

namespace Tests.IntegrationTests
{
    public class CitiyIntegrationTests(TestingWebAppFactory<Program> factory) : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task GetAllCities_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _client;

            // Act
            var response = await client.GetAsync("/api/city");
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetCitiesByCountryId_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _client;
            var countryId = 1;

            // Act
            var response = await client.GetAsync($"api/city/country/{countryId}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetCityById_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _client;
            var cityId = 1;

            // Act
            var response = await client.GetAsync($"/api/city/{cityId}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateCity_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _client;
            long cityId = 1;
            var newCity = new City { Name = "Test City", CountryId = cityId };
            var content = new StringContent(JsonConvert.SerializeObject(newCity), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/city", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateCity_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _client;
            long cityId = 1;
            long countryId = 1;
            var updatedCity = new City { Id = cityId, Name = "Updated City", CountryId = countryId };
            var content = new StringContent(JsonConvert.SerializeObject(updatedCity), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/api/city", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteCity_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _client;
            var cityId = 1;

            // Act
            var response = await client.DeleteAsync($"/api/city/{cityId}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
