using System;

namespace GeometricManagement
{
    public abstract class Shape
    {
        private double _transparency;

        protected Shape(string color, double transparency)
        {
            Id = Guid.NewGuid();
            Color = color;
            Transparency = transparency;
        }

        public Guid Id { get; private set; }
        public string Color { get; private set; }

        public double Transparency
        {
            get => _transparency;
            private set
            {
                if(value < 0 || value > 100)
                    throw new ArgumentException("Transparency should be between 0 and 100!");
                _transparency = value;
            }
        }

        public abstract double ComputeArea();

        public bool IsVisible()
        {
            return Transparency > 50;
        }

        public abstract string Draw();
    }
}