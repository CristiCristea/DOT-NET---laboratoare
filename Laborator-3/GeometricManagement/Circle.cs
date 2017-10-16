using System;

namespace GeometricManagement
{
    public class Circle : Shape
    {
        private double _radius;

        public double Radius { get => _radius;
            private set
            {
                if (value < 0) 
                    throw  new ArgumentException("Radius should be greater than 0!");
                _radius = value;
            }
        }

        public Circle(double radius, string color, double transparency) : base(color, transparency)
        {
            Radius = radius;
        }

        public override double ComputeArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string Draw()
        {
            return "Drawing Circle";
        }
    }
}
