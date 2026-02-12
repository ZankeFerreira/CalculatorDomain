using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace CalculatorDomain;
public class CalculationRequest
{
    public double Left {get;set;}
   
    public double right {get; set;}
    public OperationType  Operation {get; set;}
 
 public CalculationRequest (double left, double Right, OperationType operation)
    {
        Left = left;
        right = Right;
        Operation = operation; 

    }
}