using CalculatorDomain.Domain;

namespace CalculatorDomain.Persistence
{
    public interface ICalculationStore
    {
        Task SaveAsync(Calculation calculation);
        Task<IReadOnlyList<Calculation>> LoadAllAsync();
    }
}