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
        /// Takes in rating parameters and the rating engine outputs a quote based on valid data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ItemResponse<RatingResponse>> SubmitData(RatingRequest request)
        {
            var result = _ratingEngineService.GetRating(string.Empty);
            return new ItemResponse<RatingResponse>();
        }
    }
}
