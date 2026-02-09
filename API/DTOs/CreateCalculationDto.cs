using CalculatorDomain.Domain;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;
public class CreateCalculationDto
{
    [Required]
    public double left{get; set;}
    [Required]

    public double right{get; set;}
    [Required]

    public OperationType Operation{get; set;}
    
}