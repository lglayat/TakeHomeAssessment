using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.UnitTests
{
    public class RatingEngineControllerTests : ControllerTestsBase
    {
        static RatingRequest goodData = new RatingRequest
        {
            Business = "Plumber",
            Revenue = 5000000,
            States = new[] { "TX", "OH" },
        };

        static RatingRequest badData = new RatingRequest
        {
            Business = "Doctor",
            Revenue = 3000000,
            States = new[] { "TX", "NJ" },
        };

        [Test]
        public void TestGoodRequest()
        {
            // Act
            var result = RatingEngineController.GetRating(goodData);

            // Assert
            Assert.IsNotNull(result.Value);
            Assert.That(result.Value.Premiums.First().Premium, Is.EqualTo(9430));
            Assert.That(result.Value.Premiums.Last().Premium, Is.EqualTo(10000));
        }

        [Test]
        public void TestBadRequest()
        {
            // Act
            var result = RatingEngineController.GetRating(badData);
            var result2 = (BadRequestObjectResult)result.Result;
            
            // Assert
            Assert.AreEqual(result2.StatusCode, 400);
            Assert.AreEqual(result2.Value, "Invalid State and Business Info");
        }
    }
}
