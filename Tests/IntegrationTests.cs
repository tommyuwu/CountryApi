using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class IntegrationTests(WebApplicationFactory<IStartup> factory) : IClassFixture<WebApplicationFactory<IStartup>>
    {
        private readonly WebApplicationFactory<IStartup> _factory = factory;

        [Fact]
        public async Task Get_EndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/v1/countries");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

    }

}
