using Soneta.Types;

namespace Rekrutacja.Workers.Operations
{
    public enum Operation
    {
        [Caption("+")]
        Addition,
        [Caption("-")]
        Subtraction,
        [Caption("*")]
        Multiplication,
        [Caption("/")]
        Division,
    }
}
