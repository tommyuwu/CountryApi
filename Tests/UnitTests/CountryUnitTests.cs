using Application.Services;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;

namespace Tests.UnitTests
{
    public class CountryUnitTests
    {
        Mock<ICountryRepository> mock = new Mock<ICountryRepository>();

        [Fact]
        public async void GetCountryById_ReturnsCountryWithMatchingId()
        {
            // Arrange
            var countryId = 1;
            var expectedCountryName = "Paraguay";

            mock.Setup(x => x.GetCountryById(It.IsAny<long>()).Result)
              .Returns(new Country { Id = countryId, Name = expectedCountryName });

            var sut = new CountryService(mock.Object);

            // Act
            var country = await sut.GetCountryById(countryId);

            Console.WriteLine(country);
            // Assert
            country.Should().NotBeNull();
            country.Should().BeOfType<Country>();
        }

        [Fact]
        public async void CreateCountry_CreatesNewCountryInDatabase()
        {
            // Arrange
            var countryName = "Nueva Zelanda";

            mock.Setup(x => x.AddCountry(It.IsAny<Country>())).Verifiable();

            var sut = new CountryService(mock.Object);

            // Act
            await sut.AddCountry(new Country { Name = countryName });

            //assert
            mock.Verify(x => x.AddCountry(It.IsAny<Country>()), Times.Once);
        }

        [Fact]
        public async void UpdateCountry_UpdatesCountryName()
        {
            // Arrange
            var countryId = 2;
            var newName = "Brasil";

            mock.Setup(x => x.UpdateCountry(It.IsAny<Country>())).Verifiable();

            var sut = new CountryService(mock.Object);

            // Act
            await sut.UpdateCountry(new Country { Id = countryId, Name = newName });

            // Assert
            mock.Verify(x => x.UpdateCountry(It.IsAny<Country>()), Times.Once);
        }

        [Fact]
        public async void DeleteCountry_RemovesCountryFromDatabase()
        {
            var countryId = 3;

            mock.Setup(x => x.DeleteCountry(It.IsAny<long>())).Verifiable();

            var sut = new CountryService(mock.Object);

            // Act
            await sut.DeleteCountry(countryId);

            // Assert
            mock.Verify(x => x.DeleteCountry(It.IsAny<long>()), Times.Once);
        }
    }
}