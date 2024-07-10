namespace Rekrutacja.Workers.Shapes
{
    internal class Square : IShape
    {
        public double a;

        public Square(double a)
        {
            if(a < 0)
                throw new System.Exception("Value cannot be negative");

            this.a = a;
        }

        public int CalculateSurfaceArea() => (int)(a * a);
    }
}