
using CalculatorDomain.Logic;
using CalculatorDomain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/calculations")]
    public class CalculationsController: ControllerBase
    {
        private readonly CalculatorService _calculator;

        public CalculationsController(CalculatorService calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]  //Get \api\calculations

        public async Task<IActionResult> GetAll()
        {
            var calculations = await _calculator.GetAllAsync();
            return Ok(calculations);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculationRequest request)
        {
            var result = await _calculator.CalculateAsync(request);
            return Ok(result);
        }

    }
}