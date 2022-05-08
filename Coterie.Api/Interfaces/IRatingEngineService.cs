using System.Collections.Generic;
using Coterie.Api.Models.Responses;

namespace Coterie.Api.Interfaces
{
    public interface IRatingEngineService
    {
        string GetRating(string rating);
    }
}
