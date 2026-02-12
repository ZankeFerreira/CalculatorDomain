using CalculatorDomain.Logic;
using CalculatorDomain.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

[ApiController]
[Route("api/history")]
[Authorize(Roles ="Admin")]
public class HistoryController : ControllerBase
{
    private readonly AppDbContext _context; 
    private readonly EFCalculationStore _store;
    public HistoryController(AppDbContext context, EFCalculationStore store)
    {
        _context = context; 
        _store = store;
    }

    [HttpGet]
    public async Task<IActionResult> GetHistory()
    {
        var history = await _context.Calculations
        .Where(c => c.IsActive)
            .Include(c => c.User)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        var response = history.Select(c => new CalculationHistoryItemDto
        {
            Left = c.Left,
            Right = c.Right,
            Operation = c.Operation.ToString(),
            Result = c.Result
        });

        return Ok(response);
    }

    [HttpGet("adds")]
    public async Task <IActionResult> GetAdd()
    {
        var adds = _store.LoadAllAddsAsync();
        
        var response = adds.Result.Select(c => new CalculationHistoryItemDto
        {
            Left = c.Left,
            Right = c.Right,
            Operation = c.Operation.ToString(),
            Result = c.Result
        });

        return Ok(response);
    }
}