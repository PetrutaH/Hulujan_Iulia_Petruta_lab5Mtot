using Hulujan_Iulia_Petruta_lab5M.Models;
using System.Threading.Tasks;

namespace Hulujan_Iulia_Petruta_lab5M.Services
{
    public interface IRiskPredictionService
    {
        Task<string> PredictRiskAsync(RiskInput input);
    }
}
