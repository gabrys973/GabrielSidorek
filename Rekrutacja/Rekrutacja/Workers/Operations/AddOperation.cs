namespace Rekrutacja.Workers.Operations
{
    internal class AddOperation : IOperationStrategy
    {
        double IOperationStrategy.Calculate(double x, double y) => x + y;
    }
}
