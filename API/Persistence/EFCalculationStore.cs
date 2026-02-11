
using CalculatorDomain.Domain;
using Microsoft.EntityFrameworkCore;

namespace CalculatorDomain.Persistence;

public class EFCalculationStore: ICalculationStore
{
    private readonly AppDbContext _context;

    public EFCalculationStore(AppDbContext dbcontext)
    {
        _context = dbcontext;
    }
    public async Task SaveAsync(Calculation calculation)
    {
        _context.Calculations.Add(calculation);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Calculation>> LoadAllAsync()
    {
        return await _context.Calculations.OrderByDescending(c => c.CreatedAt).ToListAsync();
    }  
}