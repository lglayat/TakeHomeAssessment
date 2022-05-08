using System.Linq;
using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Coterie.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingEngineController : CoterieBaseController
    {
        private readonly IRatingEngineService _ratingEngineService;

        public RatingEngineController(IRatingEngineService ratingEngineService)
        {
            _ratingEngineService = ratingEngineService;
        }

        /// <summary>
        /// Takes in business parameters and the rating engine outputs a premiums based on valid data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost]
        public ActionResult<RatingResponse> GetRating(RatingRequest request)
        {
            var (result, message) = _ratingEngineService.GetRating(request);

            if (result == null)
            {
                return BadRequest(message);
            }

            return result;
        }
    }
}
