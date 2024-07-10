using Rekrutacja.Workers.Shapes;
using System.ComponentModel;

namespace Rekrutacja.Workers.Calculator
{
    public static class CalculatorService
    {
        public static double Calculate(double x, double y, Shape shapeEnum)
        {
            var shape = GetShape(x, y, shapeEnum);
            return shape.CalculateSurfaceArea();
        }

        private static IShape GetShape(double x, double y, Shape shapeEnum)
        {
            switch(shapeEnum)
            {
                case (Shape.Square):
                    return new Square(x);

                case (Shape.Rectangle):
                    return new Rectangle(x, y);

                case (Shape.Triangle):
                    return new Triangle(x, y);

                case (Shape.Circle):
                    return new Circle(x);

                default:
                    throw new InvalidEnumArgumentException("Invalid shape type");
            }
        }
    }
}