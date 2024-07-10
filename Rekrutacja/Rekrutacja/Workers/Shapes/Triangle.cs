namespace Rekrutacja.Workers.Shapes
{
    internal class Triangle : IShape
    {
        public double a;
        public double h;

        public Triangle(double a, double h)
        {
            if(a < 0 || h < 0)
                throw new System.Exception("Value cannot be negative");

            this.a = a;
            this.h = h;
        }

        public int CalculateSurfaceArea() => (int)(0.5 * a * h);
    }
}