namespace _03._Nullable_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? x = null;

            if (x.HasValue)
            {
                Console.WriteLine($"Value of x: {x.Value}");
            }
            else
            {
                Console.WriteLine("x is null!");
            }

            int? y = 4711;

            if (y.HasValue)
            {
                Console.WriteLine($"Value of y: {y.Value}");
            }
            else
            {
                Console.WriteLine("y is null!");
            }
        }
    }
}
