using System;

namespace Rekrutacja.Workers.Operations
{
    internal class DivideOperation : IOperationStrategy
    {
        public double Calculate(double x, double y)
        {
            if(y == 0)
                throw new DivideByZeroException();

            return x / y;
        }
    }
}
