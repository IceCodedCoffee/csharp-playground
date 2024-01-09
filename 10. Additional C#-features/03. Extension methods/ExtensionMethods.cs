namespace _03._Extension_methods
{
    internal static class ExtensionMethods
    {
        public static double GetVolume(this Circle circle) => Math.Pow(circle.Radius, 3) * Math.PI * 4 / 3;

        public static void Draw(this Circle circle) => Console.WriteLine("Draw as extension method.");


        public static void Display(this object obj) => Console.WriteLine(obj.ToString());

        public static void Display(this Circle circle) => Console.WriteLine($"Circle with radius {circle.Radius}");


        public static void GetAreas<T>(this T[] typeArray) where T : GeometricObject
        {
            foreach (GeometricObject geoObj in typeArray)
            {
                if (geoObj != null)
                {
                    Console.WriteLine($"{geoObj.GetArea():F2}");
                }
                else
                {
                    Console.WriteLine("null entry!");
                }
            }
        }
    }
}