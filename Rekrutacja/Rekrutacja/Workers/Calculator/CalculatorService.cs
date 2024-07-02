using Rekrutacja.Workers.Operations;
using System.ComponentModel;

namespace Rekrutacja.Workers.Calculator
{
    public static class CalculatorService
    {
        public static double Calculate(double x, double y, Operation operation)
        {
            var operationStrategy = GetOperation(operation);
            return operationStrategy.Calculate(x, y);
        }

        private static IOperationStrategy GetOperation(Operation operation)
        {
            switch(operation)
            {
                case (Operation.Addition):
                    return new AddOperation();
                case (Operation.Subtraction):
                    return new SubstractOperation();
                case (Operation.Multiplication):
                    return new MultiplyOperation();
                case (Operation.Division):
                    return new DivideOperation();
                default:
                    throw new InvalidEnumArgumentException("Invalid operation type");
            }
        }
    }
}
