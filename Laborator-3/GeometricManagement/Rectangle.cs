using System;

namespace GeometricManagement
{
    public class Rectangle : Shape
    {
        private double _width;
        private double _height;

        public double Width { get => _width;
            private set
            {
                if(value < 0)
                    throw  new ArgumentException("Width should be greater than 0!");
                _width = value;
            }
        }
        public double Height { get => _height;
            private set
            {
                if(value < 0)
                    throw new ArgumentException("Height should be greater than 0!");
                _height = value;
            }
        }

        public Rectangle(double width, double height,string color, double transparency) : base(color, transparency)
        {
            Width = width;
            Height = height;
        }

        public override double ComputeArea()
        {
            return Height * Width;
        }

        public override string Draw()
        {
            return "Drawing Rectangle";
        }
    }
}
