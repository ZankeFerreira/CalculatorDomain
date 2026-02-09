
namespace CalculatorDomain.Domain
{
    public class Calculation
    {
        public int Id { get; }
        public double Left { get; }
        public double Right { get; }
        public OperationType Operation { get; }
        public double Result { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

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

        private Calculation(){}
    }
}