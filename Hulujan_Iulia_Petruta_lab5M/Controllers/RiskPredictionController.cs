using Microsoft.AspNetCore.Mvc;
using Hulujan_Iulia_Petruta_lab5M.Models;
using Hulujan_Iulia_Petruta_lab5M.Services;
using System.Threading.Tasks;

namespace Hulujan_Iulia_Petruta_lab5M.Controllers
{
    public class RiskPredictionController : Controller
    {
        private readonly IRiskPredictionService _riskService;

        public RiskPredictionController(IRiskPredictionService riskService)
        {
            _riskService = riskService;
        }
        // GET: /RiskPrediction/Index
        [HttpGet]
        public IActionResult Risk()
        {

            var model = new RiskPredictionViewModel();
            return View("~/Views/Prediction/Risk.cshtml", model);
        }

        // POST: /RiskPrediction/Index
        [HttpPost]
        public async Task<IActionResult> Risk(RiskPredictionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Prediction/Risk.cshtml", model);
            }
            var input = new RiskInput
            {
                InspectionType = model.InspectionType,
                ViolationDescription = model.ViolationDescription
            };
            // apelăm Web API-ul
            var prediction = await _riskService.PredictRiskAsync(input);
            model.PredictedRisk = prediction;
            return View("~/Views/Prediction/Risk.cshtml", model);
        }
    }
    //public IActionResult Index()
    //{
    //    return View();
    //}
}
