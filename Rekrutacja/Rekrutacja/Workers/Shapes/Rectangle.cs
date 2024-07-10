namespace Rekrutacja.Workers.Shapes
{
    internal class Rectangle : IShape
    {
        public double a;
        public double b;

        public Rectangle(double a, double b)
        {
            if(a < 0 || b < 0)
                throw new System.Exception("Value cannot be negative");

            this.a = a;
            this.b = b;
        }

        public int CalculateSurfaceArea() => (int)(a * b);
    }
}