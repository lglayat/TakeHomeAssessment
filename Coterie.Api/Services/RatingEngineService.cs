using System;
using System.Collections.Generic;
using System.Linq;
using Coterie.Api.Interfaces;
using Coterie.Api.Models.Data;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;


namespace Coterie.Api.Services
{
    public class RatingEngineService : IRatingEngineService
    {
        private readonly Dictionary<string, State> _stateInfo;
        private readonly Dictionary<string, decimal> _businessInfo;
        private readonly int HAZARD_FACTOR = 4;

        public RatingEngineService()
        {
            State ohio = new State
            {
                Name = "Ohio",
                Abbreviation = "OH",
                StateFactor = 1,
            };

            State florida = new State
            {
                Name = "Florida",
                Abbreviation = "FL",
                StateFactor = 1.2m,
            };

            State texas = new State
            {
                Name = "Texas",
                Abbreviation = "TX",
                StateFactor = .943m,
            };


            _stateInfo = new Dictionary<string, State>
            {
                ["OH"] = ohio,
                ["OHIO"] = ohio,
                ["FL"] = florida,
                ["FLORIDA"] = florida,
                ["TX"] = texas,
                ["TEXAS"] = texas,
            };

            _businessInfo = new Dictionary<string, decimal>
            {
                ["Architect"] = 1,
                ["Plumber"] = .5m,
                ["Programmer"] = 1.25m,
            };

        }

        public (RatingResponse, string) GetRating(RatingRequest request)
        {
            // Step 1. Data Validations
            bool isValidBusiness = _businessInfo.ContainsKey(request.Business);
            bool isValidStates = IsValidStateList(request.States);

            if (!isValidStates && !isValidBusiness)
                return (null, "Invalid State and Business Info");
            else if (!isValidBusiness)
                return (null, "Invalid Business Info");
            else if(!isValidStates)
                return (null, "Invalid State Info");

            // Step 2. Process Premiums
            decimal busniessFactor = _businessInfo[request.Business];
            decimal basePremium = Math.Ceiling(request.Revenue / 1000);

            var response = new RatingResponse
            {
                Business = request.Business,
                Revenue = request.Revenue
            };

            List<PremiumWrapper> premiums = new List<PremiumWrapper>();
            foreach (var state in request.States)
            {
                premiums.Add(new PremiumWrapper
                {
                    State = _stateInfo[state.ToUpper()].Abbreviation,
                    Premium = GeneratePremium(_stateInfo[state.ToUpper()].StateFactor, busniessFactor, basePremium, HAZARD_FACTOR),
                });
            }
            response.Premiums = premiums.ToArray();

            return (response, "OK");
        }

        public decimal GeneratePremium(decimal stateFactor, decimal businessFactor, decimal basePremium, int hazardFactor)
        {
            return Math.Round(stateFactor * businessFactor * basePremium * hazardFactor, 2);
        }

        #region Private
        private bool IsValidStateList(string[] states)
        {
            foreach(var state in states)
            {
                if (!_stateInfo.ContainsKey(state.ToUpper()))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}



