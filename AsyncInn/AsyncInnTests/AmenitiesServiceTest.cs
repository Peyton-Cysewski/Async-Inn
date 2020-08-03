using System.Threading.Tasks;
using Xunit;
using AsyncInn.Models.DTOs;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;

namespace AsyncInnTests
{
    public class AmenitiesServiceTest : DatabaseTestClass
    {
        private IAmenity BuildRepository()
        {
            return new AmenityRepository(_db);
        }

        [Fact]
        public async Task CanSaveAnAmenity()
        {
            // Arrange
            var amenity = new AmenityDTO
            {
                ID = 1,
                Name = "Lamp"
            };

            var repository = BuildRepository();
            // Act
            var saved = await repository.Create(amenity);
            // Assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, amenity.ID);
            Assert.Equal(saved.ID, amenity.ID);
            Assert.Equal(saved.Name, amenity.Name);
        }

        [Fact]
        public async Task CanSaveAndGetMultipleAmenities()
        {
            // Arrange
            var amenity1 = new AmenityDTO
            {
                ID = 1,
                Name = "Lamp"
            };
            var amenity2 = new AmenityDTO
            {
                ID = 1,
                Name = "Heater"
            };
            var amenity3 = new AmenityDTO
            {
                ID = 1,
                Name = "Coffee Machine"
            };

            var repository = BuildRepository();
            // Act
            var saved1 = await repository.Create(amenity1);
            var saved2 = await repository.Create(amenity2);
            var saved3 = await repository.Create(amenity3);
            var result = await repository.GetAmenities();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(6, result.Count);
            Assert.Equal("Heater", result[4].Name);
        }


        [Fact]
        public async Task CanPutAndSaveAnAmenity()
        {
            // Arrange
            var amenity = new Amenity
            {
                Id = 1,
                Name = "Lamp"
            };

            var repository = BuildRepository();
            // Act
            await repository.Update(amenity);
            // Assert
            Assert.NotNull(amenity);
            Assert.NotEqual(0, amenity.Id);
            Assert.Equal(_db.Amenities.Find(1), amenity);
        }
    }
}
