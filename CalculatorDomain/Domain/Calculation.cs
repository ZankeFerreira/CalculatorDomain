
namespace CalculatorDomain.Domain
{
    public class Calculation
    {
        public int Id { get; set;}
        public double Left { get; set;}
        public double Right { get; set;}
        public OperationType Operation { get; set;}
        public double Result { get; set;}
        public DateTime CreatedAt { get; set;} = DateTime.UtcNow;

        public Calculation(
            double left,
            double right,
            OperationType operation,
            double result)
        {
          
            Left = left;
            Right = right;
            Operation = operation;
            Result = result;
            CreatedAt = DateTime.UtcNow;
        }

        public Calculation(){}
    }
}