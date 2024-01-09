using System.Drawing;

namespace _03._Extension_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);


            Console.WriteLine($"Extension method volume: {circle.GetVolume():F2}");


            circle.Draw();


            circle.Display();   


            GeometricObject[] geoArr = [
                new Circle(5),
                null,
                new Circle(7),
                new Circle(12)
                ];

            geoArr.GetAreas();

            Console.ReadLine();
        }
    }
}
