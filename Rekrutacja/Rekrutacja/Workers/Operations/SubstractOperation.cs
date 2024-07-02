namespace Rekrutacja.Workers.Operations
{
    internal class SubstractOperation : IOperationStrategy
    {
        double IOperationStrategy.Calculate(double x, double y) => x - y;
    }
}
