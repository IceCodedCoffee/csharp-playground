namespace _03._Extension_methods
{
    internal class Circle : GeometricObject
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public void Draw() => Console.WriteLine("Draw as instance method.");

        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
