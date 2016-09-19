using PlaceSearch.Models;
using Xunit;

namespace PlaceSearch.Tests
{
    public class PlaceTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var place = new Place();

            //Act
            var result = place.PlaceName;

            //Assert
            Assert.Equal("Wash the dog", result);
        }
    }
}
