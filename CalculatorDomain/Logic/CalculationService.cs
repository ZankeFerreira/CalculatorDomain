using CalculatorDomain;
using CalculatorDomain.Domain;
using CalculatorDomain.Persistence;

namespace CalculatorDomain.Logic
{
    public class CalculatorService
    {
        private readonly ICalculationStore _store;

        public CalculatorService(ICalculationStore store)
        {
            _store = store;
        }

        public async Task<Calculation> CalculateAsync(CalculationRequest request)
        {
            if (request.Operation == OperationType.Divide && request.right == 0)
                throw new InvalidOperationException("Division by zero is not allowed.");

            double result = request.Operation switch
            {
                OperationType.Add => request.left + request.right,
                OperationType.Subtract => request.left - request.right,
                OperationType.Multiply => request.left * request.right,
                OperationType.Divide => request.left / request.right,
                _ => throw new InvalidOperationException("Unsupported operation.")
            };

            var calculation = new Calculation(
                0, // id will be set by the store
                request.left,
                request.right,
                request.Operation,
                result,
                DateTime.UtcNow);

            await _store.SaveAsync(calculation);

            return calculation;
        }

        public Task<IReadOnlyList<Calculation>> GetAllAsync()
        {
            return _store.LoadAllAsync();
        }
    }
}