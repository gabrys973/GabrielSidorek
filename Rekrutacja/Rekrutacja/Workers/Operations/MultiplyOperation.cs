namespace Rekrutacja.Workers.Operations
{
    internal class MultiplyOperation : IOperationStrategy
    {
        public double Calculate(double x, double y) => x * y;
    }
}
