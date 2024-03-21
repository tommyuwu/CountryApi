using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;

namespace Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllCountries_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/country");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetCountryById_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var countryId = 1;

            // Act
            var response = await client.GetAsync($"/api/country/{countryId}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateCountry_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newCountry = new Country { Name = "Test Country" };
            var content = new StringContent(JsonConvert.SerializeObject(newCountry), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/country", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateCountry_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var countryId = 1;
            var updatedCountry = new Country { Id = countryId, Name = "Updated Country" };
            var content = new StringContent(JsonConvert.SerializeObject(updatedCountry), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync($"/api/country/{countryId}", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteCountry_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var countryId = 1;

            // Act
            var response = await client.DeleteAsync($"/api/country/{countryId}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}