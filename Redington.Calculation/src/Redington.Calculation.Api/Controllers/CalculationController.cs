using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redington.Calculation.Domain;

namespace Redington.Calculation.Api
{
    /// <summary>
    /// Controller 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly ILogFileService _logFileService;

        /// <summary>
        /// Initialization injection ILogFileService via DI
        /// </summary>
        /// <param name="logFileService"></param>
        public CalculationController(ILogFileService logFileService)
        {
            _logFileService = logFileService;
        }

        /// <summary>
        /// Action that calculates the result of a combined function
        /// </summary>
        /// <param name="calculationRequest">Inputs</param>
        /// <returns></returns>
        [HttpPost]
        [Route("combinedWith")]
        public async Task<IActionResult> CalculateCombinedWithFunction([FromBody] CalculationRequest calculationRequest)
        {
            try
            {
                var function = new CombinedWithFunction(calculationRequest.A, calculationRequest.B);

                var calculationResult = function.GetCalculationResult();

                await _logFileService.LogInfo(calculationResult);

                return Ok(calculationResult);
            }
            catch (Exception ex)
            {
                await _logFileService.LogError(ex.Message, "CombinedWith");

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action that calculates the result of an either function
        /// </summary>
        /// <param name="calculationRequest">Inputs</param>
        /// <returns></returns>
        [HttpPost]
        [Route("either")]
        public async Task<IActionResult> CalculateEitherFunction([FromBody] CalculationRequest calculationRequest)
        {
            try
            {
                var function = new EitherFunction(calculationRequest.A, calculationRequest.B);

                var calculationResult = function.GetCalculationResult();

                await _logFileService.LogInfo(calculationResult);

                return Ok(calculationResult);
            }
            catch (Exception ex)
            {
                await _logFileService.LogError(ex.Message, "Either");

                return BadRequest(ex.Message);
            }
        }
    }
}
