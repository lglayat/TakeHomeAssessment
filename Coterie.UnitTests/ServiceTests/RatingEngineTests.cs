using Coterie.Api.Models.Requests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.UnitTests
{
    public class RatingEngineTests : TestServiceTestsBase
    {
        static RatingRequest goodDataAbbrev = new RatingRequest
        {
            Business = "Plumber",
            Revenue = 5000000,
            States = new[] { "TX", "OH" },
        };

        static RatingRequest goodDataFullName = new RatingRequest
        {
            Business = "Plumber",
            Revenue = 5000000,
            States = new[] { "texas", "ohio" },
        };

        static RatingRequest badData =  new RatingRequest
        {
            Business = "Doctor",
            Revenue = 3000000,
            States = new[] { "TX", "NJ" },
        };

        [Test]
        public void ReturnPremiumsForGoodDataStateAbbreviations()
        {
            // Act
            var (actual, message) = RatingEngineService.GetRating(goodDataAbbrev);

            // Assert
            Assert.IsNotNull(actual);
            Assert.That(actual.Premiums.First().Premium, Is.EqualTo(9430));
            Assert.That(actual.Premiums.Last().Premium, Is.EqualTo(10000));
        }

        [Test]
        public void ReturnPremiumsForGoodDataStateFullName()
        {
            // Act
            var (actual, message) = RatingEngineService.GetRating(goodDataFullName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.That(actual.Premiums.First().Premium, Is.EqualTo(9430));
            Assert.That(actual.Premiums.Last().Premium, Is.EqualTo(10000));
        }

        [Test]
        public void ReturnMessageGivenInvalidData()
        {
            // Arrange
            var (actual, message) = RatingEngineService.GetRating(badData);

            // Assert
            Assert.IsNull(actual);
            Assert.AreEqual(message, "Invalid State and Business Info");
        }
    }
}
