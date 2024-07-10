using System;

namespace Rekrutacja.Workers.Shapes
{
    internal class Circle : IShape
    {
        public double r;

        public Circle(double r)
        {
            if(r < 0)
                throw new System.Exception("Value cannot be negative");

            this.r = r;
        }

        public int CalculateSurfaceArea() => (int)(r * r * Math.PI);
    }
}