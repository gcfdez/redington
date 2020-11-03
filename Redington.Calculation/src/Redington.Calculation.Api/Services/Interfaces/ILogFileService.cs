using Redington.Calculation.Domain;
using System.Threading.Tasks;

namespace Redington.Calculation.Api
{
    public interface ILogFileService
    {
        Task LogInfo(CalculationResult calculationResult);
        Task LogError(string errorMessage, string type);
    }
}
