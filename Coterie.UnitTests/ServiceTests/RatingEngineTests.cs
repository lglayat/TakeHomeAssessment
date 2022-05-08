using Coterie.Api.Models.Requests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.UnitTests.ServiceTests
{
    public class RatingEngineTests : TestServiceTestsBase
    {
        static RatingRequest goodData = new RatingRequest
        {
            Business = "Plumber",
            Revenue = 5000000,
            States = new[] { "TX", "OH" },
        };

        static RatingRequest badData =  new RatingRequest
        {
            Business = "Doctor",
            Revenue = 300000,
            States = new[] { "TX", "NJ" },
        };

        [Test]
        public void ReturnListOf5Results()
        {
            // Act
            var (actual, message) = RatingEngineService.GetRating(goodData);

            // Assert
            Assert.IsNotNull(actual);
            Assert.That(actual.Premiums.First().Premium, Is.EqualTo(9430));
            Assert.That(actual.Premiums.Last().Premium, Is.EqualTo(10000));
        }

        [Test]
        public void ThrowExceptionGivenInvalidData()
        {
            // Arrange
            var (actual, message) = RatingEngineService.GetRating(badData);

            // Assert
            Assert.AreEqual(message, "Invalid State and Business Info");
        }
    }
}
