namespace CalculatorDomain.Domain;
public record CalculationRequest(
    double left,
    double right,
    OperationType Operation
);