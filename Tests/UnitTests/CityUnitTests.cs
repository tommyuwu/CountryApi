using Application.Services;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;

namespace Tests.UnitTests
{
    public class CityUnitTests
    {
        Mock<ICityRepository> mock = new Mock<ICityRepository>();

        [Fact]
        public async void GetCityById_ReturnsCityWithMatchingId()
        {
            // Arrange
            var cityId = 1;
            var countryId = 1;
            var expectedCityName = "Paraguay";

            mock.Setup(x => x.GetCityById(It.IsAny<long>()).Result)
              .Returns(new City { Id = cityId, Name = expectedCityName, CountryId = countryId });

            var sut = new CityService(mock.Object);

            // Act
            var city = await sut.GetCityById(cityId);

            // Assert
            city.Should().NotBeNull();
            city.Should().BeOfType<City>();
        }

        [Fact]
        public async void CreateCity_CreatesNewCityInDatabase()
        {
            // Arrange
            var cityName = "Buenos Aires";
            var countryId = 1;

            mock.Setup(x => x.AddCity(It.IsAny<City>())).Verifiable();

            var sut = new CityService(mock.Object);

            // Act
            await sut.AddCity(new City { Name = cityName, CountryId = countryId });

            //assert
            mock.Verify(x => x.AddCity(It.IsAny<City>()), Times.Once);
        }

        [Fact]
        public async void UpdateCity_UpdatesCityName()
        {
            // Arrange
            var cityId = 2;
            var countryId = 1;
            var newName = "Brasil";

            mock.Setup(x => x.UpdateCity(It.IsAny<City>())).Verifiable();

            var sut = new CityService(mock.Object);

            // Act
            await sut.UpdateCity(new City { Id = cityId, Name = newName, CountryId = countryId });

            // Assert
            mock.Verify(x => x.UpdateCity(It.IsAny<City>()), Times.Once);
        }

        [Fact]
        public async void DeleteCity_RemovesCityFromDatabase()
        {
            var cityId = 3;

            mock.Setup(x => x.DeleteCity(It.IsAny<long>())).Verifiable();

            var sut = new CityService(mock.Object);

            // Act
            await sut.DeleteCity(cityId);

            // Assert
            mock.Verify(x => x.DeleteCity(It.IsAny<long>()), Times.Once);
        }
    }
}
